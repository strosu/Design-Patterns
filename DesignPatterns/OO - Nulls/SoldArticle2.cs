﻿using OO___Nulls.Common;
using System;
using System.Collections.Concurrent;
using System.Collections.Generic;

namespace OO___Nulls
{
    public class SoldArticle2
    {
        private Warranty _moneyBackGuarantee;
        private readonly Warranty _notOperationalWarranty;
        private Option<Part> _circuits = Option<Part>.None();
        private Warranty _circuitWarranty;

        private DeviceStatus _operationalStatus;
        private IReadOnlyDictionary<DeviceStatus, Action<Action>> _warrantyMap = new ConcurrentDictionary<DeviceStatus, Action<Action>>();

        public SoldArticle2(Warranty moneyBackGuarantee, Warranty express)
        {
            _moneyBackGuarantee = moneyBackGuarantee ?? throw new ArgumentNullException(nameof(moneyBackGuarantee));
            _notOperationalWarranty = express ?? throw new ArgumentNullException(nameof(express));
            _circuitWarranty = VoidWarranty.Instance;
            _operationalStatus = DeviceStatus.AllFine();
        }

        public void InstallCircuit(Part circuit, Warranty extendedWarranty)
        {
            _circuits = Option<Part>.Some(circuit);
            _circuitWarranty = extendedWarranty;
            _operationalStatus = _operationalStatus.CircuitRepaired();
        }

        public void CircuitNotOperational(DateTime breakDate)
        {
            _circuits.Do(c =>
            {
                c.MarkDefective(DateTime.Now);
                _operationalStatus = _operationalStatus.CircuitNotOperational();
            });
        }

        public void VisibleDamage()
        {
            _operationalStatus = _operationalStatus.VisibleDamage();
        }

        public void NotOperational()
        {
            _operationalStatus = _operationalStatus.NotOperational();
        }

        public void Repaired()
        {
            _operationalStatus = _operationalStatus.Repaired();
        }

        public void ClaimWarranty(Action onValidClaim)
        {
            _warrantyMap[_operationalStatus].Invoke(onValidClaim);
        }
    }

    public class DeviceStatus
    {
        private readonly StatusRepresentation _representation;

        [Flags]
        private enum StatusRepresentation
        {
            AllFine = 0,
            NotOperational = 1,
            VisiblyDamaged = 2,
            CircuitFailed = 4
        }

        private DeviceStatus(StatusRepresentation representation)
        {
            _representation = representation;
        }

        public static DeviceStatus AllFine() => new DeviceStatus(StatusRepresentation.AllFine);

        public DeviceStatus VisibleDamage() => new DeviceStatus(_representation | StatusRepresentation.VisiblyDamaged);
        
        public DeviceStatus NotOperational() => new DeviceStatus(_representation | StatusRepresentation.NotOperational);

        public DeviceStatus Repaired() => new DeviceStatus(_representation & ~StatusRepresentation.NotOperational);

        public DeviceStatus CircuitNotOperational() => new DeviceStatus(_representation | StatusRepresentation.CircuitFailed);

        public DeviceStatus CircuitRepaired() => new DeviceStatus(_representation & ~StatusRepresentation.CircuitFailed);
    }
}