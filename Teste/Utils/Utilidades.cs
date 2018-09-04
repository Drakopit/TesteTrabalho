using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;

namespace Teste.Utils
{
    public static class Utilidades
    {
        // Funcionando
        public static List<T> ObterArquivo<T>(string caminhoDoArquivo)
        {
            List<T> lista = new List<T>();

            if (File.Exists(caminhoDoArquivo))
            {
                String[] linhas = File.ReadAllLines(caminhoDoArquivo);
                string json = "";

                foreach (var linha in linhas)
                {
                    json += linha;
                }
                lista = JsonConvert.DeserializeObject<List<T>>(json);
            }
            else
            {
                using (var file = File.Create(caminhoDoArquivo)) { }
            }
            return lista;
        }

        // Funcionando
        public static void Inserir<T>(string caminhoDoArquivo, T domain)
        {
            if (File.Exists(caminhoDoArquivo))
            {
                List<T> lista = new List<T>();
                string json = File.ReadAllText(caminhoDoArquivo);
                lista = JsonConvert.DeserializeObject<List<T>>(json);
                lista.Add(domain);
                json = JsonConvert.SerializeObject(lista);
                File.WriteAllText(caminhoDoArquivo, json);
            }
        }

        public static void Alterar<T>(string caminhoDoArquivo, int id, T domain)
        {
            if (File.Exists(caminhoDoArquivo))
            {
                // Transforma o arquivo em json e remove
                string json = File.ReadAllText(caminhoDoArquivo);
                List<T> lista = JsonConvert.DeserializeObject<List<T>>(json);
                lista[id] = domain;
                // Salva o arquivo de novo
                json = JsonConvert.SerializeObject(lista);
                File.WriteAllText(caminhoDoArquivo, json);
            }
        }

        public static void Excluir<T>(string caminhoDoArquivo, int id)
        {
            if (File.Exists(caminhoDoArquivo))
            {
                // Transforma o arquivo em json e remove
                string json = File.ReadAllText(caminhoDoArquivo);
                List<T> lista = JsonConvert.DeserializeObject<List<T>>(json);
                lista.RemoveAt(id);
                // Salva o arquivo de novo
                json = JsonConvert.SerializeObject(lista);
                File.WriteAllText(caminhoDoArquivo, json);
            }
        }
    }
}