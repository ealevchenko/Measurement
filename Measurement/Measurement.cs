using Measurement.LocalResources;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Resources;
using System.Text;
using System.Threading.Tasks;

namespace Measurement
{
    public enum TypeMeasurement : int { not = 0, Pressure, Flow, Temp, Planimetric, Time, Gas, Calorific, Density }// тип измерения
    public enum Multiplier : int { not = 1, thousand = 1000, million = 1000000 } // множитель

    //  перечень давлений
    public enum uPressure : int
    {
        not = -1,
        yoktoPa = 0, zeptoPa, attoPa, femtoPa, pikoPa, nanoPa, mikroPa, miliPa, santiPa, deciPa, Pa, dekaPa, gektoPa, kiloPa, MegaPa, GigaPa, TeraPa, PetaPa, EksaPa, ZettaPa, YottaPa,
        bar = 30, mBar,
        g_mm2 = 40, g_sm2, g_m2, kg_mm2, kg_sm2, kg_m2, t_mm2, t_sm2, t_m2,
        H_mm2 = 50, H_sm2, H_m2, KH_mm2, KH_sm2, KH_m2, MH_mm2, MH_sm2, MH_m2,
        gs_mm2 = 60, gs_sm2, gs_m2, kgs_mm2, kgs_sm2, kgs_m2, ts_mm2, ts_sm2, ts_m2,
        at = 70,
        atm = 80,
        mm_H2O = 90, sm_H2O, m_H2O,
        mm_Hg = 100, sm_Hg, m_Hg
    }
    // перечни расходов
    public enum uFlow : int
    {
        not = -1,
        mm3_sec = 0, sm3_sec, m3_sec, ml_sec, l_sec, mm3_min, sm3_min, m3_min, ml_min, l_min,
        mm3_hour, sm3_hour, m3_hour, ml_hour, l_hour, mm3_sutki, sm3_sutki, m3_sutki, ml_sutki, l_sutki,
        mg_sec = 30, g_sec, kg_sec, ton_sec, mg_min, g_min, kg_min, ton_min,
        mg_hour, g_hour, kg_hour, ton_hour, mg_sutki, g_sutki, kg_sutki, ton_sutki
    }
    // перечни температур
    public enum uTemp : int { not = -1, grad_C=0, grad_F, grad_K }
    // перечни планомитрических чисел    
    public enum uPlanimetric : int { not = -1, Nk=0, Nl, Np }
    // перечни времени  
    public enum uTime : int { not = -1, sec=0, min, hour, sutki }
    // перечни газовый анализ
    public enum uGas : int { not = -1, percent=0, mg_m3, g_m3, mol_dm3, mm3_m3, sm3_m3, dm3_m3 }
    // перечни калорийность
    public enum uСalorific : int { not = -1, cal=0, kcal_m3 }
    // перечень плотность
    public enum uDensity : int { not = -1, mg_mm3=0, g_mm3, kg_mm3, mg_sm3, g_sm3, kg_sm3, mg_m3, g_m3, kg_m3, mg_l, g_l, kg_l }

