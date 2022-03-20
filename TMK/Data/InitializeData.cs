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
        private Pipe[] _Pipes;
        private Package[] _Packages;

        private const int steelMarkCount = 5;
        private const int pipeCount = 100;
        private const int packegesCount = 10;

        public DbInitializer(TmkDB dB, ILogger<DbInitializer> logger)
        {
            _DB = dB;
            _Logger = logger;
        }

        public void Initialize()
        {
            InitializeStellMark();
            InitializePipe();
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
        private void InitializePipe()
        {
            Random random = new Random();
            _Pipes = new Pipe[pipeCount];
            for (int i = 0; i < pipeCount; i++)
            {
                _Pipes[i] = new Pipe()
                {
                    Number = i + 1,
                    Size = random.NextDouble() * 10,
                    Weight = random.NextDouble() * 500,
                    IsGoodQuality = (int)(random.NextDouble() * 10) / 3 != 0,
                    SteelMark = _SteelMarks[random.Next(0, 4)]
                };
            }

            _DB.Pipes.AddRange(_Pipes);
            _DB.SaveChanges();
        }
        private void InitializePackeges()
        {
            Random random = new Random();
            _Packages = new Package[packegesCount];
            for (int i = 0; i < packegesCount; i++)
            {
                _Packages[i] = new Package()
                {
                    Number = i + 1,
                    Date = DateTime.Now.AddDays(-random.Next(1, 30)),
                    Pipes = new List<Pipe>()
                };
            }

            foreach (var package in _Packages)
            {
                for (int i = 0; i < random.Next(0, 11); i++)
                {
                    var rnd = random.Next(0, pipeCount);
                    if (!package.Pipes.Contains(_Pipes[rnd]))
                        package.Pipes.Add(_Pipes[rnd]);
                }
            }
            _DB.Packages.AddRange(_Packages);
            _DB.SaveChanges();
        }
    }
}
