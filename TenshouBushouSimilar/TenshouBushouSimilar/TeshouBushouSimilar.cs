using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Json;

/// <summary>
/// シリアライズに関係する汎用機能を提供するクラス 
/// </summary>
internal static class JsonExtension
{
    /// <summary>
    /// 任意のオブジェクトをJsonメッセージへシリアライズします。
    /// </summary>
    public static string Serialize(object graph)
    {
        using (var stream = new MemoryStream())
        {
            var setting = new DataContractJsonSerializerSettings()
            {
                UseSimpleDictionaryFormat = true,
            };
            var serializer = new DataContractJsonSerializer(graph.GetType(), setting);
            serializer.WriteObject(stream, graph);
            return Encoding.UTF8.GetString(stream.ToArray());
        }
    }

    /// <summary>
    /// Jsonメッセージをオブジェクトへデシリアライズします。
    /// </summary>
    public static T Deserialize<T>(string message)
    {
        using (var stream = new MemoryStream(Encoding.UTF8.GetBytes(message)))
        {
            var setting = new DataContractJsonSerializerSettings()
            {
                UseSimpleDictionaryFormat = true,
            };
            var serializer = new DataContractJsonSerializer(typeof(T), setting);
            return (T)serializer.ReadObject(stream);
        }
    }
}

// データ構造
[DataContract]
internal class BushouBiography
{
    [DataMember(Name = "ID")]
    public string ID { get; set; }

    [DataMember(Name = "代表名")]
    public string 代表名 { get; set; }

    [DataMember(Name = "別名1")]
    public string 別名_01 { get; set; }

    [DataMember(Name = "別名2")]
    public string 別名_02 { get; set; }

    [DataMember(Name = "別名3")]
    public string 別名_03 { get; set; }

    [DataMember(Name = "別名4")]
    public string 別名_04 { get; set; }

    [DataMember(Name = "別名5")]
    public string 別名_05 { get; set; }

    /*
    [DataMember(Name = "別名6")]
    public string 別名_06 { get; set; }
    */

    [DataMember(Name = "別名7")]
    public string 別名_07 { get; set; }

    [DataMember(Name = "別名8")]
    public string 別名_08 { get; set; }

    [DataMember(Name = "別名9")]
    public string 別名_09 { get; set; }

    [DataMember(Name = "別名10")]
    public string 別名_10 { get; set; }

    [DataMember(Name = "別名11")]
    public string 別名_11 { get; set; }

    [DataMember(Name = "将星録")]
    public string ID_将星録 { get; set; }

    [DataMember(Name = "烈風伝")]
    public string ID_烈風伝 { get; set; }

    [DataMember(Name = "嵐世記")]
    public string ID_嵐世記 { get; set; }

    [DataMember(Name = "蒼天録")]
    public string ID_蒼天録 { get; set; }

    [DataMember(Name = "天下創世")]
    public string ID_天下創世 { get; set; }

    [DataMember(Name = "革新")]
    public string ID_革新 { get; set; }

    [DataMember(Name = "天道")]
    public string ID_天道 { get; set; }

    [DataMember(Name = "創造")]
    public string ID_創造 { get; set; }

    [DataMember(Name = "戦国立志伝")]
    public string ID_戦国立志伝 { get; set; }

    [DataMember(Name = "大志")]
    public string ID_大志 { get; set; }


    [DataMember(Name = "天翔記-誕生")]
    public string 誕生_天翔記 { get; set; }

    [DataMember(Name = "将星録-誕生")]
    public string 誕生_将星録 { get; set; }

    [DataMember(Name = "烈風伝-誕生")]
    public string 誕生_烈風伝 { get; set; }

    [DataMember(Name = "嵐世記-誕生")]
    public string 誕生_嵐世記 { get; set; }

    [DataMember(Name = "蒼天録-誕生")]
    public string 誕生_蒼天録 { get; set; }

    [DataMember(Name = "天下創世-誕生")]
    public string 誕生_天下創世 { get; set; }

    [DataMember(Name = "革新-誕生")]
    public string 誕生_革新 { get; set; }

    [DataMember(Name = "天道-誕生")]
    public string 誕生_天道 { get; set; }

    [DataMember(Name = "創造-誕生")]
    public string 誕生_創造 { get; set; }

    [DataMember(Name = "戦国立志伝-誕生")]
    public string 誕生_戦国立志伝 { get; set; }

    [DataMember(Name = "大志-誕生")]
    public string 誕生_大志 { get; set; }

