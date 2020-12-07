ALTER TABLE [dbo].[Article]  WITH CHECK ADD  CONSTRAINT [FK__Article__Article__34C8D9D1] FOREIGN KEY([ArticleInformationID])
REFERENCES [dbo].[ArticleInformation] ([ID])
ON DELETE CASCADE
GO

ALTER TABLE [dbo].[Article] CHECK CONSTRAINT [FK__Article__Article__34C8D9D1]