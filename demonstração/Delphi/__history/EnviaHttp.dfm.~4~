object Form4: TForm4
  Left = 0
  Top = 0
  Caption = 'Nota Segura - Http'
  ClientHeight = 611
  ClientWidth = 579
  Color = clBtnFace
  Font.Charset = DEFAULT_CHARSET
  Font.Color = clWindowText
  Font.Height = -11
  Font.Name = 'Tahoma'
  Font.Style = []
  OldCreateOrder = False
  OnCreate = FormCreate
  PixelsPerInch = 96
  TextHeight = 13
  object edtUser: TLabeledEdit
    Left = 8
    Top = 16
    Width = 281
    Height = 21
    EditLabel.Width = 40
    EditLabel.Height = 13
    EditLabel.Caption = 'Usuario:'
    TabOrder = 0
  end
  object edtSenha: TLabeledEdit
    Left = 295
    Top = 16
    Width = 279
    Height = 21
    EditLabel.Width = 34
    EditLabel.Height = 13
    EditLabel.Caption = 'Senha:'
    PasswordChar = '*'
    TabOrder = 1
  end
  object edtToken: TLabeledEdit
    Left = 8
    Top = 56
    Width = 566
    Height = 21
    EditLabel.Width = 33
    EditLabel.Height = 13
    EditLabel.Caption = 'Token:'
    TabOrder = 2
  end
  object pgc1: TPageControl
    Left = 8
    Top = 83
    Width = 566
    Height = 520
    ActivePage = tsCadastroUser
    TabOrder = 3
    object tsEnviarXml: TTabSheet
      Caption = 'Envio de XML'
      ExplicitWidth = 513
      ExplicitHeight = 513
      object lbl1: TLabel
        Left = 3
        Top = 42
        Width = 23
        Height = 13
        Caption = 'XML:'
      end
      object lbl2: TLabel
        Left = 3
        Top = 265
        Width = 43
        Height = 13
        Caption = 'Retorno:'
      end
      object btnArquivo: TButton
        Left = 3
        Top = 3
        Width = 552
        Height = 33
        Caption = 'Escolher Arquivo'
        TabOrder = 0
        OnClick = btnArquivoClick
      end
      object mmoXML: TMemo
        Left = 3
        Top = 61
        Width = 552
        Height = 198
        ScrollBars = ssVertical
        TabOrder = 1
      end
      object mmoRetorno: TMemo
        Left = 3
        Top = 284
        Width = 552
        Height = 153
        ScrollBars = ssVertical
        TabOrder = 2
      end
      object btnEnviar: TButton
        Left = 3
        Top = 443
        Width = 552
        Height = 33
        Caption = 'Enviar XML'
        TabOrder = 3
        OnClick = btnEnviarClick
      end
    end
    object tsCadastroUser: TTabSheet
      Caption = 'Cadastro de Usuario'
      ImageIndex = 1
      ExplicitWidth = 559
      object Retorno: TLabel
        Left = 3
        Top = 167
        Width = 43
        Height = 13
        Caption = 'Retorno:'
      end
      object edtCorporateName: TLabeledEdit
        Left = 3
        Top = 24
        Width = 552
        Height = 21
        EditLabel.Width = 91
        EditLabel.Height = 13
        EditLabel.Caption = 'Nome Corporativo:'
        TabOrder = 0
      end
      object edtName: TLabeledEdit
        Left = 3
        Top = 64
        Width = 262
        Height = 21
        EditLabel.Width = 75
        EditLabel.Height = 13
        EditLabel.Caption = 'Nome Fantasia:'
        TabOrder = 1
      end
      object edtCpfCnpj: TLabeledEdit
        Left = 293
        Top = 64
        Width = 262
        Height = 21
        EditLabel.Width = 53
        EditLabel.Height = 13
        EditLabel.Caption = 'Cpf / Cnpj:'
        TabOrder = 2
      end
      object edtEmail: TLabeledEdit
        Left = 3
        Top = 104
        Width = 262
        Height = 21
        EditLabel.Width = 32
        EditLabel.Height = 13
        EditLabel.Caption = 'E-mail:'
        TabOrder = 3
      end
      object edtSenhaUser: TLabeledEdit
        Left = 293
        Top = 104
        Width = 262
        Height = 21
        EditLabel.Width = 34
        EditLabel.Height = 13
        EditLabel.Caption = 'Senha:'
        PasswordChar = '*'
        TabOrder = 4
      end
      object btnCadastrar: TButton
        Left = 3
        Top = 136
        Width = 552
        Height = 25
        Caption = 'Cadastrar Usuario'
        TabOrder = 5
        OnClick = btnCadastrarClick
      end
      object mmoCadastro: TMemo
        Left = 3
        Top = 184
        Width = 552
        Height = 305
        TabOrder = 6
      end
    end
  end
  object OpenDialog: TOpenDialog
    Left = 520
    Top = 88
  end
end
