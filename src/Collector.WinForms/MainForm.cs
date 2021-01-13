// Collector.TT project

using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

using Collector.Database;
using Collector.DataManagement;
using Collector.Formats;
using Collector.Formats.Cdrom;
using Collector.Import;
using Collector.Scanner;

namespace Collector.WinForms
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
        }

        private void UpdateDumpsList(IEnumerable<DumpEntity> dumps)
        {
            DumpsListView.Items.Clear();
            foreach (DumpEntity dump in dumps.OrderBy(d => d.Name))
            {
                var dumpListItem = new ListViewItem
                {
                    Text = dump.Name
                };

                _ = DumpsListView.Items.Add(dumpListItem);
            }
        }

        private void OpenDatFileMenuItem_Click(object sender, EventArgs e)
        {
            var dialog = new OpenFileDialog
            {
                CheckFileExists = true,
                Filter = "Datfile|*.dat"
            };

            if (dialog.ShowDialog() == DialogResult.OK)
            {
                var importer = new RedumpImporter();
                IEnumerable<DumpEntity> dumps = importer.Import(dialog.FileName);

                var dataMiner = new RedumpDataMiner();
                IEnumerable<ReleaseEntity> releases = dataMiner.GetReleases(dumps);

                UpdateDumpsList(dumps);
            }
        }

        private void ScannerMenuItem_Click(object sender, EventArgs e)
        {
            var dialog = new FolderBrowserDialog();
            if (dialog.ShowDialog() == DialogResult.OK)
            {
                var scanner = new DirectoryScanner();
                List<DumpEntity> result = scanner.ScanDirectory(dialog.SelectedPath);
            }
        }

        private void IsoBinConverterMenuItem_Click(object sender, EventArgs e)
        {
            var dialog = new OpenFileDialog();
            if (dialog.ShowDialog() == DialogResult.OK)
            {
                CdromFormatConverter.IsoToBin(dialog.FileName, dialog.FileName + ".bin");
            }
        }

        private void BinIsoConvertMenuItem_Click(object sender, EventArgs e)
        {
            var dialog = new OpenFileDialog();
            if (dialog.ShowDialog() == DialogResult.OK)
            {
                CdromFormatConverter.BinToiso(dialog.FileName, dialog.FileName + ".iso");
            }
        }

        private void OpenTosecDatFileMenuItem_Click(object sender, EventArgs e)
        {
            var dialog = new OpenFileDialog
            {
                CheckFileExists = true,
                Filter = "Datfile|*.dat"
            };

            if (dialog.ShowDialog() == DialogResult.OK)
            {
                var importer = new TosecImporter();
                IEnumerable<DumpEntity> dumps = importer.Import(dialog.FileName);

                var dataMiner = new RedumpDataMiner();
                IEnumerable<ReleaseEntity> releases = dataMiner.GetReleases(dumps);

                UpdateDumpsList(dumps);
            }
        }

        private void ComapreCdromImagesMenuItem_Click(object sender, EventArgs e)
        {
            var dialog = new OpenFileDialog();

            var firstFile = string.Empty;
            if (dialog.ShowDialog() == DialogResult.OK)
            {
                firstFile = dialog.FileName;
            }

            var secondFile = string.Empty;
            if (dialog.ShowDialog() == DialogResult.OK)
            {
                secondFile = dialog.FileName;
            }

            var cdromReader = new BinImageReader();
            CdromImage cdrom1 = cdromReader.ReadImage(firstFile);
            CdromImage cdrom2 = cdromReader.ReadImage(secondFile);

            var comparer = new CdromImageComparer();
            List<CdromSectorComparisonResult> result = Task.Run(() => comparer.Compare(cdrom1, cdrom2)).Result;

            var failed = result.Where(e => e.Equal == false).ToList();
        }

        private void OpenNointroFileMenuItem_Click(object sender, EventArgs e)
        {
            var dialog = new OpenFileDialog();
            if (dialog.ShowDialog() == DialogResult.OK)
            {
                var importer = new NoIntroImporter();
                importer.Import(dialog.FileName);
            }

        }

        private void RefreshTree()
        {
            DatabaseTreeView.Nodes.Clear();
            foreach (var manufacturerEntity in DatabaseContext.Db.Manufacturers.OrderBy(m => m.Name))
            {
                var manuFactuerNode = new TreeNode
                {
                    Text = manufacturerEntity.Name,
                    Tag = manufacturerEntity
                };

                DatabaseTreeView.Nodes.Add(manuFactuerNode);

                var hardware = DatabaseContext.Db.Hardware.Where(h => h.ManufacturerId == manufacturerEntity.Id)
                    .OrderBy(h => h.Name);
                foreach (var hardwareEntity in hardware)
                {
                    var hardwareNode = new TreeNode
                    {
                        Text = hardwareEntity.Name,
                        Tag = hardwareEntity
                    };

                    manuFactuerNode.Nodes.Add(hardwareNode);
                }
            }
        }

        private void OpenToolButton_Click(object sender, EventArgs e)
        {
            // TODO: database path must be taken from configuration
            var path = Path.Combine(
                Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData),
                "collector",
                "data"
                );

            DatabaseContext.Db.Load(path);
            RefreshTree();
        }

        private void UpdateToolButton_Click(object sender, EventArgs e)
        {
            // TODO: database path must be taken from configuration
            var path = Path.Combine(
                Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData),
                "collector",
                "data"
                );

            Updater.Update(path, "https://github.com/AnttiChristian/collector-data.git");
        }

        private void DatabaseTreeView_AfterSelect(object sender, TreeViewEventArgs e)
        {
            // TODO: database path must be taken from configuration
            var path = Path.Combine(
                Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData),
                "collector",
                "data"
                );

            var loader = new DatFilesManager();
            if ((DatabaseTreeView.SelectedNode?.Tag is HardwareEntity hardware) &&
                (DatabaseTreeView.SelectedNode?.Parent?.Tag is ManufacturerEntity manufacturer))
            {
                var datfiles = loader.Load(manufacturer, hardware, path);
                UpdateDumpsList(datfiles[0].Dumps);
            }
        }
    }
}
