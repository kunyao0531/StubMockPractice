using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using MainProject;
using Rhino.Mocks;
using System.Collections.Generic;

namespace UnitTestProject
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestAgeisInRange()
        {
            //arrange 
            INewThings stubNewThing = MockRepository.GenerateStub<INewThings>();
            stubNewThing.Stub(x => x.CreateNewMember(Arg<PersonInfo>.Is.Anything)).Return("Frank-27");
            Program cp = new Program();
            PersonInfo PI = new PersonInfo();
            PI.Name = "Frank";
            PI.age = 27;

            //act
            var actualWork = cp.humanresource(stubNewThing, PI);
            Assert.AreEqual("Frank-27", actualWork);

        }

        [TestMethod]
        public void TestAgeLessThan18()
        {
            //arrange 
            INewThings stubNewThing = MockRepository.GenerateStub<INewThings>();
            stubNewThing.Stub(x => x.CreateNewMember(Arg<PersonInfo>.Is.Anything)).Return("too young to work");
            Program cp = new Program();
            PersonInfo PI = new PersonInfo();
            PI.Name = "Brown";
            PI.age = 10;

            //act
            var actualWork = cp.humanresource(stubNewThing, PI);
            Assert.AreEqual("too young to work", actualWork);
        }

        [TestMethod]
        public void TestAgeGreatThan80()
        {
            //arrange 
            INewThings stubNewThing = MockRepository.GenerateStub<INewThings>();
            stubNewThing.Stub(x => x.CreateNewMember(Arg<PersonInfo>.Is.Anything)).Return("too old to work");
            var expect = "too old to work";
            Program cp = new Program();
            PersonInfo PI = new PersonInfo();
            PI.Name = "Chen";
            PI.age = 85;


            //act
            var actual = cp.humanresource(stubNewThing, PI);
            Assert.AreEqual(expect, actual);
        }


        [TestMethod]
        public void TestViaMocks()
        {
            MockRepository mock = new MockRepository();
            INewThings stubNewThings = mock.StrictMock<INewThings>();

            List<PersonInfo> People = new List<PersonInfo>();
            PersonInfo person1 = new PersonInfo();
            person1.Name = "Frank";
            person1.age = 27;
            People.Add(person1);

            PersonInfo person2 = new PersonInfo();
            person2.Name = "Brown";
            person2.age = 12;
            People.Add(person2);

            PersonInfo person3 = new PersonInfo();
            person3.Name = "Chen";
            person3.age = 89;
            People.Add(person3);


            Program cp = new Program();
            using (mock.Record())
            {
                cp.humanresource(stubNewThings, People[0]);
                LastCall
                    .Return("Frank-27");

                cp.humanresource(stubNewThings, People[1]);
                LastCall
                    .Return("too young to work");

                cp.humanresource(stubNewThings, People[2]);
                LastCall
                    .Return("too old to work");
            }

            using (mock.Playback())
            {
                var target1 = cp.humanresource(stubNewThings, People[0]);
                var target2 = cp.humanresource(stubNewThings, People[1]);
                var target3 = cp.humanresource(stubNewThings, People[2]);
            }

        }
    }
}
