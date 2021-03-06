﻿using ClosedXML.Excel;
using ExcelAux.ClassesObjetos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace ExcelAux.Manipulador
{
    public class Manipular
    {
        private static XLWorkbook AbrirExcel()
        {
            string caminhoExcel = @"C:\Users\Fellipe Mendonça\OneDrive\Documentos\Estudos OC\Guia de Estudos.xlsx";
            XLWorkbook excel = new XLWorkbook(caminhoExcel); // Abrir Excel
            return excel;
        }

        public static List<string> GetNomePlanilhas()
        {
            try
            {
                XLWorkbook excel = AbrirExcel();
                List<string> nomePlanilhas = new List<string>();
                int qtdPlanilhas = excel.Worksheets.Count; // Obter a quantidade de Planilhas
                for (int i = 1; i <= qtdPlanilhas; i++)
                {
                    nomePlanilhas.Add(excel.Worksheet(i).Name); // Obter nomes das planilhas existentes
                }
                return nomePlanilhas;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Tipo de Erro: " + ex.Message, "Erro", MessageBoxButtons.OKCancel, MessageBoxIcon.Error);
            }

            return null;
        }


        public static List<Materias> GetPlanilhaMaterias()
        {
            try
            {
                XLWorkbook excel = AbrirExcel();
                var planilha = excel.Worksheet("Materias de Estudos"); // Possivel Selected no ComboBox
                List<Materias> listaMateria = new List<Materias>();

                int linha = 2;//Começa a leitura pela linha 2 para ignorar cabeçalho
                while (true)
                {
                    Materias materia = new Materias()
                    {
                        Id = planilha.Cell("A" + linha.ToString()).Value.ToString(),
                        Local = planilha.Cell("B" + linha.ToString()).Value.ToString(),
                        Materia = planilha.Cell("C" + linha.ToString()).Value.ToString(),
                        Conteudo = planilha.Cell("D" + linha.ToString()).Value.ToString(),
                        Prioridade = planilha.Cell("E" + linha.ToString()).Value.ToString(),
                        DataInicio = planilha.Cell("F" + linha.ToString()).Value.ToString(),
                        DataFim = planilha.Cell("G" + linha.ToString()).Value.ToString(),
                        Finalizado = planilha.Cell("H" + linha.ToString()).Value.ToString()
                    };

                    if (string.IsNullOrEmpty(materia.Id)) { break; }
                    else { listaMateria.Add(materia); }

                    linha++;
                }
                planilha.Dispose();
                excel.Dispose();
                return listaMateria;
            }
            catch (Exception ex)

            {
                MessageBox.Show("Tipo de Erro: " + ex.Message, "Erro", MessageBoxButtons.OKCancel, MessageBoxIcon.Error);

            }
            return null;
        }

        public static List<Tarefas> GetPlanilhaTarefas()
        {
            try
            {
                XLWorkbook excel = AbrirExcel();
                var planilha = excel.Worksheet("Tarefas"); // Possivel Selected no ComboBox
                List<Tarefas> listaTarefa = new List<Tarefas>();

                int linha = 2;//Começa a leitura pela linha 2 para ignorar cabeçalho
                while (true)
                {
                    ClassesObjetos.Tarefas tarefa = new ClassesObjetos.Tarefas()
                    {
                        Id = planilha.Cell("A" + linha.ToString()).Value.ToString(),
                        Nome = planilha.Cell("B" + linha.ToString()).Value.ToString(),
                        Descricao = planilha.Cell("C" + linha.ToString()).Value.ToString(),
                        Prioridade = planilha.Cell("D" + linha.ToString()).Value.ToString(),
                        DataInicio = planilha.Cell("E" + linha.ToString()).Value.ToString(),
                        DataFim = planilha.Cell("F" + linha.ToString()).Value.ToString(),
                        Finalizado = planilha.Cell("G" + linha.ToString()).Value.ToString()
                    };

                    if (string.IsNullOrEmpty(tarefa.Id)) { break; }
                    else { listaTarefa.Add(tarefa); }

                    linha++;
                }
                planilha.Dispose();
                excel.Dispose();
                return listaTarefa;
            }
            catch (Exception ex)

            {
                MessageBox.Show("Tipo de Erro: " + ex.Message, "Erro", MessageBoxButtons.OKCancel, MessageBoxIcon.Error);

            }
            return null;
        }

        public static void AlterarMateria(Materias materia)
        {
            try
            {
                XLWorkbook excel = AbrirExcel();
                var planilha = excel.Worksheet("Materias de Estudos"); // Possivel Selected no ComboBox

                int linha = 2;//Começa a leitura pela linha 2 para ignorar cabeçalho
                while (true)
                {
                    if (planilha.Cell("A" + linha.ToString()).Value.ToString().Equals(materia.Id))
                    {
                        planilha.Cell("B" + linha.ToString()).Value = materia.Local;
                        planilha.Cell("C" + linha.ToString()).Value = materia.Materia;
                        planilha.Cell("D" + linha.ToString()).Value = materia.Conteudo;
                        planilha.Cell("E" + linha.ToString()).Value = materia.Prioridade;
                        planilha.Cell("F" + linha.ToString()).Value = materia.DataInicio;
                        planilha.Cell("G" + linha.ToString()).Value = materia.DataFim;
                        planilha.Cell("H" + linha.ToString()).Value = materia.Finalizado;
                        break;
                    }
                    linha++;
                }

                excel.Save();
                excel.Dispose();
            }
            catch (Exception ex)

            {
                MessageBox.Show("Tipo de Erro: " + ex.Message, "Erro", MessageBoxButtons.OKCancel, MessageBoxIcon.Error);

            }
        }

        public static void AlterarTarefas(Tarefas tarefa)
        {
            try
            {
                XLWorkbook excel = AbrirExcel();
                var planilha = excel.Worksheet("Tarefas"); // Possivel Selected no ComboBox

                int linha = 2;//Começa a leitura pela linha 2 para ignorar cabeçalho
                while (true)
                {
                    if (planilha.Cell("A" + linha.ToString()).Value.ToString().Equals(tarefa.Id))
                    {
                        planilha.Cell("B" + linha.ToString()).Value = tarefa.Nome;
                        planilha.Cell("C" + linha.ToString()).Value = tarefa.Descricao;
                        planilha.Cell("D" + linha.ToString()).Value = tarefa.Prioridade;
                        planilha.Cell("E" + linha.ToString()).Value = tarefa.DataInicio;
                        planilha.Cell("F" + linha.ToString()).Value = tarefa.DataFim;
                        planilha.Cell("G" + linha.ToString()).Value = tarefa.Finalizado;
                        break;
                    }
                    linha++;
                }

                excel.Save();
                excel.Dispose();
            }
            catch (Exception ex)

            {
                MessageBox.Show("Tipo de Erro: " + ex.Message, "Erro", MessageBoxButtons.OKCancel, MessageBoxIcon.Error);

            }
        }

        public static void IncluirMateria(Materias materia)
        {
            try
            {
                XLWorkbook excel = AbrirExcel();
                var planilha = excel.Worksheet("Materias de Estudos"); // Possivel Selected no ComboBox
                string linha = (Convert.ToInt32(materia.Id) + 1).ToString();
                planilha.Cell("A" + linha).Value = materia.Id;
                planilha.Cell("B" + linha).Value = materia.Local;
                planilha.Cell("C" + linha).Value = materia.Materia;
                planilha.Cell("D" + linha).Value = materia.Conteudo;
                planilha.Cell("E" + linha).Value = materia.Prioridade;
                planilha.Cell("F" + linha).Value = materia.DataInicio;
                planilha.Cell("G" + linha).Value = materia.DataFim;
                planilha.Cell("H" + linha).Value = materia.Finalizado;
                excel.Save();
                excel.Dispose();
            }
            catch (Exception ex)

            {
                MessageBox.Show("Tipo de Erro: " + ex.Message, "Erro", MessageBoxButtons.OKCancel, MessageBoxIcon.Error);

            }
        }

        public static void IncluirTarefas(Tarefas tarefa)
        {
            try
            {
                XLWorkbook excel = AbrirExcel();
                var planilha = excel.Worksheet("Tarefas"); // Possivel Selected no ComboBox
                string linha = (Convert.ToInt32(tarefa.Id) + 1).ToString();// Ignorar primeira linha
                planilha.Cell("A" + linha).Value = tarefa.Id;
                planilha.Cell("B" + linha).Value = tarefa.Nome;
                planilha.Cell("C" + linha).Value = tarefa.Descricao;
                planilha.Cell("D" + linha).Value = tarefa.Prioridade;
                planilha.Cell("E" + linha).Value = tarefa.DataInicio;
                planilha.Cell("F" + linha).Value = tarefa.DataFim;
                planilha.Cell("G" + linha).Value = tarefa.Finalizado;
                excel.Save();
                excel.Dispose();
            }
            catch (Exception ex)

            {
                MessageBox.Show("Tipo de Erro: " + ex.Message, "Erro", MessageBoxButtons.OKCancel, MessageBoxIcon.Error);

            }
        }
    }
}
