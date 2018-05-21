﻿using SQLite.Net.Interop;

namespace SQLiteD
{
    public interface IConfig
    {
        string DirectorioDB { get; }
        ISQLitePlatform Plataforma { get; }
    }
}
