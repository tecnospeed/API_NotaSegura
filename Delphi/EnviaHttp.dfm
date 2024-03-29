object Form4: TForm4
  Left = 0
  Top = 0
  Caption = 'Nota Segura - Http'
  ClientHeight = 611
  ClientWidth = 577
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
    ParentCustomHint = False
    ActivePage = BuscaDestinadas
    BiDiMode = bdLeftToRight
    DoubleBuffered = False
    Font.Charset = DEFAULT_CHARSET
    Font.Color = clWindowText
    Font.Height = -11
    Font.Name = 'Tahoma'
    Font.Style = []
    ParentBiDiMode = False
    ParentDoubleBuffered = False
    ParentFont = False
    ParentShowHint = False
    ShowHint = False
    TabOrder = 3
    object tsEnviarXml: TTabSheet
      Caption = 'Envio de XML'
      object lbl1: TLabel
        Left = 532
        Top = 42
        Width = 23
        Height = 13
        Caption = 'XML:'
      end
      object lbl2: TLabel
        Left = 512
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
        Left = 293
        Top = 64
        Width = 262
        Height = 21
        EditLabel.Width = 75
        EditLabel.Height = 13
        EditLabel.Caption = 'Nome Fantasia:'
        TabOrder = 1
      end
      object edtCpfCnpj: TLabeledEdit
        Left = 3
        Top = 64
        Width = 262
        Height = 21
        EditLabel.Width = 53
        EditLabel.Height = 13
        EditLabel.Caption = 'Cpf / Cnpj:'
        TabOrder = 2
      end
      object edtEmail: TLabeledEdit
        Left = 293
        Top = 104
        Width = 262
        Height = 21
        EditLabel.Width = 32
        EditLabel.Height = 13
        EditLabel.Caption = 'E-mail:'
        TabOrder = 3
      end
      object edtSenhaUser: TLabeledEdit
        Left = 3
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
    object BuscaDestinadas: TTabSheet
      Caption = 'Busca de notas destinadas'
      ImageIndex = 2
      object Label1: TLabel
        Left = 3
        Top = 349
        Width = 71
        Height = 13
        Caption = 'XML RETORNO'
      end
      object Label3: TLabel
        Left = 124
        Top = 83
        Width = 46
        Height = 13
        Caption = 'Data final'
      end
      object Label4: TLabel
        Left = 3
        Top = 83
        Width = 51
        Height = 13
        Caption = 'Data inicial'
      end
      object RadioGroup1: TRadioGroup
        Left = 3
        Top = 3
        Width = 555
        Height = 38
        Caption = 'Notas'
        Columns = 7
        Items.Strings = (
          'Emitidas'
          'Recebidas'
          'Outras'
          'Todas')
        TabOrder = 0
      end
      object Button1: TButton
        Left = 3
        Top = 129
        Width = 559
        Height = 25
        Caption = 'Consultar Notas'
        TabOrder = 1
        OnClick = Button1Click
      end
      object mmoReturn: TMemo
        Left = 3
        Top = 368
        Width = 552
        Height = 121
        TabOrder = 2
      end
      object DBGrid1: TDBGrid
        Left = 3
        Top = 160
        Width = 552
        Height = 152
        DataSource = DataSource1
        TabOrder = 3
        TitleFont.Charset = DEFAULT_CHARSET
        TitleFont.Color = clWindowText
        TitleFont.Height = -11
        TitleFont.Name = 'Tahoma'
        TitleFont.Style = []
      end
      object DateTimePicker1: TDateTimePicker
        Left = 3
        Top = 102
        Width = 106
        Height = 21
        Date = 43690.000000000000000000
        Time = 0.637081064814992700
        TabOrder = 4
      end
      object DateTimePicker2: TDateTimePicker
        Left = 124
        Top = 102
        Width = 113
        Height = 21
        Date = 43690.000000000000000000
        Time = 0.637464027779060400
        TabOrder = 5
      end
      object BtnXML: TButton
        Left = 3
        Top = 318
        Width = 552
        Height = 25
        Caption = 'Buscar XML da nota selecionada'
        TabOrder = 6
        OnClick = BtnXMLClick
      end
      object rgDownload: TRadioGroup
        Left = 3
        Top = 47
        Width = 274
        Height = 33
        Caption = 'Baixadas / N'#227'o baixadas'
        Columns = 3
        Items.Strings = (
          'Baixada'
          'N'#227'o baixada'
          'Todas')
        TabOrder = 7
      end
      object rgModelo: TRadioGroup
        Left = 283
        Top = 47
        Width = 272
        Height = 33
        Caption = 'Modelo de notas'
        Columns = 3
        Items.Strings = (
          'NFE'
          'NFCE'
          'CTE')
        TabOrder = 8
      end
    end
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
  object CheckBox1: TCheckBox
    Left = 328
    Top = 214
    Width = 241
    Height = 16
    Caption = 'Ao baixar o xml marcar como feito download ?'
    TabOrder = 4
  end
  object OpenDialog: TOpenDialog
    Left = 471
    Top = 104
  end
  object FDMemTable1: TFDMemTable
    FieldDefs = <>
    IndexDefs = <>
    FetchOptions.AssignedValues = [evMode]
    FetchOptions.Mode = fmAll
    ResourceOptions.AssignedValues = [rvSilentMode]
    ResourceOptions.SilentMode = True
    UpdateOptions.AssignedValues = [uvCheckRequired, uvAutoCommitUpdates]
    UpdateOptions.CheckRequired = False
    UpdateOptions.AutoCommitUpdates = True
    StoreDefs = True
    Left = 472
    Top = 272
    object FDMemTable1Key: TStringField
      DisplayWidth = 44
      FieldName = 'Key'
      Size = 52
    end
    object FDMemTable1serie: TStringField
      FieldName = 'serie'
      Size = 5
    end
    object FDMemTable1number: TStringField
      FieldName = 'number'
      Size = 10
    end
    object FDMemTable1cnpjemissor: TStringField
      FieldName = 'cnpj emissor'
      Size = 15
    end
    object FDMemTable1total: TStringField
      FieldName = 'total'
      Size = 5
    end
  end
  object DataSource1: TDataSource
    DataSet = FDMemTable1
    Left = 520
    Top = 272
  end
end
