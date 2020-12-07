ALTER TABLE [dbo].[OtherCostsForArticle]  WITH CHECK ADD  CONSTRAINT [FK__OtherCost__Artic__5070F446] FOREIGN KEY([ArticleInformationID])
REFERENCES [dbo].[ArticleInformation] ([ID])
ON DELETE CASCADE
GO

ALTER TABLE [dbo].[OtherCostsForArticle] CHECK CONSTRAINT [FK__OtherCost__Artic__5070F446]