using Microsoft.Extensions.Logging;
using Storage.Context;
using Storage.Entities;
using System;
using System.Collections.Generic;

namespace TMK.Data
{
    public class DbInitializer
    {
        private readonly TmkDB _DB;
        private readonly ILogger<DbInitializer> _Logger;
        private SteelMark[] _SteelMarks;
        private Tube[] _Tubes;
        private Bundle[] _Bundles;

        private const int steelMarkCount = 5;
        private const int tubeCount = 100;
        private const int packegesCount = 10;

        public DbInitializer(TmkDB dB, ILogger<DbInitializer> logger)
        {
            _DB = dB;
            _Logger = logger;
        }

        public void Initialize()
        {
            InitializeStellMark();
            InitializeTube();
            InitializePackeges();
        }

        private void InitializeStellMark()
        {
            _SteelMarks = new SteelMark[steelMarkCount];
            for (int i = 0; i < steelMarkCount; i++)
            {
                _SteelMarks[i] = new SteelMark()
                {
                    Name = $"Марка стали {i + 1}"
                };
            }

            _DB.SteelMarks.AddRange(_SteelMarks);
            _DB.SaveChanges();
        }
        private void InitializeTube()
        {
            Random random = new Random();
            _Tubes = new Tube[tubeCount];
            for (int i = 0; i < tubeCount; i++)
            {
                _Tubes[i] = new Tube()
                {
                    Number = i + 1,
                    Size = random.NextDouble() * 10,
                    Weight = random.NextDouble() * 500,
                    IsGoodQuality = (int)(random.NextDouble() * 10) / 3 != 0,
                    SteelMark = _SteelMarks[random.Next(0, 4)]
                };
            }

            _DB.Tubes.AddRange(_Tubes);
            _DB.SaveChanges();
        }
        private void InitializePackeges()
        {
            Random random = new Random();
            _Bundles = new Bundle[packegesCount];
            for (int i = 0; i < packegesCount; i++)
            {
                _Bundles[i] = new Bundle()
                {
                    Number = i + 1,
                    Date = DateTime.Now.AddDays(-random.Next(1, 30)),
                    Tubes = new List<Tube>()
                };
            }

            foreach (var bundle in _Bundles)
            {
                for (int i = 0; i < random.Next(0, 11); i++)
                {
                    var rnd = random.Next(0, tubeCount);
                    if (!bundle.Tubes.Contains(_Tubes[rnd]))
                        bundle.Tubes.Add(_Tubes[rnd]);
                }
            }
            _DB.Bundles.AddRange(_Bundles);
            _DB.SaveChanges();
        }
    }
}
