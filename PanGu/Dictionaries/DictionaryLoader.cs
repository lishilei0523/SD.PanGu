using System;
using System.Threading;
using PanGu.Enums;
using PanGu.Framework;
using File = System.IO.File;

namespace PanGu.Dictionaries
{
    class DictionaryLoader
    {
        public static Lock Lock = new Lock();

        private readonly string _dictionaryDir;

        public string DictionaryDir
        {
            get
            {
                return this._dictionaryDir;
            }
        }

        private DateTime _MainDictLastTime;
        private DateTime _ChsSingleLastTime;
        private DateTime _ChsName1LastTime;
        private DateTime _ChsName2LastTime;
        private DateTime _StopWordLastTime;
        private DateTime _SynonymLastTime;
        private DateTime _WildcardLastTime;

        private Thread _Thread;

        private DateTime GetLastTime(string fileName)
        {
            return File.GetLastWriteTime(this.DictionaryDir + fileName);
        }

        public DictionaryLoader(string dictDir)
        {
            this._dictionaryDir = Path.AppendDivision(dictDir, '\\');
            this._MainDictLastTime = this.GetLastTime(Constants.DictionaryFileName);
            this._ChsSingleLastTime = this.GetLastTime(Constants.ChsSingleNameFileName);
            this._ChsName1LastTime = this.GetLastTime(Constants.ChsDoubleName1FileName);
            this._ChsName2LastTime = this.GetLastTime(Constants.ChsDoubleName2FileName);
            this._StopWordLastTime = this.GetLastTime(Constants.StopwordFileName);
            this._SynonymLastTime = this.GetLastTime(Constants.SynonymFileName);
            this._WildcardLastTime = this.GetLastTime(Constants.WildcardFileName);

            this._Thread = new Thread(this.MonitorDictionary);
            this._Thread.IsBackground = true;
            this._Thread.Start();
        }

        private bool MainDictChanged()
        {
            try
            {
                return this._MainDictLastTime != this.GetLastTime(Constants.DictionaryFileName);
            }
            catch
            {
                return false;
            }
        }

        private bool ChsNameChanged()
        {
            try
            {
                return (this._ChsSingleLastTime != this.GetLastTime(Constants.ChsSingleNameFileName) ||
                    this._ChsName1LastTime != this.GetLastTime(Constants.ChsDoubleName1FileName) ||
                    this._ChsName2LastTime != this.GetLastTime(Constants.ChsDoubleName2FileName));
            }
            catch
            {
                return false;
            }
        }

        private bool StopWordChanged()
        {
            try
            {
                return this._StopWordLastTime != this.GetLastTime(Constants.StopwordFileName);
            }
            catch
            {
                return false;
            }
        }

        private bool SynonymChanged()
        {
            try
            {
                return this._SynonymLastTime != this.GetLastTime(Constants.SynonymFileName);
            }
            catch
            {
                return false;
            }
        }

        private bool WildcardChanged()
        {
            try
            {
                return this._WildcardLastTime != this.GetLastTime(Constants.WildcardFileName);
            }
            catch
            {
                return false;
            }

        }


        private void MonitorDictionary()
        {
            while (true)
            {
                Thread.Sleep(30000);

                try
                {
                    if (this.MainDictChanged())
                    {
                        try
                        {
                            Lock.Enter(Mode.Mutex);
                            Segment._WordDictionary.Load(this._dictionaryDir + Constants.DictionaryFileName);
                            this._MainDictLastTime = this.GetLastTime(Constants.DictionaryFileName);
                        }
                        finally
                        {
                            Lock.Leave();
                        }
                    }

                    if (this.ChsNameChanged())
                    {
                        try
                        {
                            Lock.Enter(Mode.Mutex);

                            Segment._ChsName.LoadChsName(this._dictionaryDir);
                            this._ChsSingleLastTime = this.GetLastTime(Constants.ChsSingleNameFileName);
                            this._ChsName1LastTime = this.GetLastTime(Constants.ChsDoubleName1FileName);
                            this._ChsName2LastTime = this.GetLastTime(Constants.ChsDoubleName2FileName);
                        }
                        finally
                        {
                            Lock.Leave();
                        }
                    }

                    if (this.StopWordChanged())
                    {
                        try
                        {
                            Lock.Enter(Mode.Mutex);

                            Segment._StopWord.LoadStopwordsDict(this._dictionaryDir + Constants.StopwordFileName);
                            this._StopWordLastTime = this.GetLastTime(Constants.StopwordFileName);
                        }
                        finally
                        {
                            Lock.Leave();
                        }
                    }

                    if (Segment._Synonym.Inited)
                    {
                        if (this.SynonymChanged())
                        {
                            try
                            {
                                Lock.Enter(Mode.Mutex);

                                Segment._Synonym.Load(this._dictionaryDir);
                                this._SynonymLastTime = this.GetLastTime(Constants.SynonymFileName);
                            }
                            finally
                            {
                                Lock.Leave();
                            }
                        }
                    }

                    if (Segment._Wildcard.Inited)
                    {
                        if (this.WildcardChanged())
                        {
                            try
                            {
                                Segment._Wildcard.Load(this._dictionaryDir);
                                this._WildcardLastTime = this.GetLastTime(Constants.WildcardFileName);
                            }
                            finally
                            {
                            }
                        }
                    }

                }
                catch
                {
                }


            }
        }
    }
}
