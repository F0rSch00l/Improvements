using System.Dynamic;

namespace techs
{
    internal class Program
    {
        static void readFile(string inputFile, List<Improvements> outputList)
        {
            StreamReader sr = new StreamReader(inputFile);
            sr.ReadLine();
            while (!sr.EndOfStream)
            {
                outputList.Add(new Improvements(sr.ReadLine()));
            }
            sr.Close();
        }

        static int countImprovements(List<Improvements> improvementsList,int fromDate)
        {
            List<Improvements> improvementsSince = new List<Improvements>();
            for(int i = 0; i < improvementsList.Count; i++)
            {
                if(improvementsList[i].year > fromDate)
                    improvementsSince.Add(improvementsList[i]);
            }

            return improvementsSince.Count;
        }

        static bool isSthereSomeone(List<Improvements> improvementsList)
        {
            List<string> names = new List<string>();
            for (int i = 0; i < improvementsList.Count; i++)
            {
                for(int j = 0; j < improvementsList[i].names.Count; j++)
                {
                    if (!names.Contains(improvementsList[i].names[j]))
                        names.Add(improvementsList[i].names[j]);
                    else
                        return true;
                    
                }
                

            }
            return false;
        }

        static void showLastImprovement(List<Improvements> improvementsList)
        {
            int lastYear = 0;
            int indexOfLast = 0;
            for(int i = 0; i < improvementsList.Count; i++)
            {
                if (improvementsList[i].year > lastYear)
                {
                    lastYear = improvementsList[i].year;
                    indexOfLast = i;
                }

            }
            Console.WriteLine($"Utolsó előugrás: \n Éve: {lastYear} \n Előreugrás: {improvementsList[indexOfLast].improvement} \n Előidező(k) neve: {string.Join(" / ", improvementsList[indexOfLast].names)}");
        }

        static string writeToFile(string path, string searchedImprovement, List<Improvements> improvementsList)
        {
            StreamWriter sr = new StreamWriter(path);
            foreach(Improvements improvement in improvementsList){
                if (improvement.improvement.Contains(searchedImprovement))
                {
                    sr.WriteLine($"{improvement.improvement} - {string.Join(" / ", improvement.names)}");
                    sr.Close();
                    return $"{improvement.improvement} - {string.Join(" / ", improvement.names)}";
                }
            }
            sr.Close();
            return "Hiba";

        }

        static void Main(string[] args)
        {

            List<Improvements> improvements = new List<Improvements>();
            readFile("ProjektHázi.csv", improvements);
            string yesNo = "Nem";
            Console.WriteLine($"1830 óta {countImprovements(improvements, 1830)} technológiai előugrást találtam.");
            Console.WriteLine($"Van(nak)-e olyan ember(ek), akik több technológiai előugrásért is felelősek? - {yesNo = (isSthereSomeone(improvements) ? "Igen" : yesNo)}");
            showLastImprovement(improvements);
            writeToFile("text.txt", "gőz" ,improvements);

        }

        
    }   
}
