unit EnviaHttp;

interface

uses
  Winapi.Windows, Winapi.Messages, System.SysUtils, System.Variants, System.Classes, Vcl.Graphics,
  Vcl.Controls, Vcl.Forms, Vcl.Dialogs, Vcl.StdCtrls, Vcl.ExtCtrls, DateUtils, IdBaseComponent, IdComponent,
  IdTCPConnection, IdTCPClient, IdHTTP, IdIOHandler, IdIOHandlerSocket,
  IdIOHandlerStack, IdSSL, IdSSLOpenSSL, Vcl.ComCtrls, System.JSON, Data.DB,
  Vcl.Grids, Vcl.DBGrids, FireDAC.Stan.Intf, FireDAC.Stan.Option,
  FireDAC.Stan.Param, FireDAC.Stan.Error, FireDAC.DatS, FireDAC.Phys.Intf,
  FireDAC.DApt.Intf, FireDAC.Comp.DataSet, FireDAC.Comp.Client;

type
THackStringGrid = class(TStringGrid);
  TForm4 = class(TForm)
    edtUser: TLabeledEdit;
    edtToken: TLabeledEdit;
    pgc1: TPageControl;
    tsEnviarXml: TTabSheet;
    tsCadastroUser: TTabSheet;
    btnArquivo: TButton;
    mmoXML: TMemo;
    mmoRetorno: TMemo;
    btnEnviar: TButton;
    lbl1: TLabel;
    lbl2: TLabel;
    edtCorporateName: TLabeledEdit;
    edtName: TLabeledEdit;
    edtCpfCnpj: TLabeledEdit;
    edtEmail: TLabeledEdit;
    edtSenhaUser: TLabeledEdit;
    btnCadastrar: TButton;
    Retorno: TLabel;
    BuscaDestinadas: TTabSheet;
    RadioGroup1: TRadioGroup;
    Button1: TButton;
    edtSenha: TLabeledEdit;
    mmoCadastro: TMemo;
    OpenDialog: TOpenDialog;
    Label1: TLabel;
    mmoReturn: TMemo;
    DBGrid1: TDBGrid;
    FDMemTable1: TFDMemTable;
    DataSource1: TDataSource;
    FDMemTable1Key: TStringField;
    Label3: TLabel;
    DateTimePicker1: TDateTimePicker;
    DateTimePicker2: TDateTimePicker;
    BtnXML: TButton;
    Label4: TLabel;
    FDMemTable1number: TStringField;
    FDMemTable1serie: TStringField;
    FDMemTable1cnpjemissor: TStringField;
    FDMemTable1total: TStringField;
    rgDownload: TRadioGroup;
    rgModelo: TRadioGroup;
    CheckBox1: TCheckBox;
    procedure FormCreate(Sender: TObject);
    procedure btnEnviarClick(Sender: TObject);
    procedure btnArquivoClick(Sender: TObject);
    procedure btnCadastrarClick(Sender: TObject);
    procedure Button1Click(Sender: TObject);
    procedure BtnXMLClick(Sender: TObject);
  private
    { Private declarations }
      fHTTPClient : TIdHTTP;
      fIOHandlerSocketOpenSSL : TIdSSLIOHandlerSocketOpenSSL;
      fParamList : TStringList;
      property HTTPClient : TIdHTTP read fHTTPClient write fHTTPClient;
      property ParamList : TStringList read fParamList write fParamList;

  public

    { Public declarations }
  end;

var
  Form4: TForm4;

implementation

{$R *.dfm}

procedure TForm4.btnArquivoClick(Sender: TObject);
var
 _xml : TStringStream;
 _file : string;
begin
mmoXML.Clear;
_xml := TStringStream.Create(nil);
if OpenDialog.Execute then
begin
  _file := OpenDialog.FileName;
end;
 _xml.LoadFromFile(_file);
 mmoXML.Text := _xml.DataString;
 FreeAndNil(_xml);

end;

procedure TForm4.btnCadastrarClick(Sender: TObject);
var
 url: string;
