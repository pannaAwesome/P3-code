ALTER TABLE [dbo].[Article]  WITH CHECK ADD  CONSTRAINT [FK__Article__Purchas__37A5467C] FOREIGN KEY([PurchaserID])
REFERENCES [dbo].[Purchaser] ([ID])
GO

ALTER TABLE [dbo].[Article] CHECK CONSTRAINT [FK__Article__Purchas__37A5467C]