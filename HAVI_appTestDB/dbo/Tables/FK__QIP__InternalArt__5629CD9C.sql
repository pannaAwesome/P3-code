﻿ALTER TABLE [dbo].[QIP]  WITH CHECK ADD  CONSTRAINT [FK__QIP__InternalArt__5629CD9C] FOREIGN KEY([InternalArticleInformationID])
REFERENCES [dbo].[InternalArticleInformation] ([ID])
ON DELETE CASCADE
GO

ALTER TABLE [dbo].[QIP] CHECK CONSTRAINT [FK__QIP__InternalArt__5629CD9C]