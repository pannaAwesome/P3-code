ALTER TABLE [dbo].[SAPPlant]  WITH CHECK ADD  CONSTRAINT [FK__SAPPlant__Intern__5CD6CB2B] FOREIGN KEY([InternalArticleInformationID])
REFERENCES [dbo].[InternalArticleInformation] ([ID])
ON DELETE CASCADE
GO

ALTER TABLE [dbo].[SAPPlant] CHECK CONSTRAINT [FK__SAPPlant__Intern__5CD6CB2B]