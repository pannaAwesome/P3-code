ALTER TABLE [dbo].[VailedForCustomer]  WITH CHECK ADD  CONSTRAINT [FK__VailedFor__Count__6477ECF3] FOREIGN KEY([CountryID])
REFERENCES [dbo].[Country] ([ID])
ON DELETE CASCADE
GO

ALTER TABLE [dbo].[VailedForCustomer] CHECK CONSTRAINT [FK__VailedFor__Count__6477ECF3]