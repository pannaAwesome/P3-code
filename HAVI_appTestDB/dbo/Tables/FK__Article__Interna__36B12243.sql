ALTER TABLE [dbo].[Article]  WITH CHECK ADD  CONSTRAINT [FK__Article__Interna__36B12243] FOREIGN KEY([InternalArticleInformationID])
REFERENCES [dbo].[InternalArticleInformation] ([ID])
ON DELETE CASCADE
GO

ALTER TABLE [dbo].[Article] CHECK CONSTRAINT [FK__Article__Interna__36B12243]