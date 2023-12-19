//----- (00402880) --------------------------------------------------------
int __cdecl crypt-small-file_sub_403454(
        int a1,
        int a2,
        int *a3,
        char *a4,
        int a5,
        unsigned int a6,
        char *a7,
        char *a8,
        char *a9,
        char *a10,
        unsigned int a11)
{
  unsigned int v11; // edx
  int v12; // eax
  unsigned int v13; // edx
  int v15; // [esp+0h] [ebp-24Ch]
  char v16[16]; // [esp+1Ch] [ebp-230h] BYREF
  char v17[504]; // [esp+2Ch] [ebp-220h] BYREF
  unsigned int v18; // [esp+224h] [ebp-28h]
  char *v19; // [esp+228h] [ebp-24h]
  int v20; // [esp+22Ch] [ebp-20h]
  int v21; // [esp+230h] [ebp-1Ch]
  int v22; // [esp+234h] [ebp-18h]
  int v23; // [esp+238h] [ebp-14h]
  unsigned int v24; // [esp+240h] [ebp-Ch]
  unsigned int v25; // [esp+244h] [ebp-8h] BYREF
  int v26; // [esp+248h] [ebp-4h] BYREF

  v15 = 0;
  v25 = 0;
  v18 = 0;
  v19 = (char *)(a5 + 32);
  v26 = 32;
  v24 = 0;
  v20 = 0;
  sub_406D80(v16, a4, 0x10u);
  v18 = a6 - a6 % 0x10 - 16;
  v21 = GetFileAttribute_sub_406740();
  if ( v21 != -1 && GetFileAttribute_sub_406740() == -1 && a11 + 178 < 0x100000 )
  {
    if ( (v21 & 1) != 0 )
      SetFileAttributeW();
    v20 = CreateFileW_sub_406830();
    if ( v20 != -1 )
    {
      v22 = 0;
      v23 = 0;
      if ( SetFilePointerW() && (v23 || v22) )
      {
        SetFilePointerW();
        if ( CreateFileW_sub_406830() != -1 )
        {
          if ( GetLastError_sub_4069F0() != 183 )
          {
            sub_4034C0((int)v17, a3, a4, 1);
            do
            {
              v12 = ReadFile_sub_406820();
              if ( !v12 )
                break;
              if ( !v24 || v25 )
              {
                sub_406DD0(v12, v13, (char *)a5, 0, 0x20u);
                *(_DWORD *)(a5 + 4) = 2;
                *(_DWORD *)(a5 + 8) = 1098579468;
                if ( a10 )
                {
                  *(_DWORD *)(a5 + 24) = 32;
                  sub_406D80(v19, a10, a11);
                  v19 += a11;
                  v26 += a11;
                }
                sub_406D80(v19, a7, 6u);
                v19 += 6;
                sub_406D80(v19, a9, 0x14u);
                v19 += 20;
                sub_406D80(v19, v16, 0x10u);
                v19 += 16;
                sub_406D80(v19, (char *)&v25, 4u);
                v19 += 4;
                sub_406D80(v19, a8, 0x80u);
                v19 += 128;
                sub_406D80(v19, (char *)&v26, 4u);
                v19 += 4;
                if ( sub_406910() && v19 == (char *)a5 )
                {
                  sub_406930();
                  v15 = 1;
                }
                break;
              }
              if ( v24 < v18 )
                v25 = 16 - v24 % 0x10;
              sub_403960((int)v17, (char *)a5, (char *)a5, v25 + v24);
            }
            while ( sub_406910() && !(v25 + v24) );
          }
          CloseHandle_sub_406890();
        }
      }
      if ( v15 > 0 )
      {
        SetFilePointerW();
        sub_406930();
      }
      CloseHandle_sub_406890();
    }
    if ( v15 > 0 )
    {
      SetFileAttributeW();
      sub_4067E0();
    }
    sub_406DD0((unsigned int)v17, v11, v17, 0, 0x1F4u);
  }
  return v15;
}
// 402B0F: variable 'v13' is possibly undefined
// 402CEE: variable 'v11' is possibly undefined