begin
  mmoCadastro.Clear;
  ParamList.Clear;
  mmoCadastro.Text := 'Cadastrando Usuario..';
  Application.ProcessMessages;
  url := 'https://app.notasegura.com.br/api/users/?softwarehouse=' + edtToken.Text;
  HTTPClient.Request.Accept := 'application/xml';
  HTTPClient.Request.ContentType := 'application/x-www-form-urlencoded';
  HTTPClient.Request.BasicAuthentication := False;
  HTTPClient.Request.Username := EmptyStr;
  HTTPClient.Request.Password := EmptyStr;
  ParamList.Values['corporate_name'] := edtCorporateName.Text;
  ParamList.Values['name'] := edtName.Text;
  ParamList.Values['email'] := edtEmail.Text;
  ParamList.Values['password'] := edtSenhaUser.Text;
  if Length(edtCpfCnpj.Text) = 14 then
  begin
    ParamList.Values['cnpj'] := edtCpfCnpj.Text;
    mmoCadastro.Clear;
    mmoCadastro.Text :=   fHTTPClient.Post(url, ParamList);
  end
  else if  Length(edtCpfCnpj.Text) = 11 then
  begin
    ParamList.Values['cpf'] := edtCpfCnpj.Text;
    mmoCadastro.Clear;
    mmoCadastro.Text :=   fHTTPClient.Post(url, ParamList);
  end
  else
  begin
    ShowMessage('Cpf ou Cnpj invalido');
    mmoCadastro.Text := 'Verifique o Cpf/Cnpj e tente novamente.'
  end;
end;

procedure TForm4.btnEnviarClick(Sender: TObject);
var
 url : string;
  retorno: string;
begin
  mmoRetorno.Clear;
  ParamList.Clear;
  mmoRetorno.Text := 'Enviando nota..';
  Application.ProcessMessages;
  url := 'https://app.notasegura.com.br/api/invoices';
  HTTPClient.Request.Accept := 'application/xml';
  HTTPClient.Request.ContentType := 'application/x-www-form-urlencoded';
  HTTPClient.Request.BasicAuthentication := True;
  HTTPClient.Request.Username := edtUser.Text;
  HTTPClient.Request.Password := edtSenha.Text;
  ParamList.Values['token'] := edtToken.Text;
  ParamList.Values['xml'] := mmoXML.Text;
  mmoRetorno.Clear;
  mmoRetorno.Text :=   fHTTPClient.Post(url, ParamList);

end;

procedure TForm4.BtnXMLClick(Sender: TObject);
var
  chave: string;
  url: string;
  retornoJson: TJSonValue;

begin


  chave := DBGrid1.Columns[0].Field.Value;
  if Length(chave) = 44 then
  begin
    ParamList.Clear;
    Application.ProcessMessages;


    url := 'https://app.notasegura.com.br/api/invoices/export?token='+ edtToken.Text +'&invoice_key='+ chave +'&mode=XML';
    if CheckBox1.Checked = true then
    begin
      url := url + '&downloaded=true';
    end;

    HTTPClient.Request.Accept := 'application/xml';
    HTTPClient.Request.ContentType := 'application/x-www-form-urlencoded';
    HTTPClient.Request.BasicAuthentication := true;
    HTTPClient.Request.Username := edtUser.Text;
    HTTPClient.Request.Password := edtSenha.Text;

    retornoJson  := TJSonObject.ParseJSONValue(fHTTPClient.Get(url));
    mmoReturn.Text := retornoJson.GetValue<string>('data.xml');
  end;

end;

procedure TForm4.Button1Click(Sender: TObject);
var
 url: string;
 retorno: string;
 JSonValue: TJSonValue;
 jsonRaiz: TJSONObject;
 jsArray:  TJSONArray;
 jsonObject: TJSonValue;
 total: integer;
 count: integer;
 last_id: integer;
 nRow: integer;
 dataini: string;
 datafim: string;
 tipo: string;
 modelo: string;
 downloaded: string;
 i: integer;
 a: integer;
