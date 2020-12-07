ALTER TABLE [dbo].[Purchaser]  WITH CHECK ADD  CONSTRAINT [FK__Purchaser__Profi__2A4B4B5E] FOREIGN KEY([ProfileID])
REFERENCES [dbo].[Profile] ([ID])
GO

ALTER TABLE [dbo].[Purchaser] CHECK CONSTRAINT [FK__Purchaser__Profi__2A4B4B5E]