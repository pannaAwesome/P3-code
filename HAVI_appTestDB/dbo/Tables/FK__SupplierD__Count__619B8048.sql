ALTER TABLE [dbo].[SupplierDeliveryUnit]  WITH CHECK ADD  CONSTRAINT [FK__SupplierD__Count__619B8048] FOREIGN KEY([CountryID])
REFERENCES [dbo].[Country] ([ID])
ON DELETE CASCADE
GO

ALTER TABLE [dbo].[SupplierDeliveryUnit] CHECK CONSTRAINT [FK__SupplierD__Count__619B8048]