    [DataMember(Name = "天翔記-死亡")]
    public string 死亡_天翔記 { get; set; }

    [DataMember(Name = "将星録-死亡")]
    public string 死亡_将星録 { get; set; }

    [DataMember(Name = "烈風伝-死亡")]
    public string 死亡_烈風伝 { get; set; }

    [DataMember(Name = "嵐世記-死亡")]
    public string 死亡_嵐世記 { get; set; }

    [DataMember(Name = "蒼天録-死亡")]
    public string 死亡_蒼天録 { get; set; }

    [DataMember(Name = "天下創世-死亡")]
    public string 死亡_天下創世 { get; set; }

    [DataMember(Name = "革新-死亡")]
    public string 死亡_革新 { get; set; }

    [DataMember(Name = "天道-死亡")]
    public string 死亡_天道 { get; set; }

    [DataMember(Name = "創造-死亡")]
    public string 死亡_創造 { get; set; }

    [DataMember(Name = "戦国立志伝-死亡")]
    public string 死亡_戦国立志伝 { get; set; }

    [DataMember(Name = "大志-死亡")]
    public string 死亡_大志 { get; set; }


    [DataMember(Name = "天翔記-列伝")]
    public string 列伝_天翔記 { get; set; }

    [DataMember(Name = "将星録-列伝")]
    public string 列伝_将星録 { get; set; }

    [DataMember(Name = "烈風伝-列伝")]
    public string 列伝_烈風伝 { get; set; }

    [DataMember(Name = "嵐世記-列伝")]
    public string 列伝_嵐世記 { get; set; }

    [DataMember(Name = "蒼天録-列伝")]
    public string 列伝_蒼天録 { get; set; }

    [DataMember(Name = "天下創世-列伝")]
    public string 列伝_天下創世 { get; set; }

    [DataMember(Name = "革新-列伝")]
    public string 列伝_革新 { get; set; }

    [DataMember(Name = "天道-列伝")]
    public string 列伝_天道 { get; set; }

    [DataMember(Name = "創造-列伝")]
    public string 列伝_創造 { get; set; }

    [DataMember(Name = "戦国立志伝-列伝")]
    public string 列伝_戦国立志伝 { get; set; }

    [DataMember(Name = "大志-列伝")]
    public string 列伝_大志 { get; set; }


    public BushouBiography()
    {
    }
}

interface IBushouBiographyInformation
{
    string Name { get; }

    int BornYear { get; }

    int DeathYear { get; }

    string Biography { get; }
}

namespace TenshouBushouSimilar
{


    partial class BushouBiographyAnalyzer
    {
        const string BushouBiographyFileName = "BushouBiography.json";

        public IList<BushouBiography> BushouBiographyList;

        IList<BushouBiography> GetBushouBiographyList(string strDataFileName)
        {
            string data = File.ReadAllText(strDataFileName);
            // デシリアライズ
            var list = JsonExtension.Deserialize<IList<BushouBiography>>(data);
            return list;
        }

        IList<double> GetBushouNamePointList(string strBushouFullName)
        {
            IList<double> BushouNamePointList = new List<double>();

            foreach (var bb in BushouBiographyList)
            {
                var point = GetBushouNamePoint(strBushouFullName, bb);
                BushouNamePointList.Add(point);
            }
            return BushouNamePointList;
        }

        double GetBushouNamePoint(string strBushouFullName, BushouBiography bb)
        {
            string[] adana_fullname_list =
            {
                    bb.代表名,

                    bb.別名_01,
                    bb.別名_02,
                    bb.別名_03,
                    bb.別名_04,
                    bb.別名_05,
//                    bb.別名_06,
                    bb.別名_07,
                    bb.別名_08,
                    bb.別名_09,
                    bb.別名_10,
                    bb.別名_11
                };

            foreach (var adana_full_name in adana_fullname_list)
            {
                var adana = adana_full_name.Trim(' ');
                if (adana_full_name.Length == 0)
                {
                    continue;
                }
                var partial_names = adana.Split(' ').ToList();
                if (partial_names.Count > 0)
                {
                    // 姓名のパターンでフルで一致するものがあれば、すごく得点が高い
                    if (partial_names.TrueForAll(str => str.Length > 0 && strBushouFullName.Contains(str)))
                    {
                        return 1;
                    }
                }
            }

            foreach (var adana_full_name in adana_fullname_list)
            {
                var adana = adana_full_name.Trim(' ');
                if (adana_full_name.Length == 0)
                {
                    continue;
                }
                var partial_names = adana.Split(' ').ToList();
                if (partial_names.Count > 0)
                {
                    // 姓名のパターンでフルで一致するものがあれば、すごく得点が高い
                    if (partial_names.Any(str => str.Length > 0 && strBushouFullName.Contains(str)))
                    {
                        return 0.05;
                    }
                }
            }

            return 0;
        }

