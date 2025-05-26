CREATE TABLE Products (
    Id INT PRIMARY KEY IDENTITY,
    Name NVARCHAR(100),
    Description NVARCHAR(255)
);

CREATE TABLE KnowledgeEntries (
    Id INT PRIMARY KEY IDENTITY,
    Question NVARCHAR(255),
    Answer NVARCHAR(255)
);