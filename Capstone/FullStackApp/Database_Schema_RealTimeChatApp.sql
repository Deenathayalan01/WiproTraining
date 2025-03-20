-- Step 1: Create the Database
CREATE DATABASE ChatAppDB;

-- Step 2: Use the Database
USE ChatAppDB;


-- Step 3: Create the Users Table
CREATE TABLE users (
    id UNIQUEIDENTIFIER PRIMARY KEY DEFAULT NEWID(),
    username VARCHAR(50) UNIQUE NOT NULL,
    email VARCHAR(100) UNIQUE NOT NULL,
    password_hash TEXT NOT NULL,
    profile_picture TEXT,
    created_at DATETIME DEFAULT GETDATE()
);


-- Step 4: Create the Chats Table
CREATE TABLE chats (
    id UNIQUEIDENTIFIER PRIMARY KEY DEFAULT NEWID(),
    chat_name VARCHAR(100),
    is_group BIT DEFAULT 0,
    created_at DATETIME DEFAULT GETDATE()
);


-- Step 5: Create the Chat Members Table
CREATE TABLE chat_members (
    id UNIQUEIDENTIFIER PRIMARY KEY DEFAULT NEWID(),
    chat_id UNIQUEIDENTIFIER REFERENCES chats(id) ON DELETE CASCADE,
    user_id UNIQUEIDENTIFIER REFERENCES users(id) ON DELETE CASCADE,
    joined_at DATETIME DEFAULT GETDATE()
);


-- Step 6: Create the Messages Table
CREATE TABLE messages (
    id UNIQUEIDENTIFIER PRIMARY KEY DEFAULT NEWID(),
    chat_id UNIQUEIDENTIFIER REFERENCES chats(id) ON DELETE CASCADE,
    sender_id UNIQUEIDENTIFIER REFERENCES users(id) ON DELETE CASCADE,
    message_text TEXT,
    media_url TEXT,
    media_type VARCHAR(50),
    view_once BIT DEFAULT 0,
    viewed BIT DEFAULT 0,
    created_at DATETIME DEFAULT GETDATE()
);


-- Step 7: Create the Message Views Table
CREATE TABLE message_views (
    id UNIQUEIDENTIFIER PRIMARY KEY DEFAULT NEWID(),
    message_id UNIQUEIDENTIFIER REFERENCES messages(id) ON DELETE NO ACTION,
    viewer_id UNIQUEIDENTIFIER REFERENCES users(id) ON DELETE NO ACTION,
    viewed_at DATETIME DEFAULT GETDATE()
);