begin
  DBGrid1.DataSource.DataSet.Close;
  DBGrid1.DataSource.DataSet.Open;

  dataini := FormatDateTime('yyyy-mm-dd',DateTimePicker1.Date);
  datafim := FormatDateTime('yyyy-mm-dd',DateTimePicker2.Date);

  case RadioGroup1.ItemIndex of
    0: tipo := 'sent';
    1: tipo := 'received';
    2: tipo := 'other';

    else
      tipo := 'all';
  end;

  case rgDownload.ItemIndex of
      0: downloaded := 'downloaded';
      1: downloaded := 'not_downloaded';
    else
      downloaded := 'all';
  end;

  case rgModelo.ItemIndex of
       0: modelo := 'NFE';
       1: modelo := 'NFCE';
       2: modelo := 'CTE';
    else
      modelo := 'NFE';
  end;


  ParamList.Clear;
  Application.ProcessMessages;
  url := 'https://app.notasegura.com.br/api/invoices/keys?token=' + edtToken.Text + '&date_ini='+ dataini +'&date_end='+ datafim +'&mod='+ modelo +'&transaction=' + tipo + '&limit=30&last_id=' + '&filter='+ downloaded;
  HTTPClient.Request.Accept := 'application/xml';
  HTTPClient.Request.ContentType := 'application/x-www-form-urlencoded';
  HTTPClient.Request.BasicAuthentication := true;
  HTTPClient.Request.Username := edtUser.Text;
  HTTPClient.Request.Password := edtSenha.Text;
  retorno   := fHTTPClient.Get(url);

  JSonValue :=  TJSonObject.ParseJSONValue(retorno);

  total  := JsonValue.GetValue<integer>('data.total');
  count  := JsonValue.GetValue<integer>('data.count');
  last_id := JsonValue.GetValue<integer>('data.last_id');

  jsArray := JSonValue.GetValue<TJSONArray>('data.invoices') as TJSONArray;

  for i := 0 to jsArray .Count-1 do
   begin

      jsonObject := jsArray.Items[i] as TJSONObject;
      FDMemTable1.InsertRecord([jsonObject.GetValue<string>('key'),
                                jsonObject.GetValue<string>('serie'),
                                jsonObject.GetValue<string>('number'),
                                jsonObject.GetValue<string>('cnpj_emitter'),
                                jsonObject.GetValue<string>('value') ] );
   end;

   total := total - count;
   while total > 0 do
   begin


    ParamList.Clear;
    Application.ProcessMessages;
    url := 'https://app.notasegura.com.br/api/invoices/keys?token=' + edtToken.Text + '&date_ini='+ dataini +'&date_end='+ datafim +'&mod='+ modelo +'&transaction='+ tipo +'&limit=30&last_id=' + last_id.ToString +  '&filter=' + downloaded;
    HTTPClient.Request.Accept := 'application/xml';
    HTTPClient.Request.ContentType := 'application/x-www-form-urlencoded';
    HTTPClient.Request.BasicAuthentication := true;
    HTTPClient.Request.Username := edtUser.Text;
    HTTPClient.Request.Password := edtSenha.Text;

    retorno   := fHTTPClient.Get(url);
    JSonValue :=  TJSonObject.ParseJSONValue(retorno);

    count  := JsonValue.GetValue<integer>('data.count');
    last_id := JsonValue.GetValue<integer>('data.last_id');


    jsArray := JSonValue.GetValue<TJSONArray>('data.invoices') as TJSONArray;
    for a := 0 to jsArray .Count-1 do
    begin

      jsonObject := jsArray.Items[a] as TJSONObject;
      FDMemTable1.InsertRecord([jsonObject.GetValue<string>('key'),
                                jsonObject.GetValue<string>('serie'),
                                jsonObject.GetValue<string>('number'),
                                jsonObject.GetValue<string>('cnpj_emitter'),
                                jsonObject.GetValue<string>('value') ] );

    end;

    total := total - count;
   end;


end;


procedure TForm4.FormCreate(Sender: TObject);
begin
  fHTTPClient := TIdHTTP.Create(nil);
  fIOHandlerSocketOpenSSL := TIdSSLIOHandlerSocketOpenSSL.Create(nil);
  fParamList := TStringList.Create;
  fParamList.NameValueSeparator := '=';
  HTTPClient.ProtocolVersion := pv1_1;
  HTTPClient.Request.UserAgent := 'Mozilla/5.0 (Windows NT 6.1; WOW64; Trident/7.0; rv:11.0) like Gecko';
  fHTTPClient.IOHandler := fIOHandlerSocketOpenSSL;


end;

end.