        IList<int> GetBushouBornPointList(int bornADYear)
        {
            IList<int> BushouBornPointList = new List<int>();

            foreach (var bb in BushouBiographyList)
            {
                var point = GetBushouBornPoint(bornADYear, bb);
                BushouBornPointList.Add(point);
            }
            return BushouBornPointList;
        }

        int GetBushouBornPoint(int bornADYear, BushouBiography bb)
        {
            string[] born_list =
            {
                    bb.誕生_天翔記,
                    bb.誕生_将星録,
                    bb.誕生_烈風伝,
                    bb.誕生_嵐世記,
                    bb.誕生_蒼天録,
                    bb.誕生_天下創世,
                    bb.誕生_革新,
                    bb.誕生_天道,
                    bb.誕生_創造,
                    bb.誕生_戦国立志伝,
                    bb.誕生_大志
                };

            foreach (var born in born_list)
            {
                if (born_list.Contains(bornADYear.ToString()))
                {
                    return 1;
                }
            }

            return -1;
        }

        IList<int> GetBushouDeathPointList(int bornADYear)
        {
            IList<int> BushouDeathPointList = new List<int>();

            foreach (var bb in BushouBiographyList)
            {
                var point = GetBushouDeathPoint(bornADYear, bb);
                BushouDeathPointList.Add(point);
            }
            return BushouDeathPointList;
        }

        int GetBushouDeathPoint(int deathYearAD, BushouBiography bb)
        {
            string[] death_list =
            {
                    bb.死亡_天翔記,
                    bb.死亡_将星録,
                    bb.死亡_烈風伝,
                    bb.死亡_嵐世記,
                    bb.死亡_蒼天録,
                    bb.死亡_天下創世,
                    bb.死亡_革新,
                    bb.死亡_天道,
                    bb.死亡_創造,
                    bb.死亡_戦国立志伝,
                    bb.死亡_大志
                };

            foreach (var born in death_list)
            {
                if (death_list.Contains(deathYearAD.ToString()))
                {
                    return 1;
                }
            }

            return -1;
        }

        IList<double> GetBushouNGramDistancePointList(string strBushouBiography)
        {
            IList<double> BushouNGramDistancePointList = new List<double>();

            foreach (var bb in BushouBiographyList)
            {
                var point = GetBushouNGramDistancePoint(strBushouBiography, bb);
                BushouNGramDistancePointList.Add(point);
            }

            return BushouNGramDistancePointList;
        }

        double GetBushouNGramDistancePoint(string strBushouBiography, BushouBiography bb)
        {
            if (strBushouBiography.Length <= 5)
            {
                return 0;
            }


            string[] retsuden_list =
            {
                    bb.列伝_天翔記,
                    bb.列伝_将星録,
                    bb.列伝_烈風伝,
                    bb.列伝_嵐世記,
                    bb.列伝_蒼天録,
                    bb.列伝_天下創世,
                    bb.列伝_革新,
                    bb.列伝_天道,
                    bb.列伝_創造,
                    bb.列伝_戦国立志伝,
                    bb.列伝_大志
                };

            int valid_retsuden_cnt = 0;
            double sum = 0;

            Dictionary<string, double> pointlist = new Dictionary<string, double>();

            foreach (var retsuden in retsuden_list)
            {
                if (retsuden.Length > 5)
                {
                    valid_retsuden_cnt++;
                    double culc = 0;
                    if (pointlist.ContainsKey(retsuden))
                    {
                        culc = pointlist[retsuden];
                    }
                    else
                    {
                        culc = (double)StringSimilar.Ngram.CompareBigram(strBushouBiography, retsuden.Trim(' '));
                        pointlist[retsuden] = culc;
                    }
                    sum += culc;
                }
            }

            if (valid_retsuden_cnt > 0)
            {
                sum = sum / (double)valid_retsuden_cnt;
            }

            return sum;
        }


