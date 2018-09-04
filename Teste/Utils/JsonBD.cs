using Newtonsoft.Json;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Teste.Models;

namespace Teste.Utils
{
    public static class JsonBD<T> where T : ModelBase
    {
        // Funcionando
        public static List<T> ObterArquivo(string caminhoDoArquivo)
        {
            List<T> lista = new List<T>();

            if (File.Exists(caminhoDoArquivo))
            {
                string json = File.ReadAllText(caminhoDoArquivo);
                lista = JsonConvert.DeserializeObject<List<T>>(json);
            }
            else
            {
                using (var file = File.Create(caminhoDoArquivo)) { }
            }
            return lista;
        }

        public static T Obter(string caminhoDoArquivo, int id)
        {
            List<T> lista = new List<T>();

            if (File.Exists(caminhoDoArquivo))
            {
                string json = File.ReadAllText(caminhoDoArquivo);
                lista = JsonConvert.DeserializeObject<List<T>>(json);
                return lista[id];
            }
            return lista.FirstOrDefault();
        }

        // Funcionando: Inserir um objeto
        public static void Inserir(string caminhoDoArquivo, T domain)
        {
            if (File.Exists(caminhoDoArquivo))
            {
                List<T> lista = new List<T>();
                string json = File.ReadAllText(caminhoDoArquivo);
                lista = JsonConvert.DeserializeObject<List<T>>(json);
                if (lista.Count > 0)
                {
                    int num = lista.ElementAt(0).Id;
                    for (int i = 0; i < lista.Count; i++)
                    {
                        if (num < lista[i].Id)
                        {
                            num = lista[i].Id;
                        }
                    }
                    domain.Id = (num + 1);
                }
                else
                {
                    domain.Id = 0;
                }
                lista.Add(domain);
                json = JsonConvert.SerializeObject(lista, Formatting.Indented);
                File.WriteAllText(caminhoDoArquivo, json);
            }
        }

        // Funcionando: Inserir um objeto
        public static void InserirLista(string caminhoDoArquivo, List<T> domain)
        {
            if (File.Exists(caminhoDoArquivo))
            {
                List<T> lista = new List<T>();
                string json = File.ReadAllText(caminhoDoArquivo);
                lista = JsonConvert.DeserializeObject<List<T>>(json);
                lista.AddRange(domain);
                json = JsonConvert.SerializeObject(lista, Formatting.Indented);
                File.WriteAllText(caminhoDoArquivo, json);
            }
        }

        public static void Alterar(string caminhoDoArquivo, int id, T domain)
        {
            if (File.Exists(caminhoDoArquivo))
            {
                // Transforma o arquivo em json e remove
                string json = File.ReadAllText(caminhoDoArquivo);
                List<T> lista = JsonConvert.DeserializeObject<List<T>>(json);
                lista[id] = domain;
                // Salva o arquivo de novo
                json = JsonConvert.SerializeObject(lista, Formatting.Indented);
                File.WriteAllText(caminhoDoArquivo, json);
            }
        }

        public static void ExcluirPorId(string caminhoDoArquivo, int id)
        {
            if (File.Exists(caminhoDoArquivo))
            {
                // Transforma o arquivo em json e remove
                string json = File.ReadAllText(caminhoDoArquivo);
                List<T> lista = JsonConvert.DeserializeObject<List<T>>(json);
                lista.RemoveAt(id);
                // Salva o arquivo de novo
                json = JsonConvert.SerializeObject(lista, Formatting.Indented);
                File.WriteAllText(caminhoDoArquivo, json);
            }
        }

        public static void Excluir(string caminhoDoArquivo, T domain)
        {
            if (File.Exists(caminhoDoArquivo))
            {
                // Transforma o arquivo em json e remove
                string json = File.ReadAllText(caminhoDoArquivo);
                List<T> lista = JsonConvert.DeserializeObject<List<T>>(json);
                lista.Remove(domain);
                // Salva o arquivo de novo
                json = JsonConvert.SerializeObject(lista, Formatting.Indented);
                File.WriteAllText(caminhoDoArquivo, json);
            }
        }
    }
}