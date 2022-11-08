using CONFIG_JSON;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RaffleAutomationTests.Helpers
{
    public class AllureConfigFilesHelper
    {
        public static string CreateBatFile()
        {
            string path = Browser.RootPath() + "allure serve.bat";
            string allureResultsDirectory = Browser.RootPath() + @"\allure-results";
            string allureResults = @"allure serve " + allureResultsDirectory;
            FileInfo fileInf = new FileInfo(path);
            if (fileInf.Exists)
            {
                fileInf.Delete();
            }
            else if (!Directory.Exists(allureResultsDirectory))
            {
                Directory.CreateDirectory(allureResultsDirectory);
            }
            using (FileStream fstream = new FileStream($"{path}", FileMode.OpenOrCreate))
            {
                byte[] array = Encoding.Default.GetBytes(allureResults);
                fstream.Write(array, 0, array.Length);
            }
            return path;
        }

        public static ConfigJson Json()
        {
            ConfigJson req = new()
            {
                Allure = new()
                {
                    Directory = Path.Combine(Browser.RootPath() + "allure-results"),
                    Links = new()
                    {
                        "{link}",
                        "https://testrail.com/browse/{tms}",
                        "https://jira.com/browse/{issue}"
                    }
                },
                Specflow = new()
                {
                    StepArguments = new()
                    {
                        ConvertToParameters = true,
                        ParamNameRegex = "",
                        ParamValueRegex = ""
                    },
                    Grouping = new()
                    {
                        Suites = new()
                        {
                            ParentSuite = "^parentSuite:?(.+)",
                            Suite = "^suite:?(.+)",
                            SubSuite = "^subSuite:?(.+)"
                        },
                        Behaviors = new()
                        {
                            Epic = "^epic:?(.+)",
                            Story = "^story:(.+)"
                        }
                    },
                    Labels = new()
                    {
                        Owner = "^author:?(.+)",
                        Severity = "^(normal|blocker|critical|minor|trivial)"
                    },
                    Links = new()
                    {
                        Tms = "^story:(.+)",
                        Issue = "^issue:(.+)",
                        Link = "^link:(.+)"
                    }
                }
            };

            return req;
        }

        public static void CreateJsonConfigFile()
        {
            FileInfo fileInf = new FileInfo(Path.GetFullPath(Path.Combine(AppContext.BaseDirectory)) + "allureConfig.json");
            if (fileInf.Exists == true)
            {
                fileInf.Delete();
            }
            string mainpath = Path.GetFullPath(Path.Combine(AppContext.BaseDirectory)) + "allureConfig.json";

            using (StreamWriter file = File.CreateText(mainpath))
            {
                JsonSerializer serializer = new JsonSerializer();
                //serialize object directly into file stream
                serializer.Serialize(file, Json());
            }


        }
    }
}

namespace CONFIG_JSON { 
    public partial class ConfigJson
    {
        [JsonProperty("allure")]
        public Allure Allure { get; set; }

        [JsonProperty("specflow")]
        public Specflow Specflow { get; set; }
    }

    public partial class Allure
    {
        [JsonProperty("directory")]
        public string Directory { get; set; }

        [JsonProperty("links")]
        public List<string> Links { get; set; }
    }

    public partial class Specflow
    {
        [JsonProperty("stepArguments")]
        public StepArguments StepArguments { get; set; }

        [JsonProperty("grouping")]
        public Grouping Grouping { get; set; }

        [JsonProperty("labels")]
        public Labels Labels { get; set; }

        [JsonProperty("links")]
        public Links Links { get; set; }
    }

    public partial class Grouping
    {
        [JsonProperty("suites")]
        public Suites Suites { get; set; }

        [JsonProperty("behaviors")]
        public Behaviors Behaviors { get; set; }
    }

    public partial class Behaviors
    {
        [JsonProperty("epic")]
        public string Epic { get; set; }

        [JsonProperty("story")]
        public string Story { get; set; }
    }

    public partial class Suites
    {
        [JsonProperty("parentSuite")]
        public string ParentSuite { get; set; }

        [JsonProperty("suite")]
        public string Suite { get; set; }

        [JsonProperty("subSuite")]
        public string SubSuite { get; set; }
    }

    public partial class Labels
    {
        [JsonProperty("owner")]
        public string Owner { get; set; }

        [JsonProperty("severity")]
        public string Severity { get; set; }
    }

    public partial class Links
    {
        [JsonProperty("tms")]
        public string Tms { get; set; }

        [JsonProperty("issue")]
        public string Issue { get; set; }

        [JsonProperty("link")]
        public string Link { get; set; }
    }

    public partial class StepArguments
    {
        [JsonProperty("convertToParameters")]
        public bool ConvertToParameters { get; set; }

        [JsonProperty("paramNameRegex")]
        public string ParamNameRegex { get; set; }

        [JsonProperty("paramValueRegex")]
        public string ParamValueRegex { get; set; }
    }
}
