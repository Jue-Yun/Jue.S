DO $EF$
BEGIN
    IF NOT EXISTS(SELECT 1 FROM pg_namespace WHERE nspname = 'bas') THEN
        CREATE SCHEMA bas;
    END IF;
END $EF$;

-- 文件存储
CREATE TABLE bas.file_storage (
    id character varying(36) NOT NULL,
    name varchar(512) NOT NULL,
    path varchar(512) NOT NULL,
    mime_type varchar(64) NOT NULL,
    size numeric(18,0) NOT NULL,
    md5 varchar(32) NOT NULL,
    creation_time timestamp with time zone NOT NULL,
    CONSTRAINT "PK_file_storage" PRIMARY KEY (id)
);
COMMENT ON COLUMN bas.file_storage.id IS '唯一Id';
COMMENT ON COLUMN bas.file_storage.name IS '文件名';
COMMENT ON COLUMN bas.file_storage.path IS '存储路径';
COMMENT ON COLUMN bas.file_storage.mime_type IS 'MIMI类型';
COMMENT ON COLUMN bas.file_storage.size IS '文件大小';
COMMENT ON COLUMN bas.file_storage.md5 IS 'MD5校验值';
COMMENT ON COLUMN bas.file_storage.creation_time IS '创建时间';

-- 用户信息
CREATE TABLE bas.user_info (
    id character varying(36) NOT NULL,
    name varchar(128) NOT NULL,
    pwd varchar(32) NOT NULL,
    nick varchar(128),
    CONSTRAINT "PK_user_info" PRIMARY KEY (id)
);
COMMENT ON COLUMN bas.user_info.id IS '唯一Id';
COMMENT ON COLUMN bas.user_info.name IS '名称';
COMMENT ON COLUMN bas.user_info.pwd IS '密码';
COMMENT ON COLUMN bas.user_info.nick IS '昵称';

-- 设置 用户信息 表的 名称 字段为索引字段
CREATE INDEX IDX_user_info_name ON bas.user_info (name);