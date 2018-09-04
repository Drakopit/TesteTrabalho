using Newtonsoft.Json;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Teste.Models;

namespace Teste.Utils
{
    public static class OldSchoolDataBase<T> where T : ModelBase
    {
        /// <summary>
        ///     Obtem uma lista com todos
        ///     os objetos do arquivo
        /// </summary>
        /// <param name="caminhoDoArquivo"></param>
        /// <returns></returns>
        public static List<T> ObterLista(string caminhoDoArquivo)
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

        /// <summary>
        ///     Obtem um objeto específico
        ///     do arquivo Json
        /// </summary>
        /// <param name="caminhoDoArquivo"></param>
        /// <param name="id"></param>
        /// <returns></returns>
        public static T Obter(string caminhoDoArquivo, int id)
        {
            List<T> lista = new List<T>();

            if (File.Exists(caminhoDoArquivo))
            {
                string json = File.ReadAllText(caminhoDoArquivo);
                lista = JsonConvert.DeserializeObject<List<T>>(json);
                for (int i = 0; i < lista.Count; i++)
                {
                    if (lista[i].Id == id) return lista[i];
                }
            }
            return lista.FirstOrDefault();
        }

        /// <summary>
        ///     Insere um objeto no arquivo Json
        /// </summary>
        /// <param name="caminhoDoArquivo"></param>
        /// <param name="domain"></param>
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

                    for (int j = 0; j < lista.Count; j++)
                        if (num < lista[j].Id) num = lista[j].Id;
                    domain.Id = (num + 1);
                }
                lista.Add(domain);
                json = JsonConvert.SerializeObject(lista, Formatting.Indented);
                File.WriteAllText(caminhoDoArquivo, json);
            }
        }

        /// <summary>
        ///     Insere uma lista de determinado
        ///     objeto na arquivo JSON
        /// </summary>
        /// <param name="caminhoDoArquivo"></param>
        /// <param name="domain"></param>
        public static void InserirLista(string caminhoDoArquivo, List<T> domain)
        {
            if (File.Exists(caminhoDoArquivo))
                foreach (var item in domain)
                    Inserir(caminhoDoArquivo, item);
        }

        /// <summary>
        ///     Altera um objeto do arquivo Json
        /// </summary>
        /// <param name="caminhoDoArquivo"></param>
        /// <param name="id"></param>
        /// <param name="domain"></param>
        public static void Alterar(string caminhoDoArquivo, int id, T domain)
        {
            if (File.Exists(caminhoDoArquivo))
            {
                string json = File.ReadAllText(caminhoDoArquivo);
                List<T> lista = JsonConvert.DeserializeObject<List<T>>(json);
                for (int i = 0; i < lista.Count; i++)
                    if (lista[i].Id == id) lista[i] = domain;
                json = JsonConvert.SerializeObject(lista, Formatting.Indented);
                File.WriteAllText(caminhoDoArquivo, json);
            }
        }

        /// <summary>
        ///     Exclui um objeto específico do
        ///     arquivo Json pelo id passado
        /// </summary>
        /// <param name="caminhoDoArquivo"></param>
        /// <param name="id"></param>
        public static void ExcluirPorId(string caminhoDoArquivo, int id)
        {
            if (File.Exists(caminhoDoArquivo))
            {
                string json = File.ReadAllText(caminhoDoArquivo);
                List<T> lista = JsonConvert.DeserializeObject<List<T>>(json);
                for (int i = 0; i < lista.Count; i++)
                    if (lista[i].Id == id) lista.RemoveAt(i);
                json = JsonConvert.SerializeObject(lista, Formatting.Indented);
                File.WriteAllText(caminhoDoArquivo, json);
            }
        }

        /// <summary>
        ///     Exclui um objeto, passando-o
        ///     como parametro
        /// </summary>
        /// <param name="caminhoDoArquivo"></param>
        /// <param name="domain"></param>
        public static void Excluir(string caminhoDoArquivo, T domain)
        {
            if (File.Exists(caminhoDoArquivo))
            {
                string json = File.ReadAllText(caminhoDoArquivo);
                List<T> lista = JsonConvert.DeserializeObject<List<T>>(json);
                lista.Remove(domain);
                json = JsonConvert.SerializeObject(lista, Formatting.Indented);
                File.WriteAllText(caminhoDoArquivo, json);
            }
        }
    }
}