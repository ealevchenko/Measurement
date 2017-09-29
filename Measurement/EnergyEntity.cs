using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Measurement
{
    #region Описание наборов данных для построетия списков парметров учета энергоресурсов

    public enum groupEnergy : int
    {
        Natur_gas = 1,
        Blast_furnace_gas,
        Blast,
        Steam,
        Nitrogen,
        Compressed_Air,
        Oxygen
    }

    /// <summary>
    /// Набор данных параметра учета энергоресурса
    /// </summary>
    public class EnergyValueEntity
    {
        public string name { get; set; }
        public FlowValue flow { get; set; }
        public TempValue avg_temp { get; set; }
        public PressureValue avg_pressure { get; set; }
        public PlanimetricValue planimetric { get; set; }
        public FlowValue pr_flow { get; set; }
        public TimeValue time_norm { get; set; }
        public TimeValue time_max { get; set; }
        public EnergyValueEntity()
        {

        }
    }
    /// <summary>
    /// Набор данных параметра учета энергоресурса c привязкой к объекту
    /// </summary>
    public class EnergyValueObjEntity : EnergyValueEntity
    {
        public int obj { get; set; }
        public EnergyValueObjEntity()
            : base()
        {

        }
    }
    /// <summary>
    /// Набор типов данных параметра учета энергоресурса c привязкой к объекту 
    /// </summary>
    public class TypeEnergyValueObjEntity
    {
        public int type { get; set; }
        public string name { get; set; }
        public List<EnergyValueObjEntity> list_energy = new List<EnergyValueObjEntity>();
        public TypeEnergyValueObjEntity() { }
    }
    /// <summary>
    /// Набор uhegg типов данных параметра учета энергоресурса c привязкой к объекту 
    /// </summary>
    public class GroupEnergyValueObjEntity
    {
        public groupEnergy group { get; set; }
        public string name { get; set; }
        public List<TypeEnergyValueObjEntity> list_type_energy = new List<TypeEnergyValueObjEntity>();
        public GroupEnergyValueObjEntity() { }
    }
    #endregion
}
