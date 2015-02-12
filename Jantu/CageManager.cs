using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Jantu
{
    class CageManager
    {
        private Cage _selectedCage ;
        public Cage SelectedCage
        {
            get { return _selectedCage; }
            set
            {
                if (_selectedCage != null)
                    _selectedCage.State = Cage.DisplayState.Normal;
                _selectedCage = value;
                if (_selectedCage != null)
                    _selectedCage.State = Cage.DisplayState.Selected;
            }
        }

        private List<Cage> _cages = new List<Cage>();
        public List<Cage> Cages
        {
            get { return _cages; }
        }

        public void Add(Cage cage)
        {
            if (!_cages.Contains(cage))
                _cages.Add(cage);
        }

        public void Remove(Cage cage)
        {
            _cages.Remove(cage);
        }

        public void Update()
        {
            foreach (var cage in _cages)
                cage.Update();

        }
    }
}