    //TODO: Обработка ошибок?
    public class ValueError
    {
        public string error {get;set;}
        public int num {get;set;}
        public ValueError(string error, int num) {
            this.error = error;
            this.num = num;
        }
    }

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
        string GetUnit();
        string GetTypeUnit();
        string GetMultiplier();
        string GetUnitMultiplier();

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
                return this.type;
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
                return this.multiplier;
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
                switch (type)
                {
                    case TypeMeasurement.Calorific: return (uСalorific)unit;   
                    case TypeMeasurement.Density: return (uDensity)unit;                 
                    case TypeMeasurement.Flow: return (uFlow)unit;
                    case TypeMeasurement.Gas: return (uGas)unit;
                    case TypeMeasurement.Planimetric: return (uPlanimetric)unit;
                    case TypeMeasurement.Pressure: return (uPressure)unit;
                    case TypeMeasurement.Temp: return (uTemp)unit;
                    case TypeMeasurement.Time: return (uTime)unit;
                    default: return this.unit;
                }
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
        /// <summary>
        /// методы получения текстовых параметров
        /// </summary>
        /// <param name="key"></param>
        /// <returns></returns>
        private string GetMeasurementResource(string key)
        {
            ResourceManager resourceManager = new ResourceManager(typeof(MeasurementResource));
            return resourceManager.GetString(key, CultureInfo.CurrentCulture);
        }
        private string GetСalorificResource(string key)
        {
            ResourceManager resourceManager = new ResourceManager(typeof(СalorificResource));
            return resourceManager.GetString(key, CultureInfo.CurrentCulture);
        }
        private string GetDensityResource(string key)
        {
            ResourceManager resourceManager = new ResourceManager(typeof(DensityResource));
            return resourceManager.GetString(key, CultureInfo.CurrentCulture);
        }
        private string GetFlowResource(string key)
        {
            ResourceManager resourceManager = new ResourceManager(typeof(FlowResource));
            return resourceManager.GetString(key, CultureInfo.CurrentCulture);
        }
        private string GetGasResource(string key)
        {
            ResourceManager resourceManager = new ResourceManager(typeof(GasResource));
            return resourceManager.GetString(key, CultureInfo.CurrentCulture);
        }
        private string GetPlanimetricResource(string key)
        {
            ResourceManager resourceManager = new ResourceManager(typeof(PlanimetricResource));
            return resourceManager.GetString(key, CultureInfo.CurrentCulture);
        }
        private string GetPressureResource(string key)
        {
            ResourceManager resourceManager = new ResourceManager(typeof(PressureResource));
            return resourceManager.GetString(key, CultureInfo.CurrentCulture);
        }
        private string GetTempResource(string key)
        {
            ResourceManager resourceManager = new ResourceManager(typeof(TempResource));
            return resourceManager.GetString(key, CultureInfo.CurrentCulture);
        }
        private string GetTimeResource(string key)
        {
            ResourceManager resourceManager = new ResourceManager(typeof(TimeResource));
            return resourceManager.GetString(key, CultureInfo.CurrentCulture);
        } 
        /// <summary>
        /// Получить единицы измерения параметра
        /// </summary>
        /// <returns></returns>
        public string GetUnit(){
                switch (type)
                {
                    case TypeMeasurement.Calorific: return GetСalorificResource(((uСalorific)unit).ToString());   
                    case TypeMeasurement.Density: return GetDensityResource(((uDensity)unit).ToString());                 
                    case TypeMeasurement.Flow: return GetFlowResource(((uFlow)unit).ToString());
                    case TypeMeasurement.Gas: return GetGasResource(((uGas)unit).ToString());
                    case TypeMeasurement.Planimetric: return GetPlanimetricResource(((uPlanimetric)unit).ToString());
                    case TypeMeasurement.Pressure: return GetPressureResource(((uPressure)unit).ToString());
                    case TypeMeasurement.Temp: return GetTempResource(((uTemp)unit).ToString());
                    case TypeMeasurement.Time: return GetTimeResource(((uTime)unit).ToString());
                    default: return this.unit.ToString();
                }            
        }
        /// <summary>
        /// Получить тип измерения параметра
        /// </summary>
        /// <returns></returns>
        public string GetTypeUnit()
        {
            //TODO: Выполнить получение типа параметра измерения
            throw new NotImplementedException();
        }
        /// <summary>
        /// Вернуть знчение делителя
        /// </summary>
        /// <returns></returns>
        protected string GetMultiplier(Multiplier mp){
            return GetMeasurementResource(mp.ToString());
        }
        /// <summary>
        /// Вернуть знчение делителя
        /// </summary>
        /// <returns></returns>
        public string GetMultiplier()
        {
            return GetMultiplier(this.multiplier);
        }
        /// <summary>
        /// Вернуть знчение единицы измерения параметра знчение с делителем
        /// </summary>
        /// <returns></returns>
        public string GetUnitMultiplier()
        {
            return GetMultiplier() + " " + GetUnit();
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

    //TODO: Добавить классы СalorificUnit .... TimeUnit

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
    /// <summary>
    /// Класс описания параметра давления привязаного к полю таблицы
    /// </summary>
    public class DBPressureUnit : DBUnitMeasurement
    {
        public DBPressureUnit(string field, string description, uPressure unit, Multiplier multiplier)
            : base(field, description, TypeMeasurement.Pressure, (int)unit, multiplier) { }
    }
    /// <summary>
    /// Класс описания параметра расхода привязаного к полю таблицы
    /// </summary>
    public class DBFlowUnit : DBUnitMeasurement
    {
        public DBFlowUnit(string field, string description, uFlow unit, Multiplier multiplier)
            : base(field, description, TypeMeasurement.Flow, (int)unit, multiplier) { }
    }

    //TODO: Добавить классы DBСalorificUnit .... DBTimeUnit

    #endregion

    #region Value - Параметр измерения с показанием значения 
    /// <summary>
    /// Интерфейс описания параметра измерения с показанием значения
    /// </summary>
    public interface IValueUnit:IUnit
    {
        object Value { get; set; }
        Type TypeValue { get; set; }
        object GetValue(Multiplier mt);
        string GetValue(string format);
        string GetValue(Multiplier mt, string format);
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
                    return !String.IsNullOrWhiteSpace(this.value)? Double.Parse(this.value):(double?)null;
                }
                if (this.typevalue == typeof(int)){
                    return !String.IsNullOrWhiteSpace(this.value)? int.Parse(this.value):(int?)null;
                }
                if (this.typevalue == typeof(string)){
                    return this.value;
                }
                if (this.typevalue == typeof(DateTime))
                {
                    return !String.IsNullOrWhiteSpace(this.value) ? DateTime.Parse(this.value) : (DateTime?)null;
                }
                if (this.typevalue == typeof(ValueError))
                {
                    return "error";
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
        //TODO: Обработка ошибок?
        //public ValueMeasurement(ValueError error, string description, TypeMeasurement type, int unit, Multiplier multiplier)
        //    : base(description, type, unit, multiplier)
        //{
        //    this.value = "error";
        //    this.typevalue = typeof(ValueError);
        //}
        public ValueMeasurement(Type typevalue, string description, TypeMeasurement type, int unit, Multiplier multiplier)
            : base(description, type, unit, multiplier)
        {
            this.value = null;
            this.typevalue = typevalue;
        }
        public ValueMeasurement(double? value, string description, TypeMeasurement type, int unit, Multiplier multiplier)
            : base(description, type, unit, multiplier)
        {
            this.value = value!=null ? value.ToString() : null;
            this.typevalue = typeof(double);
        }
        public ValueMeasurement(int? value, string description, TypeMeasurement type, int unit, Multiplier multiplier)
            : base(description, type, unit, multiplier)
        {
            this.value = value != null ? value.ToString() : null;
            this.typevalue = typeof(int);
        }
        public ValueMeasurement(string value, string description, TypeMeasurement type, int unit, Multiplier multiplier)
            : base(description, type, unit, multiplier)
        {
            this.value = value.ToString();
            this.typevalue = typeof(string);
        }
        public ValueMeasurement(DateTime? value, string description, TypeMeasurement type, int unit, Multiplier multiplier)
            : base(description, type, unit, multiplier)
        {
            this.value = value != null ? value.ToString() : null;
            this.typevalue = typeof(DateTime);
        }
        /// <summary>
        /// Получить значение параметра преведенное к нужному множителю
        /// </summary>
        /// <param name="mt"></param>
        /// <returns></returns>
        public object GetValue(Multiplier mt)
        {
            if ((int)mt == (int)this.multiplier | this.Value == null ) return this.Value;
            if (this.Value is Double)
            {
                return this.Value != null ? (double)((double)this.Value * (int)this.multiplier) / (int)mt : (double?)null;
            }
            if (this.Value is int)
            {
                return this.Value != null ? (int)((int)this.Value * (int)this.multiplier) / (int)mt : (int?)null;
            }
            return this.Value;
        }
        /// <summary>
        /// Форматированный вывод
        /// </summary>
        /// <param name="value"></param>
        /// <param name="format"></param>
        /// <returns></returns>
        private string GetValue(object value, string format) {
            if (value == null) return null;
            if (value is Double)
            {
                return String.Format("{0:" + format + "}", (double)value);
            }
            if (value is int)
            {
                return String.Format("{0:" + format + "}", (int)value);
            }
            return value.ToString();        
        }
        /// <summary>
        /// Форматированный вывод
        /// </summary>
        /// <param name="format"></param>
        /// <returns></returns>
        public string GetValue(string format)
        {
            return GetValue(this.Value, format);
        }
        /// <summary>
        /// Получить значение параметра преведенное к нужному множителю c форматированным выводом
        /// </summary>
        /// <param name="mt"></param>
        /// <param name="format"></param>
        /// <returns></returns>
        public string GetValue(Multiplier mt, string format)
        {
            return GetValue(GetValue(mt), format);
        }
        /// <summary>
        /// Получить значение параметра преведенное к нужному множителю c единицами измерения
        /// </summary>
        /// <param name="mt"></param>
        /// <returns></returns>
        public string GetValueUnit(Multiplier mt)
        {
            return GetValue(mt).ToString() + " " + base.GetUnit();
        }
        /// <summary>
        /// Получить значение параметра преведенное к нужному множителю c единицами измерения и множителем
        /// </summary>
        /// <param name="mt"></param>
        /// <returns></returns>
        public string GetValueUnitMultiplier(Multiplier mt)
        {
            return GetValue(mt).ToString() + " " + base.GetMultiplier(mt) + " " + base.GetUnit();
        }
        /// <summary>
        /// Получить значение параметра c форматированным выводом и единицами измерения
        /// </summary>
        /// <param name="format"></param>
        /// <returns></returns>
        public string GetValueUnit(string format)
        {
            return GetValue(format).ToString() + " " + base.GetUnit();
        }
        /// <summary>
        /// Получить значение параметра c форматированным выводом и единицами измерения и множителем
        /// </summary>
        /// <param name="format"></param>
        /// <returns></returns>
        public string GetValueUnitMultiplier(string format)
        {
            return GetValue(format).ToString() + " " + base.GetUnitMultiplier();
        }
        /// <summary>
        /// Получить значение параметра преведенное к нужному множителю c форматированным выводом c единицами измерения
        /// </summary>
        /// <param name="mt"></param>
        /// <param name="format"></param>
        /// <returns></returns>
        public string GetValueUnit(Multiplier mt, string format)
        {
            return GetValue(mt, format).ToString() + " " + base.GetUnit();
        }
        /// <summary>
        /// Получить значение параметра преведенное к нужному множителю c форматированным выводом c единицами измерения и множителем
        /// </summary>
        /// <param name="mt"></param>
        /// <param name="format"></param>
        /// <returns></returns>
        public string GetValueUnitMultiplier(Multiplier mt, string format)
        {
            return GetValue(mt, format).ToString() + " " + base.GetMultiplier(mt)+ " " + base.GetUnit();
        }
}
    /// <summary>
    /// Класс параметр каллорийность
    /// </summary>
    public class СalorificValue : ValueMeasurement {
        public СalorificValue(double? value, string description, uСalorific unit, Multiplier multiplier) : 
            base(value, description, TypeMeasurement.Calorific, (int)unit, multiplier) { }
        public СalorificValue(string description, uСalorific unit, Multiplier multiplier) : 
            base(typeof(double), description, TypeMeasurement.Calorific, (int)unit, multiplier) { }
    }
    /// <summary>
    /// Класс параметр плотность
    /// </summary>
    public class DensityValue : ValueMeasurement {
        public DensityValue(double? value, string description, uDensity unit, Multiplier multiplier) :
            base(value, description, TypeMeasurement.Density, (int)unit, multiplier) { }
        public DensityValue(string description, uDensity unit, Multiplier multiplier) : 
            base(typeof(double), description, TypeMeasurement.Density, (int)unit, multiplier) { }
    }
    /// <summary>
    /// Класс параметр расход
    /// </summary>
    public class FlowValue : ValueMeasurement {
        //TODO: Обработка ошибок?
        //public FlowValue(ValueError error, string description, uFlow unit, Multiplier multiplier) :
        //    base(error, description, TypeMeasurement.Flow, (int)unit, multiplier) { }
        public FlowValue(double? value, string description, uFlow unit, Multiplier multiplier) : 
            base(value, description, TypeMeasurement.Flow, (int)unit, multiplier) { }
        public FlowValue(string description, uFlow unit, Multiplier multiplier) :
            base(typeof(double), description, TypeMeasurement.Flow, (int)unit, multiplier) { }
    }
    /// <summary>
    /// Класс параметр газовый анализ
    /// </summary>
    public class GasValue : ValueMeasurement {
        public GasValue(double? value, string description, uGas unit, Multiplier multiplier) :
            base(value, description, TypeMeasurement.Gas, (int)unit, multiplier) { }
        public GasValue(string description, uGas unit, Multiplier multiplier) : 
            base(typeof(double), description, TypeMeasurement.Gas, (int)unit, multiplier) { }
    }
    /// <summary>
    /// Класс параметр планиметрическое число
    /// </summary>
    public class PlanimetricValue : ValueMeasurement {
        public PlanimetricValue(double? value, string description, uPlanimetric unit, Multiplier multiplier) :
            base(value, description, TypeMeasurement.Planimetric, (int)unit, multiplier) { }
        public PlanimetricValue(string description, uPlanimetric unit, Multiplier multiplier) :
            base(typeof(double), description, TypeMeasurement.Planimetric, (int)unit, multiplier) { }
    }
    /// <summary>
    /// Класс параметр давление
    /// </summary>
    public class PressureValue : ValueMeasurement {
        public PressureValue(double? value, string description, uPressure unit, Multiplier multiplier) : 
            base(value, description, TypeMeasurement.Pressure, (int)unit, multiplier) { }
        public PressureValue(string description, uPressure unit, Multiplier multiplier) : 
            base(typeof(double), description, TypeMeasurement.Pressure, (int)unit, multiplier) { }
    }
    /// <summary>
    /// Класс параметр температура
    /// </summary>
    public class TempValue : ValueMeasurement {
        public TempValue(double? value, string description, uTemp unit, Multiplier multiplier) : 
            base(value, description, TypeMeasurement.Temp, (int)unit, multiplier) { }
        public TempValue(string description, uTemp unit, Multiplier multiplier) :
            base(typeof(double), description, TypeMeasurement.Temp, (int)unit, multiplier) { }
    }
    /// <summary>
    /// Класс параметр время
    /// </summary>
    public class TimeValue : ValueMeasurement {
        public TimeValue(int? value, string description, uTime unit, Multiplier multiplier) :
            base(value, description, TypeMeasurement.Time, (int)unit, multiplier) { }
        public TimeValue(string description, uTime unit, Multiplier multiplier) :
            base(typeof(int), description, TypeMeasurement.Time, (int)unit, multiplier) { }
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

    //TODO: Добавить классы DBСalorificValue .... DBTimeValue

    #endregion
}
