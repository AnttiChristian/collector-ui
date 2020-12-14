// Collector.TT project

using System;
using System.IO;

using LibGit2Sharp;

namespace Collector.DataManagement
{
    public static class Updater
    {
        public static void Update(string repositoryPath, string repositoryUrl)
        {
            if (!Directory.Exists(Path.Combine(repositoryPath, ".git")))
            {
                Repository.Clone(repositoryUrl, repositoryPath);
            }
            else
            {
                var signature = new Signature("application", "application@app.com", DateTime.Now);
                var pullOptions = new PullOptions();
                var repository = new Repository(repositoryPath);
                Commands.Pull(repository, signature, pullOptions);
            }
        }
    }
}