        IList<double> GetBushouLevenshteinDistancePointList(string strBushouBiography)
        {
            IList<double> BushouLevenshteinDistancePointList = new List<double>();

            foreach (var bb in BushouBiographyList)
            {
                var point = GetBushouLevenshteinDistancePoint(strBushouBiography, bb);
                BushouLevenshteinDistancePointList.Add(point);
            }
            return BushouLevenshteinDistancePointList;
        }

        double GetBushouLevenshteinDistancePoint(string strBushouBiography, BushouBiography bb)
        {
            string[] retsuden_list =
            {
                    bb.列伝_天翔記,
                    bb.列伝_将星録,
                    bb.列伝_烈風伝,
                    bb.列伝_嵐世記,
                    bb.列伝_蒼天録,
                    bb.列伝_天下創世,
                    bb.列伝_革新,
                    bb.列伝_天道,
                    bb.列伝_創造,
                    bb.列伝_戦国立志伝,
                    bb.列伝_大志
                };

            int valid_retsuden_cnt = 0;
            double sum = 0;

            Dictionary<string, double> pointlist = new Dictionary<string, double>();

            foreach (var retsuden in retsuden_list)
            {
                if (retsuden.Length > 5)
                {
                    valid_retsuden_cnt++;
                    double culc = 0;
                    if (pointlist.ContainsKey(retsuden))
                    {
                        culc = pointlist[retsuden];
                    }
                    else
                    {
                        culc = (double)StringSimilar.LevenshteinDistance.Compute(strBushouBiography, retsuden.Trim(' '));
                        pointlist[retsuden] = culc;
                    }
                    sum += culc;
                }
            }

            if (valid_retsuden_cnt > 0)
            {
                sum = sum / (double)valid_retsuden_cnt;
            }

            return sum;
        }

    }


    partial class BushouBiographyAnalyzer
    {
        public BushouBiographyAnalyzer()
        {
            BushouBiographyList = GetBushouBiographyList(BushouBiographyFileName);
        }


        public IList<double> GetPointByBushouNamePointList(string strBushouName)
        {
            return GetBushouNamePointList(strBushouName);
        }

        public IList<double> GetPointByBushouBornPoint(int bornADYear)
        {
            List<double> list = new List<double>();

            var bornlist = GetBushouBornPointList(bornADYear);
            for (int i = 0; i < bornlist.Count; i++)
            {
                if (bornlist[i] > 0)
                {
                    list.Add(bornlist[i] * 0.5);
                }
                else
                {
                    list.Add(bornlist[i] * 0.25);
                }
            }

            return list;
        }

        public IList<double> GetPointByBushouDeathPoint(int deathADYear)
        {
            List<double> list = new List<double>();

            var deathlist = GetBushouDeathPointList(deathADYear);
            for (int i = 0; i < deathlist.Count; i++)
            {
                if (deathlist[i] > 0)
                {
                    list.Add(deathlist[i] * 0.5);
                }
                else
                {
                    list.Add(deathlist[i] * 0.25);
                }
            }

            return list;
        }


        public IList<double> GetPointByBushouBiographyPoint(string strBushouBiography)
        {
            var list = GetBushouNGramDistancePointList(strBushouBiography);

            // もしも全ての要素の得点が同じであれば、有意な値が入っていない
            var checklist = list.ToList();
            if (checklist.TrueForAll(e => e == checklist[0]))
            {
                for (int d = 0; d < list.Count; d++)
                {
                    list[d] = 0;
                }
            }

            List<KeyValuePair<int, double>> pairlist = new List<KeyValuePair<int, double>>();
            for (int i = 0; i < list.Count; i++)
            {
                pairlist.Add(new KeyValuePair<int, double>(i, list[i]));
            }

            pairlist.Sort(
                (KeyValuePair<int, double> a, KeyValuePair<int, double> b) =>
                {
                    // まずは得点が高いもの
                    if (a.Value > b.Value) return -1;
                    if (a.Value < b.Value) return 1;
                    // 特典が同じ場合は、番号が若い者。若い番号には有名な武将が集まっている
                    if (a.Value == b.Value)
                    {
                        if (a.Key < b.Key) return -1;
                        if (a.Key > b.Key) return 1;
                    }
                    return 0;
                });

            for (int s = 0; s < pairlist.Count; s++)
            {
                double point = 0.5 - 0.05 * s + pairlist[s].Value;
                if (point < 0) { point = 0; }
                if (pairlist[s].Value == 0)
                {
                    point = 0;
                }

                int ix = pairlist[s].Key;
                list[ix] = point;
            }

            return list;
        }
    }

}
