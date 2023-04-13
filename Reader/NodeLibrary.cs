using Microsoft.Data.Sqlite;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Reader
{
    public static class NodeLibrary
    {
        public static async Task<Node> ParseInput(string filePath)
        {
            using var context = new NodeContext();

            if (await CheckIfFileParsed(filePath))
            {
                var inputFile = await context.InputFiles
                    .Include(i => i.RootNode)
                    .FirstOrDefaultAsync(i => i.FilePath == filePath);

                return inputFile?.RootNode;
            }

            using var reader = new StreamReader(filePath);
            var parser = new Parser(reader);
            var rootNode = await parser.ParseAsync();
            var inputFileRecord = new InputFile { FilePath = filePath, RootNode = rootNode };
            context.InputFiles.Add(inputFileRecord);
            await context.SaveChangesAsync();

            return rootNode;
        }

        public static async Task<Node> FindRootNodeByFilePath(string filePath)
        {
            using var context = new NodeContext();
            var inputFile = await context.InputFiles.FirstOrDefaultAsync(file => file.FilePath == filePath);

            if (inputFile != null)
            {
                return inputFile.RootNode;
            }

            return null;
        }
        private static async Task<bool> CheckIfFileParsed(string filePath)
        {
            using var context = new NodeContext();
            return await context.InputFiles.AnyAsync(i => i.FilePath == filePath);
        }

        public static async Task EmptyDatabase()
        {
            string connectionString = "Data Source=input_files.db";

            using var connection = new SqliteConnection(connectionString);
            await connection.OpenAsync();

            using (var transaction = connection.BeginTransaction())
            {
                using (var command = new SqliteCommand(connection))
                {
                    command.Transaction = transaction;

                    // Delete all data in the Node table
                    command.CommandText = "DELETE FROM Nodes";
                    await command.ExecuteNonQueryAsync();

                    // Delete all data in the InputFiles table
                    command.CommandText = "DELETE FROM InputFiles";
                    await command.ExecuteNonQueryAsync();
                }

                transaction.Commit();
            }
        }

        public static string Print(Node node)
        {
            var sb = new StringBuilder();
            PrintNode(sb, node, 0);
            return sb.ToString();
        }

        private static void PrintNode(StringBuilder sb, Node node, int indent)
        {
            sb.AppendLine($"{new string('\t', indent)}Node");
            sb.AppendLine($"{new string('\t', indent)}{{");
            sb.AppendLine($"{new string('\t', indent + 1)}Name = {node.Name}");
            if (node.Value is not null)
            {
                sb.AppendLine($"{new string('\t', indent + 1)}Value = {node.Value}");
            }
            else if (node.Values.Count > 0)
            {
                sb.AppendLine($"{new string('\t', indent + 1)}Values =");
                sb.AppendLine($"{new string('\t', indent + 1)}{{");
                foreach (string value in node.Values)
                {
                    sb.AppendLine($"{new string('\t', indent + 2)}{value}");
                }
                sb.AppendLine($"{new string('\t', indent + 1)}}}");
            }

            if (node.Children.Count > 0)
            {
                sb.AppendLine($"{new string('\t', indent + 1)}Children =");
                sb.AppendLine($"{new string('\t', indent + 1)}{{");
                foreach (Node child in node.Children)
                {
                    PrintNode(sb, child, indent + 2);
                }
                sb.AppendLine($"{new string('\t', indent + 1)}}}");
            }

            sb.AppendLine($"{new string('\t', indent)}}}");
        }
    }

}
