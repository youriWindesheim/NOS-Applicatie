using Model;
using Model.Model_Artikel;
using ViewModel.ViewModel_Artikel;
using NUnit.Framework;

namespace ViewModel_Test.ViewModel_Artikel_Test
{
    public class Artikel_Inzien_Test
    {

        private Artikel _artikel;
        private Concept _concept;
        private Artikel_Inzien_ViewModel _viewmodel;
        
        [SetUp]
        public void SetUp()
        {
            this._viewmodel = new Artikel_Inzien_ViewModel();
            this._artikel = new Artikel(1, "Test artikel", "Dit is een test artikel");
            this._concept = new Concept(2, "Test concept", "Dit een test concept");
        }
        
        [Test]
        public void Is_Artikel_Test()
        {
            Data.Actief_Artikel = _artikel;
            Assert.IsTrue(_viewmodel.Is_Artikel());

            Data.Actief_Artikel = _concept;
            Assert.IsFalse(_viewmodel.Is_Artikel());
        } 
        
    }
}