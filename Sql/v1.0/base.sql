-- 创建 bas SCHEMA
IF SCHEMA_ID(N'bas') IS NULL EXEC(N'CREATE SCHEMA [bas];');
GO

-- 创建用户信息表
CREATE TABLE [bas].[user_info] (
    [id] varchar(32) NOT NULL,
    [name] varchar(128) NULL,
    [pwd] varchar(32) NULL,
    [nick] varchar(128) NULL,
    CONSTRAINT [PK_user_info] PRIMARY KEY ([id])
);
GO

-- 创建唯一索引
CREATE UNIQUE INDEX [IX_bas_user_info_name] ON [bas].[user_info] ([name]);
GO

-- 创建索引
--CREATE INDEX [IX_bas_user_info_nick] ON [bas].[user_info] ([nick]);
--GO