int __cdecl sub_4034C0(int a1, int *a2, char *a3, int a4)
{
  int result; // eax
  int v5; // esi
  int v6; // esi
  int v7; // esi
  int v8; // esi
  int v9; // esi
  int v10; // esi
  int v11; // esi
  int v12; // esi
  unsigned int *v13; // [esp+8h] [ebp-Ch]
  unsigned int v14; // [esp+Ch] [ebp-8h]
  unsigned int v15; // [esp+Ch] [ebp-8h]
  unsigned int v16; // [esp+Ch] [ebp-8h]
  int v17; // [esp+10h] [ebp-4h]

  v17 = 0;
  result = a1 + 4;
  v13 = (unsigned int *)(a1 + 4);
  if ( a4 )
  {
    if ( a4 != 1 )
      return result;
    *(_WORD *)a1 = 14;
  }
  else
  {
    *(_WORD *)a1 = 10;
  }
  sub_406D80((char *)(a1 + 484), a3, 0x10u);
  v5 = sub_4034A0(*a2, 8) & 0xFF00FF;
  *v13 = sub_4034B0(*a2, 8) & 0xFF00FF00 | v5;
  v6 = sub_4034A0(a2[1], 8) & 0xFF00FF;
  *(_DWORD *)(a1 + 8) = sub_4034B0(a2[1], 8) & 0xFF00FF00 | v6;
  v7 = sub_4034A0(a2[2], 8) & 0xFF00FF;
  *(_DWORD *)(a1 + 12) = sub_4034B0(a2[2], 8) & 0xFF00FF00 | v7;
  v8 = sub_4034A0(a2[3], 8) & 0xFF00FF;
  *(_DWORD *)(a1 + 16) = sub_4034B0(a2[3], 8) & 0xFF00FF00 | v8;
  if ( a4 )
  {
    v9 = sub_4034A0(a2[4], 8) & 0xFF00FF;
    *(_DWORD *)(a1 + 20) = sub_4034B0(a2[4], 8) & 0xFF00FF00 | v9;
    v10 = sub_4034A0(a2[5], 8) & 0xFF00FF;
    *(_DWORD *)(a1 + 24) = sub_4034B0(a2[5], 8) & 0xFF00FF00 | v10;
    v11 = sub_4034A0(a2[6], 8) & 0xFF00FF;
    *(_DWORD *)(a1 + 28) = sub_4034B0(a2[6], 8) & 0xFF00FF00 | v11;
    v12 = sub_4034A0(a2[7], 8) & 0xFF00FF;
    *(_DWORD *)(a1 + 32) = sub_4034B0(a2[7], 8) & 0xFF00FF00 | v12;
    while ( 1 )
    {
      v15 = v13[7];
      v13[8] = dword_40D4B8[v17] ^ (unsigned __int8)dword_40B7B8[HIBYTE(v15)] ^ dword_40B3B8[(unsigned __int8)v15] & 0xFF00 ^ dword_40BFB8[BYTE1(v15)] & 0xFF0000 ^ *v13 ^ dword_40BBB8[BYTE2(v15)] & 0xFF000000;
      v13[9] = v13[8] ^ v13[1];
      v13[10] = v13[9] ^ v13[2];
      result = v13[10] ^ v13[3];
      v13[11] = result;
      if ( ++v17 == 7 )
        break;
      v16 = v13[11];
      v13[12] = (unsigned __int8)dword_40B7B8[(unsigned __int8)v16] ^ dword_40B3B8[BYTE1(v16)] & 0xFF00 ^ dword_40BFB8[BYTE2(v16)] & 0xFF0000 ^ v13[4] ^ dword_40BBB8[HIBYTE(v16)] & 0xFF000000;
      v13[13] = v13[12] ^ v13[5];
      v13[14] = v13[13] ^ v13[6];
      v13[15] = v13[14] ^ v13[7];
      v13 += 8;
    }
  }
  else
  {
    while ( 1 )
    {
      v14 = v13[3];
      v13[4] = dword_40D4B8[v17] ^ (unsigned __int8)dword_40B7B8[HIBYTE(v14)] ^ dword_40B3B8[(unsigned __int8)v14] & 0xFF00 ^ dword_40BFB8[BYTE1(v14)] & 0xFF0000 ^ *v13 ^ dword_40BBB8[BYTE2(v14)] & 0xFF000000;
      v13[5] = v13[4] ^ v13[1];
      v13[6] = v13[5] ^ v13[2];
      result = (int)v13;
      v13[7] = v13[6] ^ v13[3];
      if ( ++v17 == 10 )
        break;
      v13 += 4;
    }
  }
  return result;
}

//----- (00406DD0) --------------------------------------------------------
char *__usercall sub_406DD0@<eax>(unsigned int a1@<eax>, unsigned int a2@<edx>, char *a3, char a4, unsigned int a5)
{
  int v5; // eax
  unsigned __int64 v6; // rt0

  if ( a5 )
  {
    LOBYTE(a1) = a4;
    BYTE1(a1) = a4;
    HIDWORD(v6) = a1;
    LODWORD(v6) = __PAIR64__(a1, a2) >> 16;
    v5 = v6 >> 16;
    memset32(a3, v5, a5 >> 2);
    memset(&a3[4 * (a5 >> 2)], v5, a5 & 3);
  }
  return a3;
}

//----- (00406D80) --------------------------------------------------------
char *__cdecl sub_406D80(char *a1, char *a2, unsigned int a3)
{
  int v3; // edx
  char *v4; // edi
  char *v5; // esi

  v3 = a3;
  if ( a2 != a1 && a3 )
  {
    if ( a2 < a1 && &a2[a3 - 1] >= a1 )
    {
      v5 = &a2[a3 - 1];
      v4 = &a1[a3 - 1];
    }
    else
    {
      v3 = a3 & 3;
      qmemcpy(a1, a2, 4 * (a3 >> 2));
      v5 = &a2[4 * (a3 >> 2)];
      v4 = &a1[4 * (a3 >> 2)];
    }
    qmemcpy(v4, v5, v3);
  }
  return a1;
}

//----- (004034A0) --------------------------------------------------------
int __cdecl sub_4034A0(int a1, char a2)
{
  return __ROL4__(a1, a2);
}

//----- (004034B0) --------------------------------------------------------
int __cdecl sub_4034B0(int a1, char a2)
{
  return __ROR4__(a1, a2);
}