ALTER TABLE [dbo].[Bundle]  WITH CHECK ADD  CONSTRAINT [FK__Bundle__Internal__3D5E1FD2] FOREIGN KEY([InternalArticleInformationID])
REFERENCES [dbo].[InternalArticleInformation] ([ID])
ON DELETE CASCADE
GO

ALTER TABLE [dbo].[Bundle] CHECK CONSTRAINT [FK__Bundle__Internal__3D5E1FD2]