using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

public class PickUpList
{

    private List<PickUpClass> _PMlist;
    public string insertURL = "http://localhost:10080/DB_test/Insert.php";


    public PickUpList()
    {
        _PMlist = new List<PickUpClass>();
    }

    public void Add(System.DateTime playerID, System.DateTime dateTime, int score, int pickUpRiskLevel)
    {
        PickUpClass pm = new PickUpClass(playerID, dateTime, score, pickUpRiskLevel);
        _PMlist.Add(pm);
    }

    public string PickUpAverage()
    {
        if (_PMlist.Count > 0)
        {
            double Avg = _PMlist.Average(item => item.PickUpRiskLevel);
            string avg = Avg.ToString("0.#");
            return avg;
        }
        else
        {
            string avg = 0.ToString("0.#");
            return avg;
        }
    }

    // The IEnumerable interface requires implementation of method GetEnumerator.
    public IEnumerator GetEnumerator()
    {
        return new TokenEnumerator(this);
    }


    // Declare an inner class that implements the IEnumerator interface.
    private class TokenEnumerator : IEnumerator
    {
        private int position = -1;
        private PickUpList t;

        public TokenEnumerator(PickUpList t)
        {
            this.t = t;
        }

        // The IEnumerator interface requires a MoveNext method.
        public bool MoveNext()
        {
            if (position < t._PMlist.Count - 1)
            {
                position++;
                return true;
            }
            else
            {
                return false;
            }
        }

        // The IEnumerator interface requires a Reset method.
        public void Reset()
        {
            position = -1;
        }

        // The IEnumerator interface requires a Current method.
        public object Current
        {
            get
            {
                return t._PMlist[position];
            }
        }
    }
}
