namespace net_ef_videogame
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Benvenuto nel gestionale");

            while (true)
            {
                Console.WriteLine($@"
1: Inserire un nuovo videogioco;
2: Ricercare un videogioco per il suo ID;
3: Ricercare tutti i videogiochi aventi il nome contenente una determinata stringa inserita in input
4: Cancellare un videogioco;
5: Inserisci una nuova Software House
6: Esci dal gestionale;
");
                Console.Write("Inserisci l'opzione desiderata --> ");
                int opzioneSelezionata = int.Parse(Console.ReadLine());
                switch (opzioneSelezionata)
                {
                    case 1:
                        Videogioco nuovoVideogioco = VideoGameManager.CreazioneVideogioco();

                        using (VideogameContext db = new VideogameContext())
                        {
                            try
                            {
                                db.Add(nuovoVideogioco);
                                db.SaveChanges();

                                Console.WriteLine("Il videogioco è stato aggiunto");
                            }
                            catch (Exception ex)
                            {
                                Console.WriteLine(ex.Message);
                            }
                        }

                        break;
                    case 2:

                        Console.WriteLine("Inserisci l'ID del gioco che vuoi trovare");
                        long gameid = long.Parse(Console.ReadLine());

                        using (VideogameContext db = new VideogameContext())
                        {
                            Videogioco videogioco = db.Videogiochi.FirstOrDefault(videogioco => videogioco.VideogameId == gameid);
                            if (videogioco != null)
                            {
                                Console.WriteLine($"Nome: {videogioco.Name}");
                                Console.WriteLine($"Descrizione: {videogioco.Overview}");
                                Console.WriteLine($"Data di rilascio: {videogioco.Release_date}");
                                Console.WriteLine($"Id della software house: {videogioco.Software_houseId}");
                            }
                            else
                            {
                                Console.WriteLine("Nessun videogioco presente nel database appartente a quel id...Se vuoi puoi contattate la casa produttrice e inserirlo all'interno del database con il tasto 1");
                            }
                        }
                        break;
                    case 3:
                        Console.WriteLine("Inserisci dei caratteri");
                        string stringa = Console.ReadLine();
                        using (VideogameContext db = new VideogameContext())
                        {
                            List<Videogioco> videogioco = db.Videogiochi.Where(videogioco => videogioco.Name.Contains(stringa)).ToList<Videogioco>();

                            foreach (Videogioco videogiocoTrovato in videogioco)
                            {
                                Console.WriteLine($"{videogiocoTrovato.Name}");
                            }
                        }

                        break;
                    case 4:

                        Console.Write("Inserisci l'id del gioco che vuoi eliminare dal sistema --> ");
                        long videogameid = long.Parse(Console.ReadLine());

                        try
                        {
                            using (VideogameContext db = new VideogameContext())
                            {
                                Videogioco videogioco = db.Videogiochi.Where(videogioco => videogioco.VideogameId == videogameid).First();

                                db.Remove(videogioco);
                                db.SaveChanges();

                                Console.WriteLine("Il videogioco è stato eliminato dal sistema");
                            }
                        } catch (Exception ex)
                        {
                            Console.WriteLine(ex.Message);
                        }

                        break;
                    case 5:

                        Software_house nuovaSoftwareHouse = VideoGameManager.CreazioneSoftwareHouse();

                        using (VideogameContext db = new VideogameContext())
                        {
                            try
                            {
                                db.Add(nuovaSoftwareHouse);
                                db.SaveChanges();

                                Console.WriteLine("La software house è stata creata");
                            }
                            catch (Exception ex)
                            {
                                Console.WriteLine(ex.Message);
                            }
                        }

                        break;

                        
                    case 6:
                        return;
                        break;
                }
            }
        }
    }
}