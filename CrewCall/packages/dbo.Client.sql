CREATE TABLE [dbo].[Client] (
    [ClientId]  INT            IDENTITY (1, 1) NOT NULL,
    [Company]   NVARCHAR (MAX) NOT NULL,
    CONSTRAINT [PK_dbo.Client] PRIMARY KEY CLUSTERED ([ClientId] ASC)
);

