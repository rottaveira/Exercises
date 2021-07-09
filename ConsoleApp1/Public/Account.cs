using NUnit.Framework;

namespace Exercises
{
    public class Account
    {
        public double Balance { get; private set; }
        public double OverdraftLimit { get; private set; }


        public Account(double overdraftLimit)
        {
            this.OverdraftLimit = overdraftLimit > 0 ? overdraftLimit : 0;
            this.Balance = 0;
        }

        /*Deposito*/
        public bool Deposit(double amount)
        {
            if (amount >= 0)
            {
                this.Balance += amount;
                return true;
            }
            return false;
        }

        /*Saque*/
        public bool Withdraw(double amount)
        {
            if (this.Balance - amount >= -this.OverdraftLimit && amount >= 0)
            {
                this.Balance -= amount;
                return true;
            }
            return false;
        }
    }



    [TestFixture]
    public class Tester
    {
        /* Cases:
         *  The Deposit and Withdraw methods will not accept negative numbers.
         *  Account cannot overstep its overdraft limit.
         *  The Deposit and Withdraw methods will deposit or withdraw the correct amount, respectively.
         *  The Withdraw and Deposit methods return the correct results.
         */

        private double epsilon = 1e-6; /*0,000001, utilizar para comparar ponto flutuante*/

        [Test]
        public void AccountCannotHaveNegativeOverdraftLimit()
        {
            var account = new Account(-20);

            Assert.AreEqual(0, account.OverdraftLimit, epsilon);
        }

        [Test]
        public void DepositoNaoAceitaNumerosNegativos()
        {
            var account = new Account(20);
            account.Deposit(-10);

            Assert.AreEqual(0d, account.Balance, epsilon);
        }

        [Test]
        public void SaqueNaoAceitaNumerosNegativos()
        {
            var account = new Account(20);
            account.Withdraw(-10);

            Assert.AreEqual(0d, account.Balance, epsilon);
        }


        [Test]
        public void DepositoValorPositivo()
        {
            var account = new Account(20);
            account.Deposit(10);

            Assert.AreEqual(10d, account.Balance, epsilon);
        }

        [Test]
        public void SaqueValorPositivoNaoEstouraOLimite()
        {
            var account = new Account(20);
            account.Withdraw(10);

            Assert.AreEqual(-10d, account.Balance, epsilon);
        }


        [Test]
        public void SaqueNaoEstouraLimite()
        {
            var account = new Account(20);
            var efetuouSaque = account.Withdraw(30);

            //o balanço continua o mesmo pois o saque não foi efetuado

            Assert.AreEqual(0d, account.Balance, epsilon);  
        }

        [Test]
        public void EfetuaSaqueEDeposito()
        {
            var account = new Account(40);
            var efetuouSaque = account.Withdraw(40);
            var efetuouDeposito = account.Deposit(90);
             
            Assert.AreEqual(efetuouSaque, efetuouDeposito);
        }
    }
}