using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Transliterator;
using System.Collections.Generic;

namespace UnitTest
{
    [TestClass]
    public class TransliterTests
    {
        [TestMethod]
        public void Translit_UkrLat_Correct()
        {
            string ukr = "Василь";
            string lat = "Vasyl";

            Transliter t = new Transliter();
            string actual = t.Translit(ukr);
            Assert.AreEqual(lat, actual);
        }
        [TestMethod]
        public void Translit_EmptyString_Correct()
        {
            string ukr = "";
            string lat = "";

            Transliter t = new Transliter();
            string actual = t.Translit(ukr);
            Assert.AreEqual(lat, actual);
        }
        [TestMethod]
        public void Translit_LognString_Correct()
        {
            string ukr = "|Єнакієве |Гаєвич |Короп’є Згорани Розгон |Юрій |Корюківка";
            string lat = "|Yenakiieve |Haievych |Koropie Zghorany Rozghon |Yurii |Koriukivka";

            Transliter t = new Transliter();
            string actual = t.Translit(ukr);
            Assert.AreEqual(lat, actual);
        }
        [TestMethod]
        public void ModifyRuleSimple()
        {
            string ukr = "а";
            string lat = "b";

            Transliter t = new Transliter();
            t.ModifyRule("а", "b");
            string actual = t.Translit(ukr);
            Assert.AreEqual(lat, t.Translit(ukr));
        }

    }
}
