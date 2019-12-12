CREATE TABLE [dbo].[TaiKhoan] (
    [TenTaiKhoan_ID] NVARCHAR (128) NOT NULL,
    [MatKhau]        NVARCHAR (MAX) NOT NULL,
    [MaNV_ID]        NVARCHAR (128) NOT NULL,
    CONSTRAINT [PK_dbo.TaiKhoan] PRIMARY KEY CLUSTERED ([TenTaiKhoan_ID] ASC),
    CONSTRAINT [FK_dbo.TaiKhoan_dbo.NhanVien_MaNV_ID] FOREIGN KEY ([MaNV_ID]) REFERENCES [dbo].[NhanVien] ([MaNV_ID])
);


GO
CREATE NONCLUSTERED INDEX [IX_MaNV_ID]
    ON [dbo].[TaiKhoan]([MaNV_ID] ASC);

