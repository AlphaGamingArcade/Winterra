EXEC sp_rename 'accounts.gems', 'stellar', 'COLUMN';

create table ww_content (
    content_id INT IDENTITY(1, 1) PRIMARY KEY,
    content_type VARCHAR(20),
    content_title VARCHAR(250),
    content_data TEXT,
    content_published_at DATETIME
)

create table ww_preview (
    preview_id INT IDENTITY(1, 1) PRIMARY KEY,
    preview_type VARCHAR(20),
    preview_image TEXT
    preview_name VARCHAR(100)
)