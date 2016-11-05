using System;
using NUnit.Framework;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;
using System.Collections.Generic;




namespace Serialization_dotNetFramework
{
    class Tests
    {
        [TestFixture]

        public class GuyTest
        {
            [Test]
            public void AddFoundsTest()
            {

                Guy tester = new Guy("Tester", 1000);

                tester.AddMoney(2000);

                Assert.AreEqual(3000, tester.Wallet);
            }

            [Test]
            public void SubtractFoundsTest()
            {
                Guy tester = new Guy("Tester", 10000);

                tester.Subtract(5000);

                Assert.AreEqual(5000, 5000);

            }
        }

        [TestFixture]
        public class SerializeTests
        {

         

            [Test]
            public void SerializeTest()
            {
                string path = @"D:\test.dat";

                Guy testerI = new Guy("TesterI", 1000);
                /*   Guy testerII = new Guy("TesterII", 2000);
                   Guy testerIII = new Guy("TesterIII", 3000);

                    List<Guy> toSerialize = new List<Guy>();

                   toSerialize.Add(testerI);
                   toSerialize.Add(testerII);
                   toSerialize.Add(testerIII);*/



                testerI.AddMoney(1000);


                Serialization serialize = new Serialization(path);
              
                serialize.Serialize(testerI);

                testerI.Wallet = 0;

                Assert.True(File.Exists(path));
                File.Delete(path);               
             
            }

            [Test]
            public void SerializeAllTest()
            {
                List<Guy> guys = new List<Guy>
                {
                    new Guy("testerI", 2000),
                    new Guy("testerII", 3000),
                    new Guy("TesterIII", 3400)
                };

                string path = @"D:\multipleSerilize.dat";

                Serialization serilize = new Serialization(path);

                serilize.Serialize(guys);
            }

            [Test]
            public void DeserializeAllTest()
            {
                List<Guy> listGuys = new List<Guy>()
                {
                    new Guy("TesterI", 1000),
                    new Guy("TesterII", 2000),
                    new Guy("TesterIII", 3000)
                };

                string path = @"D:\deserializeTest.dat";

                Serialization deserialize = new Serialization(path);

                deserialize.Serialize(listGuys);

                foreach( Guy guy in listGuys)
                {
                    guy.AddMoney(2000);
                }

              
                listGuys = deserialize.DeserializeAll();

                Assert.AreEqual(1000, listGuys[0].Wallet);
            }

            [Test]
            public void DeserializeTest()
            {
                Guy testerII = new Guy("TesterII", 1500);
                string path = @"D:\deserialize.dat";

                Serialization serialize = new Serialization(path);

                serialize.Serialize(testerII);

                testerII.AddMoney(1000);

               testerII = serialize.Deserialize(testerII);

                Assert.True(testerII.Wallet == 1500);

                File.Delete(path);

            }
        }

     
        

    }

                
   

}

