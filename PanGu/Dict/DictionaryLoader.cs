using PanGu.Enums;
using PanGu.Framework;
using System;
using System.Threading;
using File = System.IO.File;

namespace PanGu.Dict
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
            _MainDictLastTime = GetLastTime("Dict.dct");
            _ChsSingleLastTime = GetLastTime(ChsName.ChsSingleNameFileName);
            _ChsName1LastTime = GetLastTime(ChsName.ChsDoubleName1FileName);
            _ChsName2LastTime = GetLastTime(ChsName.ChsDoubleName2FileName);
            _StopWordLastTime = GetLastTime("Stopword.txt");
            _SynonymLastTime = GetLastTime(Synonym.SynonymFileName);
            _WildcardLastTime = GetLastTime(Wildcard.WildcardFileName);

            _Thread = new Thread(MonitorDictionary);
            _Thread.IsBackground = true;
            _Thread.Start();
        }

        private bool MainDictChanged()
        {
            try
            {
                return _MainDictLastTime != GetLastTime("Dict.dct");
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
                return (_ChsSingleLastTime != GetLastTime(ChsName.ChsSingleNameFileName) ||
                    _ChsName1LastTime != GetLastTime(ChsName.ChsDoubleName1FileName) ||
                    _ChsName2LastTime != GetLastTime(ChsName.ChsDoubleName2FileName));
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
                return _StopWordLastTime != GetLastTime("Stopword.txt");
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
                return _SynonymLastTime != GetLastTime(Synonym.SynonymFileName);
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
                return _WildcardLastTime != GetLastTime(Wildcard.WildcardFileName);
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
                    if (MainDictChanged())
                    {
                        try
                        {
                            Lock.Enter(Mode.Mutex);
                            Segment._WordDictionary.Load(this._dictionaryDir + "Dict.dct");
                            _MainDictLastTime = GetLastTime("Dict.dct");
                        }
                        finally
                        {
                            Lock.Leave();
                        }
                    }

                    if (ChsNameChanged())
                    {
                        try
                        {
                            Lock.Enter(Mode.Mutex);

                            Segment._ChsName.LoadChsName(this._dictionaryDir);
                            _ChsSingleLastTime = GetLastTime(ChsName.ChsSingleNameFileName);
                            _ChsName1LastTime = GetLastTime(ChsName.ChsDoubleName1FileName);
                            _ChsName2LastTime = GetLastTime(ChsName.ChsDoubleName2FileName);
                        }
                        finally
                        {
                            Lock.Leave();
                        }
                    }

                    if (StopWordChanged())
                    {
                        try
                        {
                            Lock.Enter(Mode.Mutex);

                            Segment._StopWord.LoadStopwordsDict(this._dictionaryDir + "Stopword.txt");
                            _StopWordLastTime = GetLastTime("Stopword.txt");
                        }
                        finally
                        {
                            Lock.Leave();
                        }
                    }

                    if (Segment._Synonym.Inited)
                    {
                        if (SynonymChanged())
                        {
                            try
                            {
                                Lock.Enter(Mode.Mutex);

                                Segment._Synonym.Load(this._dictionaryDir);
                                _SynonymLastTime = GetLastTime(Synonym.SynonymFileName);
                            }
                            finally
                            {
                                Lock.Leave();
                            }
                        }
                    }

                    if (Segment._Wildcard.Inited)
                    {
                        if (WildcardChanged())
                        {
                            try
                            {
                                Segment._Wildcard.Load(this._dictionaryDir);
                                _WildcardLastTime = GetLastTime(Wildcard.WildcardFileName);
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
