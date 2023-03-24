using System.Collections.Generic;
using System.IO;
using System.Text.Json;

namespace WorkTimeLogger.Services
{
    public static class JsonReader
    {
        public static List<string> GetMostUsedPhrases(string filePath)
        {
            List<string> mostUsedPhrases = new List<string>();

            try
            {
                // Read the JSON file
                string jsonString = File.ReadAllText(filePath);

                // Parse the JSON string into a JsonDocument object
                JsonDocument jsonDocument = JsonDocument.Parse(jsonString);

                // Get the root element of the JSON document
                JsonElement root = jsonDocument.RootElement;

                // Get the "MostUsedPhrases" array from the JSON document
                JsonElement mostUsedPhrasesElement = root.GetProperty("MostUsedPhrases");

                // Convert the "MostUsedPhrases" array to a list of strings
                foreach (JsonElement element in mostUsedPhrasesElement.EnumerateArray())
                {
                    mostUsedPhrases.Add(element.GetString());
                }
            }
            catch (JsonException e)
            {
                // Handle JSON parsing errors
                MessageBox.Show($"Error parsing JSON file: {e.Message}","Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (IOException e)
            {
                // Handle file reading errors
                MessageBox.Show($"Error reading file: {e.Message}", "Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            return mostUsedPhrases;
        }

    }
}
