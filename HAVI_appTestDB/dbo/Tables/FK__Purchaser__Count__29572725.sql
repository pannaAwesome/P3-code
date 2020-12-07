ALTER TABLE [dbo].[Purchaser]  WITH CHECK ADD  CONSTRAINT [FK__Purchaser__Count__29572725] FOREIGN KEY([CountryID])
REFERENCES [dbo].[Country] ([ID])
GO

ALTER TABLE [dbo].[Purchaser] CHECK CONSTRAINT [FK__Purchaser__Count__29572725]