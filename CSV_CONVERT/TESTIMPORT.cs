using CsvHelper;
using CsvHelper.Configuration;
using CsvHelper.Configuration.Attributes;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;

namespace CSV_CONVERT
{
    internal class TESTIMPORT
    {
        [Name("Vault name")]
        public string VaultName { get; set; }

        [Name("Folder name")]
        public string FolderName { get; set; }

        [Name("Password name")]
        public string PasswordName { get; set; }

        [Name("Password login")]
        public string PasswordLogin { get; set; }

        [Name("Password url")]
        public string PasswordUrl { get; set; }

        [Name("Password")]
        public string Password { get; set; }

        [Name("Description")]
        public string Description { get; set; }

        [Name("Full Path")]
        public string FullPath { get; set; }

        [Name("Nota1")]
        public string Nota1 { get; set; }

        [Name("Nota2")]
        public string Nota2 { get; set; }

        [Name("Nota3")]
        public string Nota3 { get; set; }


        public string[] GetPathItems()
        {
            // Controlla se la colonna "FullPath" è vuota o solo spazi bianchi
            if (string.IsNullOrWhiteSpace(FullPath))
            {
                return default;
            }
            // Altrimenti esegui questo blocco di codice
            else
            {
                // Separiamo la stringa "FullPath" usando il simbolo "~" e mettiamo le parole in un array
                string[] ArrayParole = FullPath.Split('~');

                // Verifica che l'array non sia vuoto
                if (ArrayParole.Length > 0)
                {
                    // Spostiamo il primo elemento alla fine
                    string primaParola = ArrayParole[0];

                    // Creiamo un nuovo array per contenere la nuova disposizione
                    ArrayParole = ArrayParole.Skip(1).Concat(new string[] { primaParola }).ToArray();
                }

                return ArrayParole;
            }

        }
    }
}
