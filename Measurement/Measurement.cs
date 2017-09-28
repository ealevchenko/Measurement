using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Measurement
{
    public enum TypeMeasurement : int { not = 0, Pressure, Flow, Temp, Planimetric, Time, Gas, Calorific, Density }// тип измерения
    public enum Multiplier : int { No = 1, thousand = 1000, million = 1000000 } // множитель

    public enum uPressure : int
    {
        yPa = 0, zPa, aPa, fPa, pPa, nPa, µPa, mPa, cPa, dPa, Pa, daPa, hPa, kPa, MPa, GPa, TPa, PPa, EPa, ZPa, YPa,
        bar = 30, mBar,
        g_mm2 = 40, g_sm2, g_m2, kg_mm2, kg_sm2, kg_m2, t_mm2, t_sm2, t_m2,
        H_mm2 = 50, H_sm2, H_m2, KH_mm2, KH_sm2, KH_m2, MH_mm2, MH_sm2, MH_m2,
        gs_mm2 = 60, gs_sm2, gs_m2, kgs_mm2, kgs_sm2, kgs_m2, ts_mm2, ts_sm2, ts_m2,
        at = 70,
        atm = 80,
        mm_H2O = 90, sm_H2O, m_H2O,
        mm_Hg = 100, sm_Hg, m_Hg
    }
    // перчень далений
    public enum uPressurePa : int { yPa = 0, zPa, aPa, fPa, pPa, nPa, µPa, mPa, cPa, dPa, Pa, daPa, hPa, kPa, MPa, GPa, TPa, PPa, EPa, ZPa, YPa };
    public enum uPressureBar : int { bar = 0, mBar };
    public enum uPressureKgsm2 : int { g_mm2 = 0, g_sm2, g_m2, kg_mm2, kg_sm2, kg_m2, t_mm2, t_sm2, t_m2 };
    public enum uPressureHm2 : int { H_mm2 = 0, H_sm2, H_m2, KH_mm2, KH_sm2, KH_m2, MH_mm2, MH_sm2, MH_m2 };
    public enum uPressureKgssm2 : int { gs_mm2 = 0, gs_sm2, gs_m2, kgs_mm2, kgs_sm2, kgs_m2, ts_mm2, ts_sm2, ts_m2 };
    public enum uPressureAt : int { at = 0 };
    public enum uPressureAtm : int { atm = 0 };
    public enum uPressureH2O : int { mm_H2O = 0, sm_H2O, m_H2O }
    public enum uPressureHg : int { mm_Hg = 0, sm_Hg, m_Hg }
    // перечни расходов
    public enum uFlow : int
    {
        mm3_sec = 0, sm3_sec, m3_sec, ml_sec, l_sec, mm3_min, sm3_min, m3_min, ml_min, l_min,
        mm3_hour, sm3_hour, m3_hour, ml_hour, l_hour, mm3_sutki, sm3_sutki, m3_sutki, ml_sutki, l_sutki,
        mg_sec = 30, g_sec, kg_sec, ton_sec, mg_min, g_min, kg_min, ton_min,
        mg_hour, g_hour, kg_hour, ton_hour, mg_sutki, g_sutki, kg_sutki, ton_sutki
    }
    // перечни температур
    public enum uTemp : int { grad_C, grad_F, grad_K }
    // перечни планомитрических чисел    
    public enum uPlanimetric : int { Nk, Nl, Np }
    // перечни времени  
    public enum uTime : int { sec, min, hour, sutki }
    // перечни газовый анализ
    public enum uGas : int { percent, mg_m3, g_m3, mol_dm3, mm3_m3, sm3_m3, dm3_m3 }
    // перечни калорийность
    public enum uСalorific : int { cal, kcal_m3 }
    // перечень плотность
    public enum uDensity : int { mg_mm3, g_mm3, kg_mm3, mg_sm3, g_sm3, kg_sm3, mg_m3, g_m3, kg_m3, mg_l, g_l, kg_l }
    
    #region UNION - Параметр измерения
    /// <summary>
    /// Интерфейс описания параметра измерения
    /// </summary>
    public interface IUnit
    {
        TypeMeasurement Type { get; set; }
        Multiplier Multiplier { get; set; }
        object Unit  { get; set; }
        string Description  { get; set; }
    }
    /// <summary>
    /// Класс описания параметра измерения
    /// </summary>
    public class UnitMeasurement : IUnit
    {
        protected TypeMeasurement type;
        public TypeMeasurement Type
        {
            get
            {
                throw new NotImplementedException();
            }
            set
            {
                throw new NotImplementedException();
            }
        }
        protected Multiplier multiplier;
        public Multiplier Multiplier
        {
            get
            {
                throw new NotImplementedException();
            }
            set
            {
                throw new NotImplementedException();
            }
        }
        protected int unit;
        public object Unit
        {
            get
            {
                throw new NotImplementedException();
            }
            set
            {
                throw new NotImplementedException();
            }
        }
        protected string description;
        public string Description
        {
            get
            {
                return this.description;
            }
            set
            {
                this.description = value;
            }
        }
        public UnitMeasurement(string description, TypeMeasurement type, int unit, Multiplier multiplier)
        {
            this.type = type; this.unit = unit; this.multiplier = multiplier; this.description = description;
        }
    }
    /// <summary>
    /// Класс описания параметра измерения давления
    /// </summary>
    public class PressureUnit : UnitMeasurement {
        public PressureUnit(string name, uPressure unit, Multiplier multiplier):base(name,TypeMeasurement.Pressure, (int)unit, multiplier) { 
        }
    }
    /// <summary>
    /// Класс описания параметра измерения расхода
    /// </summary>
    public class FlowUnit : UnitMeasurement {
        public FlowUnit(string name, uFlow unit, Multiplier multiplier)
            : base(name, TypeMeasurement.Flow, (int)unit, multiplier)
        { 
        }
    }
    #endregion

    #region DBUNION - Параметр измерения с привязанный к полю таблицы
    /// <summary>
    /// Интерфейс описания параметра измерения привязанного к полю таблицы
    /// </summary>
    public interface IDBUnit:IUnit
    {
        string Field { get; set; }
    }
    /// <summary>
    /// Класс описания параметра измерения привязаного к полю таблицы
    /// </summary>
    public class DBUnitMeasurement : UnitMeasurement, IDBUnit 
    {
        protected string field;
        public string Field
        {
            get
            {
                throw new NotImplementedException();
            }
            set
            {
                throw new NotImplementedException();
            }
        }
        public DBUnitMeasurement(string field, string description, TypeMeasurement type, int unit, Multiplier multiplier)
            : base(description, type, unit, multiplier)
        {
            this.field = field;
        }
    }

    public class DBPressureUnit : DBUnitMeasurement
    {
        public DBPressureUnit(string field, string description, uPressure unit, Multiplier multiplier)
            : base(field, description, TypeMeasurement.Pressure, (int)unit, multiplier) { }
    }

    public class DBFlowUnit : DBUnitMeasurement
    {
        public DBFlowUnit(string field, string description, uFlow unit, Multiplier multiplier)
            : base(field, description, TypeMeasurement.Flow, (int)unit, multiplier) { }
    }
    #endregion

    #region Value - Параметр измерения с показанием значения 
    /// <summary>
    /// Интерфейс описания параметра измерения с показанием значения
    /// </summary>
    public interface IValueUnit:IUnit
    {
        object Value { get; set; }
        Type TypeValue { get; set; }
    }
    /// <summary>
    /// 
    /// </summary>
    public class ValueMeasurement : UnitMeasurement, IValueUnit {
        protected string value { get; set; }
        public object Value
        {
            get
            {
                if (this.typevalue == typeof(Double)){
                    return Double.Parse(this.value);
                }
                if (this.typevalue == typeof(int)){
                    return int.Parse(this.value);
                }
                if (this.typevalue == typeof(string)){
                    return this.value;
                }
                if (this.typevalue == typeof(DateTime))
                {
                    return DateTime.Parse(this.value);
                }
                return null;
            }
            set
            {
                throw new NotImplementedException();
            }
        }
        protected Type typevalue { get; set; }
        public Type TypeValue
        {
            get
            {
                return this.typevalue;
            }
            set
            {
                throw new NotImplementedException();
            }
        }
        public ValueMeasurement(Type typevalue, string description, TypeMeasurement type, int unit, Multiplier multiplier)
            : base(description, type, unit, multiplier)
        {
            this.value = null;
            this.typevalue = typevalue;
        }
        public ValueMeasurement(double value, string description, TypeMeasurement type, int unit, Multiplier multiplier)
            : base(description, type, unit, multiplier)
        {
            this.value = value.ToString();
            this.typevalue = typeof(double);
        }
        public ValueMeasurement(int value, string description, TypeMeasurement type, int unit, Multiplier multiplier)
            : base(description, type, unit, multiplier)
        {
            this.value = value.ToString();
            this.typevalue = typeof(int);
        }
        public ValueMeasurement(string value, string description, TypeMeasurement type, int unit, Multiplier multiplier)
            : base(description, type, unit, multiplier)
        {
            this.value = value.ToString();
            this.typevalue = typeof(string);
        }
        public ValueMeasurement(DateTime value, string description, TypeMeasurement type, int unit, Multiplier multiplier)
            : base(description, type, unit, multiplier)
        {
            this.value = value.ToString();
            this.typevalue = typeof(DateTime);
        }
    }

    public class PressureValue : ValueMeasurement {
        public PressureValue(double value, string description, uPressure unit, Multiplier multiplier) : 
            base(value, description, TypeMeasurement.Pressure, (int)unit, multiplier) { }
        public PressureValue(string description, uPressure unit, Multiplier multiplier) : 
            base(typeof(double), description, TypeMeasurement.Pressure, (int)unit, multiplier) { }
    }

    public class FlowValue : ValueMeasurement {
        public FlowValue(double value, string description, uFlow unit, Multiplier multiplier) : 
            base(value, description, TypeMeasurement.Flow, (int)unit, multiplier) { }
        public FlowValue(string description, uFlow unit, Multiplier multiplier) :
            base(typeof(double), description, TypeMeasurement.Flow, (int)unit, multiplier) { }
    }

    public class TempValue : ValueMeasurement {
        public TempValue(double value, string description, uTemp unit, Multiplier multiplier) : 
            base(value, description, TypeMeasurement.Temp, (int)unit, multiplier) { }
        public TempValue(string description, uTemp unit, Multiplier multiplier) :
            base(typeof(double), description, TypeMeasurement.Temp, (int)unit, multiplier) { }
    }

    public class PlanimetricValue : ValueMeasurement {
        public PlanimetricValue(double value, string description, uPlanimetric unit, Multiplier multiplier) :
            base(value, description, TypeMeasurement.Planimetric, (int)unit, multiplier) { }
        public PlanimetricValue(string description, uPlanimetric unit, Multiplier multiplier) :
            base(typeof(double), description, TypeMeasurement.Planimetric, (int)unit, multiplier) { }
    }

    public class TimeValue : ValueMeasurement {
        public TimeValue(double value, string description, uTime unit, Multiplier multiplier) :
            base(value, description, TypeMeasurement.Time, (int)unit, multiplier) { }
        public TimeValue(string description, uTime unit, Multiplier multiplier) :
            base(typeof(double), description, TypeMeasurement.Time, (int)unit, multiplier) { }
    }

    #endregion

    #region DBValue - Параметр измерения с показанием значения с привязанный к полю таблицы  
    public class DBValueMeasurement : ValueMeasurement, IDBUnit {
        protected string field;
        public string Field
        {
            get
            {
                throw new NotImplementedException();
            }
            set
            {
                throw new NotImplementedException();
            }
        }
        public DBValueMeasurement(double value, string field, string description, TypeMeasurement type, int unit, Multiplier multiplier) 
            : base(value,description,type,(int)unit,multiplier) {
                this.field = field;
        }
        public DBValueMeasurement(int value, string field, string description, TypeMeasurement type, int unit, Multiplier multiplier) 
            : base(value,description,type,(int)unit,multiplier) { 
                this.field = field;
        }
        public DBValueMeasurement(string value, string field, string description, TypeMeasurement type, int unit, Multiplier multiplier) 
            : base(value,description,type,(int)unit,multiplier) { 
                this.field = field;
        }
        public DBValueMeasurement(DateTime value, string field, string description, TypeMeasurement type, int unit, Multiplier multiplier) 
            : base(value,description,type,(int)unit,multiplier) { 
                this.field = field;
        }
        public DBValueMeasurement(Type typevalue, string field, string description, TypeMeasurement type, int unit, Multiplier multiplier)
            : base(typevalue, description, type, (int)unit, multiplier)
        {
                this.field = field;
        }

    }

    public class DBPressureValue : DBValueMeasurement {
        public DBPressureValue(double value, string field, string description, uPressure unit, Multiplier multiplier) : 
            base(value,field,description,TypeMeasurement.Pressure,(int)unit,multiplier) { }
        public DBPressureValue(string field, string description, uPressure unit, Multiplier multiplier) : 
            base(typeof(double),field,description,TypeMeasurement.Pressure,(int)unit,multiplier) { }
    }

    public class DBFlowValue : DBValueMeasurement {
        public DBFlowValue(double value, string field, string description, uFlow unit, Multiplier multiplier) : 
            base(value,field,description,TypeMeasurement.Pressure,(int)unit,multiplier) { }
        public DBFlowValue(string field, string description, uFlow unit, Multiplier multiplier) : 
            base(typeof(double),field,description,TypeMeasurement.Pressure,(int)unit,multiplier) { }
    }

    #endregion
    /// <summary>
    /// Набор данных параметра учета энергоресурса
    /// </summary>
    public class EnergyValueEntity {
        public string name { get; set; }
        public FlowValue flow { get; set; }
        public TempValue avg_temp { get; set; }
        public PressureValue avg_pressure { get; set; }
        public PlanimetricValue planimetric { get; set; }
        public FlowValue pr_flow { get; set; }
        public TimeValue time_norm { get; set; }
        public TimeValue time_max { get; set; }
        public EnergyValueEntity() { 
        
        }
    }

}
