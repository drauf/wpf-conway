using Conway.Service;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Conway.Test
{
    [TestClass]
    public class LoadSaveServiceTest
    {
        [TestMethod]
        public void LoadSaveService_OnCreate_InitializesLoadAndSaveSlots()
        {
            Assert.AreEqual(10, LoadSaveService.LoadSlots.Count);
            Assert.AreEqual(10, LoadSaveService.SaveSlots.Count);
        }

        // test IsEmpty method
        // test if Load returns previously Saved item
        // test immutability of Save method
        // test immutability of Load method
    }
}
