using OO___Nulls.Common;
using System;

namespace OO___Nulls
{
    public class SoldArticle1
    {
        private Warranty _moneyBackGuarantee;
        private readonly Warranty _notOperationalWarranty;
        private Option<Part> _circuits = Option<Part>.None();
        private Warranty _circuitWarranty;

        private DeviceStatusEnum _operationalStatus;

        public SoldArticle1(Warranty moneyBackGuarantee, Warranty express)
        {
            _moneyBackGuarantee = moneyBackGuarantee ?? throw new ArgumentNullException(nameof(moneyBackGuarantee));
            _notOperationalWarranty = express ?? throw new ArgumentNullException(nameof(express));
            _circuitWarranty = VoidWarranty.Instance;
        }

        public void InstallCircuit(Part circuit, Warranty extendedWarranty)
        {
            _circuits = Option<Part>.Some(circuit);
            _circuitWarranty = extendedWarranty;
            _operationalStatus &= DeviceStatusEnum.CircuitFailed;
        }

        public void CircuitNotOperational(DateTime breakDate)
        {
            _circuits.Do(c =>
            {
                c.MarkDefective(DateTime.Now);
                _operationalStatus |= DeviceStatusEnum.CircuitFailed;
            });
        }

        public void VisibleDamage()
        {
            _operationalStatus |= DeviceStatusEnum.VisiblyDamaged;
        }

        public void NotOperational()
        {
            _operationalStatus |= DeviceStatusEnum.NotOperational;
        }

        public void Repaired()
        {
            _operationalStatus &= DeviceStatusEnum.NotOperational;
        }

        public void ClaimWarranty(Action onValidClaim)
        {
            switch (_operationalStatus)
            {
                case DeviceStatusEnum.AllFine:
                    _moneyBackGuarantee.Claim(DateTime.Now, onValidClaim);
                    break;
                case DeviceStatusEnum.NotOperational:
                case DeviceStatusEnum.NotOperational | DeviceStatusEnum.VisiblyDamaged:
                case DeviceStatusEnum.NotOperational | DeviceStatusEnum.CircuitFailed:
                case DeviceStatusEnum.NotOperational | DeviceStatusEnum.VisiblyDamaged | DeviceStatusEnum.CircuitFailed:
                    _notOperationalWarranty.Claim(DateTime.Now, onValidClaim);
                    break;
                case DeviceStatusEnum.VisiblyDamaged:
                    break;
                case DeviceStatusEnum.CircuitFailed:
                case DeviceStatusEnum.VisiblyDamaged | DeviceStatusEnum.CircuitFailed:
                    _circuits.Do(circuit => _circuitWarranty.Claim(circuit.BreakDate, onValidClaim));
                    break;
            }
        }
    }

    internal enum DeviceStatusEnum
    {
        AllFine = 0,
        NotOperational = 1,
        VisiblyDamaged = 2,
        CircuitFailed = 4
    }
}