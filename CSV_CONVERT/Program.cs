namespace CSV_CONVERT
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // Controllo cse sono passati due argomenti
            if (args.Length == 2)
            {
                Console.WriteLine("Esatto: Hai inserito i file CSV richiesti.");

                // Assegna gli argomenti alle variabili
                string InputFileCsv = args[0];
                string OutputFileCsv = InputFileCsv.Replace("2.csv", "_Corretto.csv");
                string OutPutFileJson = args[1];

                CONVERTI.SistemaFileCsv(InputFileCsv, OutputFileCsv);

                CONVERTI.ConvertiInJson(OutputFileCsv, OutPutFileJson);
            }
            else
            {
                Console.WriteLine("Errore: Devi passarmi gli argomenti giusti");
            }
        }
    }
}
