EXEC sp_rename 'accounts.gems', 'stellar', 'COLUMN';

create table p2egames_content (
    content_id INT IDENTITY(1, 1) PRIMARY KEY,
    content_type VARCHAR(20),
    content_title VARCHAR(250),
    content_data TEXT,
    content_published_at DATETIME
)