using distributore_benzina_finito;
namespace test_libreria_benzinaio
{
    public class UnitTest1
    {
        [Fact]
        public void Test1() //test per verificare che il denaro viene caricato 
        {
            distributore_benzina benzinaio = new distributore_benzina("kdfds","cndjfd",100);
            benzinaio.AggiungiDenaro(10);
            Assert.True(benzinaio.Denaro_caricato == 10);
            

        }

        [Fact]
        public void Test2() //test per verificare che in caso di denaro <5 e >100 dia un ecezzione
        {
            distributore_benzina benzinaio = new distributore_benzina("kdfds", "cndjfd", 100);
            
            
            Assert.Throws<Exception>(() => benzinaio.AggiungiDenaro(4));

        }

        [Fact]
        public void Test3() //controllo per verificare se il programma blocca l'inserimento di un numero negativo
        {
            distributore_benzina benzinaio = new distributore_benzina("kdfds", "cndjfd", 100);


            Assert.Throws<Exception>(() => benzinaio.AggiungiDenaro(-2));

        }

        [Fact]
        public void Test4() //controllo per verificare se il programma blocca l'inserimento di benzina quando il distributore supera la capacità massima 
        {
            distributore_benzina benzinaio = new distributore_benzina("kdfds", "cndjfd", 100);


            Assert.Throws<Exception>(() => benzinaio.ControlloRiempireDistributore(101));

        }

        [Fact]
        public void Test5() //controllo per verificare se il programma blocca l'inserimento di numeri negativi
        {
            distributore_benzina benzinaio = new distributore_benzina("kdfds", "cndjfd", 100);


            Assert.Throws<Exception>(() => benzinaio.ControlloRiempireDistributore(-3));

        }

        [Fact]
        public void Test6() //controllo per verificare se il programma permette di erogare benzina
        {
            distributore_benzina benzinaio = new distributore_benzina("kdfds", "cndjfd", 100);
            benzinaio.AggiungiDenaro(10);
            benzinaio.Prezzo_litro = 1;
            benzinaio.ControlloLivelloBenzinaErogazione(10);
            benzinaio.ControlloRiempireDistributore(9);
            Assert.True(benzinaio.Livello_benzina == 99);


        }

        [Fact]
        public void Test7() //controllo per verificare se il denaro è insufficente non permette di erogare benzina 
        {
            distributore_benzina benzinaio = new distributore_benzina("kdfds", "cndjfd", 100);
            benzinaio.AggiungiDenaro(8);
            benzinaio.Prezzo_litro = 1;
            Assert.Throws<Exception>(() => benzinaio.ControlloLivelloBenzinaErogazione(10));
        }

        [Fact]
        public void Test8() //controllo per verificare che il programma non permette di erogare più beziana rispetto alla capacita di contenimento del distributore
        {
            distributore_benzina benzinaio = new distributore_benzina("kdfds", "cndjfd", 99);
            benzinaio.AggiungiDenaro(100);
            benzinaio.Prezzo_litro = 1;
            Assert.Throws<Exception>(() => benzinaio.ControlloLivelloBenzinaErogazione(100));

        }
    }
}