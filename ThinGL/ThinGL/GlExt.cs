// GL_GLEXT_VERSION 20131018

namespace ThinGL
{
  public class GlExt
  {
    #region GL_VERSION_1_2
    public const uint GL_UNSIGNED_BYTE_3_3_2 = 0x8032;
    public const uint GL_UNSIGNED_SHORT_4_4_4_4 = 0x8033;
    public const uint GL_UNSIGNED_SHORT_5_5_5_1 = 0x8034;
    public const uint GL_UNSIGNED_INT_8_8_8_8 = 0x8035;
    public const uint GL_UNSIGNED_INT_10_10_10_2 = 0x8036;
    public const uint GL_TEXTURE_BINDING_3D = 0x806A;
    public const uint GL_PACK_SKIP_IMAGES = 0x806B;
    public const uint GL_PACK_IMAGE_HEIGHT = 0x806C;
    public const uint GL_UNPACK_SKIP_IMAGES = 0x806D;
    public const uint GL_UNPACK_IMAGE_HEIGHT = 0x806E;
    public const uint GL_TEXTURE_3D = 0x806F;
    public const uint GL_PROXY_TEXTURE_3D = 0x8070;
    public const uint GL_TEXTURE_DEPTH = 0x8071;
    public const uint GL_TEXTURE_WRAP_R = 0x8072;
    public const uint GL_MAX_3D_TEXTURE_SIZE = 0x8073;
    public const uint GL_UNSIGNED_BYTE_2_3_3_REV = 0x8362;
    public const uint GL_UNSIGNED_SHORT_5_6_5 = 0x8363;
    public const uint GL_UNSIGNED_SHORT_5_6_5_REV = 0x8364;
    public const uint GL_UNSIGNED_SHORT_4_4_4_4_REV = 0x8365;
    public const uint GL_UNSIGNED_SHORT_1_5_5_5_REV = 0x8366;
    public const uint GL_UNSIGNED_INT_8_8_8_8_REV = 0x8367;
    public const uint GL_UNSIGNED_INT_2_10_10_10_REV = 0x8368;
    public const uint GL_BGR = 0x80E0;
    public const uint GL_BGRA = 0x80E1;
    public const uint GL_MAX_ELEMENTS_VERTICES = 0x80E8;
    public const uint GL_MAX_ELEMENTS_INDICES = 0x80E9;
    public const uint GL_CLAMP_TO_EDGE = 0x812F;
    public const uint GL_TEXTURE_MIN_LOD = 0x813A;
    public const uint GL_TEXTURE_MAX_LOD = 0x813B;
    public const uint GL_TEXTURE_BASE_LEVEL = 0x813C;
    public const uint GL_TEXTURE_MAX_LEVEL = 0x813D;
    public const uint GL_SMOOTH_POINT_SIZE_RANGE = 0x0B12;
    public const uint GL_SMOOTH_POINT_SIZE_GRANULARITY = 0x0B13;
    public const uint GL_SMOOTH_LINE_WIDTH_RANGE = 0x0B22;
    public const uint GL_SMOOTH_LINE_WIDTH_GRANULARITY = 0x0B23;
    public const uint GL_ALIASED_LINE_WIDTH_RANGE = 0x846E;
    public const uint GL_RESCALE_NORMAL = 0x803A;
    public const uint GL_LIGHT_MODEL_COLOR_CONTROL = 0x81F8;
    public const uint GL_SINGLE_COLOR = 0x81F9;
    public const uint GL_SEPARATE_SPECULAR_COLOR = 0x81FA;
    public const uint GL_ALIASED_POINT_SIZE_RANGE = 0x846D;
    
    private delegate void PFNGLDRAWRANGEELEMENTSPROC(uint mode, uint start, uint end, uint count, uint type, const void *indices);
    private delegate void PFNGLTEXIMAGE3DPROC(uint target, int level, int internalformat, uint width, uint height, uint depth, int border, uint format, uint type, const void *pixels);
    private delegate void PFNGLTEXSUBIMAGE3DPROC(uint target, int level, int xoffset, int yoffset, int zoffset, uint width, uint height, uint depth, uint format, uint type, const void *pixels);
    private delegate void PFNGLCOPYTEXSUBIMAGE3DPROC(uint target, int level, int xoffset, int yoffset, int zoffset, int x, int y, uint width, uint height);

    public static void glDrawRangeElements(uint mode, uint start, uint end, uint count, uint type, const void *indices);
    public static void glTexImage3D(uint target, int level, int internalformat, uint width, uint height, uint depth, int border, uint format, uint type, const void *pixels);
    public static void glTexSubImage3D(uint target, int level, int xoffset, int yoffset, int zoffset, uint width, uint height, uint depth, uint format, uint type, const void *pixels);
    public static void glCopyTexSubImage3D(uint target, int level, int xoffset, int yoffset, int zoffset, int x, int y, uint width, uint height);
    #endregion

    #region GL_VERSION_1_3
    public const uint GL_TEXTURE0 = 0x84C0;
    public const uint GL_TEXTURE1 = 0x84C1;
    public const uint GL_TEXTURE2 = 0x84C2;
    public const uint GL_TEXTURE3 = 0x84C3;
    public const uint GL_TEXTURE4 = 0x84C4;
    public const uint GL_TEXTURE5 = 0x84C5;
    public const uint GL_TEXTURE6 = 0x84C6;
    public const uint GL_TEXTURE7 = 0x84C7;
    public const uint GL_TEXTURE8 = 0x84C8;
    public const uint GL_TEXTURE9 = 0x84C9;
    public const uint GL_TEXTURE10 = 0x84CA;
    public const uint GL_TEXTURE11 = 0x84CB;
    public const uint GL_TEXTURE12 = 0x84CC;
    public const uint GL_TEXTURE13 = 0x84CD;
    public const uint GL_TEXTURE14 = 0x84CE;
    public const uint GL_TEXTURE15 = 0x84CF;
    public const uint GL_TEXTURE16 = 0x84D0;
    public const uint GL_TEXTURE17 = 0x84D1;
    public const uint GL_TEXTURE18 = 0x84D2;
    public const uint GL_TEXTURE19 = 0x84D3;
    public const uint GL_TEXTURE20 = 0x84D4;
    public const uint GL_TEXTURE21 = 0x84D5;
    public const uint GL_TEXTURE22 = 0x84D6;
    public const uint GL_TEXTURE23 = 0x84D7;
    public const uint GL_TEXTURE24 = 0x84D8;
    public const uint GL_TEXTURE25 = 0x84D9;
    public const uint GL_TEXTURE26 = 0x84DA;
    public const uint GL_TEXTURE27 = 0x84DB;
    public const uint GL_TEXTURE28 = 0x84DC;
    public const uint GL_TEXTURE29 = 0x84DD;
    public const uint GL_TEXTURE30 = 0x84DE;
    public const uint GL_TEXTURE31 = 0x84DF;
    public const uint GL_ACTIVE_TEXTURE = 0x84E0;
    public const uint GL_MULTISAMPLE = 0x809D;
    public const uint GL_SAMPLE_ALPHA_TO_COVERAGE = 0x809E;
    public const uint GL_SAMPLE_ALPHA_TO_ONE = 0x809F;
    public const uint GL_SAMPLE_COVERAGE = 0x80A0;
    public const uint GL_SAMPLE_BUFFERS = 0x80A8;
    public const uint GL_SAMPLES = 0x80A9;
    public const uint GL_SAMPLE_COVERAGE_VALUE = 0x80AA;
    public const uint GL_SAMPLE_COVERAGE_INVERT = 0x80AB;
    public const uint GL_TEXTURE_CUBE_MAP = 0x8513;
    public const uint GL_TEXTURE_BINDING_CUBE_MAP = 0x8514;
    public const uint GL_TEXTURE_CUBE_MAP_POSITIVE_X = 0x8515;
    public const uint GL_TEXTURE_CUBE_MAP_NEGATIVE_X = 0x8516;
    public const uint GL_TEXTURE_CUBE_MAP_POSITIVE_Y = 0x8517;
    public const uint GL_TEXTURE_CUBE_MAP_NEGATIVE_Y = 0x8518;
    public const uint GL_TEXTURE_CUBE_MAP_POSITIVE_Z = 0x8519;
    public const uint GL_TEXTURE_CUBE_MAP_NEGATIVE_Z = 0x851A;
    public const uint GL_PROXY_TEXTURE_CUBE_MAP = 0x851B;
    public const uint GL_MAX_CUBE_MAP_TEXTURE_SIZE = 0x851C;
    public const uint GL_COMPRESSED_RGB = 0x84ED;
    public const uint GL_COMPRESSED_RGBA = 0x84EE;
    public const uint GL_TEXTURE_COMPRESSION_HINT = 0x84EF;
    public const uint GL_TEXTURE_COMPRESSED_IMAGE_SIZE = 0x86A0;
    public const uint GL_TEXTURE_COMPRESSED = 0x86A1;
    public const uint GL_NUM_COMPRESSED_TEXTURE_FORMATS = 0x86A2;
    public const uint GL_COMPRESSED_TEXTURE_FORMATS = 0x86A3;
    public const uint GL_CLAMP_TO_BORDER = 0x812D;
    public const uint GL_CLIENT_ACTIVE_TEXTURE = 0x84E1;
    public const uint GL_MAX_TEXTURE_UNITS = 0x84E2;
    public const uint GL_TRANSPOSE_MODELVIEW_MATRIX = 0x84E3;
    public const uint GL_TRANSPOSE_PROJECTION_MATRIX = 0x84E4;
    public const uint GL_TRANSPOSE_TEXTURE_MATRIX = 0x84E5;
    public const uint GL_TRANSPOSE_COLOR_MATRIX = 0x84E6;
    public const uint GL_MULTISAMPLE_BIT = 0x20000000;
    public const uint GL_NORMAL_MAP = 0x8511;
    public const uint GL_REFLECTION_MAP = 0x8512;
    public const uint GL_COMPRESSED_ALPHA = 0x84E9;
    public const uint GL_COMPRESSED_LUMINANCE = 0x84EA;
    public const uint GL_COMPRESSED_LUMINANCE_ALPHA = 0x84EB;
    public const uint GL_COMPRESSED_INTENSITY = 0x84EC;
    public const uint GL_COMBINE = 0x8570;
    public const uint GL_COMBINE_RGB = 0x8571;
    public const uint GL_COMBINE_ALPHA = 0x8572;
    public const uint GL_SOURCE0_RGB = 0x8580;
    public const uint GL_SOURCE1_RGB = 0x8581;
    public const uint GL_SOURCE2_RGB = 0x8582;
    public const uint GL_SOURCE0_ALPHA = 0x8588;
    public const uint GL_SOURCE1_ALPHA = 0x8589;
    public const uint GL_SOURCE2_ALPHA = 0x858A;
    public const uint GL_OPERAND0_RGB = 0x8590;
    public const uint GL_OPERAND1_RGB = 0x8591;
    public const uint GL_OPERAND2_RGB = 0x8592;
    public const uint GL_OPERAND0_ALPHA = 0x8598;
    public const uint GL_OPERAND1_ALPHA = 0x8599;
    public const uint GL_OPERAND2_ALPHA = 0x859A;
    public const uint GL_RGB_SCALE = 0x8573;
    public const uint GL_ADD_SIGNED = 0x8574;
    public const uint GL_INTERPOLATE = 0x8575;
    public const uint GL_SUBTRACT = 0x84E7;
    public const uint GL_CONSTANT = 0x8576;
    public const uint GL_PRIMARY_COLOR = 0x8577;
    public const uint GL_PREVIOUS = 0x8578;
    public const uint GL_DOT3_RGB = 0x86AE;
    public const uint GL_DOT3_RGBA = 0x86AF;
    
    private delegate void PFNGLACTIVETEXTUREPROC(uint texture);
    private delegate void PFNGLSAMPLECOVERAGEPROC(float value, bool invert);
    private delegate void PFNGLCOMPRESSEDTEXIMAGE3DPROC(uint target, int level, uint internalformat, uint width, uint height, uint depth, int border, uint imageSize, const void *data);
    private delegate void PFNGLCOMPRESSEDTEXIMAGE2DPROC(uint target, int level, uint internalformat, uint width, uint height, int border, uint imageSize, const void *data);
    private delegate void PFNGLCOMPRESSEDTEXIMAGE1DPROC(uint target, int level, uint internalformat, uint width, int border, uint imageSize, const void *data);
    private delegate void PFNGLCOMPRESSEDTEXSUBIMAGE3DPROC(uint target, int level, int xoffset, int yoffset, int zoffset, uint width, uint height, uint depth, uint format, uint imageSize, const void *data);
    private delegate void PFNGLCOMPRESSEDTEXSUBIMAGE2DPROC(uint target, int level, int xoffset, int yoffset, uint width, uint height, uint format, uint imageSize, const void *data);
    private delegate void PFNGLCOMPRESSEDTEXSUBIMAGE1DPROC(uint target, int level, int xoffset, uint width, uint format, uint imageSize, const void *data);
    private delegate void PFNGLGETCOMPRESSEDTEXIMAGEPROC(uint target, int level, void *img);
    private delegate void PFNGLCLIENTACTIVETEXTUREPROC(uint texture);
    private delegate void PFNGLMULTITEXCOORD1DPROC(uint target, double s);
    private delegate void PFNGLMULTITEXCOORD1DVPROC(uint target, const double *v);
    private delegate void PFNGLMULTITEXCOORD1FPROC(uint target, float s);
    private delegate void PFNGLMULTITEXCOORD1FVPROC(uint target, const float *v);
    private delegate void PFNGLMULTITEXCOORD1IPROC(uint target, int s);
    private delegate void PFNGLMULTITEXCOORD1IVPROC(uint target, const int *v);
    private delegate void PFNGLMULTITEXCOORD1SPROC(uint target, short s);
    private delegate void PFNGLMULTITEXCOORD1SVPROC(uint target, const short *v);
    private delegate void PFNGLMULTITEXCOORD2DPROC(uint target, double s, double t);
    private delegate void PFNGLMULTITEXCOORD2DVPROC(uint target, const double *v);
    private delegate void PFNGLMULTITEXCOORD2FPROC(uint target, float s, float t);
    private delegate void PFNGLMULTITEXCOORD2FVPROC(uint target, const float *v);
    private delegate void PFNGLMULTITEXCOORD2IPROC(uint target, int s, int t);
    private delegate void PFNGLMULTITEXCOORD2IVPROC(uint target, const int *v);
    private delegate void PFNGLMULTITEXCOORD2SPROC(uint target, short s, short t);
    private delegate void PFNGLMULTITEXCOORD2SVPROC(uint target, const short *v);
    private delegate void PFNGLMULTITEXCOORD3DPROC(uint target, double s, double t, double r);
    private delegate void PFNGLMULTITEXCOORD3DVPROC(uint target, const double *v);
    private delegate void PFNGLMULTITEXCOORD3FPROC(uint target, float s, float t, float r);
    private delegate void PFNGLMULTITEXCOORD3FVPROC(uint target, const float *v);
    private delegate void PFNGLMULTITEXCOORD3IPROC(uint target, int s, int t, int r);
    private delegate void PFNGLMULTITEXCOORD3IVPROC(uint target, const int *v);
    private delegate void PFNGLMULTITEXCOORD3SPROC(uint target, short s, short t, short r);
    private delegate void PFNGLMULTITEXCOORD3SVPROC(uint target, const short *v);
    private delegate void PFNGLMULTITEXCOORD4DPROC(uint target, double s, double t, double r, double q);
    private delegate void PFNGLMULTITEXCOORD4DVPROC(uint target, const double *v);
    private delegate void PFNGLMULTITEXCOORD4FPROC(uint target, float s, float t, float r, float q);
    private delegate void PFNGLMULTITEXCOORD4FVPROC(uint target, const float *v);
    private delegate void PFNGLMULTITEXCOORD4IPROC(uint target, int s, int t, int r, int q);
    private delegate void PFNGLMULTITEXCOORD4IVPROC(uint target, const int *v);
    private delegate void PFNGLMULTITEXCOORD4SPROC(uint target, short s, short t, short r, short q);
    private delegate void PFNGLMULTITEXCOORD4SVPROC(uint target, const short *v);
    private delegate void PFNGLLOADTRANSPOSEMATRIXFPROC(const float *m);
    private delegate void PFNGLLOADTRANSPOSEMATRIXDPROC(const double *m);
    private delegate void PFNGLMULTTRANSPOSEMATRIXFPROC(const float *m);
    private delegate void PFNGLMULTTRANSPOSEMATRIXDPROC(const double *m);

    public static void glActiveTexture(uint texture);
    public static void glSampleCoverage(float value, bool invert);
    public static void glCompressedTexImage3D(uint target, int level, uint internalformat, uint width, uint height, uint depth, int border, uint imageSize, const void *data);
    public static void glCompressedTexImage2D(uint target, int level, uint internalformat, uint width, uint height, int border, uint imageSize, const void *data);
    public static void glCompressedTexImage1D(uint target, int level, uint internalformat, uint width, int border, uint imageSize, const void *data);
    public static void glCompressedTexSubImage3D(uint target, int level, int xoffset, int yoffset, int zoffset, uint width, uint height, uint depth, uint format, uint imageSize, const void *data);
    public static void glCompressedTexSubImage2D(uint target, int level, int xoffset, int yoffset, uint width, uint height, uint format, uint imageSize, const void *data);
    public static void glCompressedTexSubImage1D(uint target, int level, int xoffset, uint width, uint format, uint imageSize, const void *data);
    public static void glGetCompressedTexImage(uint target, int level, void *img);
    public static void glClientActiveTexture(uint texture);
    public static void glMultiTexCoord1d(uint target, double s);
    public static void glMultiTexCoord1dv(uint target, const double *v);
    public static void glMultiTexCoord1f(uint target, float s);
    public static void glMultiTexCoord1fv(uint target, const float *v);
    public static void glMultiTexCoord1i(uint target, int s);
    public static void glMultiTexCoord1iv(uint target, const int *v);
    public static void glMultiTexCoord1s(uint target, short s);
    public static void glMultiTexCoord1sv(uint target, const short *v);
    public static void glMultiTexCoord2d(uint target, double s, double t);
    public static void glMultiTexCoord2dv(uint target, const double *v);
    public static void glMultiTexCoord2f(uint target, float s, float t);
    public static void glMultiTexCoord2fv(uint target, const float *v);
    public static void glMultiTexCoord2i(uint target, int s, int t);
    public static void glMultiTexCoord2iv(uint target, const int *v);
    public static void glMultiTexCoord2s(uint target, short s, short t);
    public static void glMultiTexCoord2sv(uint target, const short *v);
    public static void glMultiTexCoord3d(uint target, double s, double t, double r);
    public static void glMultiTexCoord3dv(uint target, const double *v);
    public static void glMultiTexCoord3f(uint target, float s, float t, float r);
    public static void glMultiTexCoord3fv(uint target, const float *v);
    public static void glMultiTexCoord3i(uint target, int s, int t, int r);
    public static void glMultiTexCoord3iv(uint target, const int *v);
    public static void glMultiTexCoord3s(uint target, short s, short t, short r);
    public static void glMultiTexCoord3sv(uint target, const short *v);
    public static void glMultiTexCoord4d(uint target, double s, double t, double r, double q);
    public static void glMultiTexCoord4dv(uint target, const double *v);
    public static void glMultiTexCoord4f(uint target, float s, float t, float r, float q);
    public static void glMultiTexCoord4fv(uint target, const float *v);
    public static void glMultiTexCoord4i(uint target, int s, int t, int r, int q);
    public static void glMultiTexCoord4iv(uint target, const int *v);
    public static void glMultiTexCoord4s(uint target, short s, short t, short r, short q);
    public static void glMultiTexCoord4sv(uint target, const short *v);
    public static void glLoadTransposeMatrixf(const float *m);
    public static void glLoadTransposeMatrixd(const double *m);
    public static void glMultTransposeMatrixf(const float *m);
    public static void glMultTransposeMatrixd(const double *m);
    #endregion

    #region GL_VERSION_1_4
    public const uint GL_BLEND_DST_RGB = 0x80C8;
    public const uint GL_BLEND_SRC_RGB = 0x80C9;
    public const uint GL_BLEND_DST_ALPHA = 0x80CA;
    public const uint GL_BLEND_SRC_ALPHA = 0x80CB;
    public const uint GL_POINT_FADE_THRESHOLD_SIZE = 0x8128;
    public const uint GL_DEPTH_COMPONENT16 = 0x81A5;
    public const uint GL_DEPTH_COMPONENT24 = 0x81A6;
    public const uint GL_DEPTH_COMPONENT32 = 0x81A7;
    public const uint GL_MIRRORED_REPEAT = 0x8370;
    public const uint GL_MAX_TEXTURE_LOD_BIAS = 0x84FD;
    public const uint GL_TEXTURE_LOD_BIAS = 0x8501;
    public const uint GL_INCR_WRAP = 0x8507;
    public const uint GL_DECR_WRAP = 0x8508;
    public const uint GL_TEXTURE_DEPTH_SIZE = 0x884A;
    public const uint GL_TEXTURE_COMPARE_MODE = 0x884C;
    public const uint GL_TEXTURE_COMPARE_FUNC = 0x884D;
    public const uint GL_POINT_SIZE_MIN = 0x8126;
    public const uint GL_POINT_SIZE_MAX = 0x8127;
    public const uint GL_POINT_DISTANCE_ATTENUATION = 0x8129;
    public const uint GL_GENERATE_MIPMAP = 0x8191;
    public const uint GL_GENERATE_MIPMAP_HINT = 0x8192;
    public const uint GL_FOG_COORDINATE_SOURCE = 0x8450;
    public const uint GL_FOG_COORDINATE = 0x8451;
    public const uint GL_FRAGMENT_DEPTH = 0x8452;
    public const uint GL_CURRENT_FOG_COORDINATE = 0x8453;
    public const uint GL_FOG_COORDINATE_ARRAY_TYPE = 0x8454;
    public const uint GL_FOG_COORDINATE_ARRAY_STRIDE = 0x8455;
    public const uint GL_FOG_COORDINATE_ARRAY_POINTER = 0x8456;
    public const uint GL_FOG_COORDINATE_ARRAY = 0x8457;
    public const uint GL_COLOR_SUM = 0x8458;
    public const uint GL_CURRENT_SECONDARY_COLOR = 0x8459;
    public const uint GL_SECONDARY_COLOR_ARRAY_SIZE = 0x845A;
    public const uint GL_SECONDARY_COLOR_ARRAY_TYPE = 0x845B;
    public const uint GL_SECONDARY_COLOR_ARRAY_STRIDE = 0x845C;
    public const uint GL_SECONDARY_COLOR_ARRAY_POINTER = 0x845D;
    public const uint GL_SECONDARY_COLOR_ARRAY = 0x845E;
    public const uint GL_TEXTURE_FILTER_CONTROL = 0x8500;
    public const uint GL_DEPTH_TEXTURE_MODE = 0x884B;
    public const uint GL_COMPARE_R_TO_TEXTURE = 0x884E;
    public const uint GL_FUNC_ADD = 0x8006;
    public const uint GL_FUNC_SUBTRACT = 0x800A;
    public const uint GL_FUNC_REVERSE_SUBTRACT = 0x800B;
    public const uint GL_MIN = 0x8007;
    public const uint GL_MAX = 0x8008;
    public const uint GL_CONSTANT_COLOR = 0x8001;
    public const uint GL_ONE_MINUS_CONSTANT_COLOR = 0x8002;
    public const uint GL_CONSTANT_ALPHA = 0x8003;
    public const uint GL_ONE_MINUS_CONSTANT_ALPHA = 0x8004;
    
    private delegate void PFNGLBLENDFUNCSEPARATEPROC(uint sfactorRGB, uint dfactorRGB, uint sfactorAlpha, uint dfactorAlpha);
    private delegate void PFNGLMULTIDRAWARRAYSPROC(uint mode, const int *first, const uint *count, uint drawcount);
    private delegate void PFNGLMULTIDRAWELEMENTSPROC(uint mode, const uint *count, uint type, const void *const*indices, uint drawcount);
    private delegate void PFNGLPOINTPARAMETERFPROC(uint pname, float param);
    private delegate void PFNGLPOINTPARAMETERFVPROC(uint pname, const float *params);
    private delegate void PFNGLPOINTPARAMETERIPROC(uint pname, int param);
    private delegate void PFNGLPOINTPARAMETERIVPROC(uint pname, const int *params);
    private delegate void PFNGLFOGCOORDFPROC(float coord);
    private delegate void PFNGLFOGCOORDFVPROC(const float *coord);
    private delegate void PFNGLFOGCOORDDPROC(double coord);
    private delegate void PFNGLFOGCOORDDVPROC(const double *coord);
    private delegate void PFNGLFOGCOORDPOINTERPROC(uint type, uint stride, const void *pointer);
    private delegate void PFNGLSECONDARYCOLOR3BPROC(sbyte red, sbyte green, sbyte blue);
    private delegate void PFNGLSECONDARYCOLOR3BVPROC(const sbyte *v);
    private delegate void PFNGLSECONDARYCOLOR3DPROC(double red, double green, double blue);
    private delegate void PFNGLSECONDARYCOLOR3DVPROC(const double *v);
    private delegate void PFNGLSECONDARYCOLOR3FPROC(float red, float green, float blue);
    private delegate void PFNGLSECONDARYCOLOR3FVPROC(const float *v);
    private delegate void PFNGLSECONDARYCOLOR3IPROC(int red, int green, int blue);
    private delegate void PFNGLSECONDARYCOLOR3IVPROC(const int *v);
    private delegate void PFNGLSECONDARYCOLOR3SPROC(short red, short green, short blue);
    private delegate void PFNGLSECONDARYCOLOR3SVPROC(const short *v);
    private delegate void PFNGLSECONDARYCOLOR3UBPROC(byte red, byte green, byte blue);
    private delegate void PFNGLSECONDARYCOLOR3UBVPROC(const byte *v);
    private delegate void PFNGLSECONDARYCOLOR3UIPROC(uint red, uint green, uint blue);
    private delegate void PFNGLSECONDARYCOLOR3UIVPROC(const uint *v);
    private delegate void PFNGLSECONDARYCOLOR3USPROC(ushort red, ushort green, ushort blue);
    private delegate void PFNGLSECONDARYCOLOR3USVPROC(const ushort *v);
    private delegate void PFNGLSECONDARYCOLORPOINTERPROC(int size, uint type, uint stride, const void *pointer);
    private delegate void PFNGLWINDOWPOS2DPROC(double x, double y);
    private delegate void PFNGLWINDOWPOS2DVPROC(const double *v);
    private delegate void PFNGLWINDOWPOS2FPROC(float x, float y);
    private delegate void PFNGLWINDOWPOS2FVPROC(const float *v);
    private delegate void PFNGLWINDOWPOS2IPROC(int x, int y);
    private delegate void PFNGLWINDOWPOS2IVPROC(const int *v);
    private delegate void PFNGLWINDOWPOS2SPROC(short x, short y);
    private delegate void PFNGLWINDOWPOS2SVPROC(const short *v);
    private delegate void PFNGLWINDOWPOS3DPROC(double x, double y, double z);
    private delegate void PFNGLWINDOWPOS3DVPROC(const double *v);
    private delegate void PFNGLWINDOWPOS3FPROC(float x, float y, float z);
    private delegate void PFNGLWINDOWPOS3FVPROC(const float *v);
    private delegate void PFNGLWINDOWPOS3IPROC(int x, int y, int z);
    private delegate void PFNGLWINDOWPOS3IVPROC(const int *v);
    private delegate void PFNGLWINDOWPOS3SPROC(short x, short y, short z);
    private delegate void PFNGLWINDOWPOS3SVPROC(const short *v);
    private delegate void PFNGLBLENDCOLORPROC(float red, float green, float blue, float alpha);
    private delegate void PFNGLBLENDEQUATIONPROC(uint mode);

    public static void glBlendFuncSeparate(uint sfactorRGB, uint dfactorRGB, uint sfactorAlpha, uint dfactorAlpha);
    public static void glMultiDrawArrays(uint mode, const int *first, const uint *count, uint drawcount);
    public static void glMultiDrawElements(uint mode, const uint *count, uint type, const void *const*indices, uint drawcount);
    public static void glPointParameterf(uint pname, float param);
    public static void glPointParameterfv(uint pname, const float *params);
    public static void glPointParameteri(uint pname, int param);
    public static void glPointParameteriv(uint pname, const int *params);
    public static void glFogCoordf(float coord);
    public static void glFogCoordfv(const float *coord);
    public static void glFogCoordd(double coord);
    public static void glFogCoorddv(const double *coord);
    public static void glFogCoordPointer(uint type, uint stride, const void *pointer);
    public static void glSecondaryColor3b(sbyte red, sbyte green, sbyte blue);
    public static void glSecondaryColor3bv(const sbyte *v);
    public static void glSecondaryColor3d(double red, double green, double blue);
    public static void glSecondaryColor3dv(const double *v);
    public static void glSecondaryColor3f(float red, float green, float blue);
    public static void glSecondaryColor3fv(const float *v);
    public static void glSecondaryColor3i(int red, int green, int blue);
    public static void glSecondaryColor3iv(const int *v);
    public static void glSecondaryColor3s(short red, short green, short blue);
    public static void glSecondaryColor3sv(const short *v);
    public static void glSecondaryColor3ub(byte red, byte green, byte blue);
    public static void glSecondaryColor3ubv(const byte *v);
    public static void glSecondaryColor3ui(uint red, uint green, uint blue);
    public static void glSecondaryColor3uiv(const uint *v);
    public static void glSecondaryColor3us(ushort red, ushort green, ushort blue);
    public static void glSecondaryColor3usv(const ushort *v);
    public static void glSecondaryColorPointer(int size, uint type, uint stride, const void *pointer);
    public static void glWindowPos2d(double x, double y);
    public static void glWindowPos2dv(const double *v);
    public static void glWindowPos2f(float x, float y);
    public static void glWindowPos2fv(const float *v);
    public static void glWindowPos2i(int x, int y);
    public static void glWindowPos2iv(const int *v);
    public static void glWindowPos2s(short x, short y);
    public static void glWindowPos2sv(const short *v);
    public static void glWindowPos3d(double x, double y, double z);
    public static void glWindowPos3dv(const double *v);
    public static void glWindowPos3f(float x, float y, float z);
    public static void glWindowPos3fv(const float *v);
    public static void glWindowPos3i(int x, int y, int z);
    public static void glWindowPos3iv(const int *v);
    public static void glWindowPos3s(short x, short y, short z);
    public static void glWindowPos3sv(const short *v);
    public static void glBlendColor(float red, float green, float blue, float alpha);
    public static void glBlendEquation(uint mode);
    #endregion

    #region GL_VERSION_1_5
    public const uint GL_BUFFER_SIZE = 0x8764;
    public const uint GL_BUFFER_USAGE = 0x8765;
    public const uint GL_QUERY_COUNTER_BITS = 0x8864;
    public const uint GL_CURRENT_QUERY = 0x8865;
    public const uint GL_QUERY_RESULT = 0x8866;
    public const uint GL_QUERY_RESULT_AVAILABLE = 0x8867;
    public const uint GL_ARRAY_BUFFER = 0x8892;
    public const uint GL_ELEMENT_ARRAY_BUFFER = 0x8893;
    public const uint GL_ARRAY_BUFFER_BINDING = 0x8894;
    public const uint GL_ELEMENT_ARRAY_BUFFER_BINDING = 0x8895;
    public const uint GL_VERTEX_ATTRIB_ARRAY_BUFFER_BINDING = 0x889F;
    public const uint GL_READ_ONLY = 0x88B8;
    public const uint GL_WRITE_ONLY = 0x88B9;
    public const uint GL_READ_WRITE = 0x88BA;
    public const uint GL_BUFFER_ACCESS = 0x88BB;
    public const uint GL_BUFFER_MAPPED = 0x88BC;
    public const uint GL_BUFFER_MAP_POINTER = 0x88BD;
    public const uint GL_STREAM_DRAW = 0x88E0;
    public const uint GL_STREAM_READ = 0x88E1;
    public const uint GL_STREAM_COPY = 0x88E2;
    public const uint GL_STATIC_DRAW = 0x88E4;
    public const uint GL_STATIC_READ = 0x88E5;
    public const uint GL_STATIC_COPY = 0x88E6;
    public const uint GL_DYNAMIC_DRAW = 0x88E8;
    public const uint GL_DYNAMIC_READ = 0x88E9;
    public const uint GL_DYNAMIC_COPY = 0x88EA;
    public const uint GL_SAMPLES_PASSED = 0x8914;
    public const uint GL_SRC1_ALPHA = 0x8589;
    public const uint GL_VERTEX_ARRAY_BUFFER_BINDING = 0x8896;
    public const uint GL_NORMAL_ARRAY_BUFFER_BINDING = 0x8897;
    public const uint GL_COLOR_ARRAY_BUFFER_BINDING = 0x8898;
    public const uint GL_INDEX_ARRAY_BUFFER_BINDING = 0x8899;
    public const uint GL_TEXTURE_COORD_ARRAY_BUFFER_BINDING = 0x889A;
    public const uint GL_EDGE_FLAG_ARRAY_BUFFER_BINDING = 0x889B;
    public const uint GL_SECONDARY_COLOR_ARRAY_BUFFER_BINDING = 0x889C;
    public const uint GL_FOG_COORDINATE_ARRAY_BUFFER_BINDING = 0x889D;
    public const uint GL_WEIGHT_ARRAY_BUFFER_BINDING = 0x889E;
    public const uint GL_FOG_COORD_SRC = 0x8450;
    public const uint GL_FOG_COORD = 0x8451;
    public const uint GL_CURRENT_FOG_COORD = 0x8453;
    public const uint GL_FOG_COORD_ARRAY_TYPE = 0x8454;
    public const uint GL_FOG_COORD_ARRAY_STRIDE = 0x8455;
    public const uint GL_FOG_COORD_ARRAY_POINTER = 0x8456;
    public const uint GL_FOG_COORD_ARRAY = 0x8457;
    public const uint GL_FOG_COORD_ARRAY_BUFFER_BINDING = 0x889D;
    public const uint GL_SRC0_RGB = 0x8580;
    public const uint GL_SRC1_RGB = 0x8581;
    public const uint GL_SRC2_RGB = 0x8582;
    public const uint GL_SRC0_ALPHA = 0x8588;
    public const uint GL_SRC2_ALPHA = 0x858A;
    
    private delegate void PFNGLGENQUERIESPROC(uint n, uint *ids);
    private delegate void PFNGLDELETEQUERIESPROC(uint n, const uint *ids);
    private delegate bool PFNGLISQUERYPROC(uint id);
    private delegate void PFNGLBEGINQUERYPROC(uint target, uint id);
    private delegate void PFNGLENDQUERYPROC(uint target);
    private delegate void PFNGLGETQUERYIVPROC(uint target, uint pname, int *params);
    private delegate void PFNGLGETQUERYOBJECTIVPROC(uint id, uint pname, int *params);
    private delegate void PFNGLGETQUERYOBJECTUIVPROC(uint id, uint pname, uint *params);
    private delegate void PFNGLBINDBUFFERPROC(uint target, uint buffer);
    private delegate void PFNGLDELETEBUFFERSPROC(uint n, const uint *buffers);
    private delegate void PFNGLGENBUFFERSPROC(uint n, uint *buffers);
    private delegate bool PFNGLISBUFFERPROC(uint buffer);
    private delegate void PFNGLBUFFERDATAPROC(uint target, uintptr size, const void *data, uint usage);
    private delegate void PFNGLBUFFERSUBDATAPROC(uint target, intptr offset, uintptr size, const void *data);
    private delegate void PFNGLGETBUFFERSUBDATAPROC(uint target, intptr offset, uintptr size, void *data);
    private delegate void* PFNGLMAPBUFFERPROC(uint target, uint access);
    private delegate bool PFNGLUNMAPBUFFERPROC(uint target);
    private delegate void PFNGLGETBUFFERPARAMETERIVPROC(uint target, uint pname, int *params);
    private delegate void PFNGLGETBUFFERPOINTERVPROC(uint target, uint pname, void **params);

    public static void glGenQueries(uint n, uint *ids);
    public static void glDeleteQueries(uint n, const uint *ids);
    public static bool glIsQuery(uint id);
    public static void glBeginQuery(uint target, uint id);
    public static void glEndQuery(uint target);
    public static void glGetQueryiv(uint target, uint pname, int *params);
    public static void glGetQueryObjectiv(uint id, uint pname, int *params);
    public static void glGetQueryObjectuiv(uint id, uint pname, uint *params);
    public static void glBindBuffer(uint target, uint buffer);
    public static void glDeleteBuffers(uint n, const uint *buffers);
    public static void glGenBuffers(uint n, uint *buffers);
    public static bool glIsBuffer(uint buffer);
    public static void glBufferData(uint target, uintptr size, const void *data, uint usage);
    public static void glBufferSubData(uint target, intptr offset, uintptr size, const void *data);
    public static void glGetBufferSubData(uint target, intptr offset, uintptr size, void *data);
    public static void* glMapBuffer(uint target, uint access);
    public static bool glUnmapBuffer(uint target);
    public static void glGetBufferParameteriv(uint target, uint pname, int *params);
    public static void glGetBufferPointerv(uint target, uint pname, void **params);
    #endregion

    #region GL_VERSION_2_0
    public const uint GL_BLEND_EQUATION_RGB = 0x8009;
    public const uint GL_VERTEX_ATTRIB_ARRAY_ENABLED = 0x8622;
    public const uint GL_VERTEX_ATTRIB_ARRAY_SIZE = 0x8623;
    public const uint GL_VERTEX_ATTRIB_ARRAY_STRIDE = 0x8624;
    public const uint GL_VERTEX_ATTRIB_ARRAY_TYPE = 0x8625;
    public const uint GL_CURRENT_VERTEX_ATTRIB = 0x8626;
    public const uint GL_VERTEX_PROGRAM_POINT_SIZE = 0x8642;
    public const uint GL_VERTEX_ATTRIB_ARRAY_POINTER = 0x8645;
    public const uint GL_STENCIL_BACK_FUNC = 0x8800;
    public const uint GL_STENCIL_BACK_FAIL = 0x8801;
    public const uint GL_STENCIL_BACK_PASS_DEPTH_FAIL = 0x8802;
    public const uint GL_STENCIL_BACK_PASS_DEPTH_PASS = 0x8803;
    public const uint GL_MAX_DRAW_BUFFERS = 0x8824;
    public const uint GL_DRAW_BUFFER0 = 0x8825;
    public const uint GL_DRAW_BUFFER1 = 0x8826;
    public const uint GL_DRAW_BUFFER2 = 0x8827;
    public const uint GL_DRAW_BUFFER3 = 0x8828;
    public const uint GL_DRAW_BUFFER4 = 0x8829;
    public const uint GL_DRAW_BUFFER5 = 0x882A;
    public const uint GL_DRAW_BUFFER6 = 0x882B;
    public const uint GL_DRAW_BUFFER7 = 0x882C;
    public const uint GL_DRAW_BUFFER8 = 0x882D;
    public const uint GL_DRAW_BUFFER9 = 0x882E;
    public const uint GL_DRAW_BUFFER10 = 0x882F;
    public const uint GL_DRAW_BUFFER11 = 0x8830;
    public const uint GL_DRAW_BUFFER12 = 0x8831;
    public const uint GL_DRAW_BUFFER13 = 0x8832;
    public const uint GL_DRAW_BUFFER14 = 0x8833;
    public const uint GL_DRAW_BUFFER15 = 0x8834;
    public const uint GL_BLEND_EQUATION_ALPHA = 0x883D;
    public const uint GL_MAX_VERTEX_ATTRIBS = 0x8869;
    public const uint GL_VERTEX_ATTRIB_ARRAY_NORMALIZED = 0x886A;
    public const uint GL_MAX_TEXTURE_IMAGE_UNITS = 0x8872;
    public const uint GL_FRAGMENT_SHADER = 0x8B30;
    public const uint GL_VERTEX_SHADER = 0x8B31;
    public const uint GL_MAX_FRAGMENT_UNIFORM_COMPONENTS = 0x8B49;
    public const uint GL_MAX_VERTEX_UNIFORM_COMPONENTS = 0x8B4A;
    public const uint GL_MAX_VARYING_FLOATS = 0x8B4B;
    public const uint GL_MAX_VERTEX_TEXTURE_IMAGE_UNITS = 0x8B4C;
    public const uint GL_MAX_COMBINED_TEXTURE_IMAGE_UNITS = 0x8B4D;
    public const uint GL_SHADER_TYPE = 0x8B4F;
    public const uint GL_FLOAT_VEC2 = 0x8B50;
    public const uint GL_FLOAT_VEC3 = 0x8B51;
    public const uint GL_FLOAT_VEC4 = 0x8B52;
    public const uint GL_INT_VEC2 = 0x8B53;
    public const uint GL_INT_VEC3 = 0x8B54;
    public const uint GL_INT_VEC4 = 0x8B55;
    public const uint GL_BOOL = 0x8B56;
    public const uint GL_BOOL_VEC2 = 0x8B57;
    public const uint GL_BOOL_VEC3 = 0x8B58;
    public const uint GL_BOOL_VEC4 = 0x8B59;
    public const uint GL_FLOAT_MAT2 = 0x8B5A;
    public const uint GL_FLOAT_MAT3 = 0x8B5B;
    public const uint GL_FLOAT_MAT4 = 0x8B5C;
    public const uint GL_SAMPLER_1D = 0x8B5D;
    public const uint GL_SAMPLER_2D = 0x8B5E;
    public const uint GL_SAMPLER_3D = 0x8B5F;
    public const uint GL_SAMPLER_CUBE = 0x8B60;
    public const uint GL_SAMPLER_1D_SHADOW = 0x8B61;
    public const uint GL_SAMPLER_2D_SHADOW = 0x8B62;
    public const uint GL_DELETE_STATUS = 0x8B80;
    public const uint GL_COMPILE_STATUS = 0x8B81;
    public const uint GL_LINK_STATUS = 0x8B82;
    public const uint GL_VALIDATE_STATUS = 0x8B83;
    public const uint GL_INFO_LOG_LENGTH = 0x8B84;
    public const uint GL_ATTACHED_SHADERS = 0x8B85;
    public const uint GL_ACTIVE_UNIFORMS = 0x8B86;
    public const uint GL_ACTIVE_UNIFORM_MAX_LENGTH = 0x8B87;
    public const uint GL_SHADER_SOURCE_LENGTH = 0x8B88;
    public const uint GL_ACTIVE_ATTRIBUTES = 0x8B89;
    public const uint GL_ACTIVE_ATTRIBUTE_MAX_LENGTH = 0x8B8A;
    public const uint GL_FRAGMENT_SHADER_DERIVATIVE_HINT = 0x8B8B;
    public const uint GL_SHADING_LANGUAGE_VERSION = 0x8B8C;
    public const uint GL_CURRENT_PROGRAM = 0x8B8D;
    public const uint GL_POINT_SPRITE_COORD_ORIGIN = 0x8CA0;
    public const uint GL_LOWER_LEFT = 0x8CA1;
    public const uint GL_UPPER_LEFT = 0x8CA2;
    public const uint GL_STENCIL_BACK_REF = 0x8CA3;
    public const uint GL_STENCIL_BACK_VALUE_MASK = 0x8CA4;
    public const uint GL_STENCIL_BACK_WRITEMASK = 0x8CA5;
    public const uint GL_VERTEX_PROGRAM_TWO_SIDE = 0x8643;
    public const uint GL_POINT_SPRITE = 0x8861;
    public const uint GL_COORD_REPLACE = 0x8862;
    public const uint GL_MAX_TEXTURE_COORDS = 0x8871;
    
    private delegate void PFNGLBLENDEQUATIONSEPARATEPROC(uint modeRGB, uint modeAlpha);
    private delegate void PFNGLDRAWBUFFERSPROC(uint n, const uint *bufs);
    private delegate void PFNGLSTENCILOPSEPARATEPROC(uint face, uint sfail, uint dpfail, uint dppass);
    private delegate void PFNGLSTENCILFUNCSEPARATEPROC(uint face, uint func, int ref, uint mask);
    private delegate void PFNGLSTENCILMASKSEPARATEPROC(uint face, uint mask);
    private delegate void PFNGLATTACHSHADERPROC(uint program, uint shader);
    private delegate void PFNGLBINDATTRIBLOCATIONPROC(uint program, uint index, const byte *name);
    private delegate void PFNGLCOMPILESHADERPROC(uint shader);
    private delegate uint PFNGLCREATEPROGRAMPROC(void);
    private delegate uint PFNGLCREATESHADERPROC(uint type);
    private delegate void PFNGLDELETEPROGRAMPROC(uint program);
    private delegate void PFNGLDELETESHADERPROC(uint shader);
    private delegate void PFNGLDETACHSHADERPROC(uint program, uint shader);
    private delegate void PFNGLDISABLEVERTEXATTRIBARRAYPROC(uint index);
    private delegate void PFNGLENABLEVERTEXATTRIBARRAYPROC(uint index);
    private delegate void PFNGLGETACTIVEATTRIBPROC(uint program, uint index, uint bufSize, uint *length, int *size, uint *type, byte *name);
    private delegate void PFNGLGETACTIVEUNIFORMPROC(uint program, uint index, uint bufSize, uint *length, int *size, uint *type, byte *name);
    private delegate void PFNGLGETATTACHEDSHADERSPROC(uint program, uint maxCount, uint *count, uint *shaders);
    private delegate int PFNGLGETATTRIBLOCATIONPROC(uint program, const byte *name);
    private delegate void PFNGLGETPROGRAMIVPROC(uint program, uint pname, int *params);
    private delegate void PFNGLGETPROGRAMINFOLOGPROC(uint program, uint bufSize, uint *length, byte *infoLog);
    private delegate void PFNGLGETSHADERIVPROC(uint shader, uint pname, int *params);
    private delegate void PFNGLGETSHADERINFOLOGPROC(uint shader, uint bufSize, uint *length, byte *infoLog);
    private delegate void PFNGLGETSHADERSOURCEPROC(uint shader, uint bufSize, uint *length, byte *source);
    private delegate int PFNGLGETUNIFORMLOCATIONPROC(uint program, const byte *name);
    private delegate void PFNGLGETUNIFORMFVPROC(uint program, int location, float *params);
    private delegate void PFNGLGETUNIFORMIVPROC(uint program, int location, int *params);
    private delegate void PFNGLGETVERTEXATTRIBDVPROC(uint index, uint pname, double *params);
    private delegate void PFNGLGETVERTEXATTRIBFVPROC(uint index, uint pname, float *params);
    private delegate void PFNGLGETVERTEXATTRIBIVPROC(uint index, uint pname, int *params);
    private delegate void PFNGLGETVERTEXATTRIBPOINTERVPROC(uint index, uint pname, void **pointer);
    private delegate bool PFNGLISPROGRAMPROC(uint program);
    private delegate bool PFNGLISSHADERPROC(uint shader);
    private delegate void PFNGLLINKPROGRAMPROC(uint program);
    private delegate void PFNGLSHADERSOURCEPROC(uint shader, uint count, const byte *const*string, const int *length);
    private delegate void PFNGLUSEPROGRAMPROC(uint program);
    private delegate void PFNGLUNIFORM1FPROC(int location, float v0);
    private delegate void PFNGLUNIFORM2FPROC(int location, float v0, float v1);
    private delegate void PFNGLUNIFORM3FPROC(int location, float v0, float v1, float v2);
    private delegate void PFNGLUNIFORM4FPROC(int location, float v0, float v1, float v2, float v3);
    private delegate void PFNGLUNIFORM1IPROC(int location, int v0);
    private delegate void PFNGLUNIFORM2IPROC(int location, int v0, int v1);
    private delegate void PFNGLUNIFORM3IPROC(int location, int v0, int v1, int v2);
    private delegate void PFNGLUNIFORM4IPROC(int location, int v0, int v1, int v2, int v3);
    private delegate void PFNGLUNIFORM1FVPROC(int location, uint count, const float *value);
    private delegate void PFNGLUNIFORM2FVPROC(int location, uint count, const float *value);
    private delegate void PFNGLUNIFORM3FVPROC(int location, uint count, const float *value);
    private delegate void PFNGLUNIFORM4FVPROC(int location, uint count, const float *value);
    private delegate void PFNGLUNIFORM1IVPROC(int location, uint count, const int *value);
    private delegate void PFNGLUNIFORM2IVPROC(int location, uint count, const int *value);
    private delegate void PFNGLUNIFORM3IVPROC(int location, uint count, const int *value);
    private delegate void PFNGLUNIFORM4IVPROC(int location, uint count, const int *value);
    private delegate void PFNGLUNIFORMMATRIX2FVPROC(int location, uint count, bool transpose, const float *value);
    private delegate void PFNGLUNIFORMMATRIX3FVPROC(int location, uint count, bool transpose, const float *value);
    private delegate void PFNGLUNIFORMMATRIX4FVPROC(int location, uint count, bool transpose, const float *value);
    private delegate void PFNGLVALIDATEPROGRAMPROC(uint program);
    private delegate void PFNGLVERTEXATTRIB1DPROC(uint index, double x);
    private delegate void PFNGLVERTEXATTRIB1DVPROC(uint index, const double *v);
    private delegate void PFNGLVERTEXATTRIB1FPROC(uint index, float x);
    private delegate void PFNGLVERTEXATTRIB1FVPROC(uint index, const float *v);
    private delegate void PFNGLVERTEXATTRIB1SPROC(uint index, short x);
    private delegate void PFNGLVERTEXATTRIB1SVPROC(uint index, const short *v);
    private delegate void PFNGLVERTEXATTRIB2DPROC(uint index, double x, double y);
    private delegate void PFNGLVERTEXATTRIB2DVPROC(uint index, const double *v);
    private delegate void PFNGLVERTEXATTRIB2FPROC(uint index, float x, float y);
    private delegate void PFNGLVERTEXATTRIB2FVPROC(uint index, const float *v);
    private delegate void PFNGLVERTEXATTRIB2SPROC(uint index, short x, short y);
    private delegate void PFNGLVERTEXATTRIB2SVPROC(uint index, const short *v);
    private delegate void PFNGLVERTEXATTRIB3DPROC(uint index, double x, double y, double z);
    private delegate void PFNGLVERTEXATTRIB3DVPROC(uint index, const double *v);
    private delegate void PFNGLVERTEXATTRIB3FPROC(uint index, float x, float y, float z);
    private delegate void PFNGLVERTEXATTRIB3FVPROC(uint index, const float *v);
    private delegate void PFNGLVERTEXATTRIB3SPROC(uint index, short x, short y, short z);
    private delegate void PFNGLVERTEXATTRIB3SVPROC(uint index, const short *v);
    private delegate void PFNGLVERTEXATTRIB4NBVPROC(uint index, const sbyte *v);
    private delegate void PFNGLVERTEXATTRIB4NIVPROC(uint index, const int *v);
    private delegate void PFNGLVERTEXATTRIB4NSVPROC(uint index, const short *v);
    private delegate void PFNGLVERTEXATTRIB4NUBPROC(uint index, byte x, byte y, byte z, byte w);
    private delegate void PFNGLVERTEXATTRIB4NUBVPROC(uint index, const byte *v);
    private delegate void PFNGLVERTEXATTRIB4NUIVPROC(uint index, const uint *v);
    private delegate void PFNGLVERTEXATTRIB4NUSVPROC(uint index, const ushort *v);
    private delegate void PFNGLVERTEXATTRIB4BVPROC(uint index, const sbyte *v);
    private delegate void PFNGLVERTEXATTRIB4DPROC(uint index, double x, double y, double z, double w);
    private delegate void PFNGLVERTEXATTRIB4DVPROC(uint index, const double *v);
    private delegate void PFNGLVERTEXATTRIB4FPROC(uint index, float x, float y, float z, float w);
    private delegate void PFNGLVERTEXATTRIB4FVPROC(uint index, const float *v);
    private delegate void PFNGLVERTEXATTRIB4IVPROC(uint index, const int *v);
    private delegate void PFNGLVERTEXATTRIB4SPROC(uint index, short x, short y, short z, short w);
    private delegate void PFNGLVERTEXATTRIB4SVPROC(uint index, const short *v);
    private delegate void PFNGLVERTEXATTRIB4UBVPROC(uint index, const byte *v);
    private delegate void PFNGLVERTEXATTRIB4UIVPROC(uint index, const uint *v);
    private delegate void PFNGLVERTEXATTRIB4USVPROC(uint index, const ushort *v);
    private delegate void PFNGLVERTEXATTRIBPOINTERPROC(uint index, int size, uint type, bool normalized, uint stride, const void *pointer);

    public static void glBlendEquationSeparate(uint modeRGB, uint modeAlpha);
    public static void glDrawBuffers(uint n, const uint *bufs);
    public static void glStencilOpSeparate(uint face, uint sfail, uint dpfail, uint dppass);
    public static void glStencilFuncSeparate(uint face, uint func, int ref, uint mask);
    public static void glStencilMaskSeparate(uint face, uint mask);
    public static void glAttachShader(uint program, uint shader);
    public static void glBindAttribLocation(uint program, uint index, const byte *name);
    public static void glCompileShader(uint shader);
    public static uint glCreateProgram(void);
    public static uint glCreateShader(uint type);
    public static void glDeleteProgram(uint program);
    public static void glDeleteShader(uint shader);
    public static void glDetachShader(uint program, uint shader);
    public static void glDisableVertexAttribArray(uint index);
    public static void glEnableVertexAttribArray(uint index);
    public static void glGetActiveAttrib(uint program, uint index, uint bufSize, uint *length, int *size, uint *type, byte *name);
    public static void glGetActiveUniform(uint program, uint index, uint bufSize, uint *length, int *size, uint *type, byte *name);
    public static void glGetAttachedShaders(uint program, uint maxCount, uint *count, uint *shaders);
    public static int glGetAttribLocation(uint program, const byte *name);
    public static void glGetProgramiv(uint program, uint pname, int *params);
    public static void glGetProgramInfoLog(uint program, uint bufSize, uint *length, byte *infoLog);
    public static void glGetShaderiv(uint shader, uint pname, int *params);
    public static void glGetShaderInfoLog(uint shader, uint bufSize, uint *length, byte *infoLog);
    public static void glGetShaderSource(uint shader, uint bufSize, uint *length, byte *source);
    public static int glGetUniformLocation(uint program, const byte *name);
    public static void glGetUniformfv(uint program, int location, float *params);
    public static void glGetUniformiv(uint program, int location, int *params);
    public static void glGetVertexAttribdv(uint index, uint pname, double *params);
    public static void glGetVertexAttribfv(uint index, uint pname, float *params);
    public static void glGetVertexAttribiv(uint index, uint pname, int *params);
    public static void glGetVertexAttribPointerv(uint index, uint pname, void **pointer);
    public static bool glIsProgram(uint program);
    public static bool glIsShader(uint shader);
    public static void glLinkProgram(uint program);
    public static void glShaderSource(uint shader, uint count, const byte *const*string, const int *length);
    public static void glUseProgram(uint program);
    public static void glUniform1f(int location, float v0);
    public static void glUniform2f(int location, float v0, float v1);
    public static void glUniform3f(int location, float v0, float v1, float v2);
    public static void glUniform4f(int location, float v0, float v1, float v2, float v3);
    public static void glUniform1i(int location, int v0);
    public static void glUniform2i(int location, int v0, int v1);
    public static void glUniform3i(int location, int v0, int v1, int v2);
    public static void glUniform4i(int location, int v0, int v1, int v2, int v3);
    public static void glUniform1fv(int location, uint count, const float *value);
    public static void glUniform2fv(int location, uint count, const float *value);
    public static void glUniform3fv(int location, uint count, const float *value);
    public static void glUniform4fv(int location, uint count, const float *value);
    public static void glUniform1iv(int location, uint count, const int *value);
    public static void glUniform2iv(int location, uint count, const int *value);
    public static void glUniform3iv(int location, uint count, const int *value);
    public static void glUniform4iv(int location, uint count, const int *value);
    public static void glUniformMatrix2fv(int location, uint count, bool transpose, const float *value);
    public static void glUniformMatrix3fv(int location, uint count, bool transpose, const float *value);
    public static void glUniformMatrix4fv(int location, uint count, bool transpose, const float *value);
    public static void glValidateProgram(uint program);
    public static void glVertexAttrib1d(uint index, double x);
    public static void glVertexAttrib1dv(uint index, const double *v);
    public static void glVertexAttrib1f(uint index, float x);
    public static void glVertexAttrib1fv(uint index, const float *v);
    public static void glVertexAttrib1s(uint index, short x);
    public static void glVertexAttrib1sv(uint index, const short *v);
    public static void glVertexAttrib2d(uint index, double x, double y);
    public static void glVertexAttrib2dv(uint index, const double *v);
    public static void glVertexAttrib2f(uint index, float x, float y);
    public static void glVertexAttrib2fv(uint index, const float *v);
    public static void glVertexAttrib2s(uint index, short x, short y);
    public static void glVertexAttrib2sv(uint index, const short *v);
    public static void glVertexAttrib3d(uint index, double x, double y, double z);
    public static void glVertexAttrib3dv(uint index, const double *v);
    public static void glVertexAttrib3f(uint index, float x, float y, float z);
    public static void glVertexAttrib3fv(uint index, const float *v);
    public static void glVertexAttrib3s(uint index, short x, short y, short z);
    public static void glVertexAttrib3sv(uint index, const short *v);
    public static void glVertexAttrib4Nbv(uint index, const sbyte *v);
    public static void glVertexAttrib4Niv(uint index, const int *v);
    public static void glVertexAttrib4Nsv(uint index, const short *v);
    public static void glVertexAttrib4Nub(uint index, byte x, byte y, byte z, byte w);
    public static void glVertexAttrib4Nubv(uint index, const byte *v);
    public static void glVertexAttrib4Nuiv(uint index, const uint *v);
    public static void glVertexAttrib4Nusv(uint index, const ushort *v);
    public static void glVertexAttrib4bv(uint index, const sbyte *v);
    public static void glVertexAttrib4d(uint index, double x, double y, double z, double w);
    public static void glVertexAttrib4dv(uint index, const double *v);
    public static void glVertexAttrib4f(uint index, float x, float y, float z, float w);
    public static void glVertexAttrib4fv(uint index, const float *v);
    public static void glVertexAttrib4iv(uint index, const int *v);
    public static void glVertexAttrib4s(uint index, short x, short y, short z, short w);
    public static void glVertexAttrib4sv(uint index, const short *v);
    public static void glVertexAttrib4ubv(uint index, const byte *v);
    public static void glVertexAttrib4uiv(uint index, const uint *v);
    public static void glVertexAttrib4usv(uint index, const ushort *v);
    public static void glVertexAttribPointer(uint index, int size, uint type, bool normalized, uint stride, const void *pointer);
    #endregion

    #region GL_VERSION_2_1
    public const uint GL_PIXEL_PACK_BUFFER = 0x88EB;
    public const uint GL_PIXEL_UNPACK_BUFFER = 0x88EC;
    public const uint GL_PIXEL_PACK_BUFFER_BINDING = 0x88ED;
    public const uint GL_PIXEL_UNPACK_BUFFER_BINDING = 0x88EF;
    public const uint GL_FLOAT_MAT2x3 = 0x8B65;
    public const uint GL_FLOAT_MAT2x4 = 0x8B66;
    public const uint GL_FLOAT_MAT3x2 = 0x8B67;
    public const uint GL_FLOAT_MAT3x4 = 0x8B68;
    public const uint GL_FLOAT_MAT4x2 = 0x8B69;
    public const uint GL_FLOAT_MAT4x3 = 0x8B6A;
    public const uint GL_SRGB = 0x8C40;
    public const uint GL_SRGB8 = 0x8C41;
    public const uint GL_SRGB_ALPHA = 0x8C42;
    public const uint GL_SRGB8_ALPHA8 = 0x8C43;
    public const uint GL_COMPRESSED_SRGB = 0x8C48;
    public const uint GL_COMPRESSED_SRGB_ALPHA = 0x8C49;
    public const uint GL_CURRENT_RASTER_SECONDARY_COLOR = 0x845F;
    public const uint GL_SLUMINANCE_ALPHA = 0x8C44;
    public const uint GL_SLUMINANCE8_ALPHA8 = 0x8C45;
    public const uint GL_SLUMINANCE = 0x8C46;
    public const uint GL_SLUMINANCE8 = 0x8C47;
    public const uint GL_COMPRESSED_SLUMINANCE = 0x8C4A;
    public const uint GL_COMPRESSED_SLUMINANCE_ALPHA = 0x8C4B;
    
    private delegate void PFNGLUNIFORMMATRIX2X3FVPROC(int location, uint count, bool transpose, const float *value);
    private delegate void PFNGLUNIFORMMATRIX3X2FVPROC(int location, uint count, bool transpose, const float *value);
    private delegate void PFNGLUNIFORMMATRIX2X4FVPROC(int location, uint count, bool transpose, const float *value);
    private delegate void PFNGLUNIFORMMATRIX4X2FVPROC(int location, uint count, bool transpose, const float *value);
    private delegate void PFNGLUNIFORMMATRIX3X4FVPROC(int location, uint count, bool transpose, const float *value);
    private delegate void PFNGLUNIFORMMATRIX4X3FVPROC(int location, uint count, bool transpose, const float *value);

    public static void glUniformMatrix2x3fv(int location, uint count, bool transpose, const float *value);
    public static void glUniformMatrix3x2fv(int location, uint count, bool transpose, const float *value);
    public static void glUniformMatrix2x4fv(int location, uint count, bool transpose, const float *value);
    public static void glUniformMatrix4x2fv(int location, uint count, bool transpose, const float *value);
    public static void glUniformMatrix3x4fv(int location, uint count, bool transpose, const float *value);
    public static void glUniformMatrix4x3fv(int location, uint count, bool transpose, const float *value);
    #endregion

    #region GL_VERSION_3_0
    public const uint GL_COMPARE_REF_TO_TEXTURE = 0x884E;
    public const uint GL_CLIP_DISTANCE0 = 0x3000;
    public const uint GL_CLIP_DISTANCE1 = 0x3001;
    public const uint GL_CLIP_DISTANCE2 = 0x3002;
    public const uint GL_CLIP_DISTANCE3 = 0x3003;
    public const uint GL_CLIP_DISTANCE4 = 0x3004;
    public const uint GL_CLIP_DISTANCE5 = 0x3005;
    public const uint GL_CLIP_DISTANCE6 = 0x3006;
    public const uint GL_CLIP_DISTANCE7 = 0x3007;
    public const uint GL_MAX_CLIP_DISTANCES = 0x0D32;
    public const uint GL_MAJOR_VERSION = 0x821B;
    public const uint GL_MINOR_VERSION = 0x821C;
    public const uint GL_NUM_EXTENSIONS = 0x821D;
    public const uint GL_CONTEXT_FLAGS = 0x821E;
    public const uint GL_COMPRESSED_RED = 0x8225;
    public const uint GL_COMPRESSED_RG = 0x8226;
    public const uint GL_CONTEXT_FLAG_FORWARD_COMPATIBLE_BIT = 0x00000001;
    public const uint GL_RGBA32F = 0x8814;
    public const uint GL_RGB32F = 0x8815;
    public const uint GL_RGBA16F = 0x881A;
    public const uint GL_RGB16F = 0x881B;
    public const uint GL_VERTEX_ATTRIB_ARRAY_INTEGER = 0x88FD;
    public const uint GL_MAX_ARRAY_TEXTURE_LAYERS = 0x88FF;
    public const uint GL_MIN_PROGRAM_TEXEL_OFFSET = 0x8904;
    public const uint GL_MAX_PROGRAM_TEXEL_OFFSET = 0x8905;
    public const uint GL_CLAMP_READ_COLOR = 0x891C;
    public const uint GL_FIXED_ONLY = 0x891D;
    public const uint GL_MAX_VARYING_COMPONENTS = 0x8B4B;
    public const uint GL_TEXTURE_1D_ARRAY = 0x8C18;
    public const uint GL_PROXY_TEXTURE_1D_ARRAY = 0x8C19;
    public const uint GL_TEXTURE_2D_ARRAY = 0x8C1A;
    public const uint GL_PROXY_TEXTURE_2D_ARRAY = 0x8C1B;
    public const uint GL_TEXTURE_BINDING_1D_ARRAY = 0x8C1C;
    public const uint GL_TEXTURE_BINDING_2D_ARRAY = 0x8C1D;
    public const uint GL_R11F_G11F_B10F = 0x8C3A;
    public const uint GL_UNSIGNED_INT_10F_11F_11F_REV = 0x8C3B;
    public const uint GL_RGB9_E5 = 0x8C3D;
    public const uint GL_UNSIGNED_INT_5_9_9_9_REV = 0x8C3E;
    public const uint GL_TEXTURE_SHARED_SIZE = 0x8C3F;
    public const uint GL_TRANSFORM_FEEDBACK_VARYING_MAX_LENGTH = 0x8C76;
    public const uint GL_TRANSFORM_FEEDBACK_BUFFER_MODE = 0x8C7F;
    public const uint GL_MAX_TRANSFORM_FEEDBACK_SEPARATE_COMPONENTS = 0x8C80;
    public const uint GL_TRANSFORM_FEEDBACK_VARYINGS = 0x8C83;
    public const uint GL_TRANSFORM_FEEDBACK_BUFFER_START = 0x8C84;
    public const uint GL_TRANSFORM_FEEDBACK_BUFFER_SIZE = 0x8C85;
    public const uint GL_PRIMITIVES_GENERATED = 0x8C87;
    public const uint GL_TRANSFORM_FEEDBACK_PRIMITIVES_WRITTEN = 0x8C88;
    public const uint GL_RASTERIZER_DISCARD = 0x8C89;
    public const uint GL_MAX_TRANSFORM_FEEDBACK_INTERLEAVED_COMPONENTS = 0x8C8A;
    public const uint GL_MAX_TRANSFORM_FEEDBACK_SEPARATE_ATTRIBS = 0x8C8B;
    public const uint GL_INTERLEAVED_ATTRIBS = 0x8C8C;
    public const uint GL_SEPARATE_ATTRIBS = 0x8C8D;
    public const uint GL_TRANSFORM_FEEDBACK_BUFFER = 0x8C8E;
    public const uint GL_TRANSFORM_FEEDBACK_BUFFER_BINDING = 0x8C8F;
    public const uint GL_RGBA32UI = 0x8D70;
    public const uint GL_RGB32UI = 0x8D71;
    public const uint GL_RGBA16UI = 0x8D76;
    public const uint GL_RGB16UI = 0x8D77;
    public const uint GL_RGBA8UI = 0x8D7C;
    public const uint GL_RGB8UI = 0x8D7D;
    public const uint GL_RGBA32I = 0x8D82;
    public const uint GL_RGB32I = 0x8D83;
    public const uint GL_RGBA16I = 0x8D88;
    public const uint GL_RGB16I = 0x8D89;
    public const uint GL_RGBA8I = 0x8D8E;
    public const uint GL_RGB8I = 0x8D8F;
    public const uint GL_RED_INTEGER = 0x8D94;
    public const uint GL_GREEN_INTEGER = 0x8D95;
    public const uint GL_BLUE_INTEGER = 0x8D96;
    public const uint GL_RGB_INTEGER = 0x8D98;
    public const uint GL_RGBA_INTEGER = 0x8D99;
    public const uint GL_BGR_INTEGER = 0x8D9A;
    public const uint GL_BGRA_INTEGER = 0x8D9B;
    public const uint GL_SAMPLER_1D_ARRAY = 0x8DC0;
    public const uint GL_SAMPLER_2D_ARRAY = 0x8DC1;
    public const uint GL_SAMPLER_1D_ARRAY_SHADOW = 0x8DC3;
    public const uint GL_SAMPLER_2D_ARRAY_SHADOW = 0x8DC4;
    public const uint GL_SAMPLER_CUBE_SHADOW = 0x8DC5;
    public const uint GL_UNSIGNED_INT_VEC2 = 0x8DC6;
    public const uint GL_UNSIGNED_INT_VEC3 = 0x8DC7;
    public const uint GL_UNSIGNED_INT_VEC4 = 0x8DC8;
    public const uint GL_INT_SAMPLER_1D = 0x8DC9;
    public const uint GL_INT_SAMPLER_2D = 0x8DCA;
    public const uint GL_INT_SAMPLER_3D = 0x8DCB;
    public const uint GL_INT_SAMPLER_CUBE = 0x8DCC;
    public const uint GL_INT_SAMPLER_1D_ARRAY = 0x8DCE;
    public const uint GL_INT_SAMPLER_2D_ARRAY = 0x8DCF;
    public const uint GL_UNSIGNED_INT_SAMPLER_1D = 0x8DD1;
    public const uint GL_UNSIGNED_INT_SAMPLER_2D = 0x8DD2;
    public const uint GL_UNSIGNED_INT_SAMPLER_3D = 0x8DD3;
    public const uint GL_UNSIGNED_INT_SAMPLER_CUBE = 0x8DD4;
    public const uint GL_UNSIGNED_INT_SAMPLER_1D_ARRAY = 0x8DD6;
    public const uint GL_UNSIGNED_INT_SAMPLER_2D_ARRAY = 0x8DD7;
    public const uint GL_QUERY_WAIT = 0x8E13;
    public const uint GL_QUERY_NO_WAIT = 0x8E14;
    public const uint GL_QUERY_BY_REGION_WAIT = 0x8E15;
    public const uint GL_QUERY_BY_REGION_NO_WAIT = 0x8E16;
    public const uint GL_BUFFER_ACCESS_FLAGS = 0x911F;
    public const uint GL_BUFFER_MAP_LENGTH = 0x9120;
    public const uint GL_BUFFER_MAP_OFFSET = 0x9121;
    public const uint GL_DEPTH_COMPONENT32F = 0x8CAC;
    public const uint GL_DEPTH32F_STENCIL8 = 0x8CAD;
    public const uint GL_FLOAT_32_UNSIGNED_INT_24_8_REV = 0x8DAD;
    public const uint GL_INVALID_FRAMEBUFFER_OPERATION = 0x0506;
    public const uint GL_FRAMEBUFFER_ATTACHMENT_COLOR_ENCODING = 0x8210;
    public const uint GL_FRAMEBUFFER_ATTACHMENT_COMPONENT_TYPE = 0x8211;
    public const uint GL_FRAMEBUFFER_ATTACHMENT_RED_SIZE = 0x8212;
    public const uint GL_FRAMEBUFFER_ATTACHMENT_GREEN_SIZE = 0x8213;
    public const uint GL_FRAMEBUFFER_ATTACHMENT_BLUE_SIZE = 0x8214;
    public const uint GL_FRAMEBUFFER_ATTACHMENT_ALPHA_SIZE = 0x8215;
    public const uint GL_FRAMEBUFFER_ATTACHMENT_DEPTH_SIZE = 0x8216;
    public const uint GL_FRAMEBUFFER_ATTACHMENT_STENCIL_SIZE = 0x8217;
    public const uint GL_FRAMEBUFFER_DEFAULT = 0x8218;
    public const uint GL_FRAMEBUFFER_UNDEFINED = 0x8219;
    public const uint GL_DEPTH_STENCIL_ATTACHMENT = 0x821A;
    public const uint GL_MAX_RENDERBUFFER_SIZE = 0x84E8;
    public const uint GL_DEPTH_STENCIL = 0x84F9;
    public const uint GL_UNSIGNED_INT_24_8 = 0x84FA;
    public const uint GL_DEPTH24_STENCIL8 = 0x88F0;
    public const uint GL_TEXTURE_STENCIL_SIZE = 0x88F1;
    public const uint GL_TEXTURE_RED_TYPE = 0x8C10;
    public const uint GL_TEXTURE_GREEN_TYPE = 0x8C11;
    public const uint GL_TEXTURE_BLUE_TYPE = 0x8C12;
    public const uint GL_TEXTURE_ALPHA_TYPE = 0x8C13;
    public const uint GL_TEXTURE_DEPTH_TYPE = 0x8C16;
    public const uint GL_UNSIGNED_NORMALIZED = 0x8C17;
    public const uint GL_FRAMEBUFFER_BINDING = 0x8CA6;
    public const uint GL_DRAW_FRAMEBUFFER_BINDING = 0x8CA6;
    public const uint GL_RENDERBUFFER_BINDING = 0x8CA7;
    public const uint GL_READ_FRAMEBUFFER = 0x8CA8;
    public const uint GL_DRAW_FRAMEBUFFER = 0x8CA9;
    public const uint GL_READ_FRAMEBUFFER_BINDING = 0x8CAA;
    public const uint GL_RENDERBUFFER_SAMPLES = 0x8CAB;
    public const uint GL_FRAMEBUFFER_ATTACHMENT_OBJECT_TYPE = 0x8CD0;
    public const uint GL_FRAMEBUFFER_ATTACHMENT_OBJECT_NAME = 0x8CD1;
    public const uint GL_FRAMEBUFFER_ATTACHMENT_TEXTURE_LEVEL = 0x8CD2;
    public const uint GL_FRAMEBUFFER_ATTACHMENT_TEXTURE_CUBE_MAP_FACE = 0x8CD3;
    public const uint GL_FRAMEBUFFER_ATTACHMENT_TEXTURE_LAYER = 0x8CD4;
    public const uint GL_FRAMEBUFFER_COMPLETE = 0x8CD5;
    public const uint GL_FRAMEBUFFER_INCOMPLETE_ATTACHMENT = 0x8CD6;
    public const uint GL_FRAMEBUFFER_INCOMPLETE_MISSING_ATTACHMENT = 0x8CD7;
    public const uint GL_FRAMEBUFFER_INCOMPLETE_DRAW_BUFFER = 0x8CDB;
    public const uint GL_FRAMEBUFFER_INCOMPLETE_READ_BUFFER = 0x8CDC;
    public const uint GL_FRAMEBUFFER_UNSUPPORTED = 0x8CDD;
    public const uint GL_MAX_COLOR_ATTACHMENTS = 0x8CDF;
    public const uint GL_COLOR_ATTACHMENT0 = 0x8CE0;
    public const uint GL_COLOR_ATTACHMENT1 = 0x8CE1;
    public const uint GL_COLOR_ATTACHMENT2 = 0x8CE2;
    public const uint GL_COLOR_ATTACHMENT3 = 0x8CE3;
    public const uint GL_COLOR_ATTACHMENT4 = 0x8CE4;
    public const uint GL_COLOR_ATTACHMENT5 = 0x8CE5;
    public const uint GL_COLOR_ATTACHMENT6 = 0x8CE6;
    public const uint GL_COLOR_ATTACHMENT7 = 0x8CE7;
    public const uint GL_COLOR_ATTACHMENT8 = 0x8CE8;
    public const uint GL_COLOR_ATTACHMENT9 = 0x8CE9;
    public const uint GL_COLOR_ATTACHMENT10 = 0x8CEA;
    public const uint GL_COLOR_ATTACHMENT11 = 0x8CEB;
    public const uint GL_COLOR_ATTACHMENT12 = 0x8CEC;
    public const uint GL_COLOR_ATTACHMENT13 = 0x8CED;
    public const uint GL_COLOR_ATTACHMENT14 = 0x8CEE;
    public const uint GL_COLOR_ATTACHMENT15 = 0x8CEF;
    public const uint GL_DEPTH_ATTACHMENT = 0x8D00;
    public const uint GL_STENCIL_ATTACHMENT = 0x8D20;
    public const uint GL_FRAMEBUFFER = 0x8D40;
    public const uint GL_RENDERBUFFER = 0x8D41;
    public const uint GL_RENDERBUFFER_WIDTH = 0x8D42;
    public const uint GL_RENDERBUFFER_HEIGHT = 0x8D43;
    public const uint GL_RENDERBUFFER_INTERNAL_FORMAT = 0x8D44;
    public const uint GL_STENCIL_INDEX1 = 0x8D46;
    public const uint GL_STENCIL_INDEX4 = 0x8D47;
    public const uint GL_STENCIL_INDEX8 = 0x8D48;
    public const uint GL_STENCIL_INDEX16 = 0x8D49;
    public const uint GL_RENDERBUFFER_RED_SIZE = 0x8D50;
    public const uint GL_RENDERBUFFER_GREEN_SIZE = 0x8D51;
    public const uint GL_RENDERBUFFER_BLUE_SIZE = 0x8D52;
    public const uint GL_RENDERBUFFER_ALPHA_SIZE = 0x8D53;
    public const uint GL_RENDERBUFFER_DEPTH_SIZE = 0x8D54;
    public const uint GL_RENDERBUFFER_STENCIL_SIZE = 0x8D55;
    public const uint GL_FRAMEBUFFER_INCOMPLETE_MULTISAMPLE = 0x8D56;
    public const uint GL_MAX_SAMPLES = 0x8D57;
    public const uint GL_INDEX = 0x8222;
    public const uint GL_TEXTURE_LUMINANCE_TYPE = 0x8C14;
    public const uint GL_TEXTURE_INTENSITY_TYPE = 0x8C15;
    public const uint GL_FRAMEBUFFER_SRGB = 0x8DB9;
    public const uint GL_HALF_FLOAT = 0x140B;
    public const uint GL_MAP_READ_BIT = 0x0001;
    public const uint GL_MAP_WRITE_BIT = 0x0002;
    public const uint GL_MAP_INVALIDATE_RANGE_BIT = 0x0004;
    public const uint GL_MAP_INVALIDATE_BUFFER_BIT = 0x0008;
    public const uint GL_MAP_FLUSH_EXPLICIT_BIT = 0x0010;
    public const uint GL_MAP_UNSYNCHRONIZED_BIT = 0x0020;
    public const uint GL_COMPRESSED_RED_RGTC1 = 0x8DBB;
    public const uint GL_COMPRESSED_SIGNED_RED_RGTC1 = 0x8DBC;
    public const uint GL_COMPRESSED_RG_RGTC2 = 0x8DBD;
    public const uint GL_COMPRESSED_SIGNED_RG_RGTC2 = 0x8DBE;
    public const uint GL_RG = 0x8227;
    public const uint GL_RG_INTEGER = 0x8228;
    public const uint GL_R8 = 0x8229;
    public const uint GL_R16 = 0x822A;
    public const uint GL_RG8 = 0x822B;
    public const uint GL_RG16 = 0x822C;
    public const uint GL_R16F = 0x822D;
    public const uint GL_R32F = 0x822E;
    public const uint GL_RG16F = 0x822F;
    public const uint GL_RG32F = 0x8230;
    public const uint GL_R8I = 0x8231;
    public const uint GL_R8UI = 0x8232;
    public const uint GL_R16I = 0x8233;
    public const uint GL_R16UI = 0x8234;
    public const uint GL_R32I = 0x8235;
    public const uint GL_R32UI = 0x8236;
    public const uint GL_RG8I = 0x8237;
    public const uint GL_RG8UI = 0x8238;
    public const uint GL_RG16I = 0x8239;
    public const uint GL_RG16UI = 0x823A;
    public const uint GL_RG32I = 0x823B;
    public const uint GL_RG32UI = 0x823C;
    public const uint GL_VERTEX_ARRAY_BINDING = 0x85B5;
    public const uint GL_CLAMP_VERTEX_COLOR = 0x891A;
    public const uint GL_CLAMP_FRAGMENT_COLOR = 0x891B;
    public const uint GL_ALPHA_INTEGER = 0x8D97;
    
    private delegate void PFNGLCOLORMASKIPROC(uint index, bool r, bool g, bool b, bool a);
    private delegate void PFNGLGETBOOLEANI_VPROC(uint target, uint index, bool *data);
    private delegate void PFNGLGETINTEGERI_VPROC(uint target, uint index, int *data);
    private delegate void PFNGLENABLEIPROC(uint target, uint index);
    private delegate void PFNGLDISABLEIPROC(uint target, uint index);
    private delegate bool PFNGLISENABLEDIPROC(uint target, uint index);
    private delegate void PFNGLBEGINTRANSFORMFEEDBACKPROC(uint primitiveMode);
    private delegate void PFNGLENDTRANSFORMFEEDBACKPROC(void);
    private delegate void PFNGLBINDBUFFERRANGEPROC(uint target, uint index, uint buffer, intptr offset, uintptr size);
    private delegate void PFNGLBINDBUFFERBASEPROC(uint target, uint index, uint buffer);
    private delegate void PFNGLTRANSFORMFEEDBACKVARYINGSPROC(uint program, uint count, const byte *const*varyings, uint bufferMode);
    private delegate void PFNGLGETTRANSFORMFEEDBACKVARYINGPROC(uint program, uint index, uint bufSize, uint *length, uint *size, uint *type, byte *name);
    private delegate void PFNGLCLAMPCOLORPROC(uint target, uint clamp);
    private delegate void PFNGLBEGINCONDITIONALRENDERPROC(uint id, uint mode);
    private delegate void PFNGLENDCONDITIONALRENDERPROC(void);
    private delegate void PFNGLVERTEXATTRIBIPOINTERPROC(uint index, int size, uint type, uint stride, const void *pointer);
    private delegate void PFNGLGETVERTEXATTRIBIIVPROC(uint index, uint pname, int *params);
    private delegate void PFNGLGETVERTEXATTRIBIUIVPROC(uint index, uint pname, uint *params);
    private delegate void PFNGLVERTEXATTRIBI1IPROC(uint index, int x);
    private delegate void PFNGLVERTEXATTRIBI2IPROC(uint index, int x, int y);
    private delegate void PFNGLVERTEXATTRIBI3IPROC(uint index, int x, int y, int z);
    private delegate void PFNGLVERTEXATTRIBI4IPROC(uint index, int x, int y, int z, int w);
    private delegate void PFNGLVERTEXATTRIBI1UIPROC(uint index, uint x);
    private delegate void PFNGLVERTEXATTRIBI2UIPROC(uint index, uint x, uint y);
    private delegate void PFNGLVERTEXATTRIBI3UIPROC(uint index, uint x, uint y, uint z);
    private delegate void PFNGLVERTEXATTRIBI4UIPROC(uint index, uint x, uint y, uint z, uint w);
    private delegate void PFNGLVERTEXATTRIBI1IVPROC(uint index, const int *v);
    private delegate void PFNGLVERTEXATTRIBI2IVPROC(uint index, const int *v);
    private delegate void PFNGLVERTEXATTRIBI3IVPROC(uint index, const int *v);
    private delegate void PFNGLVERTEXATTRIBI4IVPROC(uint index, const int *v);
    private delegate void PFNGLVERTEXATTRIBI1UIVPROC(uint index, const uint *v);
    private delegate void PFNGLVERTEXATTRIBI2UIVPROC(uint index, const uint *v);
    private delegate void PFNGLVERTEXATTRIBI3UIVPROC(uint index, const uint *v);
    private delegate void PFNGLVERTEXATTRIBI4UIVPROC(uint index, const uint *v);
    private delegate void PFNGLVERTEXATTRIBI4BVPROC(uint index, const sbyte *v);
    private delegate void PFNGLVERTEXATTRIBI4SVPROC(uint index, const short *v);
    private delegate void PFNGLVERTEXATTRIBI4UBVPROC(uint index, const byte *v);
    private delegate void PFNGLVERTEXATTRIBI4USVPROC(uint index, const ushort *v);
    private delegate void PFNGLGETUNIFORMUIVPROC(uint program, int location, uint *params);
    private delegate void PFNGLBINDFRAGDATALOCATIONPROC(uint program, uint color, const byte *name);
    private delegate int PFNGLGETFRAGDATALOCATIONPROC(uint program, const byte *name);
    private delegate void PFNGLUNIFORM1UIPROC(int location, uint v0);
    private delegate void PFNGLUNIFORM2UIPROC(int location, uint v0, uint v1);
    private delegate void PFNGLUNIFORM3UIPROC(int location, uint v0, uint v1, uint v2);
    private delegate void PFNGLUNIFORM4UIPROC(int location, uint v0, uint v1, uint v2, uint v3);
    private delegate void PFNGLUNIFORM1UIVPROC(int location, uint count, const uint *value);
    private delegate void PFNGLUNIFORM2UIVPROC(int location, uint count, const uint *value);
    private delegate void PFNGLUNIFORM3UIVPROC(int location, uint count, const uint *value);
    private delegate void PFNGLUNIFORM4UIVPROC(int location, uint count, const uint *value);
    private delegate void PFNGLTEXPARAMETERIIVPROC(uint target, uint pname, const int *params);
    private delegate void PFNGLTEXPARAMETERIUIVPROC(uint target, uint pname, const uint *params);
    private delegate void PFNGLGETTEXPARAMETERIIVPROC(uint target, uint pname, int *params);
    private delegate void PFNGLGETTEXPARAMETERIUIVPROC(uint target, uint pname, uint *params);
    private delegate void PFNGLCLEARBUFFERIVPROC(uint buffer, int drawbuffer, const int *value);
    private delegate void PFNGLCLEARBUFFERUIVPROC(uint buffer, int drawbuffer, const uint *value);
    private delegate void PFNGLCLEARBUFFERFVPROC(uint buffer, int drawbuffer, const float *value);
    private delegate void PFNGLCLEARBUFFERFIPROC(uint buffer, int drawbuffer, float depth, int stencil);
    typedef const byte *(APIENTRYP PFNGLGETSTRINGIPROC) (uint name, uint index);
    private delegate bool PFNGLISRENDERBUFFERPROC(uint renderbuffer);
    private delegate void PFNGLBINDRENDERBUFFERPROC(uint target, uint renderbuffer);
    private delegate void PFNGLDELETERENDERBUFFERSPROC(uint n, const uint *renderbuffers);
    private delegate void PFNGLGENRENDERBUFFERSPROC(uint n, uint *renderbuffers);
    private delegate void PFNGLRENDERBUFFERSTORAGEPROC(uint target, uint internalformat, uint width, uint height);
    private delegate void PFNGLGETRENDERBUFFERPARAMETERIVPROC(uint target, uint pname, int *params);
    private delegate bool PFNGLISFRAMEBUFFERPROC(uint framebuffer);
    private delegate void PFNGLBINDFRAMEBUFFERPROC(uint target, uint framebuffer);
    private delegate void PFNGLDELETEFRAMEBUFFERSPROC(uint n, const uint *framebuffers);
    private delegate void PFNGLGENFRAMEBUFFERSPROC(uint n, uint *framebuffers);
    private delegate uint PFNGLCHECKFRAMEBUFFERSTATUSPROC(uint target);
    private delegate void PFNGLFRAMEBUFFERTEXTURE1DPROC(uint target, uint attachment, uint textarget, uint texture, int level);
    private delegate void PFNGLFRAMEBUFFERTEXTURE2DPROC(uint target, uint attachment, uint textarget, uint texture, int level);
    private delegate void PFNGLFRAMEBUFFERTEXTURE3DPROC(uint target, uint attachment, uint textarget, uint texture, int level, int zoffset);
    private delegate void PFNGLFRAMEBUFFERRENDERBUFFERPROC(uint target, uint attachment, uint renderbuffertarget, uint renderbuffer);
    private delegate void PFNGLGETFRAMEBUFFERATTACHMENTPARAMETERIVPROC(uint target, uint attachment, uint pname, int *params);
    private delegate void PFNGLGENERATEMIPMAPPROC(uint target);
    private delegate void PFNGLBLITFRAMEBUFFERPROC(int srcX0, int srcY0, int srcX1, int srcY1, int dstX0, int dstY0, int dstX1, int dstY1, uint mask, uint filter);
    private delegate void PFNGLRENDERBUFFERSTORAGEMULTISAMPLEPROC(uint target, uint samples, uint internalformat, uint width, uint height);
    private delegate void PFNGLFRAMEBUFFERTEXTURELAYERPROC(uint target, uint attachment, uint texture, int level, int layer);
    private delegate void* PFNGLMAPBUFFERRANGEPROC(uint target, intptr offset, uintptr length, uint access);
    private delegate void PFNGLFLUSHMAPPEDBUFFERRANGEPROC(uint target, intptr offset, uintptr length);
    private delegate void PFNGLBINDVERTEXARRAYPROC(uint array);
    private delegate void PFNGLDELETEVERTEXARRAYSPROC(uint n, const uint *arrays);
    private delegate void PFNGLGENVERTEXARRAYSPROC(uint n, uint *arrays);
    private delegate bool PFNGLISVERTEXARRAYPROC(uint array);

    public static void glColorMaski(uint index, bool r, bool g, bool b, bool a);
    public static void glGetBooleani_v(uint target, uint index, bool *data);
    public static void glGetIntegeri_v(uint target, uint index, int *data);
    public static void glEnablei(uint target, uint index);
    public static void glDisablei(uint target, uint index);
    public static bool glIsEnabledi(uint target, uint index);
    public static void glBeginTransformFeedback(uint primitiveMode);
    public static void glEndTransformFeedback(void);
    public static void glBindBufferRange(uint target, uint index, uint buffer, intptr offset, uintptr size);
    public static void glBindBufferBase(uint target, uint index, uint buffer);
    public static void glTransformFeedbackVaryings(uint program, uint count, const byte *const*varyings, uint bufferMode);
    public static void glGetTransformFeedbackVarying(uint program, uint index, uint bufSize, uint *length, uint *size, uint *type, byte *name);
    public static void glClampColor(uint target, uint clamp);
    public static void glBeginConditionalRender(uint id, uint mode);
    public static void glEndConditionalRender(void);
    public static void glVertexAttribIPointer(uint index, int size, uint type, uint stride, const void *pointer);
    public static void glGetVertexAttribIiv(uint index, uint pname, int *params);
    public static void glGetVertexAttribIuiv(uint index, uint pname, uint *params);
    public static void glVertexAttribI1i(uint index, int x);
    public static void glVertexAttribI2i(uint index, int x, int y);
    public static void glVertexAttribI3i(uint index, int x, int y, int z);
    public static void glVertexAttribI4i(uint index, int x, int y, int z, int w);
    public static void glVertexAttribI1ui(uint index, uint x);
    public static void glVertexAttribI2ui(uint index, uint x, uint y);
    public static void glVertexAttribI3ui(uint index, uint x, uint y, uint z);
    public static void glVertexAttribI4ui(uint index, uint x, uint y, uint z, uint w);
    public static void glVertexAttribI1iv(uint index, const int *v);
    public static void glVertexAttribI2iv(uint index, const int *v);
    public static void glVertexAttribI3iv(uint index, const int *v);
    public static void glVertexAttribI4iv(uint index, const int *v);
    public static void glVertexAttribI1uiv(uint index, const uint *v);
    public static void glVertexAttribI2uiv(uint index, const uint *v);
    public static void glVertexAttribI3uiv(uint index, const uint *v);
    public static void glVertexAttribI4uiv(uint index, const uint *v);
    public static void glVertexAttribI4bv(uint index, const sbyte *v);
    public static void glVertexAttribI4sv(uint index, const short *v);
    public static void glVertexAttribI4ubv(uint index, const byte *v);
    public static void glVertexAttribI4usv(uint index, const ushort *v);
    public static void glGetUniformuiv(uint program, int location, uint *params);
    public static void glBindFragDataLocation(uint program, uint color, const byte *name);
    public static int glGetFragDataLocation(uint program, const byte *name);
    public static void glUniform1ui(int location, uint v0);
    public static void glUniform2ui(int location, uint v0, uint v1);
    public static void glUniform3ui(int location, uint v0, uint v1, uint v2);
    public static void glUniform4ui(int location, uint v0, uint v1, uint v2, uint v3);
    public static void glUniform1uiv(int location, uint count, const uint *value);
    public static void glUniform2uiv(int location, uint count, const uint *value);
    public static void glUniform3uiv(int location, uint count, const uint *value);
    public static void glUniform4uiv(int location, uint count, const uint *value);
    public static void glTexParameterIiv(uint target, uint pname, const int *params);
    public static void glTexParameterIuiv(uint target, uint pname, const uint *params);
    public static void glGetTexParameterIiv(uint target, uint pname, int *params);
    public static void glGetTexParameterIuiv(uint target, uint pname, uint *params);
    public static void glClearBufferiv(uint buffer, int drawbuffer, const int *value);
    public static void glClearBufferuiv(uint buffer, int drawbuffer, const uint *value);
    public static void glClearBufferfv(uint buffer, int drawbuffer, const float *value);
    public static void glClearBufferfi(uint buffer, int drawbuffer, float depth, int stencil);
    GLAPI const byte *APIENTRY glGetStringi (uint name, uint index);
    public static bool glIsRenderbuffer(uint renderbuffer);
    public static void glBindRenderbuffer(uint target, uint renderbuffer);
    public static void glDeleteRenderbuffers(uint n, const uint *renderbuffers);
    public static void glGenRenderbuffers(uint n, uint *renderbuffers);
    public static void glRenderbufferStorage(uint target, uint internalformat, uint width, uint height);
    public static void glGetRenderbufferParameteriv(uint target, uint pname, int *params);
    public static bool glIsFramebuffer(uint framebuffer);
    public static void glBindFramebuffer(uint target, uint framebuffer);
    public static void glDeleteFramebuffers(uint n, const uint *framebuffers);
    public static void glGenFramebuffers(uint n, uint *framebuffers);
    public static uint glCheckFramebufferStatus(uint target);
    public static void glFramebufferTexture1D(uint target, uint attachment, uint textarget, uint texture, int level);
    public static void glFramebufferTexture2D(uint target, uint attachment, uint textarget, uint texture, int level);
    public static void glFramebufferTexture3D(uint target, uint attachment, uint textarget, uint texture, int level, int zoffset);
    public static void glFramebufferRenderbuffer(uint target, uint attachment, uint renderbuffertarget, uint renderbuffer);
    public static void glGetFramebufferAttachmentParameteriv(uint target, uint attachment, uint pname, int *params);
    public static void glGenerateMipmap(uint target);
    public static void glBlitFramebuffer(int srcX0, int srcY0, int srcX1, int srcY1, int dstX0, int dstY0, int dstX1, int dstY1, uint mask, uint filter);
    public static void glRenderbufferStorageMultisample(uint target, uint samples, uint internalformat, uint width, uint height);
    public static void glFramebufferTextureLayer(uint target, uint attachment, uint texture, int level, int layer);
    public static void* glMapBufferRange(uint target, intptr offset, uintptr length, uint access);
    public static void glFlushMappedBufferRange(uint target, intptr offset, uintptr length);
    public static void glBindVertexArray(uint array);
    public static void glDeleteVertexArrays(uint n, const uint *arrays);
    public static void glGenVertexArrays(uint n, uint *arrays);
    public static bool glIsVertexArray(uint array);
    #endregion

    #region GL_VERSION_3_1
    public const uint GL_SAMPLER_2D_RECT = 0x8B63;
    public const uint GL_SAMPLER_2D_RECT_SHADOW = 0x8B64;
    public const uint GL_SAMPLER_BUFFER = 0x8DC2;
    public const uint GL_INT_SAMPLER_2D_RECT = 0x8DCD;
    public const uint GL_INT_SAMPLER_BUFFER = 0x8DD0;
    public const uint GL_UNSIGNED_INT_SAMPLER_2D_RECT = 0x8DD5;
    public const uint GL_UNSIGNED_INT_SAMPLER_BUFFER = 0x8DD8;
    public const uint GL_TEXTURE_BUFFER = 0x8C2A;
    public const uint GL_MAX_TEXTURE_BUFFER_SIZE = 0x8C2B;
    public const uint GL_TEXTURE_BINDING_BUFFER = 0x8C2C;
    public const uint GL_TEXTURE_BUFFER_DATA_STORE_BINDING = 0x8C2D;
    public const uint GL_TEXTURE_RECTANGLE = 0x84F5;
    public const uint GL_TEXTURE_BINDING_RECTANGLE = 0x84F6;
    public const uint GL_PROXY_TEXTURE_RECTANGLE = 0x84F7;
    public const uint GL_MAX_RECTANGLE_TEXTURE_SIZE = 0x84F8;
    public const uint GL_R8_SNORM = 0x8F94;
    public const uint GL_RG8_SNORM = 0x8F95;
    public const uint GL_RGB8_SNORM = 0x8F96;
    public const uint GL_RGBA8_SNORM = 0x8F97;
    public const uint GL_R16_SNORM = 0x8F98;
    public const uint GL_RG16_SNORM = 0x8F99;
    public const uint GL_RGB16_SNORM = 0x8F9A;
    public const uint GL_RGBA16_SNORM = 0x8F9B;
    public const uint GL_SIGNED_NORMALIZED = 0x8F9C;
    public const uint GL_PRIMITIVE_RESTART = 0x8F9D;
    public const uint GL_PRIMITIVE_RESTART_INDEX = 0x8F9E;
    public const uint GL_COPY_READ_BUFFER = 0x8F36;
    public const uint GL_COPY_WRITE_BUFFER = 0x8F37;
    public const uint GL_UNIFORM_BUFFER = 0x8A11;
    public const uint GL_UNIFORM_BUFFER_BINDING = 0x8A28;
    public const uint GL_UNIFORM_BUFFER_START = 0x8A29;
    public const uint GL_UNIFORM_BUFFER_SIZE = 0x8A2A;
    public const uint GL_MAX_VERTEX_UNIFORM_BLOCKS = 0x8A2B;
    public const uint GL_MAX_FRAGMENT_UNIFORM_BLOCKS = 0x8A2D;
    public const uint GL_MAX_COMBINED_UNIFORM_BLOCKS = 0x8A2E;
    public const uint GL_MAX_UNIFORM_BUFFER_BINDINGS = 0x8A2F;
    public const uint GL_MAX_UNIFORM_BLOCK_SIZE = 0x8A30;
    public const uint GL_MAX_COMBINED_VERTEX_UNIFORM_COMPONENTS = 0x8A31;
    public const uint GL_MAX_COMBINED_FRAGMENT_UNIFORM_COMPONENTS = 0x8A33;
    public const uint GL_UNIFORM_BUFFER_OFFSET_ALIGNMENT = 0x8A34;
    public const uint GL_ACTIVE_UNIFORM_BLOCK_MAX_NAME_LENGTH = 0x8A35;
    public const uint GL_ACTIVE_UNIFORM_BLOCKS = 0x8A36;
    public const uint GL_UNIFORM_TYPE = 0x8A37;
    public const uint GL_UNIFORM_SIZE = 0x8A38;
    public const uint GL_UNIFORM_NAME_LENGTH = 0x8A39;
    public const uint GL_UNIFORM_BLOCK_INDEX = 0x8A3A;
    public const uint GL_UNIFORM_OFFSET = 0x8A3B;
    public const uint GL_UNIFORM_ARRAY_STRIDE = 0x8A3C;
    public const uint GL_UNIFORM_MATRIX_STRIDE = 0x8A3D;
    public const uint GL_UNIFORM_IS_ROW_MAJOR = 0x8A3E;
    public const uint GL_UNIFORM_BLOCK_BINDING = 0x8A3F;
    public const uint GL_UNIFORM_BLOCK_DATA_SIZE = 0x8A40;
    public const uint GL_UNIFORM_BLOCK_NAME_LENGTH = 0x8A41;
    public const uint GL_UNIFORM_BLOCK_ACTIVE_UNIFORMS = 0x8A42;
    public const uint GL_UNIFORM_BLOCK_ACTIVE_UNIFORM_INDICES = 0x8A43;
    public const uint GL_UNIFORM_BLOCK_REFERENCED_BY_VERTEX_SHADER = 0x8A44;
    public const uint GL_UNIFORM_BLOCK_REFERENCED_BY_FRAGMENT_SHADER = 0x8A46;
    public const uint GL_INVALID_INDEX = 0xFFFFFFFF;
    
    private delegate void PFNGLDRAWARRAYSINSTANCEDPROC(uint mode, int first, uint count, uint instancecount);
    private delegate void PFNGLDRAWELEMENTSINSTANCEDPROC(uint mode, uint count, uint type, const void *indices, uint instancecount);
    private delegate void PFNGLTEXBUFFERPROC(uint target, uint internalformat, uint buffer);
    private delegate void PFNGLPRIMITIVERESTARTINDEXPROC(uint index);
    private delegate void PFNGLCOPYBUFFERSUBDATAPROC(uint readTarget, uint writeTarget, intptr readOffset, intptr writeOffset, uintptr size);
    private delegate void PFNGLGETUNIFORMINDICESPROC(uint program, uint uniformCount, const byte *const*uniformNames, uint *uniformIndices);
    private delegate void PFNGLGETACTIVEUNIFORMSIVPROC(uint program, uint uniformCount, const uint *uniformIndices, uint pname, int *params);
    private delegate void PFNGLGETACTIVEUNIFORMNAMEPROC(uint program, uint uniformIndex, uint bufSize, uint *length, byte *uniformName);
    private delegate uint PFNGLGETUNIFORMBLOCKINDEXPROC(uint program, const byte *uniformBlockName);
    private delegate void PFNGLGETACTIVEUNIFORMBLOCKIVPROC(uint program, uint uniformBlockIndex, uint pname, int *params);
    private delegate void PFNGLGETACTIVEUNIFORMBLOCKNAMEPROC(uint program, uint uniformBlockIndex, uint bufSize, uint *length, byte *uniformBlockName);
    private delegate void PFNGLUNIFORMBLOCKBINDINGPROC(uint program, uint uniformBlockIndex, uint uniformBlockBinding);

    public static void glDrawArraysInstanced(uint mode, int first, uint count, uint instancecount);
    public static void glDrawElementsInstanced(uint mode, uint count, uint type, const void *indices, uint instancecount);
    public static void glTexBuffer(uint target, uint internalformat, uint buffer);
    public static void glPrimitiveRestartIndex(uint index);
    public static void glCopyBufferSubData(uint readTarget, uint writeTarget, intptr readOffset, intptr writeOffset, uintptr size);
    public static void glGetUniformIndices(uint program, uint uniformCount, const byte *const*uniformNames, uint *uniformIndices);
    public static void glGetActiveUniformsiv(uint program, uint uniformCount, const uint *uniformIndices, uint pname, int *params);
    public static void glGetActiveUniformName(uint program, uint uniformIndex, uint bufSize, uint *length, byte *uniformName);
    public static uint glGetUniformBlockIndex(uint program, const byte *uniformBlockName);
    public static void glGetActiveUniformBlockiv(uint program, uint uniformBlockIndex, uint pname, int *params);
    public static void glGetActiveUniformBlockName(uint program, uint uniformBlockIndex, uint bufSize, uint *length, byte *uniformBlockName);
    public static void glUniformBlockBinding(uint program, uint uniformBlockIndex, uint uniformBlockBinding);
    #endregion

    #region GL_VERSION_3_2
    //typedef struct __GLsync *GLsync;
    public const uint GL_CONTEXT_CORE_PROFILE_BIT = 0x00000001;
    public const uint GL_CONTEXT_COMPATIBILITY_PROFILE_BIT = 0x00000002;
    public const uint GL_LINES_ADJACENCY = 0x000A;
    public const uint GL_LINE_STRIP_ADJACENCY = 0x000B;
    public const uint GL_TRIANGLES_ADJACENCY = 0x000C;
    public const uint GL_TRIANGLE_STRIP_ADJACENCY = 0x000D;
    public const uint GL_PROGRAM_POINT_SIZE = 0x8642;
    public const uint GL_MAX_GEOMETRY_TEXTURE_IMAGE_UNITS = 0x8C29;
    public const uint GL_FRAMEBUFFER_ATTACHMENT_LAYERED = 0x8DA7;
    public const uint GL_FRAMEBUFFER_INCOMPLETE_LAYER_TARGETS = 0x8DA8;
    public const uint GL_GEOMETRY_SHADER = 0x8DD9;
    public const uint GL_GEOMETRY_VERTICES_OUT = 0x8916;
    public const uint GL_GEOMETRY_INPUT_TYPE = 0x8917;
    public const uint GL_GEOMETRY_OUTPUT_TYPE = 0x8918;
    public const uint GL_MAX_GEOMETRY_UNIFORM_COMPONENTS = 0x8DDF;
    public const uint GL_MAX_GEOMETRY_OUTPUT_VERTICES = 0x8DE0;
    public const uint GL_MAX_GEOMETRY_TOTAL_OUTPUT_COMPONENTS = 0x8DE1;
    public const uint GL_MAX_VERTEX_OUTPUT_COMPONENTS = 0x9122;
    public const uint GL_MAX_GEOMETRY_INPUT_COMPONENTS = 0x9123;
    public const uint GL_MAX_GEOMETRY_OUTPUT_COMPONENTS = 0x9124;
    public const uint GL_MAX_FRAGMENT_INPUT_COMPONENTS = 0x9125;
    public const uint GL_CONTEXT_PROFILE_MASK = 0x9126;
    public const uint GL_DEPTH_CLAMP = 0x864F;
    public const uint GL_QUADS_FOLLOW_PROVOKING_VERTEX_CONVENTION = 0x8E4C;
    public const uint GL_FIRST_VERTEX_CONVENTION = 0x8E4D;
    public const uint GL_LAST_VERTEX_CONVENTION = 0x8E4E;
    public const uint GL_PROVOKING_VERTEX = 0x8E4F;
    public const uint GL_TEXTURE_CUBE_MAP_SEAMLESS = 0x884F;
    public const uint GL_MAX_SERVER_WAIT_TIMEOUT = 0x9111;
    public const uint GL_OBJECT_TYPE = 0x9112;
    public const uint GL_SYNC_CONDITION = 0x9113;
    public const uint GL_SYNC_STATUS = 0x9114;
    public const uint GL_SYNC_FLAGS = 0x9115;
    public const uint GL_SYNC_FENCE = 0x9116;
    public const uint GL_SYNC_GPU_COMMANDS_COMPLETE = 0x9117;
    public const uint GL_UNSIGNALED = 0x9118;
    public const uint GL_SIGNALED = 0x9119;
    public const uint GL_ALREADY_SIGNALED = 0x911A;
    public const uint GL_TIMEOUT_EXPIRED = 0x911B;
    public const uint GL_CONDITION_SATISFIED = 0x911C;
    public const uint GL_WAIT_FAILED = 0x911D;
    public const uint GL_TIMEOUT_IGNORED = 0xFFFFFFFFFFFFFFFF;ull
    public const uint GL_SYNC_FLUSH_COMMANDS_BIT = 0x00000001;
    public const uint GL_SAMPLE_POSITION = 0x8E50;
    public const uint GL_SAMPLE_MASK = 0x8E51;
    public const uint GL_SAMPLE_MASK_VALUE = 0x8E52;
    public const uint GL_MAX_SAMPLE_MASK_WORDS = 0x8E59;
    public const uint GL_TEXTURE_2D_MULTISAMPLE = 0x9100;
    public const uint GL_PROXY_TEXTURE_2D_MULTISAMPLE = 0x9101;
    public const uint GL_TEXTURE_2D_MULTISAMPLE_ARRAY = 0x9102;
    public const uint GL_PROXY_TEXTURE_2D_MULTISAMPLE_ARRAY = 0x9103;
    public const uint GL_TEXTURE_BINDING_2D_MULTISAMPLE = 0x9104;
    public const uint GL_TEXTURE_BINDING_2D_MULTISAMPLE_ARRAY = 0x9105;
    public const uint GL_TEXTURE_SAMPLES = 0x9106;
    public const uint GL_TEXTURE_FIXED_SAMPLE_LOCATIONS = 0x9107;
    public const uint GL_SAMPLER_2D_MULTISAMPLE = 0x9108;
    public const uint GL_INT_SAMPLER_2D_MULTISAMPLE = 0x9109;
    public const uint GL_UNSIGNED_INT_SAMPLER_2D_MULTISAMPLE = 0x910A;
    public const uint GL_SAMPLER_2D_MULTISAMPLE_ARRAY = 0x910B;
    public const uint GL_INT_SAMPLER_2D_MULTISAMPLE_ARRAY = 0x910C;
    public const uint GL_UNSIGNED_INT_SAMPLER_2D_MULTISAMPLE_ARRAY = 0x910D;
    public const uint GL_MAX_COLOR_TEXTURE_SAMPLES = 0x910E;
    public const uint GL_MAX_DEPTH_TEXTURE_SAMPLES = 0x910F;
    public const uint GL_MAX_INTEGER_SAMPLES = 0x9110;
    private delegate void PFNGLDRAWELEMENTSBASEVERTEXPROC(uint mode, uint count, uint type, const void *indices, int basevertex);
    private delegate void PFNGLDRAWRANGEELEMENTSBASEVERTEXPROC(uint mode, uint start, uint end, uint count, uint type, const void *indices, int basevertex);
    private delegate void PFNGLDRAWELEMENTSINSTANCEDBASEVERTEXPROC(uint mode, uint count, uint type, const void *indices, uint instancecount, int basevertex);
    private delegate void PFNGLMULTIDRAWELEMENTSBASEVERTEXPROC(uint mode, const uint *count, uint type, const void *const*indices, uint drawcount, const int *basevertex);
    private delegate void PFNGLPROVOKINGVERTEXPROC(uint mode);
    //private delegate GLsync PFNGLFENCESYNCPROC(uint condition, uint flags);
    //private delegate bool PFNGLISSYNCPROC(GLsync sync);
    //private delegate void PFNGLDELETESYNCPROC(GLsync sync);
    //private delegate uint PFNGLCLIENTWAITSYNCPROC(GLsync sync, uint flags, ulong timeout);
    //private delegate void PFNGLWAITSYNCPROC(GLsync sync, uint flags, ulong timeout);
    private delegate void PFNGLGETINTEGER64VPROC(uint pname, long *params);
    //private delegate void PFNGLGETSYNCIVPROC(GLsync sync, uint pname, uint bufSize, uint *length, int *values);
    private delegate void PFNGLGETINTEGER64I_VPROC(uint target, uint index, long *data);
    private delegate void PFNGLGETBUFFERPARAMETERI64VPROC(uint target, uint pname, long *params);
    private delegate void PFNGLFRAMEBUFFERTEXTUREPROC(uint target, uint attachment, uint texture, int level);
    private delegate void PFNGLTEXIMAGE2DMULTISAMPLEPROC(uint target, uint samples, uint internalformat, uint width, uint height, bool fixedsamplelocations);
    private delegate void PFNGLTEXIMAGE3DMULTISAMPLEPROC(uint target, uint samples, uint internalformat, uint width, uint height, uint depth, bool fixedsamplelocations);
    private delegate void PFNGLGETMULTISAMPLEFVPROC(uint pname, uint index, float *val);
    private delegate void PFNGLSAMPLEMASKIPROC(uint index, uint mask);

    public static void glDrawElementsBaseVertex(uint mode, uint count, uint type, const void *indices, int basevertex);
    public static void glDrawRangeElementsBaseVertex(uint mode, uint start, uint end, uint count, uint type, const void *indices, int basevertex);
    public static void glDrawElementsInstancedBaseVertex(uint mode, uint count, uint type, const void *indices, uint instancecount, int basevertex);
    public static void glMultiDrawElementsBaseVertex(uint mode, const uint *count, uint type, const void *const*indices, uint drawcount, const int *basevertex);
    public static void glProvokingVertex(uint mode);
    //public static GLsync glFenceSync(uint condition, uint flags);
    //public static bool glIsSync(GLsync sync);
    //public static void glDeleteSync(GLsync sync);
    //public static uint glClientWaitSync(GLsync sync, uint flags, ulong timeout);
    //public static void glWaitSync(GLsync sync, uint flags, ulong timeout);
    public static void glGetInteger64v(uint pname, long *params);
    //public static void glGetSynciv(GLsync sync, uint pname, uint bufSize, uint *length, int *values);
    public static void glGetInteger64i_v(uint target, uint index, long *data);
    public static void glGetBufferParameteri64v(uint target, uint pname, long *params);
    public static void glFramebufferTexture(uint target, uint attachment, uint texture, int level);
    public static void glTexImage2DMultisample(uint target, uint samples, uint internalformat, uint width, uint height, bool fixedsamplelocations);
    public static void glTexImage3DMultisample(uint target, uint samples, uint internalformat, uint width, uint height, uint depth, bool fixedsamplelocations);
    public static void glGetMultisamplefv(uint pname, uint index, float *val);
    public static void glSampleMaski(uint index, uint mask);
    #endregion

    #region GL_VERSION_3_3
    public const uint GL_VERTEX_ATTRIB_ARRAY_DIVISOR = 0x88FE;
    public const uint GL_SRC1_COLOR = 0x88F9;
    public const uint GL_ONE_MINUS_SRC1_COLOR = 0x88FA;
    public const uint GL_ONE_MINUS_SRC1_ALPHA = 0x88FB;
    public const uint GL_MAX_DUAL_SOURCE_DRAW_BUFFERS = 0x88FC;
    public const uint GL_ANY_SAMPLES_PASSED = 0x8C2F;
    public const uint GL_SAMPLER_BINDING = 0x8919;
    public const uint GL_RGB10_A2UI = 0x906F;
    public const uint GL_TEXTURE_SWIZZLE_R = 0x8E42;
    public const uint GL_TEXTURE_SWIZZLE_G = 0x8E43;
    public const uint GL_TEXTURE_SWIZZLE_B = 0x8E44;
    public const uint GL_TEXTURE_SWIZZLE_A = 0x8E45;
    public const uint GL_TEXTURE_SWIZZLE_RGBA = 0x8E46;
    public const uint GL_TIME_ELAPSED = 0x88BF;
    public const uint GL_TIMESTAMP = 0x8E28;
    public const uint GL_INT_2_10_10_10_REV = 0x8D9F;
    
    private delegate void PFNGLBINDFRAGDATALOCATIONINDEXEDPROC(uint program, uint colorNumber, uint index, const byte *name);
    private delegate int PFNGLGETFRAGDATAINDEXPROC(uint program, const byte *name);
    private delegate void PFNGLGENSAMPLERSPROC(uint count, uint *samplers);
    private delegate void PFNGLDELETESAMPLERSPROC(uint count, const uint *samplers);
    private delegate bool PFNGLISSAMPLERPROC(uint sampler);
    private delegate void PFNGLBINDSAMPLERPROC(uint unit, uint sampler);
    private delegate void PFNGLSAMPLERPARAMETERIPROC(uint sampler, uint pname, int param);
    private delegate void PFNGLSAMPLERPARAMETERIVPROC(uint sampler, uint pname, const int *param);
    private delegate void PFNGLSAMPLERPARAMETERFPROC(uint sampler, uint pname, float param);
    private delegate void PFNGLSAMPLERPARAMETERFVPROC(uint sampler, uint pname, const float *param);
    private delegate void PFNGLSAMPLERPARAMETERIIVPROC(uint sampler, uint pname, const int *param);
    private delegate void PFNGLSAMPLERPARAMETERIUIVPROC(uint sampler, uint pname, const uint *param);
    private delegate void PFNGLGETSAMPLERPARAMETERIVPROC(uint sampler, uint pname, int *params);
    private delegate void PFNGLGETSAMPLERPARAMETERIIVPROC(uint sampler, uint pname, int *params);
    private delegate void PFNGLGETSAMPLERPARAMETERFVPROC(uint sampler, uint pname, float *params);
    private delegate void PFNGLGETSAMPLERPARAMETERIUIVPROC(uint sampler, uint pname, uint *params);
    private delegate void PFNGLQUERYCOUNTERPROC(uint id, uint target);
    private delegate void PFNGLGETQUERYOBJECTI64VPROC(uint id, uint pname, long *params);
    private delegate void PFNGLGETQUERYOBJECTUI64VPROC(uint id, uint pname, ulong *params);
    private delegate void PFNGLVERTEXATTRIBDIVISORPROC(uint index, uint divisor);
    private delegate void PFNGLVERTEXATTRIBP1UIPROC(uint index, uint type, bool normalized, uint value);
    private delegate void PFNGLVERTEXATTRIBP1UIVPROC(uint index, uint type, bool normalized, const uint *value);
    private delegate void PFNGLVERTEXATTRIBP2UIPROC(uint index, uint type, bool normalized, uint value);
    private delegate void PFNGLVERTEXATTRIBP2UIVPROC(uint index, uint type, bool normalized, const uint *value);
    private delegate void PFNGLVERTEXATTRIBP3UIPROC(uint index, uint type, bool normalized, uint value);
    private delegate void PFNGLVERTEXATTRIBP3UIVPROC(uint index, uint type, bool normalized, const uint *value);
    private delegate void PFNGLVERTEXATTRIBP4UIPROC(uint index, uint type, bool normalized, uint value);
    private delegate void PFNGLVERTEXATTRIBP4UIVPROC(uint index, uint type, bool normalized, const uint *value);
    private delegate void PFNGLVERTEXP2UIPROC(uint type, uint value);
    private delegate void PFNGLVERTEXP2UIVPROC(uint type, const uint *value);
    private delegate void PFNGLVERTEXP3UIPROC(uint type, uint value);
    private delegate void PFNGLVERTEXP3UIVPROC(uint type, const uint *value);
    private delegate void PFNGLVERTEXP4UIPROC(uint type, uint value);
    private delegate void PFNGLVERTEXP4UIVPROC(uint type, const uint *value);
    private delegate void PFNGLTEXCOORDP1UIPROC(uint type, uint coords);
    private delegate void PFNGLTEXCOORDP1UIVPROC(uint type, const uint *coords);
    private delegate void PFNGLTEXCOORDP2UIPROC(uint type, uint coords);
    private delegate void PFNGLTEXCOORDP2UIVPROC(uint type, const uint *coords);
    private delegate void PFNGLTEXCOORDP3UIPROC(uint type, uint coords);
    private delegate void PFNGLTEXCOORDP3UIVPROC(uint type, const uint *coords);
    private delegate void PFNGLTEXCOORDP4UIPROC(uint type, uint coords);
    private delegate void PFNGLTEXCOORDP4UIVPROC(uint type, const uint *coords);
    private delegate void PFNGLMULTITEXCOORDP1UIPROC(uint texture, uint type, uint coords);
    private delegate void PFNGLMULTITEXCOORDP1UIVPROC(uint texture, uint type, const uint *coords);
    private delegate void PFNGLMULTITEXCOORDP2UIPROC(uint texture, uint type, uint coords);
    private delegate void PFNGLMULTITEXCOORDP2UIVPROC(uint texture, uint type, const uint *coords);
    private delegate void PFNGLMULTITEXCOORDP3UIPROC(uint texture, uint type, uint coords);
    private delegate void PFNGLMULTITEXCOORDP3UIVPROC(uint texture, uint type, const uint *coords);
    private delegate void PFNGLMULTITEXCOORDP4UIPROC(uint texture, uint type, uint coords);
    private delegate void PFNGLMULTITEXCOORDP4UIVPROC(uint texture, uint type, const uint *coords);
    private delegate void PFNGLNORMALP3UIPROC(uint type, uint coords);
    private delegate void PFNGLNORMALP3UIVPROC(uint type, const uint *coords);
    private delegate void PFNGLCOLORP3UIPROC(uint type, uint color);
    private delegate void PFNGLCOLORP3UIVPROC(uint type, const uint *color);
    private delegate void PFNGLCOLORP4UIPROC(uint type, uint color);
    private delegate void PFNGLCOLORP4UIVPROC(uint type, const uint *color);
    private delegate void PFNGLSECONDARYCOLORP3UIPROC(uint type, uint color);
    private delegate void PFNGLSECONDARYCOLORP3UIVPROC(uint type, const uint *color);

    public static void glBindFragDataLocationIndexed(uint program, uint colorNumber, uint index, const byte *name);
    public static int glGetFragDataIndex(uint program, const byte *name);
    public static void glGenSamplers(uint count, uint *samplers);
    public static void glDeleteSamplers(uint count, const uint *samplers);
    public static bool glIsSampler(uint sampler);
    public static void glBindSampler(uint unit, uint sampler);
    public static void glSamplerParameteri(uint sampler, uint pname, int param);
    public static void glSamplerParameteriv(uint sampler, uint pname, const int *param);
    public static void glSamplerParameterf(uint sampler, uint pname, float param);
    public static void glSamplerParameterfv(uint sampler, uint pname, const float *param);
    public static void glSamplerParameterIiv(uint sampler, uint pname, const int *param);
    public static void glSamplerParameterIuiv(uint sampler, uint pname, const uint *param);
    public static void glGetSamplerParameteriv(uint sampler, uint pname, int *params);
    public static void glGetSamplerParameterIiv(uint sampler, uint pname, int *params);
    public static void glGetSamplerParameterfv(uint sampler, uint pname, float *params);
    public static void glGetSamplerParameterIuiv(uint sampler, uint pname, uint *params);
    public static void glQueryCounter(uint id, uint target);
    public static void glGetQueryObjecti64v(uint id, uint pname, long *params);
    public static void glGetQueryObjectui64v(uint id, uint pname, ulong *params);
    public static void glVertexAttribDivisor(uint index, uint divisor);
    public static void glVertexAttribP1ui(uint index, uint type, bool normalized, uint value);
    public static void glVertexAttribP1uiv(uint index, uint type, bool normalized, const uint *value);
    public static void glVertexAttribP2ui(uint index, uint type, bool normalized, uint value);
    public static void glVertexAttribP2uiv(uint index, uint type, bool normalized, const uint *value);
    public static void glVertexAttribP3ui(uint index, uint type, bool normalized, uint value);
    public static void glVertexAttribP3uiv(uint index, uint type, bool normalized, const uint *value);
    public static void glVertexAttribP4ui(uint index, uint type, bool normalized, uint value);
    public static void glVertexAttribP4uiv(uint index, uint type, bool normalized, const uint *value);
    public static void glVertexP2ui(uint type, uint value);
    public static void glVertexP2uiv(uint type, const uint *value);
    public static void glVertexP3ui(uint type, uint value);
    public static void glVertexP3uiv(uint type, const uint *value);
    public static void glVertexP4ui(uint type, uint value);
    public static void glVertexP4uiv(uint type, const uint *value);
    public static void glTexCoordP1ui(uint type, uint coords);
    public static void glTexCoordP1uiv(uint type, const uint *coords);
    public static void glTexCoordP2ui(uint type, uint coords);
    public static void glTexCoordP2uiv(uint type, const uint *coords);
    public static void glTexCoordP3ui(uint type, uint coords);
    public static void glTexCoordP3uiv(uint type, const uint *coords);
    public static void glTexCoordP4ui(uint type, uint coords);
    public static void glTexCoordP4uiv(uint type, const uint *coords);
    public static void glMultiTexCoordP1ui(uint texture, uint type, uint coords);
    public static void glMultiTexCoordP1uiv(uint texture, uint type, const uint *coords);
    public static void glMultiTexCoordP2ui(uint texture, uint type, uint coords);
    public static void glMultiTexCoordP2uiv(uint texture, uint type, const uint *coords);
    public static void glMultiTexCoordP3ui(uint texture, uint type, uint coords);
    public static void glMultiTexCoordP3uiv(uint texture, uint type, const uint *coords);
    public static void glMultiTexCoordP4ui(uint texture, uint type, uint coords);
    public static void glMultiTexCoordP4uiv(uint texture, uint type, const uint *coords);
    public static void glNormalP3ui(uint type, uint coords);
    public static void glNormalP3uiv(uint type, const uint *coords);
    public static void glColorP3ui(uint type, uint color);
    public static void glColorP3uiv(uint type, const uint *color);
    public static void glColorP4ui(uint type, uint color);
    public static void glColorP4uiv(uint type, const uint *color);
    public static void glSecondaryColorP3ui(uint type, uint color);
    public static void glSecondaryColorP3uiv(uint type, const uint *color);
    #endregion

    #region GL_VERSION_4_0
    public const uint GL_SAMPLE_SHADING = 0x8C36;
    public const uint GL_MIN_SAMPLE_SHADING_VALUE = 0x8C37;
    public const uint GL_MIN_PROGRAM_TEXTURE_GATHER_OFFSET = 0x8E5E;
    public const uint GL_MAX_PROGRAM_TEXTURE_GATHER_OFFSET = 0x8E5F;
    public const uint GL_TEXTURE_CUBE_MAP_ARRAY = 0x9009;
    public const uint GL_TEXTURE_BINDING_CUBE_MAP_ARRAY = 0x900A;
    public const uint GL_PROXY_TEXTURE_CUBE_MAP_ARRAY = 0x900B;
    public const uint GL_SAMPLER_CUBE_MAP_ARRAY = 0x900C;
    public const uint GL_SAMPLER_CUBE_MAP_ARRAY_SHADOW = 0x900D;
    public const uint GL_INT_SAMPLER_CUBE_MAP_ARRAY = 0x900E;
    public const uint GL_UNSIGNED_INT_SAMPLER_CUBE_MAP_ARRAY = 0x900F;
    public const uint GL_DRAW_INDIRECT_BUFFER = 0x8F3F;
    public const uint GL_DRAW_INDIRECT_BUFFER_BINDING = 0x8F43;
    public const uint GL_GEOMETRY_SHADER_INVOCATIONS = 0x887F;
    public const uint GL_MAX_GEOMETRY_SHADER_INVOCATIONS = 0x8E5A;
    public const uint GL_MIN_FRAGMENT_INTERPOLATION_OFFSET = 0x8E5B;
    public const uint GL_MAX_FRAGMENT_INTERPOLATION_OFFSET = 0x8E5C;
    public const uint GL_FRAGMENT_INTERPOLATION_OFFSET_BITS = 0x8E5D;
    public const uint GL_MAX_VERTEX_STREAMS = 0x8E71;
    public const uint GL_DOUBLE_VEC2 = 0x8FFC;
    public const uint GL_DOUBLE_VEC3 = 0x8FFD;
    public const uint GL_DOUBLE_VEC4 = 0x8FFE;
    public const uint GL_DOUBLE_MAT2 = 0x8F46;
    public const uint GL_DOUBLE_MAT3 = 0x8F47;
    public const uint GL_DOUBLE_MAT4 = 0x8F48;
    public const uint GL_DOUBLE_MAT2x3 = 0x8F49;
    public const uint GL_DOUBLE_MAT2x4 = 0x8F4A;
    public const uint GL_DOUBLE_MAT3x2 = 0x8F4B;
    public const uint GL_DOUBLE_MAT3x4 = 0x8F4C;
    public const uint GL_DOUBLE_MAT4x2 = 0x8F4D;
    public const uint GL_DOUBLE_MAT4x3 = 0x8F4E;
    public const uint GL_ACTIVE_SUBROUTINES = 0x8DE5;
    public const uint GL_ACTIVE_SUBROUTINE_UNIFORMS = 0x8DE6;
    public const uint GL_ACTIVE_SUBROUTINE_UNIFORM_LOCATIONS = 0x8E47;
    public const uint GL_ACTIVE_SUBROUTINE_MAX_LENGTH = 0x8E48;
    public const uint GL_ACTIVE_SUBROUTINE_UNIFORM_MAX_LENGTH = 0x8E49;
    public const uint GL_MAX_SUBROUTINES = 0x8DE7;
    public const uint GL_MAX_SUBROUTINE_UNIFORM_LOCATIONS = 0x8DE8;
    public const uint GL_NUM_COMPATIBLE_SUBROUTINES = 0x8E4A;
    public const uint GL_COMPATIBLE_SUBROUTINES = 0x8E4B;
    public const uint GL_PATCHES = 0x000E;
    public const uint GL_PATCH_VERTICES = 0x8E72;
    public const uint GL_PATCH_DEFAULT_INNER_LEVEL = 0x8E73;
    public const uint GL_PATCH_DEFAULT_OUTER_LEVEL = 0x8E74;
    public const uint GL_TESS_CONTROL_OUTPUT_VERTICES = 0x8E75;
    public const uint GL_TESS_GEN_MODE = 0x8E76;
    public const uint GL_TESS_GEN_SPACING = 0x8E77;
    public const uint GL_TESS_GEN_VERTEX_ORDER = 0x8E78;
    public const uint GL_TESS_GEN_POINT_MODE = 0x8E79;
    public const uint GL_ISOLINES = 0x8E7A;
    public const uint GL_FRACTIONAL_ODD = 0x8E7B;
    public const uint GL_FRACTIONAL_EVEN = 0x8E7C;
    public const uint GL_MAX_PATCH_VERTICES = 0x8E7D;
    public const uint GL_MAX_TESS_GEN_LEVEL = 0x8E7E;
    public const uint GL_MAX_TESS_CONTROL_UNIFORM_COMPONENTS = 0x8E7F;
    public const uint GL_MAX_TESS_EVALUATION_UNIFORM_COMPONENTS = 0x8E80;
    public const uint GL_MAX_TESS_CONTROL_TEXTURE_IMAGE_UNITS = 0x8E81;
    public const uint GL_MAX_TESS_EVALUATION_TEXTURE_IMAGE_UNITS = 0x8E82;
    public const uint GL_MAX_TESS_CONTROL_OUTPUT_COMPONENTS = 0x8E83;
    public const uint GL_MAX_TESS_PATCH_COMPONENTS = 0x8E84;
    public const uint GL_MAX_TESS_CONTROL_TOTAL_OUTPUT_COMPONENTS = 0x8E85;
    public const uint GL_MAX_TESS_EVALUATION_OUTPUT_COMPONENTS = 0x8E86;
    public const uint GL_MAX_TESS_CONTROL_UNIFORM_BLOCKS = 0x8E89;
    public const uint GL_MAX_TESS_EVALUATION_UNIFORM_BLOCKS = 0x8E8A;
    public const uint GL_MAX_TESS_CONTROL_INPUT_COMPONENTS = 0x886C;
    public const uint GL_MAX_TESS_EVALUATION_INPUT_COMPONENTS = 0x886D;
    public const uint GL_MAX_COMBINED_TESS_CONTROL_UNIFORM_COMPONENTS = 0x8E1E;
    public const uint GL_MAX_COMBINED_TESS_EVALUATION_UNIFORM_COMPONENTS = 0x8E1F;
    public const uint GL_UNIFORM_BLOCK_REFERENCED_BY_TESS_CONTROL_SHADER = 0x84F0;
    public const uint GL_UNIFORM_BLOCK_REFERENCED_BY_TESS_EVALUATION_SHADER = 0x84F1;
    public const uint GL_TESS_EVALUATION_SHADER = 0x8E87;
    public const uint GL_TESS_CONTROL_SHADER = 0x8E88;
    public const uint GL_TRANSFORM_FEEDBACK = 0x8E22;
    public const uint GL_TRANSFORM_FEEDBACK_BUFFER_PAUSED = 0x8E23;
    public const uint GL_TRANSFORM_FEEDBACK_BUFFER_ACTIVE = 0x8E24;
    public const uint GL_TRANSFORM_FEEDBACK_BINDING = 0x8E25;
    public const uint GL_MAX_TRANSFORM_FEEDBACK_BUFFERS = 0x8E70;
    
    private delegate void PFNGLMINSAMPLESHADINGPROC(float value);
    private delegate void PFNGLBLENDEQUATIONIPROC(uint buf, uint mode);
    private delegate void PFNGLBLENDEQUATIONSEPARATEIPROC(uint buf, uint modeRGB, uint modeAlpha);
    private delegate void PFNGLBLENDFUNCIPROC(uint buf, uint src, uint dst);
    private delegate void PFNGLBLENDFUNCSEPARATEIPROC(uint buf, uint srcRGB, uint dstRGB, uint srcAlpha, uint dstAlpha);
    private delegate void PFNGLDRAWARRAYSINDIRECTPROC(uint mode, const void *indirect);
    private delegate void PFNGLDRAWELEMENTSINDIRECTPROC(uint mode, uint type, const void *indirect);
    private delegate void PFNGLUNIFORM1DPROC(int location, double x);
    private delegate void PFNGLUNIFORM2DPROC(int location, double x, double y);
    private delegate void PFNGLUNIFORM3DPROC(int location, double x, double y, double z);
    private delegate void PFNGLUNIFORM4DPROC(int location, double x, double y, double z, double w);
    private delegate void PFNGLUNIFORM1DVPROC(int location, uint count, const double *value);
    private delegate void PFNGLUNIFORM2DVPROC(int location, uint count, const double *value);
    private delegate void PFNGLUNIFORM3DVPROC(int location, uint count, const double *value);
    private delegate void PFNGLUNIFORM4DVPROC(int location, uint count, const double *value);
    private delegate void PFNGLUNIFORMMATRIX2DVPROC(int location, uint count, bool transpose, const double *value);
    private delegate void PFNGLUNIFORMMATRIX3DVPROC(int location, uint count, bool transpose, const double *value);
    private delegate void PFNGLUNIFORMMATRIX4DVPROC(int location, uint count, bool transpose, const double *value);
    private delegate void PFNGLUNIFORMMATRIX2X3DVPROC(int location, uint count, bool transpose, const double *value);
    private delegate void PFNGLUNIFORMMATRIX2X4DVPROC(int location, uint count, bool transpose, const double *value);
    private delegate void PFNGLUNIFORMMATRIX3X2DVPROC(int location, uint count, bool transpose, const double *value);
    private delegate void PFNGLUNIFORMMATRIX3X4DVPROC(int location, uint count, bool transpose, const double *value);
    private delegate void PFNGLUNIFORMMATRIX4X2DVPROC(int location, uint count, bool transpose, const double *value);
    private delegate void PFNGLUNIFORMMATRIX4X3DVPROC(int location, uint count, bool transpose, const double *value);
    private delegate void PFNGLGETUNIFORMDVPROC(uint program, int location, double *params);
    private delegate int PFNGLGETSUBROUTINEUNIFORMLOCATIONPROC(uint program, uint shadertype, const byte *name);
    private delegate uint PFNGLGETSUBROUTINEINDEXPROC(uint program, uint shadertype, const byte *name);
    private delegate void PFNGLGETACTIVESUBROUTINEUNIFORMIVPROC(uint program, uint shadertype, uint index, uint pname, int *values);
    private delegate void PFNGLGETACTIVESUBROUTINEUNIFORMNAMEPROC(uint program, uint shadertype, uint index, uint bufsize, uint *length, byte *name);
    private delegate void PFNGLGETACTIVESUBROUTINENAMEPROC(uint program, uint shadertype, uint index, uint bufsize, uint *length, byte *name);
    private delegate void PFNGLUNIFORMSUBROUTINESUIVPROC(uint shadertype, uint count, const uint *indices);
    private delegate void PFNGLGETUNIFORMSUBROUTINEUIVPROC(uint shadertype, int location, uint *params);
    private delegate void PFNGLGETPROGRAMSTAGEIVPROC(uint program, uint shadertype, uint pname, int *values);
    private delegate void PFNGLPATCHPARAMETERIPROC(uint pname, int value);
    private delegate void PFNGLPATCHPARAMETERFVPROC(uint pname, const float *values);
    private delegate void PFNGLBINDTRANSFORMFEEDBACKPROC(uint target, uint id);
    private delegate void PFNGLDELETETRANSFORMFEEDBACKSPROC(uint n, const uint *ids);
    private delegate void PFNGLGENTRANSFORMFEEDBACKSPROC(uint n, uint *ids);
    private delegate bool PFNGLISTRANSFORMFEEDBACKPROC(uint id);
    private delegate void PFNGLPAUSETRANSFORMFEEDBACKPROC(void);
    private delegate void PFNGLRESUMETRANSFORMFEEDBACKPROC(void);
    private delegate void PFNGLDRAWTRANSFORMFEEDBACKPROC(uint mode, uint id);
    private delegate void PFNGLDRAWTRANSFORMFEEDBACKSTREAMPROC(uint mode, uint id, uint stream);
    private delegate void PFNGLBEGINQUERYINDEXEDPROC(uint target, uint index, uint id);
    private delegate void PFNGLENDQUERYINDEXEDPROC(uint target, uint index);
    private delegate void PFNGLGETQUERYINDEXEDIVPROC(uint target, uint index, uint pname, int *params);

    public static void glMinSampleShading(float value);
    public static void glBlendEquationi(uint buf, uint mode);
    public static void glBlendEquationSeparatei(uint buf, uint modeRGB, uint modeAlpha);
    public static void glBlendFunci(uint buf, uint src, uint dst);
    public static void glBlendFuncSeparatei(uint buf, uint srcRGB, uint dstRGB, uint srcAlpha, uint dstAlpha);
    public static void glDrawArraysIndirect(uint mode, const void *indirect);
    public static void glDrawElementsIndirect(uint mode, uint type, const void *indirect);
    public static void glUniform1d(int location, double x);
    public static void glUniform2d(int location, double x, double y);
    public static void glUniform3d(int location, double x, double y, double z);
    public static void glUniform4d(int location, double x, double y, double z, double w);
    public static void glUniform1dv(int location, uint count, const double *value);
    public static void glUniform2dv(int location, uint count, const double *value);
    public static void glUniform3dv(int location, uint count, const double *value);
    public static void glUniform4dv(int location, uint count, const double *value);
    public static void glUniformMatrix2dv(int location, uint count, bool transpose, const double *value);
    public static void glUniformMatrix3dv(int location, uint count, bool transpose, const double *value);
    public static void glUniformMatrix4dv(int location, uint count, bool transpose, const double *value);
    public static void glUniformMatrix2x3dv(int location, uint count, bool transpose, const double *value);
    public static void glUniformMatrix2x4dv(int location, uint count, bool transpose, const double *value);
    public static void glUniformMatrix3x2dv(int location, uint count, bool transpose, const double *value);
    public static void glUniformMatrix3x4dv(int location, uint count, bool transpose, const double *value);
    public static void glUniformMatrix4x2dv(int location, uint count, bool transpose, const double *value);
    public static void glUniformMatrix4x3dv(int location, uint count, bool transpose, const double *value);
    public static void glGetUniformdv(uint program, int location, double *params);
    public static int glGetSubroutineUniformLocation(uint program, uint shadertype, const byte *name);
    public static uint glGetSubroutineIndex(uint program, uint shadertype, const byte *name);
    public static void glGetActiveSubroutineUniformiv(uint program, uint shadertype, uint index, uint pname, int *values);
    public static void glGetActiveSubroutineUniformName(uint program, uint shadertype, uint index, uint bufsize, uint *length, byte *name);
    public static void glGetActiveSubroutineName(uint program, uint shadertype, uint index, uint bufsize, uint *length, byte *name);
    public static void glUniformSubroutinesuiv(uint shadertype, uint count, const uint *indices);
    public static void glGetUniformSubroutineuiv(uint shadertype, int location, uint *params);
    public static void glGetProgramStageiv(uint program, uint shadertype, uint pname, int *values);
    public static void glPatchParameteri(uint pname, int value);
    public static void glPatchParameterfv(uint pname, const float *values);
    public static void glBindTransformFeedback(uint target, uint id);
    public static void glDeleteTransformFeedbacks(uint n, const uint *ids);
    public static void glGenTransformFeedbacks(uint n, uint *ids);
    public static bool glIsTransformFeedback(uint id);
    public static void glPauseTransformFeedback(void);
    public static void glResumeTransformFeedback(void);
    public static void glDrawTransformFeedback(uint mode, uint id);
    public static void glDrawTransformFeedbackStream(uint mode, uint id, uint stream);
    public static void glBeginQueryIndexed(uint target, uint index, uint id);
    public static void glEndQueryIndexed(uint target, uint index);
    public static void glGetQueryIndexediv(uint target, uint index, uint pname, int *params);
    #endregion

    #region GL_VERSION_4_1
    public const uint GL_FIXED = 0x140C;
    public const uint GL_IMPLEMENTATION_COLOR_READ_TYPE = 0x8B9A;
    public const uint GL_IMPLEMENTATION_COLOR_READ_FORMAT = 0x8B9B;
    public const uint GL_LOW_FLOAT = 0x8DF0;
    public const uint GL_MEDIUM_FLOAT = 0x8DF1;
    public const uint GL_HIGH_FLOAT = 0x8DF2;
    public const uint GL_LOW_INT = 0x8DF3;
    public const uint GL_MEDIUM_INT = 0x8DF4;
    public const uint GL_HIGH_INT = 0x8DF5;
    public const uint GL_SHADER_COMPILER = 0x8DFA;
    public const uint GL_SHADER_BINARY_FORMATS = 0x8DF8;
    public const uint GL_NUM_SHADER_BINARY_FORMATS = 0x8DF9;
    public const uint GL_MAX_VERTEX_UNIFORM_VECTORS = 0x8DFB;
    public const uint GL_MAX_VARYING_VECTORS = 0x8DFC;
    public const uint GL_MAX_FRAGMENT_UNIFORM_VECTORS = 0x8DFD;
    public const uint GL_RGB565 = 0x8D62;
    public const uint GL_PROGRAM_BINARY_RETRIEVABLE_HINT = 0x8257;
    public const uint GL_PROGRAM_BINARY_LENGTH = 0x8741;
    public const uint GL_NUM_PROGRAM_BINARY_FORMATS = 0x87FE;
    public const uint GL_PROGRAM_BINARY_FORMATS = 0x87FF;
    public const uint GL_VERTEX_SHADER_BIT = 0x00000001;
    public const uint GL_FRAGMENT_SHADER_BIT = 0x00000002;
    public const uint GL_GEOMETRY_SHADER_BIT = 0x00000004;
    public const uint GL_TESS_CONTROL_SHADER_BIT = 0x00000008;
    public const uint GL_TESS_EVALUATION_SHADER_BIT = 0x00000010;
    public const uint GL_ALL_SHADER_BITS = 0xFFFFFFFF;
    public const uint GL_PROGRAM_SEPARABLE = 0x8258;
    public const uint GL_ACTIVE_PROGRAM = 0x8259;
    public const uint GL_PROGRAM_PIPELINE_BINDING = 0x825A;
    public const uint GL_MAX_VIEWPORTS = 0x825B;
    public const uint GL_VIEWPORT_SUBPIXEL_BITS = 0x825C;
    public const uint GL_VIEWPORT_BOUNDS_RANGE = 0x825D;
    public const uint GL_LAYER_PROVOKING_VERTEX = 0x825E;
    public const uint GL_VIEWPORT_INDEX_PROVOKING_VERTEX = 0x825F;
    public const uint GL_UNDEFINED_VERTEX = 0x8260;
    
    private delegate void PFNGLRELEASESHADERCOMPILERPROC(void);
    private delegate void PFNGLSHADERBINARYPROC(uint count, const uint *shaders, uint binaryformat, const void *binary, uint length);
    private delegate void PFNGLGETSHADERPRECISIONFORMATPROC(uint shadertype, uint precisiontype, int *range, int *precision);
    private delegate void PFNGLDEPTHRANGEFPROC(float n, float f);
    private delegate void PFNGLCLEARDEPTHFPROC(float d);
    private delegate void PFNGLGETPROGRAMBINARYPROC(uint program, uint bufSize, uint *length, uint *binaryFormat, void *binary);
    private delegate void PFNGLPROGRAMBINARYPROC(uint program, uint binaryFormat, const void *binary, uint length);
    private delegate void PFNGLPROGRAMPARAMETERIPROC(uint program, uint pname, int value);
    private delegate void PFNGLUSEPROGRAMSTAGESPROC(uint pipeline, uint stages, uint program);
    private delegate void PFNGLACTIVESHADERPROGRAMPROC(uint pipeline, uint program);
    private delegate uint PFNGLCREATESHADERPROGRAMVPROC(uint type, uint count, const byte *const*strings);
    private delegate void PFNGLBINDPROGRAMPIPELINEPROC(uint pipeline);
    private delegate void PFNGLDELETEPROGRAMPIPELINESPROC(uint n, const uint *pipelines);
    private delegate void PFNGLGENPROGRAMPIPELINESPROC(uint n, uint *pipelines);
    private delegate bool PFNGLISPROGRAMPIPELINEPROC(uint pipeline);
    private delegate void PFNGLGETPROGRAMPIPELINEIVPROC(uint pipeline, uint pname, int *params);
    private delegate void PFNGLPROGRAMUNIFORM1IPROC(uint program, int location, int v0);
    private delegate void PFNGLPROGRAMUNIFORM1IVPROC(uint program, int location, uint count, const int *value);
    private delegate void PFNGLPROGRAMUNIFORM1FPROC(uint program, int location, float v0);
    private delegate void PFNGLPROGRAMUNIFORM1FVPROC(uint program, int location, uint count, const float *value);
    private delegate void PFNGLPROGRAMUNIFORM1DPROC(uint program, int location, double v0);
    private delegate void PFNGLPROGRAMUNIFORM1DVPROC(uint program, int location, uint count, const double *value);
    private delegate void PFNGLPROGRAMUNIFORM1UIPROC(uint program, int location, uint v0);
    private delegate void PFNGLPROGRAMUNIFORM1UIVPROC(uint program, int location, uint count, const uint *value);
    private delegate void PFNGLPROGRAMUNIFORM2IPROC(uint program, int location, int v0, int v1);
    private delegate void PFNGLPROGRAMUNIFORM2IVPROC(uint program, int location, uint count, const int *value);
    private delegate void PFNGLPROGRAMUNIFORM2FPROC(uint program, int location, float v0, float v1);
    private delegate void PFNGLPROGRAMUNIFORM2FVPROC(uint program, int location, uint count, const float *value);
    private delegate void PFNGLPROGRAMUNIFORM2DPROC(uint program, int location, double v0, double v1);
    private delegate void PFNGLPROGRAMUNIFORM2DVPROC(uint program, int location, uint count, const double *value);
    private delegate void PFNGLPROGRAMUNIFORM2UIPROC(uint program, int location, uint v0, uint v1);
    private delegate void PFNGLPROGRAMUNIFORM2UIVPROC(uint program, int location, uint count, const uint *value);
    private delegate void PFNGLPROGRAMUNIFORM3IPROC(uint program, int location, int v0, int v1, int v2);
    private delegate void PFNGLPROGRAMUNIFORM3IVPROC(uint program, int location, uint count, const int *value);
    private delegate void PFNGLPROGRAMUNIFORM3FPROC(uint program, int location, float v0, float v1, float v2);
    private delegate void PFNGLPROGRAMUNIFORM3FVPROC(uint program, int location, uint count, const float *value);
    private delegate void PFNGLPROGRAMUNIFORM3DPROC(uint program, int location, double v0, double v1, double v2);
    private delegate void PFNGLPROGRAMUNIFORM3DVPROC(uint program, int location, uint count, const double *value);
    private delegate void PFNGLPROGRAMUNIFORM3UIPROC(uint program, int location, uint v0, uint v1, uint v2);
    private delegate void PFNGLPROGRAMUNIFORM3UIVPROC(uint program, int location, uint count, const uint *value);
    private delegate void PFNGLPROGRAMUNIFORM4IPROC(uint program, int location, int v0, int v1, int v2, int v3);
    private delegate void PFNGLPROGRAMUNIFORM4IVPROC(uint program, int location, uint count, const int *value);
    private delegate void PFNGLPROGRAMUNIFORM4FPROC(uint program, int location, float v0, float v1, float v2, float v3);
    private delegate void PFNGLPROGRAMUNIFORM4FVPROC(uint program, int location, uint count, const float *value);
    private delegate void PFNGLPROGRAMUNIFORM4DPROC(uint program, int location, double v0, double v1, double v2, double v3);
    private delegate void PFNGLPROGRAMUNIFORM4DVPROC(uint program, int location, uint count, const double *value);
    private delegate void PFNGLPROGRAMUNIFORM4UIPROC(uint program, int location, uint v0, uint v1, uint v2, uint v3);
    private delegate void PFNGLPROGRAMUNIFORM4UIVPROC(uint program, int location, uint count, const uint *value);
    private delegate void PFNGLPROGRAMUNIFORMMATRIX2FVPROC(uint program, int location, uint count, bool transpose, const float *value);
    private delegate void PFNGLPROGRAMUNIFORMMATRIX3FVPROC(uint program, int location, uint count, bool transpose, const float *value);
    private delegate void PFNGLPROGRAMUNIFORMMATRIX4FVPROC(uint program, int location, uint count, bool transpose, const float *value);
    private delegate void PFNGLPROGRAMUNIFORMMATRIX2DVPROC(uint program, int location, uint count, bool transpose, const double *value);
    private delegate void PFNGLPROGRAMUNIFORMMATRIX3DVPROC(uint program, int location, uint count, bool transpose, const double *value);
    private delegate void PFNGLPROGRAMUNIFORMMATRIX4DVPROC(uint program, int location, uint count, bool transpose, const double *value);
    private delegate void PFNGLPROGRAMUNIFORMMATRIX2X3FVPROC(uint program, int location, uint count, bool transpose, const float *value);
    private delegate void PFNGLPROGRAMUNIFORMMATRIX3X2FVPROC(uint program, int location, uint count, bool transpose, const float *value);
    private delegate void PFNGLPROGRAMUNIFORMMATRIX2X4FVPROC(uint program, int location, uint count, bool transpose, const float *value);
    private delegate void PFNGLPROGRAMUNIFORMMATRIX4X2FVPROC(uint program, int location, uint count, bool transpose, const float *value);
    private delegate void PFNGLPROGRAMUNIFORMMATRIX3X4FVPROC(uint program, int location, uint count, bool transpose, const float *value);
    private delegate void PFNGLPROGRAMUNIFORMMATRIX4X3FVPROC(uint program, int location, uint count, bool transpose, const float *value);
    private delegate void PFNGLPROGRAMUNIFORMMATRIX2X3DVPROC(uint program, int location, uint count, bool transpose, const double *value);
    private delegate void PFNGLPROGRAMUNIFORMMATRIX3X2DVPROC(uint program, int location, uint count, bool transpose, const double *value);
    private delegate void PFNGLPROGRAMUNIFORMMATRIX2X4DVPROC(uint program, int location, uint count, bool transpose, const double *value);
    private delegate void PFNGLPROGRAMUNIFORMMATRIX4X2DVPROC(uint program, int location, uint count, bool transpose, const double *value);
    private delegate void PFNGLPROGRAMUNIFORMMATRIX3X4DVPROC(uint program, int location, uint count, bool transpose, const double *value);
    private delegate void PFNGLPROGRAMUNIFORMMATRIX4X3DVPROC(uint program, int location, uint count, bool transpose, const double *value);
    private delegate void PFNGLVALIDATEPROGRAMPIPELINEPROC(uint pipeline);
    private delegate void PFNGLGETPROGRAMPIPELINEINFOLOGPROC(uint pipeline, uint bufSize, uint *length, byte *infoLog);
    private delegate void PFNGLVERTEXATTRIBL1DPROC(uint index, double x);
    private delegate void PFNGLVERTEXATTRIBL2DPROC(uint index, double x, double y);
    private delegate void PFNGLVERTEXATTRIBL3DPROC(uint index, double x, double y, double z);
    private delegate void PFNGLVERTEXATTRIBL4DPROC(uint index, double x, double y, double z, double w);
    private delegate void PFNGLVERTEXATTRIBL1DVPROC(uint index, const double *v);
    private delegate void PFNGLVERTEXATTRIBL2DVPROC(uint index, const double *v);
    private delegate void PFNGLVERTEXATTRIBL3DVPROC(uint index, const double *v);
    private delegate void PFNGLVERTEXATTRIBL4DVPROC(uint index, const double *v);
    private delegate void PFNGLVERTEXATTRIBLPOINTERPROC(uint index, int size, uint type, uint stride, const void *pointer);
    private delegate void PFNGLGETVERTEXATTRIBLDVPROC(uint index, uint pname, double *params);
    private delegate void PFNGLVIEWPORTARRAYVPROC(uint first, uint count, const float *v);
    private delegate void PFNGLVIEWPORTINDEXEDFPROC(uint index, float x, float y, float w, float h);
    private delegate void PFNGLVIEWPORTINDEXEDFVPROC(uint index, const float *v);
    private delegate void PFNGLSCISSORARRAYVPROC(uint first, uint count, const int *v);
    private delegate void PFNGLSCISSORINDEXEDPROC(uint index, int left, int bottom, uint width, uint height);
    private delegate void PFNGLSCISSORINDEXEDVPROC(uint index, const int *v);
    private delegate void PFNGLDEPTHRANGEARRAYVPROC(uint first, uint count, const double *v);
    private delegate void PFNGLDEPTHRANGEINDEXEDPROC(uint index, double n, double f);
    private delegate void PFNGLGETFLOATI_VPROC(uint target, uint index, float *data);
    private delegate void PFNGLGETDOUBLEI_VPROC(uint target, uint index, double *data);

    public static void glReleaseShaderCompiler(void);
    public static void glShaderBinary(uint count, const uint *shaders, uint binaryformat, const void *binary, uint length);
    public static void glGetShaderPrecisionFormat(uint shadertype, uint precisiontype, int *range, int *precision);
    public static void glDepthRangef(float n, float f);
    public static void glClearDepthf(float d);
    public static void glGetProgramBinary(uint program, uint bufSize, uint *length, uint *binaryFormat, void *binary);
    public static void glProgramBinary(uint program, uint binaryFormat, const void *binary, uint length);
    public static void glProgramParameteri(uint program, uint pname, int value);
    public static void glUseProgramStages(uint pipeline, uint stages, uint program);
    public static void glActiveShaderProgram(uint pipeline, uint program);
    public static uint glCreateShaderProgramv(uint type, uint count, const byte *const*strings);
    public static void glBindProgramPipeline(uint pipeline);
    public static void glDeleteProgramPipelines(uint n, const uint *pipelines);
    public static void glGenProgramPipelines(uint n, uint *pipelines);
    public static bool glIsProgramPipeline(uint pipeline);
    public static void glGetProgramPipelineiv(uint pipeline, uint pname, int *params);
    public static void glProgramUniform1i(uint program, int location, int v0);
    public static void glProgramUniform1iv(uint program, int location, uint count, const int *value);
    public static void glProgramUniform1f(uint program, int location, float v0);
    public static void glProgramUniform1fv(uint program, int location, uint count, const float *value);
    public static void glProgramUniform1d(uint program, int location, double v0);
    public static void glProgramUniform1dv(uint program, int location, uint count, const double *value);
    public static void glProgramUniform1ui(uint program, int location, uint v0);
    public static void glProgramUniform1uiv(uint program, int location, uint count, const uint *value);
    public static void glProgramUniform2i(uint program, int location, int v0, int v1);
    public static void glProgramUniform2iv(uint program, int location, uint count, const int *value);
    public static void glProgramUniform2f(uint program, int location, float v0, float v1);
    public static void glProgramUniform2fv(uint program, int location, uint count, const float *value);
    public static void glProgramUniform2d(uint program, int location, double v0, double v1);
    public static void glProgramUniform2dv(uint program, int location, uint count, const double *value);
    public static void glProgramUniform2ui(uint program, int location, uint v0, uint v1);
    public static void glProgramUniform2uiv(uint program, int location, uint count, const uint *value);
    public static void glProgramUniform3i(uint program, int location, int v0, int v1, int v2);
    public static void glProgramUniform3iv(uint program, int location, uint count, const int *value);
    public static void glProgramUniform3f(uint program, int location, float v0, float v1, float v2);
    public static void glProgramUniform3fv(uint program, int location, uint count, const float *value);
    public static void glProgramUniform3d(uint program, int location, double v0, double v1, double v2);
    public static void glProgramUniform3dv(uint program, int location, uint count, const double *value);
    public static void glProgramUniform3ui(uint program, int location, uint v0, uint v1, uint v2);
    public static void glProgramUniform3uiv(uint program, int location, uint count, const uint *value);
    public static void glProgramUniform4i(uint program, int location, int v0, int v1, int v2, int v3);
    public static void glProgramUniform4iv(uint program, int location, uint count, const int *value);
    public static void glProgramUniform4f(uint program, int location, float v0, float v1, float v2, float v3);
    public static void glProgramUniform4fv(uint program, int location, uint count, const float *value);
    public static void glProgramUniform4d(uint program, int location, double v0, double v1, double v2, double v3);
    public static void glProgramUniform4dv(uint program, int location, uint count, const double *value);
    public static void glProgramUniform4ui(uint program, int location, uint v0, uint v1, uint v2, uint v3);
    public static void glProgramUniform4uiv(uint program, int location, uint count, const uint *value);
    public static void glProgramUniformMatrix2fv(uint program, int location, uint count, bool transpose, const float *value);
    public static void glProgramUniformMatrix3fv(uint program, int location, uint count, bool transpose, const float *value);
    public static void glProgramUniformMatrix4fv(uint program, int location, uint count, bool transpose, const float *value);
    public static void glProgramUniformMatrix2dv(uint program, int location, uint count, bool transpose, const double *value);
    public static void glProgramUniformMatrix3dv(uint program, int location, uint count, bool transpose, const double *value);
    public static void glProgramUniformMatrix4dv(uint program, int location, uint count, bool transpose, const double *value);
    public static void glProgramUniformMatrix2x3fv(uint program, int location, uint count, bool transpose, const float *value);
    public static void glProgramUniformMatrix3x2fv(uint program, int location, uint count, bool transpose, const float *value);
    public static void glProgramUniformMatrix2x4fv(uint program, int location, uint count, bool transpose, const float *value);
    public static void glProgramUniformMatrix4x2fv(uint program, int location, uint count, bool transpose, const float *value);
    public static void glProgramUniformMatrix3x4fv(uint program, int location, uint count, bool transpose, const float *value);
    public static void glProgramUniformMatrix4x3fv(uint program, int location, uint count, bool transpose, const float *value);
    public static void glProgramUniformMatrix2x3dv(uint program, int location, uint count, bool transpose, const double *value);
    public static void glProgramUniformMatrix3x2dv(uint program, int location, uint count, bool transpose, const double *value);
    public static void glProgramUniformMatrix2x4dv(uint program, int location, uint count, bool transpose, const double *value);
    public static void glProgramUniformMatrix4x2dv(uint program, int location, uint count, bool transpose, const double *value);
    public static void glProgramUniformMatrix3x4dv(uint program, int location, uint count, bool transpose, const double *value);
    public static void glProgramUniformMatrix4x3dv(uint program, int location, uint count, bool transpose, const double *value);
    public static void glValidateProgramPipeline(uint pipeline);
    public static void glGetProgramPipelineInfoLog(uint pipeline, uint bufSize, uint *length, byte *infoLog);
    public static void glVertexAttribL1d(uint index, double x);
    public static void glVertexAttribL2d(uint index, double x, double y);
    public static void glVertexAttribL3d(uint index, double x, double y, double z);
    public static void glVertexAttribL4d(uint index, double x, double y, double z, double w);
    public static void glVertexAttribL1dv(uint index, const double *v);
    public static void glVertexAttribL2dv(uint index, const double *v);
    public static void glVertexAttribL3dv(uint index, const double *v);
    public static void glVertexAttribL4dv(uint index, const double *v);
    public static void glVertexAttribLPointer(uint index, int size, uint type, uint stride, const void *pointer);
    public static void glGetVertexAttribLdv(uint index, uint pname, double *params);
    public static void glViewportArrayv(uint first, uint count, const float *v);
    public static void glViewportIndexedf(uint index, float x, float y, float w, float h);
    public static void glViewportIndexedfv(uint index, const float *v);
    public static void glScissorArrayv(uint first, uint count, const int *v);
    public static void glScissorIndexed(uint index, int left, int bottom, uint width, uint height);
    public static void glScissorIndexedv(uint index, const int *v);
    public static void glDepthRangeArrayv(uint first, uint count, const double *v);
    public static void glDepthRangeIndexed(uint index, double n, double f);
    public static void glGetFloati_v(uint target, uint index, float *data);
    public static void glGetDoublei_v(uint target, uint index, double *data);
    #endregion

    #region GL_VERSION_4_2
    public const uint GL_UNPACK_COMPRESSED_BLOCK_WIDTH = 0x9127;
    public const uint GL_UNPACK_COMPRESSED_BLOCK_HEIGHT = 0x9128;
    public const uint GL_UNPACK_COMPRESSED_BLOCK_DEPTH = 0x9129;
    public const uint GL_UNPACK_COMPRESSED_BLOCK_SIZE = 0x912A;
    public const uint GL_PACK_COMPRESSED_BLOCK_WIDTH = 0x912B;
    public const uint GL_PACK_COMPRESSED_BLOCK_HEIGHT = 0x912C;
    public const uint GL_PACK_COMPRESSED_BLOCK_DEPTH = 0x912D;
    public const uint GL_PACK_COMPRESSED_BLOCK_SIZE = 0x912E;
    public const uint GL_NUM_SAMPLE_COUNTS = 0x9380;
    public const uint GL_MIN_MAP_BUFFER_ALIGNMENT = 0x90BC;
    public const uint GL_ATOMIC_COUNTER_BUFFER = 0x92C0;
    public const uint GL_ATOMIC_COUNTER_BUFFER_BINDING = 0x92C1;
    public const uint GL_ATOMIC_COUNTER_BUFFER_START = 0x92C2;
    public const uint GL_ATOMIC_COUNTER_BUFFER_SIZE = 0x92C3;
    public const uint GL_ATOMIC_COUNTER_BUFFER_DATA_SIZE = 0x92C4;
    public const uint GL_ATOMIC_COUNTER_BUFFER_ACTIVE_ATOMIC_COUNTERS = 0x92C5;
    public const uint GL_ATOMIC_COUNTER_BUFFER_ACTIVE_ATOMIC_COUNTER_INDICES = 0x92C6;
    public const uint GL_ATOMIC_COUNTER_BUFFER_REFERENCED_BY_VERTEX_SHADER = 0x92C7;
    public const uint GL_ATOMIC_COUNTER_BUFFER_REFERENCED_BY_TESS_CONTROL_SHADER = 0x92C8;
    public const uint GL_ATOMIC_COUNTER_BUFFER_REFERENCED_BY_TESS_EVALUATION_SHADER = 0x92C9;
    public const uint GL_ATOMIC_COUNTER_BUFFER_REFERENCED_BY_GEOMETRY_SHADER = 0x92CA;
    public const uint GL_ATOMIC_COUNTER_BUFFER_REFERENCED_BY_FRAGMENT_SHADER = 0x92CB;
    public const uint GL_MAX_VERTEX_ATOMIC_COUNTER_BUFFERS = 0x92CC;
    public const uint GL_MAX_TESS_CONTROL_ATOMIC_COUNTER_BUFFERS = 0x92CD;
    public const uint GL_MAX_TESS_EVALUATION_ATOMIC_COUNTER_BUFFERS = 0x92CE;
    public const uint GL_MAX_GEOMETRY_ATOMIC_COUNTER_BUFFERS = 0x92CF;
    public const uint GL_MAX_FRAGMENT_ATOMIC_COUNTER_BUFFERS = 0x92D0;
    public const uint GL_MAX_COMBINED_ATOMIC_COUNTER_BUFFERS = 0x92D1;
    public const uint GL_MAX_VERTEX_ATOMIC_COUNTERS = 0x92D2;
    public const uint GL_MAX_TESS_CONTROL_ATOMIC_COUNTERS = 0x92D3;
    public const uint GL_MAX_TESS_EVALUATION_ATOMIC_COUNTERS = 0x92D4;
    public const uint GL_MAX_GEOMETRY_ATOMIC_COUNTERS = 0x92D5;
    public const uint GL_MAX_FRAGMENT_ATOMIC_COUNTERS = 0x92D6;
    public const uint GL_MAX_COMBINED_ATOMIC_COUNTERS = 0x92D7;
    public const uint GL_MAX_ATOMIC_COUNTER_BUFFER_SIZE = 0x92D8;
    public const uint GL_MAX_ATOMIC_COUNTER_BUFFER_BINDINGS = 0x92DC;
    public const uint GL_ACTIVE_ATOMIC_COUNTER_BUFFERS = 0x92D9;
    public const uint GL_UNIFORM_ATOMIC_COUNTER_BUFFER_INDEX = 0x92DA;
    public const uint GL_UNSIGNED_INT_ATOMIC_COUNTER = 0x92DB;
    public const uint GL_VERTEX_ATTRIB_ARRAY_BARRIER_BIT = 0x00000001;
    public const uint GL_ELEMENT_ARRAY_BARRIER_BIT = 0x00000002;
    public const uint GL_UNIFORM_BARRIER_BIT = 0x00000004;
    public const uint GL_TEXTURE_FETCH_BARRIER_BIT = 0x00000008;
    public const uint GL_SHADER_IMAGE_ACCESS_BARRIER_BIT = 0x00000020;
    public const uint GL_COMMAND_BARRIER_BIT = 0x00000040;
    public const uint GL_PIXEL_BUFFER_BARRIER_BIT = 0x00000080;
    public const uint GL_TEXTURE_UPDATE_BARRIER_BIT = 0x00000100;
    public const uint GL_BUFFER_UPDATE_BARRIER_BIT = 0x00000200;
    public const uint GL_FRAMEBUFFER_BARRIER_BIT = 0x00000400;
    public const uint GL_TRANSFORM_FEEDBACK_BARRIER_BIT = 0x00000800;
    public const uint GL_ATOMIC_COUNTER_BARRIER_BIT = 0x00001000;
    public const uint GL_ALL_BARRIER_BITS = 0xFFFFFFFF;
    public const uint GL_MAX_IMAGE_UNITS = 0x8F38;
    public const uint GL_MAX_COMBINED_IMAGE_UNITS_AND_FRAGMENT_OUTPUTS = 0x8F39;
    public const uint GL_IMAGE_BINDING_NAME = 0x8F3A;
    public const uint GL_IMAGE_BINDING_LEVEL = 0x8F3B;
    public const uint GL_IMAGE_BINDING_LAYERED = 0x8F3C;
    public const uint GL_IMAGE_BINDING_LAYER = 0x8F3D;
    public const uint GL_IMAGE_BINDING_ACCESS = 0x8F3E;
    public const uint GL_IMAGE_1D = 0x904C;
    public const uint GL_IMAGE_2D = 0x904D;
    public const uint GL_IMAGE_3D = 0x904E;
    public const uint GL_IMAGE_2D_RECT = 0x904F;
    public const uint GL_IMAGE_CUBE = 0x9050;
    public const uint GL_IMAGE_BUFFER = 0x9051;
    public const uint GL_IMAGE_1D_ARRAY = 0x9052;
    public const uint GL_IMAGE_2D_ARRAY = 0x9053;
    public const uint GL_IMAGE_CUBE_MAP_ARRAY = 0x9054;
    public const uint GL_IMAGE_2D_MULTISAMPLE = 0x9055;
    public const uint GL_IMAGE_2D_MULTISAMPLE_ARRAY = 0x9056;
    public const uint GL_INT_IMAGE_1D = 0x9057;
    public const uint GL_INT_IMAGE_2D = 0x9058;
    public const uint GL_INT_IMAGE_3D = 0x9059;
    public const uint GL_INT_IMAGE_2D_RECT = 0x905A;
    public const uint GL_INT_IMAGE_CUBE = 0x905B;
    public const uint GL_INT_IMAGE_BUFFER = 0x905C;
    public const uint GL_INT_IMAGE_1D_ARRAY = 0x905D;
    public const uint GL_INT_IMAGE_2D_ARRAY = 0x905E;
    public const uint GL_INT_IMAGE_CUBE_MAP_ARRAY = 0x905F;
    public const uint GL_INT_IMAGE_2D_MULTISAMPLE = 0x9060;
    public const uint GL_INT_IMAGE_2D_MULTISAMPLE_ARRAY = 0x9061;
    public const uint GL_UNSIGNED_INT_IMAGE_1D = 0x9062;
    public const uint GL_UNSIGNED_INT_IMAGE_2D = 0x9063;
    public const uint GL_UNSIGNED_INT_IMAGE_3D = 0x9064;
    public const uint GL_UNSIGNED_INT_IMAGE_2D_RECT = 0x9065;
    public const uint GL_UNSIGNED_INT_IMAGE_CUBE = 0x9066;
    public const uint GL_UNSIGNED_INT_IMAGE_BUFFER = 0x9067;
    public const uint GL_UNSIGNED_INT_IMAGE_1D_ARRAY = 0x9068;
    public const uint GL_UNSIGNED_INT_IMAGE_2D_ARRAY = 0x9069;
    public const uint GL_UNSIGNED_INT_IMAGE_CUBE_MAP_ARRAY = 0x906A;
    public const uint GL_UNSIGNED_INT_IMAGE_2D_MULTISAMPLE = 0x906B;
    public const uint GL_UNSIGNED_INT_IMAGE_2D_MULTISAMPLE_ARRAY = 0x906C;
    public const uint GL_MAX_IMAGE_SAMPLES = 0x906D;
    public const uint GL_IMAGE_BINDING_FORMAT = 0x906E;
    public const uint GL_IMAGE_FORMAT_COMPATIBILITY_TYPE = 0x90C7;
    public const uint GL_IMAGE_FORMAT_COMPATIBILITY_BY_SIZE = 0x90C8;
    public const uint GL_IMAGE_FORMAT_COMPATIBILITY_BY_CLASS = 0x90C9;
    public const uint GL_MAX_VERTEX_IMAGE_UNIFORMS = 0x90CA;
    public const uint GL_MAX_TESS_CONTROL_IMAGE_UNIFORMS = 0x90CB;
    public const uint GL_MAX_TESS_EVALUATION_IMAGE_UNIFORMS = 0x90CC;
    public const uint GL_MAX_GEOMETRY_IMAGE_UNIFORMS = 0x90CD;
    public const uint GL_MAX_FRAGMENT_IMAGE_UNIFORMS = 0x90CE;
    public const uint GL_MAX_COMBINED_IMAGE_UNIFORMS = 0x90CF;
    public const uint GL_TEXTURE_IMMUTABLE_FORMAT = 0x912F;
    
    private delegate void PFNGLDRAWARRAYSINSTANCEDBASEINSTANCEPROC(uint mode, int first, uint count, uint instancecount, uint baseinstance);
    private delegate void PFNGLDRAWELEMENTSINSTANCEDBASEINSTANCEPROC(uint mode, uint count, uint type, const void *indices, uint instancecount, uint baseinstance);
    private delegate void PFNGLDRAWELEMENTSINSTANCEDBASEVERTEXBASEINSTANCEPROC(uint mode, uint count, uint type, const void *indices, uint instancecount, int basevertex, uint baseinstance);
    private delegate void PFNGLGETINTERNALFORMATIVPROC(uint target, uint internalformat, uint pname, uint bufSize, int *params);
    private delegate void PFNGLGETACTIVEATOMICCOUNTERBUFFERIVPROC(uint program, uint bufferIndex, uint pname, int *params);
    private delegate void PFNGLBINDIMAGETEXTUREPROC(uint unit, uint texture, int level, bool layered, int layer, uint access, uint format);
    private delegate void PFNGLMEMORYBARRIERPROC(uint barriers);
    private delegate void PFNGLTEXSTORAGE1DPROC(uint target, uint levels, uint internalformat, uint width);
    private delegate void PFNGLTEXSTORAGE2DPROC(uint target, uint levels, uint internalformat, uint width, uint height);
    private delegate void PFNGLTEXSTORAGE3DPROC(uint target, uint levels, uint internalformat, uint width, uint height, uint depth);
    private delegate void PFNGLDRAWTRANSFORMFEEDBACKINSTANCEDPROC(uint mode, uint id, uint instancecount);
    private delegate void PFNGLDRAWTRANSFORMFEEDBACKSTREAMINSTANCEDPROC(uint mode, uint id, uint stream, uint instancecount);

    public static void glDrawArraysInstancedBaseInstance(uint mode, int first, uint count, uint instancecount, uint baseinstance);
    public static void glDrawElementsInstancedBaseInstance(uint mode, uint count, uint type, const void *indices, uint instancecount, uint baseinstance);
    public static void glDrawElementsInstancedBaseVertexBaseInstance(uint mode, uint count, uint type, const void *indices, uint instancecount, int basevertex, uint baseinstance);
    public static void glGetInternalformativ(uint target, uint internalformat, uint pname, uint bufSize, int *params);
    public static void glGetActiveAtomicCounterBufferiv(uint program, uint bufferIndex, uint pname, int *params);
    public static void glBindImageTexture(uint unit, uint texture, int level, bool layered, int layer, uint access, uint format);
    public static void glMemoryBarrier(uint barriers);
    public static void glTexStorage1D(uint target, uint levels, uint internalformat, uint width);
    public static void glTexStorage2D(uint target, uint levels, uint internalformat, uint width, uint height);
    public static void glTexStorage3D(uint target, uint levels, uint internalformat, uint width, uint height, uint depth);
    public static void glDrawTransformFeedbackInstanced(uint mode, uint id, uint instancecount);
    public static void glDrawTransformFeedbackStreamInstanced(uint mode, uint id, uint stream, uint instancecount);
    #endregion

    #region GL_VERSION_4_3
    typedef void (APIENTRY  *GLDEBUGPROC)(uint source,uint type,uint id,uint severity,uint length,const byte *message,const void *userParam);
    public const uint GL_NUM_SHADING_LANGUAGE_VERSIONS = 0x82E9;
    public const uint GL_VERTEX_ATTRIB_ARRAY_LONG = 0x874E;
    public const uint GL_COMPRESSED_RGB8_ETC2 = 0x9274;
    public const uint GL_COMPRESSED_SRGB8_ETC2 = 0x9275;
    public const uint GL_COMPRESSED_RGB8_PUNCHTHROUGH_ALPHA1_ETC2 = 0x9276;
    public const uint GL_COMPRESSED_SRGB8_PUNCHTHROUGH_ALPHA1_ETC2 = 0x9277;
    public const uint GL_COMPRESSED_RGBA8_ETC2_EAC = 0x9278;
    public const uint GL_COMPRESSED_SRGB8_ALPHA8_ETC2_EAC = 0x9279;
    public const uint GL_COMPRESSED_R11_EAC = 0x9270;
    public const uint GL_COMPRESSED_SIGNED_R11_EAC = 0x9271;
    public const uint GL_COMPRESSED_RG11_EAC = 0x9272;
    public const uint GL_COMPRESSED_SIGNED_RG11_EAC = 0x9273;
    public const uint GL_PRIMITIVE_RESTART_FIXED_INDEX = 0x8D69;
    public const uint GL_ANY_SAMPLES_PASSED_CONSERVATIVE = 0x8D6A;
    public const uint GL_MAX_ELEMENT_INDEX = 0x8D6B;
    public const uint GL_COMPUTE_SHADER = 0x91B9;
    public const uint GL_MAX_COMPUTE_UNIFORM_BLOCKS = 0x91BB;
    public const uint GL_MAX_COMPUTE_TEXTURE_IMAGE_UNITS = 0x91BC;
    public const uint GL_MAX_COMPUTE_IMAGE_UNIFORMS = 0x91BD;
    public const uint GL_MAX_COMPUTE_SHARED_MEMORY_SIZE = 0x8262;
    public const uint GL_MAX_COMPUTE_UNIFORM_COMPONENTS = 0x8263;
    public const uint GL_MAX_COMPUTE_ATOMIC_COUNTER_BUFFERS = 0x8264;
    public const uint GL_MAX_COMPUTE_ATOMIC_COUNTERS = 0x8265;
    public const uint GL_MAX_COMBINED_COMPUTE_UNIFORM_COMPONENTS = 0x8266;
    public const uint GL_MAX_COMPUTE_WORK_GROUP_INVOCATIONS = 0x90EB;
    public const uint GL_MAX_COMPUTE_WORK_GROUP_COUNT = 0x91BE;
    public const uint GL_MAX_COMPUTE_WORK_GROUP_SIZE = 0x91BF;
    public const uint GL_COMPUTE_WORK_GROUP_SIZE = 0x8267;
    public const uint GL_UNIFORM_BLOCK_REFERENCED_BY_COMPUTE_SHADER = 0x90EC;
    public const uint GL_ATOMIC_COUNTER_BUFFER_REFERENCED_BY_COMPUTE_SHADER = 0x90ED;
    public const uint GL_DISPATCH_INDIRECT_BUFFER = 0x90EE;
    public const uint GL_DISPATCH_INDIRECT_BUFFER_BINDING = 0x90EF;
    public const uint GL_DEBUG_OUTPUT_SYNCHRONOUS = 0x8242;
    public const uint GL_DEBUG_NEXT_LOGGED_MESSAGE_LENGTH = 0x8243;
    public const uint GL_DEBUG_CALLBACK_FUNCTION = 0x8244;
    public const uint GL_DEBUG_CALLBACK_USER_PARAM = 0x8245;
    public const uint GL_DEBUG_SOURCE_API = 0x8246;
    public const uint GL_DEBUG_SOURCE_WINDOW_SYSTEM = 0x8247;
    public const uint GL_DEBUG_SOURCE_SHADER_COMPILER = 0x8248;
    public const uint GL_DEBUG_SOURCE_THIRD_PARTY = 0x8249;
    public const uint GL_DEBUG_SOURCE_APPLICATION = 0x824A;
    public const uint GL_DEBUG_SOURCE_OTHER = 0x824B;
    public const uint GL_DEBUG_TYPE_ERROR = 0x824C;
    public const uint GL_DEBUG_TYPE_DEPRECATED_BEHAVIOR = 0x824D;
    public const uint GL_DEBUG_TYPE_UNDEFINED_BEHAVIOR = 0x824E;
    public const uint GL_DEBUG_TYPE_PORTABILITY = 0x824F;
    public const uint GL_DEBUG_TYPE_PERFORMANCE = 0x8250;
    public const uint GL_DEBUG_TYPE_OTHER = 0x8251;
    public const uint GL_MAX_DEBUG_MESSAGE_LENGTH = 0x9143;
    public const uint GL_MAX_DEBUG_LOGGED_MESSAGES = 0x9144;
    public const uint GL_DEBUG_LOGGED_MESSAGES = 0x9145;
    public const uint GL_DEBUG_SEVERITY_HIGH = 0x9146;
    public const uint GL_DEBUG_SEVERITY_MEDIUM = 0x9147;
    public const uint GL_DEBUG_SEVERITY_LOW = 0x9148;
    public const uint GL_DEBUG_TYPE_MARKER = 0x8268;
    public const uint GL_DEBUG_TYPE_PUSH_GROUP = 0x8269;
    public const uint GL_DEBUG_TYPE_POP_GROUP = 0x826A;
    public const uint GL_DEBUG_SEVERITY_NOTIFICATION = 0x826B;
    public const uint GL_MAX_DEBUG_GROUP_STACK_DEPTH = 0x826C;
    public const uint GL_DEBUG_GROUP_STACK_DEPTH = 0x826D;
    public const uint GL_BUFFER = 0x82E0;
    public const uint GL_SHADER = 0x82E1;
    public const uint GL_PROGRAM = 0x82E2;
    public const uint GL_QUERY = 0x82E3;
    public const uint GL_PROGRAM_PIPELINE = 0x82E4;
    public const uint GL_SAMPLER = 0x82E6;
    public const uint GL_MAX_LABEL_LENGTH = 0x82E8;
    public const uint GL_DEBUG_OUTPUT = 0x92E0;
    public const uint GL_CONTEXT_FLAG_DEBUG_BIT = 0x00000002;
    public const uint GL_MAX_UNIFORM_LOCATIONS = 0x826E;
    public const uint GL_FRAMEBUFFER_DEFAULT_WIDTH = 0x9310;
    public const uint GL_FRAMEBUFFER_DEFAULT_HEIGHT = 0x9311;
    public const uint GL_FRAMEBUFFER_DEFAULT_LAYERS = 0x9312;
    public const uint GL_FRAMEBUFFER_DEFAULT_SAMPLES = 0x9313;
    public const uint GL_FRAMEBUFFER_DEFAULT_FIXED_SAMPLE_LOCATIONS = 0x9314;
    public const uint GL_MAX_FRAMEBUFFER_WIDTH = 0x9315;
    public const uint GL_MAX_FRAMEBUFFER_HEIGHT = 0x9316;
    public const uint GL_MAX_FRAMEBUFFER_LAYERS = 0x9317;
    public const uint GL_MAX_FRAMEBUFFER_SAMPLES = 0x9318;
    public const uint GL_INTERNALFORMAT_SUPPORTED = 0x826F;
    public const uint GL_INTERNALFORMAT_PREFERRED = 0x8270;
    public const uint GL_INTERNALFORMAT_RED_SIZE = 0x8271;
    public const uint GL_INTERNALFORMAT_GREEN_SIZE = 0x8272;
    public const uint GL_INTERNALFORMAT_BLUE_SIZE = 0x8273;
    public const uint GL_INTERNALFORMAT_ALPHA_SIZE = 0x8274;
    public const uint GL_INTERNALFORMAT_DEPTH_SIZE = 0x8275;
    public const uint GL_INTERNALFORMAT_STENCIL_SIZE = 0x8276;
    public const uint GL_INTERNALFORMAT_SHARED_SIZE = 0x8277;
    public const uint GL_INTERNALFORMAT_RED_TYPE = 0x8278;
    public const uint GL_INTERNALFORMAT_GREEN_TYPE = 0x8279;
    public const uint GL_INTERNALFORMAT_BLUE_TYPE = 0x827A;
    public const uint GL_INTERNALFORMAT_ALPHA_TYPE = 0x827B;
    public const uint GL_INTERNALFORMAT_DEPTH_TYPE = 0x827C;
    public const uint GL_INTERNALFORMAT_STENCIL_TYPE = 0x827D;
    public const uint GL_MAX_WIDTH = 0x827E;
    public const uint GL_MAX_HEIGHT = 0x827F;
    public const uint GL_MAX_DEPTH = 0x8280;
    public const uint GL_MAX_LAYERS = 0x8281;
    public const uint GL_MAX_COMBINED_DIMENSIONS = 0x8282;
    public const uint GL_COLOR_COMPONENTS = 0x8283;
    public const uint GL_DEPTH_COMPONENTS = 0x8284;
    public const uint GL_STENCIL_COMPONENTS = 0x8285;
    public const uint GL_COLOR_RENDERABLE = 0x8286;
    public const uint GL_DEPTH_RENDERABLE = 0x8287;
    public const uint GL_STENCIL_RENDERABLE = 0x8288;
    public const uint GL_FRAMEBUFFER_RENDERABLE = 0x8289;
    public const uint GL_FRAMEBUFFER_RENDERABLE_LAYERED = 0x828A;
    public const uint GL_FRAMEBUFFER_BLEND = 0x828B;
    public const uint GL_READ_PIXELS = 0x828C;
    public const uint GL_READ_PIXELS_FORMAT = 0x828D;
    public const uint GL_READ_PIXELS_TYPE = 0x828E;
    public const uint GL_TEXTURE_IMAGE_FORMAT = 0x828F;
    public const uint GL_TEXTURE_IMAGE_TYPE = 0x8290;
    public const uint GL_GET_TEXTURE_IMAGE_FORMAT = 0x8291;
    public const uint GL_GET_TEXTURE_IMAGE_TYPE = 0x8292;
    public const uint GL_MIPMAP = 0x8293;
    public const uint GL_MANUAL_GENERATE_MIPMAP = 0x8294;
    public const uint GL_AUTO_GENERATE_MIPMAP = 0x8295;
    public const uint GL_COLOR_ENCODING = 0x8296;
    public const uint GL_SRGB_READ = 0x8297;
    public const uint GL_SRGB_WRITE = 0x8298;
    public const uint GL_FILTER = 0x829A;
    public const uint GL_VERTEX_TEXTURE = 0x829B;
    public const uint GL_TESS_CONTROL_TEXTURE = 0x829C;
    public const uint GL_TESS_EVALUATION_TEXTURE = 0x829D;
    public const uint GL_GEOMETRY_TEXTURE = 0x829E;
    public const uint GL_FRAGMENT_TEXTURE = 0x829F;
    public const uint GL_COMPUTE_TEXTURE = 0x82A0;
    public const uint GL_TEXTURE_SHADOW = 0x82A1;
    public const uint GL_TEXTURE_GATHER = 0x82A2;
    public const uint GL_TEXTURE_GATHER_SHADOW = 0x82A3;
    public const uint GL_SHADER_IMAGE_LOAD = 0x82A4;
    public const uint GL_SHADER_IMAGE_STORE = 0x82A5;
    public const uint GL_SHADER_IMAGE_ATOMIC = 0x82A6;
    public const uint GL_IMAGE_TEXEL_SIZE = 0x82A7;
    public const uint GL_IMAGE_COMPATIBILITY_CLASS = 0x82A8;
    public const uint GL_IMAGE_PIXEL_FORMAT = 0x82A9;
    public const uint GL_IMAGE_PIXEL_TYPE = 0x82AA;
    public const uint GL_SIMULTANEOUS_TEXTURE_AND_DEPTH_TEST = 0x82AC;
    public const uint GL_SIMULTANEOUS_TEXTURE_AND_STENCIL_TEST = 0x82AD;
    public const uint GL_SIMULTANEOUS_TEXTURE_AND_DEPTH_WRITE = 0x82AE;
    public const uint GL_SIMULTANEOUS_TEXTURE_AND_STENCIL_WRITE = 0x82AF;
    public const uint GL_TEXTURE_COMPRESSED_BLOCK_WIDTH = 0x82B1;
    public const uint GL_TEXTURE_COMPRESSED_BLOCK_HEIGHT = 0x82B2;
    public const uint GL_TEXTURE_COMPRESSED_BLOCK_SIZE = 0x82B3;
    public const uint GL_CLEAR_BUFFER = 0x82B4;
    public const uint GL_TEXTURE_VIEW = 0x82B5;
    public const uint GL_VIEW_COMPATIBILITY_CLASS = 0x82B6;
    public const uint GL_FULL_SUPPORT = 0x82B7;
    public const uint GL_CAVEAT_SUPPORT = 0x82B8;
    public const uint GL_IMAGE_CLASS_4_X_32 = 0x82B9;
    public const uint GL_IMAGE_CLASS_2_X_32 = 0x82BA;
    public const uint GL_IMAGE_CLASS_1_X_32 = 0x82BB;
    public const uint GL_IMAGE_CLASS_4_X_16 = 0x82BC;
    public const uint GL_IMAGE_CLASS_2_X_16 = 0x82BD;
    public const uint GL_IMAGE_CLASS_1_X_16 = 0x82BE;
    public const uint GL_IMAGE_CLASS_4_X_8 = 0x82BF;
    public const uint GL_IMAGE_CLASS_2_X_8 = 0x82C0;
    public const uint GL_IMAGE_CLASS_1_X_8 = 0x82C1;
    public const uint GL_IMAGE_CLASS_11_11_10 = 0x82C2;
    public const uint GL_IMAGE_CLASS_10_10_10_2 = 0x82C3;
    public const uint GL_VIEW_CLASS_128_BITS = 0x82C4;
    public const uint GL_VIEW_CLASS_96_BITS = 0x82C5;
    public const uint GL_VIEW_CLASS_64_BITS = 0x82C6;
    public const uint GL_VIEW_CLASS_48_BITS = 0x82C7;
    public const uint GL_VIEW_CLASS_32_BITS = 0x82C8;
    public const uint GL_VIEW_CLASS_24_BITS = 0x82C9;
    public const uint GL_VIEW_CLASS_16_BITS = 0x82CA;
    public const uint GL_VIEW_CLASS_8_BITS = 0x82CB;
    public const uint GL_VIEW_CLASS_S3TC_DXT1_RGB = 0x82CC;
    public const uint GL_VIEW_CLASS_S3TC_DXT1_RGBA = 0x82CD;
    public const uint GL_VIEW_CLASS_S3TC_DXT3_RGBA = 0x82CE;
    public const uint GL_VIEW_CLASS_S3TC_DXT5_RGBA = 0x82CF;
    public const uint GL_VIEW_CLASS_RGTC1_RED = 0x82D0;
    public const uint GL_VIEW_CLASS_RGTC2_RG = 0x82D1;
    public const uint GL_VIEW_CLASS_BPTC_UNORM = 0x82D2;
    public const uint GL_VIEW_CLASS_BPTC_FLOAT = 0x82D3;
    public const uint GL_UNIFORM = 0x92E1;
    public const uint GL_UNIFORM_BLOCK = 0x92E2;
    public const uint GL_PROGRAM_INPUT = 0x92E3;
    public const uint GL_PROGRAM_OUTPUT = 0x92E4;
    public const uint GL_BUFFER_VARIABLE = 0x92E5;
    public const uint GL_SHADER_STORAGE_BLOCK = 0x92E6;
    public const uint GL_VERTEX_SUBROUTINE = 0x92E8;
    public const uint GL_TESS_CONTROL_SUBROUTINE = 0x92E9;
    public const uint GL_TESS_EVALUATION_SUBROUTINE = 0x92EA;
    public const uint GL_GEOMETRY_SUBROUTINE = 0x92EB;
    public const uint GL_FRAGMENT_SUBROUTINE = 0x92EC;
    public const uint GL_COMPUTE_SUBROUTINE = 0x92ED;
    public const uint GL_VERTEX_SUBROUTINE_UNIFORM = 0x92EE;
    public const uint GL_TESS_CONTROL_SUBROUTINE_UNIFORM = 0x92EF;
    public const uint GL_TESS_EVALUATION_SUBROUTINE_UNIFORM = 0x92F0;
    public const uint GL_GEOMETRY_SUBROUTINE_UNIFORM = 0x92F1;
    public const uint GL_FRAGMENT_SUBROUTINE_UNIFORM = 0x92F2;
    public const uint GL_COMPUTE_SUBROUTINE_UNIFORM = 0x92F3;
    public const uint GL_TRANSFORM_FEEDBACK_VARYING = 0x92F4;
    public const uint GL_ACTIVE_RESOURCES = 0x92F5;
    public const uint GL_MAX_NAME_LENGTH = 0x92F6;
    public const uint GL_MAX_NUM_ACTIVE_VARIABLES = 0x92F7;
    public const uint GL_MAX_NUM_COMPATIBLE_SUBROUTINES = 0x92F8;
    public const uint GL_NAME_LENGTH = 0x92F9;
    public const uint GL_TYPE = 0x92FA;
    public const uint GL_ARRAY_SIZE = 0x92FB;
    public const uint GL_OFFSET = 0x92FC;
    public const uint GL_BLOCK_INDEX = 0x92FD;
    public const uint GL_ARRAY_STRIDE = 0x92FE;
    public const uint GL_MATRIX_STRIDE = 0x92FF;
    public const uint GL_IS_ROW_MAJOR = 0x9300;
    public const uint GL_ATOMIC_COUNTER_BUFFER_INDEX = 0x9301;
    public const uint GL_BUFFER_BINDING = 0x9302;
    public const uint GL_BUFFER_DATA_SIZE = 0x9303;
    public const uint GL_NUM_ACTIVE_VARIABLES = 0x9304;
    public const uint GL_ACTIVE_VARIABLES = 0x9305;
    public const uint GL_REFERENCED_BY_VERTEX_SHADER = 0x9306;
    public const uint GL_REFERENCED_BY_TESS_CONTROL_SHADER = 0x9307;
    public const uint GL_REFERENCED_BY_TESS_EVALUATION_SHADER = 0x9308;
    public const uint GL_REFERENCED_BY_GEOMETRY_SHADER = 0x9309;
    public const uint GL_REFERENCED_BY_FRAGMENT_SHADER = 0x930A;
    public const uint GL_REFERENCED_BY_COMPUTE_SHADER = 0x930B;
    public const uint GL_TOP_LEVEL_ARRAY_SIZE = 0x930C;
    public const uint GL_TOP_LEVEL_ARRAY_STRIDE = 0x930D;
    public const uint GL_LOCATION = 0x930E;
    public const uint GL_LOCATION_INDEX = 0x930F;
    public const uint GL_IS_PER_PATCH = 0x92E7;
    public const uint GL_SHADER_STORAGE_BUFFER = 0x90D2;
    public const uint GL_SHADER_STORAGE_BUFFER_BINDING = 0x90D3;
    public const uint GL_SHADER_STORAGE_BUFFER_START = 0x90D4;
    public const uint GL_SHADER_STORAGE_BUFFER_SIZE = 0x90D5;
    public const uint GL_MAX_VERTEX_SHADER_STORAGE_BLOCKS = 0x90D6;
    public const uint GL_MAX_GEOMETRY_SHADER_STORAGE_BLOCKS = 0x90D7;
    public const uint GL_MAX_TESS_CONTROL_SHADER_STORAGE_BLOCKS = 0x90D8;
    public const uint GL_MAX_TESS_EVALUATION_SHADER_STORAGE_BLOCKS = 0x90D9;
    public const uint GL_MAX_FRAGMENT_SHADER_STORAGE_BLOCKS = 0x90DA;
    public const uint GL_MAX_COMPUTE_SHADER_STORAGE_BLOCKS = 0x90DB;
    public const uint GL_MAX_COMBINED_SHADER_STORAGE_BLOCKS = 0x90DC;
    public const uint GL_MAX_SHADER_STORAGE_BUFFER_BINDINGS = 0x90DD;
    public const uint GL_MAX_SHADER_STORAGE_BLOCK_SIZE = 0x90DE;
    public const uint GL_SHADER_STORAGE_BUFFER_OFFSET_ALIGNMENT = 0x90DF;
    public const uint GL_SHADER_STORAGE_BARRIER_BIT = 0x00002000;
    public const uint GL_MAX_COMBINED_SHADER_OUTPUT_RESOURCES = 0x8F39;
    public const uint GL_DEPTH_STENCIL_TEXTURE_MODE = 0x90EA;
    public const uint GL_TEXTURE_BUFFER_OFFSET = 0x919D;
    public const uint GL_TEXTURE_BUFFER_SIZE = 0x919E;
    public const uint GL_TEXTURE_BUFFER_OFFSET_ALIGNMENT = 0x919F;
    public const uint GL_TEXTURE_VIEW_MIN_LEVEL = 0x82DB;
    public const uint GL_TEXTURE_VIEW_NUM_LEVELS = 0x82DC;
    public const uint GL_TEXTURE_VIEW_MIN_LAYER = 0x82DD;
    public const uint GL_TEXTURE_VIEW_NUM_LAYERS = 0x82DE;
    public const uint GL_TEXTURE_IMMUTABLE_LEVELS = 0x82DF;
    public const uint GL_VERTEX_ATTRIB_BINDING = 0x82D4;
    public const uint GL_VERTEX_ATTRIB_RELATIVE_OFFSET = 0x82D5;
    public const uint GL_VERTEX_BINDING_DIVISOR = 0x82D6;
    public const uint GL_VERTEX_BINDING_OFFSET = 0x82D7;
    public const uint GL_VERTEX_BINDING_STRIDE = 0x82D8;
    public const uint GL_MAX_VERTEX_ATTRIB_RELATIVE_OFFSET = 0x82D9;
    public const uint GL_MAX_VERTEX_ATTRIB_BINDINGS = 0x82DA;
    public const uint GL_DISPLAY_LIST = 0x82E7;
    
    private delegate void PFNGLCLEARBUFFERDATAPROC(uint target, uint internalformat, uint format, uint type, const void *data);
    private delegate void PFNGLCLEARBUFFERSUBDATAPROC(uint target, uint internalformat, intptr offset, uintptr size, uint format, uint type, const void *data);
    private delegate void PFNGLDISPATCHCOMPUTEPROC(uint num_groups_x, uint num_groups_y, uint num_groups_z);
    private delegate void PFNGLDISPATCHCOMPUTEINDIRECTPROC(intptr indirect);
    private delegate void PFNGLCOPYIMAGESUBDATAPROC(uint srcName, uint srcTarget, int srcLevel, int srcX, int srcY, int srcZ, uint dstName, uint dstTarget, int dstLevel, int dstX, int dstY, int dstZ, uint srcWidth, uint srcHeight, uint srcDepth);
    private delegate void PFNGLFRAMEBUFFERPARAMETERIPROC(uint target, uint pname, int param);
    private delegate void PFNGLGETFRAMEBUFFERPARAMETERIVPROC(uint target, uint pname, int *params);
    private delegate void PFNGLGETINTERNALFORMATI64VPROC(uint target, uint internalformat, uint pname, uint bufSize, long *params);
    private delegate void PFNGLINVALIDATETEXSUBIMAGEPROC(uint texture, int level, int xoffset, int yoffset, int zoffset, uint width, uint height, uint depth);
    private delegate void PFNGLINVALIDATETEXIMAGEPROC(uint texture, int level);
    private delegate void PFNGLINVALIDATEBUFFERSUBDATAPROC(uint buffer, intptr offset, uintptr length);
    private delegate void PFNGLINVALIDATEBUFFERDATAPROC(uint buffer);
    private delegate void PFNGLINVALIDATEFRAMEBUFFERPROC(uint target, uint numAttachments, const uint *attachments);
    private delegate void PFNGLINVALIDATESUBFRAMEBUFFERPROC(uint target, uint numAttachments, const uint *attachments, int x, int y, uint width, uint height);
    private delegate void PFNGLMULTIDRAWARRAYSINDIRECTPROC(uint mode, const void *indirect, uint drawcount, uint stride);
    private delegate void PFNGLMULTIDRAWELEMENTSINDIRECTPROC(uint mode, uint type, const void *indirect, uint drawcount, uint stride);
    private delegate void PFNGLGETPROGRAMINTERFACEIVPROC(uint program, uint programInterface, uint pname, int *params);
    private delegate uint PFNGLGETPROGRAMRESOURCEINDEXPROC(uint program, uint programInterface, const byte *name);
    private delegate void PFNGLGETPROGRAMRESOURCENAMEPROC(uint program, uint programInterface, uint index, uint bufSize, uint *length, byte *name);
    private delegate void PFNGLGETPROGRAMRESOURCEIVPROC(uint program, uint programInterface, uint index, uint propCount, const uint *props, uint bufSize, uint *length, int *params);
    private delegate int PFNGLGETPROGRAMRESOURCELOCATIONPROC(uint program, uint programInterface, const byte *name);
    private delegate int PFNGLGETPROGRAMRESOURCELOCATIONINDEXPROC(uint program, uint programInterface, const byte *name);
    private delegate void PFNGLSHADERSTORAGEBLOCKBINDINGPROC(uint program, uint storageBlockIndex, uint storageBlockBinding);
    private delegate void PFNGLTEXBUFFERRANGEPROC(uint target, uint internalformat, uint buffer, intptr offset, uintptr size);
    private delegate void PFNGLTEXSTORAGE2DMULTISAMPLEPROC(uint target, uint samples, uint internalformat, uint width, uint height, bool fixedsamplelocations);
    private delegate void PFNGLTEXSTORAGE3DMULTISAMPLEPROC(uint target, uint samples, uint internalformat, uint width, uint height, uint depth, bool fixedsamplelocations);
    private delegate void PFNGLTEXTUREVIEWPROC(uint texture, uint target, uint origtexture, uint internalformat, uint minlevel, uint numlevels, uint minlayer, uint numlayers);
    private delegate void PFNGLBINDVERTEXBUFFERPROC(uint bindingindex, uint buffer, intptr offset, uint stride);
    private delegate void PFNGLVERTEXATTRIBFORMATPROC(uint attribindex, int size, uint type, bool normalized, uint relativeoffset);
    private delegate void PFNGLVERTEXATTRIBIFORMATPROC(uint attribindex, int size, uint type, uint relativeoffset);
    private delegate void PFNGLVERTEXATTRIBLFORMATPROC(uint attribindex, int size, uint type, uint relativeoffset);
    private delegate void PFNGLVERTEXATTRIBBINDINGPROC(uint attribindex, uint bindingindex);
    private delegate void PFNGLVERTEXBINDINGDIVISORPROC(uint bindingindex, uint divisor);
    private delegate void PFNGLDEBUGMESSAGECONTROLPROC(uint source, uint type, uint severity, uint count, const uint *ids, bool enabled);
    private delegate void PFNGLDEBUGMESSAGEINSERTPROC(uint source, uint type, uint id, uint severity, uint length, const byte *buf);
    private delegate void PFNGLDEBUGMESSAGECALLBACKPROC(GLDEBUGPROC callback, const void *userParam);
    private delegate uint PFNGLGETDEBUGMESSAGELOGPROC(uint count, uint bufSize, uint *sources, uint *types, uint *ids, uint *severities, uint *lengths, byte *messageLog);
    private delegate void PFNGLPUSHDEBUGGROUPPROC(uint source, uint id, uint length, const byte *message);
    private delegate void PFNGLPOPDEBUGGROUPPROC(void);
    private delegate void PFNGLOBJECTLABELPROC(uint identifier, uint name, uint length, const byte *label);
    private delegate void PFNGLGETOBJECTLABELPROC(uint identifier, uint name, uint bufSize, uint *length, byte *label);
    private delegate void PFNGLOBJECTPTRLABELPROC(const void *ptr, uint length, const byte *label);
    private delegate void PFNGLGETOBJECTPTRLABELPROC(const void *ptr, uint bufSize, uint *length, byte *label);

    public static void glClearBufferData(uint target, uint internalformat, uint format, uint type, const void *data);
    public static void glClearBufferSubData(uint target, uint internalformat, intptr offset, uintptr size, uint format, uint type, const void *data);
    public static void glDispatchCompute(uint num_groups_x, uint num_groups_y, uint num_groups_z);
    public static void glDispatchComputeIndirect(intptr indirect);
    public static void glCopyImageSubData(uint srcName, uint srcTarget, int srcLevel, int srcX, int srcY, int srcZ, uint dstName, uint dstTarget, int dstLevel, int dstX, int dstY, int dstZ, uint srcWidth, uint srcHeight, uint srcDepth);
    public static void glFramebufferParameteri(uint target, uint pname, int param);
    public static void glGetFramebufferParameteriv(uint target, uint pname, int *params);
    public static void glGetInternalformati64v(uint target, uint internalformat, uint pname, uint bufSize, long *params);
    public static void glInvalidateTexSubImage(uint texture, int level, int xoffset, int yoffset, int zoffset, uint width, uint height, uint depth);
    public static void glInvalidateTexImage(uint texture, int level);
    public static void glInvalidateBufferSubData(uint buffer, intptr offset, uintptr length);
    public static void glInvalidateBufferData(uint buffer);
    public static void glInvalidateFramebuffer(uint target, uint numAttachments, const uint *attachments);
    public static void glInvalidateSubFramebuffer(uint target, uint numAttachments, const uint *attachments, int x, int y, uint width, uint height);
    public static void glMultiDrawArraysIndirect(uint mode, const void *indirect, uint drawcount, uint stride);
    public static void glMultiDrawElementsIndirect(uint mode, uint type, const void *indirect, uint drawcount, uint stride);
    public static void glGetProgramInterfaceiv(uint program, uint programInterface, uint pname, int *params);
    public static uint glGetProgramResourceIndex(uint program, uint programInterface, const byte *name);
    public static void glGetProgramResourceName(uint program, uint programInterface, uint index, uint bufSize, uint *length, byte *name);
    public static void glGetProgramResourceiv(uint program, uint programInterface, uint index, uint propCount, const uint *props, uint bufSize, uint *length, int *params);
    public static int glGetProgramResourceLocation(uint program, uint programInterface, const byte *name);
    public static int glGetProgramResourceLocationIndex(uint program, uint programInterface, const byte *name);
    public static void glShaderStorageBlockBinding(uint program, uint storageBlockIndex, uint storageBlockBinding);
    public static void glTexBufferRange(uint target, uint internalformat, uint buffer, intptr offset, uintptr size);
    public static void glTexStorage2DMultisample(uint target, uint samples, uint internalformat, uint width, uint height, bool fixedsamplelocations);
    public static void glTexStorage3DMultisample(uint target, uint samples, uint internalformat, uint width, uint height, uint depth, bool fixedsamplelocations);
    public static void glTextureView(uint texture, uint target, uint origtexture, uint internalformat, uint minlevel, uint numlevels, uint minlayer, uint numlayers);
    public static void glBindVertexBuffer(uint bindingindex, uint buffer, intptr offset, uint stride);
    public static void glVertexAttribFormat(uint attribindex, int size, uint type, bool normalized, uint relativeoffset);
    public static void glVertexAttribIFormat(uint attribindex, int size, uint type, uint relativeoffset);
    public static void glVertexAttribLFormat(uint attribindex, int size, uint type, uint relativeoffset);
    public static void glVertexAttribBinding(uint attribindex, uint bindingindex);
    public static void glVertexBindingDivisor(uint bindingindex, uint divisor);
    public static void glDebugMessageControl(uint source, uint type, uint severity, uint count, const uint *ids, bool enabled);
    public static void glDebugMessageInsert(uint source, uint type, uint id, uint severity, uint length, const byte *buf);
    public static void glDebugMessageCallback(GLDEBUGPROC callback, const void *userParam);
    public static uint glGetDebugMessageLog(uint count, uint bufSize, uint *sources, uint *types, uint *ids, uint *severities, uint *lengths, byte *messageLog);
    public static void glPushDebugGroup(uint source, uint id, uint length, const byte *message);
    public static void glPopDebugGroup(void);
    public static void glObjectLabel(uint identifier, uint name, uint length, const byte *label);
    public static void glGetObjectLabel(uint identifier, uint name, uint bufSize, uint *length, byte *label);
    public static void glObjectPtrLabel(const void *ptr, uint length, const byte *label);
    public static void glGetObjectPtrLabel(const void *ptr, uint bufSize, uint *length, byte *label);
    #endregion

    #region GL_VERSION_4_4
    public const uint GL_MAX_VERTEX_ATTRIB_STRIDE = 0x82E5;
    public const uint GL_PRIMITIVE_RESTART_FOR_PATCHES_SUPPORTED = 0x8221;
    public const uint GL_TEXTURE_BUFFER_BINDING = 0x8C2A;
    public const uint GL_MAP_PERSISTENT_BIT = 0x0040;
    public const uint GL_MAP_COHERENT_BIT = 0x0080;
    public const uint GL_DYNAMIC_STORAGE_BIT = 0x0100;
    public const uint GL_CLIENT_STORAGE_BIT = 0x0200;
    public const uint GL_CLIENT_MAPPED_BUFFER_BARRIER_BIT = 0x00004000;
    public const uint GL_BUFFER_IMMUTABLE_STORAGE = 0x821F;
    public const uint GL_BUFFER_STORAGE_FLAGS = 0x8220;
    public const uint GL_CLEAR_TEXTURE = 0x9365;
    public const uint GL_LOCATION_COMPONENT = 0x934A;
    public const uint GL_TRANSFORM_FEEDBACK_BUFFER_INDEX = 0x934B;
    public const uint GL_TRANSFORM_FEEDBACK_BUFFER_STRIDE = 0x934C;
    public const uint GL_QUERY_BUFFER = 0x9192;
    public const uint GL_QUERY_BUFFER_BARRIER_BIT = 0x00008000;
    public const uint GL_QUERY_BUFFER_BINDING = 0x9193;
    public const uint GL_QUERY_RESULT_NO_WAIT = 0x9194;
    public const uint GL_MIRROR_CLAMP_TO_EDGE = 0x8743;
    
    private delegate void PFNGLBUFFERSTORAGEPROC(uint target, uintptr size, const void *data, uint flags);
    private delegate void PFNGLCLEARTEXIMAGEPROC(uint texture, int level, uint format, uint type, const void *data);
    private delegate void PFNGLCLEARTEXSUBIMAGEPROC(uint texture, int level, int xoffset, int yoffset, int zoffset, uint width, uint height, uint depth, uint format, uint type, const void *data);
    private delegate void PFNGLBINDBUFFERSBASEPROC(uint target, uint first, uint count, const uint *buffers);
    private delegate void PFNGLBINDBUFFERSRANGEPROC(uint target, uint first, uint count, const uint *buffers, const intptr *offsets, const uintptr *sizes);
    private delegate void PFNGLBINDTEXTURESPROC(uint first, uint count, const uint *textures);
    private delegate void PFNGLBINDSAMPLERSPROC(uint first, uint count, const uint *samplers);
    private delegate void PFNGLBINDIMAGETEXTURESPROC(uint first, uint count, const uint *textures);
    private delegate void PFNGLBINDVERTEXBUFFERSPROC(uint first, uint count, const uint *buffers, const intptr *offsets, const uint *strides);

    public static void glBufferStorage(uint target, uintptr size, const void *data, uint flags);
    public static void glClearTexImage(uint texture, int level, uint format, uint type, const void *data);
    public static void glClearTexSubImage(uint texture, int level, int xoffset, int yoffset, int zoffset, uint width, uint height, uint depth, uint format, uint type, const void *data);
    public static void glBindBuffersBase(uint target, uint first, uint count, const uint *buffers);
    public static void glBindBuffersRange(uint target, uint first, uint count, const uint *buffers, const intptr *offsets, const uintptr *sizes);
    public static void glBindTextures(uint first, uint count, const uint *textures);
    public static void glBindSamplers(uint first, uint count, const uint *samplers);
    public static void glBindImageTextures(uint first, uint count, const uint *textures);
    public static void glBindVertexBuffers(uint first, uint count, const uint *buffers, const intptr *offsets, const uint *strides);
    #endregion

    #ifndef GL_ARB_ES2_compatibility
    #define GL_ARB_ES2_compatibility 1
    #endif /* GL_ARB_ES2_compatibility */

    #ifndef GL_ARB_ES3_compatibility
    #define GL_ARB_ES3_compatibility 1
    #endif /* GL_ARB_ES3_compatibility */

    #ifndef GL_ARB_arrays_of_arrays
    #define GL_ARB_arrays_of_arrays 1
    #endif /* GL_ARB_arrays_of_arrays */

    #ifndef GL_ARB_base_instance
    #define GL_ARB_base_instance 1
    #endif /* GL_ARB_base_instance */

    #region GL_ARB_bindless_texture
    public const uint GL_UNSIGNED_long_ARB = 0x140F;
    
    private delegate ulong PFNGLGETTEXTUREHANDLEARBPROC(uint texture);
    private delegate ulong PFNGLGETTEXTURESAMPLERHANDLEARBPROC(uint texture, uint sampler);
    private delegate void PFNGLMAKETEXTUREHANDLERESIDENTARBPROC(ulong handle);
    private delegate void PFNGLMAKETEXTUREHANDLENONRESIDENTARBPROC(ulong handle);
    private delegate ulong PFNGLGETIMAGEHANDLEARBPROC(uint texture, int level, bool layered, int layer, uint format);
    private delegate void PFNGLMAKEIMAGEHANDLERESIDENTARBPROC(ulong handle, uint access);
    private delegate void PFNGLMAKEIMAGEHANDLENONRESIDENTARBPROC(ulong handle);
    private delegate void PFNGLUNIFORMHANDLEUI64ARBPROC(int location, ulong value);
    private delegate void PFNGLUNIFORMHANDLEUI64VARBPROC(int location, uint count, const ulong *value);
    private delegate void PFNGLPROGRAMUNIFORMHANDLEUI64ARBPROC(uint program, int location, ulong value);
    private delegate void PFNGLPROGRAMUNIFORMHANDLEUI64VARBPROC(uint program, int location, uint count, const ulong *values);
    private delegate bool PFNGLISTEXTUREHANDLERESIDENTARBPROC(ulong handle);
    private delegate bool PFNGLISIMAGEHANDLERESIDENTARBPROC(ulong handle);
    private delegate void PFNGLVERTEXATTRIBL1UI64ARBPROC(uint index, ulong x);
    private delegate void PFNGLVERTEXATTRIBL1UI64VARBPROC(uint index, const ulong *v);
    private delegate void PFNGLGETVERTEXATTRIBLUI64VARBPROC(uint index, uint pname, ulong *params);

    public static ulong glGetTextureHandleARB(uint texture);
    public static ulong glGetTextureSamplerHandleARB(uint texture, uint sampler);
    public static void glMakeTextureHandleResidentARB(ulong handle);
    public static void glMakeTextureHandleNonResidentARB(ulong handle);
    public static ulong glGetImageHandleARB(uint texture, int level, bool layered, int layer, uint format);
    public static void glMakeImageHandleResidentARB(ulong handle, uint access);
    public static void glMakeImageHandleNonResidentARB(ulong handle);
    public static void glUniformHandleui64ARB(int location, ulong value);
    public static void glUniformHandleui64vARB(int location, uint count, const ulong *value);
    public static void glProgramUniformHandleui64ARB(uint program, int location, ulong value);
    public static void glProgramUniformHandleui64vARB(uint program, int location, uint count, const ulong *values);
    public static bool glIsTextureHandleResidentARB(ulong handle);
    public static bool glIsImageHandleResidentARB(ulong handle);
    public static void glVertexAttribL1ui64ARB(uint index, ulong x);
    public static void glVertexAttribL1ui64vARB(uint index, const ulong *v);
    public static void glGetVertexAttribLui64vARB(uint index, uint pname, ulong *params);
    #endregion

    /*#ifndef GL_ARB_cl_event
    struct _cl_context;
    struct _cl_event;
    public const uint GL_SYNC_CL_EVENT_ARB = 0x8240;
    public const uint GL_SYNC_CL_EVENT_COMPLETE_ARB = 0x8241;
    private delegate GLsync PFNGLCREATESYNCFROMCLEVENTARBPROC(struct _cl_context *context, struct _cl_event *event, uint flags);
    public static GLsync glCreateSyncFromCLeventARB(struct _cl_context *context, struct _cl_event *event, uint flags);
    #endif /* GL_ARB_cl_event */

    #region GL_ARB_color_buffer_float
    public const uint GL_RGBA_FLOAT_MODE_ARB = 0x8820;
    public const uint GL_CLAMP_VERTEX_COLOR_ARB = 0x891A;
    public const uint GL_CLAMP_FRAGMENT_COLOR_ARB = 0x891B;
    public const uint GL_CLAMP_READ_COLOR_ARB = 0x891C;
    public const uint GL_FIXED_ONLY_ARB = 0x891D;
    
    private delegate void PFNGLCLAMPCOLORARBPROC(uint target, uint clamp);

    public static void glClampColorARB(uint target, uint clamp);
    #endregion

    #region GL_ARB_compute_shader
    public const uint GL_COMPUTE_SHADER_BIT = 0x00000020;
    #endregion

    #region GL_ARB_compute_variable_group_size
    public const uint GL_MAX_COMPUTE_VARIABLE_GROUP_INVOCATIONS_ARB = 0x9344;
    public const uint GL_MAX_COMPUTE_FIXED_GROUP_INVOCATIONS_ARB = 0x90EB;
    public const uint GL_MAX_COMPUTE_VARIABLE_GROUP_SIZE_ARB = 0x9345;
    public const uint GL_MAX_COMPUTE_FIXED_GROUP_SIZE_ARB = 0x91BF;
    
    private delegate void PFNGLDISPATCHCOMPUTEGROUPSIZEARBPROC(uint num_groups_x, uint num_groups_y, uint num_groups_z, uint group_size_x, uint group_size_y, uint group_size_z);

    public static void glDispatchComputeGroupSizeARB(uint num_groups_x, uint num_groups_y, uint num_groups_z, uint group_size_x, uint group_size_y, uint group_size_z);
    #endregion

    #region GL_ARB_copy_buffer
    public const uint GL_COPY_READ_BUFFER_BINDING = 0x8F36;
    public const uint GL_COPY_WRITE_BUFFER_BINDING = 0x8F37;
    #endregion

    #region GL_ARB_debug_output
    typedef void (APIENTRY  *GLDEBUGPROCARB)(uint source,uint type,uint id,uint severity,uint length,const byte *message,const void *userParam);
    public const uint GL_DEBUG_OUTPUT_SYNCHRONOUS_ARB = 0x8242;
    public const uint GL_DEBUG_NEXT_LOGGED_MESSAGE_LENGTH_ARB = 0x8243;
    public const uint GL_DEBUG_CALLBACK_FUNCTION_ARB = 0x8244;
    public const uint GL_DEBUG_CALLBACK_USER_PARAM_ARB = 0x8245;
    public const uint GL_DEBUG_SOURCE_API_ARB = 0x8246;
    public const uint GL_DEBUG_SOURCE_WINDOW_SYSTEM_ARB = 0x8247;
    public const uint GL_DEBUG_SOURCE_SHADER_COMPILER_ARB = 0x8248;
    public const uint GL_DEBUG_SOURCE_THIRD_PARTY_ARB = 0x8249;
    public const uint GL_DEBUG_SOURCE_APPLICATION_ARB = 0x824A;
    public const uint GL_DEBUG_SOURCE_OTHER_ARB = 0x824B;
    public const uint GL_DEBUG_TYPE_ERROR_ARB = 0x824C;
    public const uint GL_DEBUG_TYPE_DEPRECATED_BEHAVIOR_ARB = 0x824D;
    public const uint GL_DEBUG_TYPE_UNDEFINED_BEHAVIOR_ARB = 0x824E;
    public const uint GL_DEBUG_TYPE_PORTABILITY_ARB = 0x824F;
    public const uint GL_DEBUG_TYPE_PERFORMANCE_ARB = 0x8250;
    public const uint GL_DEBUG_TYPE_OTHER_ARB = 0x8251;
    public const uint GL_MAX_DEBUG_MESSAGE_LENGTH_ARB = 0x9143;
    public const uint GL_MAX_DEBUG_LOGGED_MESSAGES_ARB = 0x9144;
    public const uint GL_DEBUG_LOGGED_MESSAGES_ARB = 0x9145;
    public const uint GL_DEBUG_SEVERITY_HIGH_ARB = 0x9146;
    public const uint GL_DEBUG_SEVERITY_MEDIUM_ARB = 0x9147;
    public const uint GL_DEBUG_SEVERITY_LOW_ARB = 0x9148;
    
    private delegate void PFNGLDEBUGMESSAGECONTROLARBPROC(uint source, uint type, uint severity, uint count, const uint *ids, bool enabled);
    private delegate void PFNGLDEBUGMESSAGEINSERTARBPROC(uint source, uint type, uint id, uint severity, uint length, const byte *buf);
    private delegate void PFNGLDEBUGMESSAGECALLBACKARBPROC(GLDEBUGPROCARB callback, const void *userParam);
    private delegate uint PFNGLGETDEBUGMESSAGELOGARBPROC(uint count, uint bufSize, uint *sources, uint *types, uint *ids, uint *severities, uint *lengths, byte *messageLog);

    public static void glDebugMessageControlARB(uint source, uint type, uint severity, uint count, const uint *ids, bool enabled);
    public static void glDebugMessageInsertARB(uint source, uint type, uint id, uint severity, uint length, const byte *buf);
    public static void glDebugMessageCallbackARB(GLDEBUGPROCARB callback, const void *userParam);
    public static uint glGetDebugMessageLogARB(uint count, uint bufSize, uint *sources, uint *types, uint *ids, uint *severities, uint *lengths, byte *messageLog);
    #endregion

    #region GL_ARB_depth_texture
    public const uint GL_DEPTH_COMPONENT16_ARB = 0x81A5;
    public const uint GL_DEPTH_COMPONENT24_ARB = 0x81A6;
    public const uint GL_DEPTH_COMPONENT32_ARB = 0x81A7;
    public const uint GL_TEXTURE_DEPTH_SIZE_ARB = 0x884A;
    public const uint GL_DEPTH_TEXTURE_MODE_ARB = 0x884B;
    #endregion

    #ifndef GL_ARB_draw_buffers
    #define GL_ARB_draw_buffers 1
    public const uint GL_MAX_DRAW_BUFFERS_ARB = 0x8824;
    public const uint GL_DRAW_BUFFER0_ARB = 0x8825;
    public const uint GL_DRAW_BUFFER1_ARB = 0x8826;
    public const uint GL_DRAW_BUFFER2_ARB = 0x8827;
    public const uint GL_DRAW_BUFFER3_ARB = 0x8828;
    public const uint GL_DRAW_BUFFER4_ARB = 0x8829;
    public const uint GL_DRAW_BUFFER5_ARB = 0x882A;
    public const uint GL_DRAW_BUFFER6_ARB = 0x882B;
    public const uint GL_DRAW_BUFFER7_ARB = 0x882C;
    public const uint GL_DRAW_BUFFER8_ARB = 0x882D;
    public const uint GL_DRAW_BUFFER9_ARB = 0x882E;
    public const uint GL_DRAW_BUFFER10_ARB = 0x882F;
    public const uint GL_DRAW_BUFFER11_ARB = 0x8830;
    public const uint GL_DRAW_BUFFER12_ARB = 0x8831;
    public const uint GL_DRAW_BUFFER13_ARB = 0x8832;
    public const uint GL_DRAW_BUFFER14_ARB = 0x8833;
    public const uint GL_DRAW_BUFFER15_ARB = 0x8834;
    private delegate void PFNGLDRAWBUFFERSARBPROC(uint n, const uint *bufs);
    #ifdef GL_GLEXT_PROTOTYPES
    public static void glDrawBuffersARB(uint n, const uint *bufs);
    #endif
    #endif /* GL_ARB_draw_buffers */

    #ifndef GL_ARB_draw_buffers_blend
    #define GL_ARB_draw_buffers_blend 1
    private delegate void PFNGLBLENDEQUATIONIARBPROC(uint buf, uint mode);
    private delegate void PFNGLBLENDEQUATIONSEPARATEIARBPROC(uint buf, uint modeRGB, uint modeAlpha);
    private delegate void PFNGLBLENDFUNCIARBPROC(uint buf, uint src, uint dst);
    private delegate void PFNGLBLENDFUNCSEPARATEIARBPROC(uint buf, uint srcRGB, uint dstRGB, uint srcAlpha, uint dstAlpha);
    #ifdef GL_GLEXT_PROTOTYPES
    public static void glBlendEquationiARB(uint buf, uint mode);
    public static void glBlendEquationSeparateiARB(uint buf, uint modeRGB, uint modeAlpha);
    public static void glBlendFunciARB(uint buf, uint src, uint dst);
    public static void glBlendFuncSeparateiARB(uint buf, uint srcRGB, uint dstRGB, uint srcAlpha, uint dstAlpha);
    #endif
    #endif /* GL_ARB_draw_buffers_blend */

    #ifndef GL_ARB_draw_elements_base_vertex
    #define GL_ARB_draw_elements_base_vertex 1
    #endif /* GL_ARB_draw_elements_base_vertex */

    #ifndef GL_ARB_draw_indirect
    #define GL_ARB_draw_indirect 1
    #endif /* GL_ARB_draw_indirect */

    #ifndef GL_ARB_draw_instanced
    #define GL_ARB_draw_instanced 1
    private delegate void PFNGLDRAWARRAYSINSTANCEDARBPROC(uint mode, int first, uint count, uint primcount);
    private delegate void PFNGLDRAWELEMENTSINSTANCEDARBPROC(uint mode, uint count, uint type, const void *indices, uint primcount);
    #ifdef GL_GLEXT_PROTOTYPES
    public static void glDrawArraysInstancedARB(uint mode, int first, uint count, uint primcount);
    public static void glDrawElementsInstancedARB(uint mode, uint count, uint type, const void *indices, uint primcount);
    #endif
    #endif /* GL_ARB_draw_instanced */

    #ifndef GL_ARB_enhanced_layouts
    #define GL_ARB_enhanced_layouts 1
    #endif /* GL_ARB_enhanced_layouts */

    #ifndef GL_ARB_explicit_attrib_location
    #define GL_ARB_explicit_attrib_location 1
    #endif /* GL_ARB_explicit_attrib_location */

    #ifndef GL_ARB_explicit_uniform_location
    #define GL_ARB_explicit_uniform_location 1
    #endif /* GL_ARB_explicit_uniform_location */

    #ifndef GL_ARB_fragment_coord_conventions
    #define GL_ARB_fragment_coord_conventions 1
    #endif /* GL_ARB_fragment_coord_conventions */

    #ifndef GL_ARB_fragment_layer_viewport
    #define GL_ARB_fragment_layer_viewport 1
    #endif /* GL_ARB_fragment_layer_viewport */

    #ifndef GL_ARB_fragment_program
    #define GL_ARB_fragment_program 1
    public const uint GL_FRAGMENT_PROGRAM_ARB = 0x8804;
    public const uint GL_PROGRAM_FORMAT_ASCII_ARB = 0x8875;
    public const uint GL_PROGRAM_LENGTH_ARB = 0x8627;
    public const uint GL_PROGRAM_FORMAT_ARB = 0x8876;
    public const uint GL_PROGRAM_BINDING_ARB = 0x8677;
    public const uint GL_PROGRAM_INSTRUCTIONS_ARB = 0x88A0;
    public const uint GL_MAX_PROGRAM_INSTRUCTIONS_ARB = 0x88A1;
    public const uint GL_PROGRAM_NATIVE_INSTRUCTIONS_ARB = 0x88A2;
    public const uint GL_MAX_PROGRAM_NATIVE_INSTRUCTIONS_ARB = 0x88A3;
    public const uint GL_PROGRAM_TEMPORARIES_ARB = 0x88A4;
    public const uint GL_MAX_PROGRAM_TEMPORARIES_ARB = 0x88A5;
    public const uint GL_PROGRAM_NATIVE_TEMPORARIES_ARB = 0x88A6;
    public const uint GL_MAX_PROGRAM_NATIVE_TEMPORARIES_ARB = 0x88A7;
    public const uint GL_PROGRAM_PARAMETERS_ARB = 0x88A8;
    public const uint GL_MAX_PROGRAM_PARAMETERS_ARB = 0x88A9;
    public const uint GL_PROGRAM_NATIVE_PARAMETERS_ARB = 0x88AA;
    public const uint GL_MAX_PROGRAM_NATIVE_PARAMETERS_ARB = 0x88AB;
    public const uint GL_PROGRAM_ATTRIBS_ARB = 0x88AC;
    public const uint GL_MAX_PROGRAM_ATTRIBS_ARB = 0x88AD;
    public const uint GL_PROGRAM_NATIVE_ATTRIBS_ARB = 0x88AE;
    public const uint GL_MAX_PROGRAM_NATIVE_ATTRIBS_ARB = 0x88AF;
    public const uint GL_MAX_PROGRAM_LOCAL_PARAMETERS_ARB = 0x88B4;
    public const uint GL_MAX_PROGRAM_ENV_PARAMETERS_ARB = 0x88B5;
    public const uint GL_PROGRAM_UNDER_NATIVE_LIMITS_ARB = 0x88B6;
    public const uint GL_PROGRAM_ALU_INSTRUCTIONS_ARB = 0x8805;
    public const uint GL_PROGRAM_TEX_INSTRUCTIONS_ARB = 0x8806;
    public const uint GL_PROGRAM_TEX_INDIRECTIONS_ARB = 0x8807;
    public const uint GL_PROGRAM_NATIVE_ALU_INSTRUCTIONS_ARB = 0x8808;
    public const uint GL_PROGRAM_NATIVE_TEX_INSTRUCTIONS_ARB = 0x8809;
    public const uint GL_PROGRAM_NATIVE_TEX_INDIRECTIONS_ARB = 0x880A;
    public const uint GL_MAX_PROGRAM_ALU_INSTRUCTIONS_ARB = 0x880B;
    public const uint GL_MAX_PROGRAM_TEX_INSTRUCTIONS_ARB = 0x880C;
    public const uint GL_MAX_PROGRAM_TEX_INDIRECTIONS_ARB = 0x880D;
    public const uint GL_MAX_PROGRAM_NATIVE_ALU_INSTRUCTIONS_ARB = 0x880E;
    public const uint GL_MAX_PROGRAM_NATIVE_TEX_INSTRUCTIONS_ARB = 0x880F;
    public const uint GL_MAX_PROGRAM_NATIVE_TEX_INDIRECTIONS_ARB = 0x8810;
    public const uint GL_PROGRAM_STRING_ARB = 0x8628;
    public const uint GL_PROGRAM_ERROR_POSITION_ARB = 0x864B;
    public const uint GL_CURRENT_MATRIX_ARB = 0x8641;
    public const uint GL_TRANSPOSE_CURRENT_MATRIX_ARB = 0x88B7;
    public const uint GL_CURRENT_MATRIX_STACK_DEPTH_ARB = 0x8640;
    public const uint GL_MAX_PROGRAM_MATRICES_ARB = 0x862F;
    public const uint GL_MAX_PROGRAM_MATRIX_STACK_DEPTH_ARB = 0x862E;
    public const uint GL_MAX_TEXTURE_COORDS_ARB = 0x8871;
    public const uint GL_MAX_TEXTURE_IMAGE_UNITS_ARB = 0x8872;
    public const uint GL_PROGRAM_ERROR_STRING_ARB = 0x8874;
    public const uint GL_MATRIX0_ARB = 0x88C0;
    public const uint GL_MATRIX1_ARB = 0x88C1;
    public const uint GL_MATRIX2_ARB = 0x88C2;
    public const uint GL_MATRIX3_ARB = 0x88C3;
    public const uint GL_MATRIX4_ARB = 0x88C4;
    public const uint GL_MATRIX5_ARB = 0x88C5;
    public const uint GL_MATRIX6_ARB = 0x88C6;
    public const uint GL_MATRIX7_ARB = 0x88C7;
    public const uint GL_MATRIX8_ARB = 0x88C8;
    public const uint GL_MATRIX9_ARB = 0x88C9;
    public const uint GL_MATRIX10_ARB = 0x88CA;
    public const uint GL_MATRIX11_ARB = 0x88CB;
    public const uint GL_MATRIX12_ARB = 0x88CC;
    public const uint GL_MATRIX13_ARB = 0x88CD;
    public const uint GL_MATRIX14_ARB = 0x88CE;
    public const uint GL_MATRIX15_ARB = 0x88CF;
    public const uint GL_MATRIX16_ARB = 0x88D0;
    public const uint GL_MATRIX17_ARB = 0x88D1;
    public const uint GL_MATRIX18_ARB = 0x88D2;
    public const uint GL_MATRIX19_ARB = 0x88D3;
    public const uint GL_MATRIX20_ARB = 0x88D4;
    public const uint GL_MATRIX21_ARB = 0x88D5;
    public const uint GL_MATRIX22_ARB = 0x88D6;
    public const uint GL_MATRIX23_ARB = 0x88D7;
    public const uint GL_MATRIX24_ARB = 0x88D8;
    public const uint GL_MATRIX25_ARB = 0x88D9;
    public const uint GL_MATRIX26_ARB = 0x88DA;
    public const uint GL_MATRIX27_ARB = 0x88DB;
    public const uint GL_MATRIX28_ARB = 0x88DC;
    public const uint GL_MATRIX29_ARB = 0x88DD;
    public const uint GL_MATRIX30_ARB = 0x88DE;
    public const uint GL_MATRIX31_ARB = 0x88DF;
    private delegate void PFNGLPROGRAMSTRINGARBPROC(uint target, uint format, uint len, const void *string);
    private delegate void PFNGLBINDPROGRAMARBPROC(uint target, uint program);
    private delegate void PFNGLDELETEPROGRAMSARBPROC(uint n, const uint *programs);
    private delegate void PFNGLGENPROGRAMSARBPROC(uint n, uint *programs);
    private delegate void PFNGLPROGRAMENVPARAMETER4DARBPROC(uint target, uint index, double x, double y, double z, double w);
    private delegate void PFNGLPROGRAMENVPARAMETER4DVARBPROC(uint target, uint index, const double *params);
    private delegate void PFNGLPROGRAMENVPARAMETER4FARBPROC(uint target, uint index, float x, float y, float z, float w);
    private delegate void PFNGLPROGRAMENVPARAMETER4FVARBPROC(uint target, uint index, const float *params);
    private delegate void PFNGLPROGRAMLOCALPARAMETER4DARBPROC(uint target, uint index, double x, double y, double z, double w);
    private delegate void PFNGLPROGRAMLOCALPARAMETER4DVARBPROC(uint target, uint index, const double *params);
    private delegate void PFNGLPROGRAMLOCALPARAMETER4FARBPROC(uint target, uint index, float x, float y, float z, float w);
    private delegate void PFNGLPROGRAMLOCALPARAMETER4FVARBPROC(uint target, uint index, const float *params);
    private delegate void PFNGLGETPROGRAMENVPARAMETERDVARBPROC(uint target, uint index, double *params);
    private delegate void PFNGLGETPROGRAMENVPARAMETERFVARBPROC(uint target, uint index, float *params);
    private delegate void PFNGLGETPROGRAMLOCALPARAMETERDVARBPROC(uint target, uint index, double *params);
    private delegate void PFNGLGETPROGRAMLOCALPARAMETERFVARBPROC(uint target, uint index, float *params);
    private delegate void PFNGLGETPROGRAMIVARBPROC(uint target, uint pname, int *params);
    private delegate void PFNGLGETPROGRAMSTRINGARBPROC(uint target, uint pname, void *string);
    private delegate bool PFNGLISPROGRAMARBPROC(uint program);
    #ifdef GL_GLEXT_PROTOTYPES
    public static void glProgramStringARB(uint target, uint format, uint len, const void *string);
    public static void glBindProgramARB(uint target, uint program);
    public static void glDeleteProgramsARB(uint n, const uint *programs);
    public static void glGenProgramsARB(uint n, uint *programs);
    public static void glProgramEnvParameter4dARB(uint target, uint index, double x, double y, double z, double w);
    public static void glProgramEnvParameter4dvARB(uint target, uint index, const double *params);
    public static void glProgramEnvParameter4fARB(uint target, uint index, float x, float y, float z, float w);
    public static void glProgramEnvParameter4fvARB(uint target, uint index, const float *params);
    public static void glProgramLocalParameter4dARB(uint target, uint index, double x, double y, double z, double w);
    public static void glProgramLocalParameter4dvARB(uint target, uint index, const double *params);
    public static void glProgramLocalParameter4fARB(uint target, uint index, float x, float y, float z, float w);
    public static void glProgramLocalParameter4fvARB(uint target, uint index, const float *params);
    public static void glGetProgramEnvParameterdvARB(uint target, uint index, double *params);
    public static void glGetProgramEnvParameterfvARB(uint target, uint index, float *params);
    public static void glGetProgramLocalParameterdvARB(uint target, uint index, double *params);
    public static void glGetProgramLocalParameterfvARB(uint target, uint index, float *params);
    public static void glGetProgramivARB(uint target, uint pname, int *params);
    public static void glGetProgramStringARB(uint target, uint pname, void *string);
    public static bool glIsProgramARB(uint program);
    #endif
    #endif /* GL_ARB_fragment_program */

    #ifndef GL_ARB_fragment_program_shadow
    #define GL_ARB_fragment_program_shadow 1
    #endif /* GL_ARB_fragment_program_shadow */

    #ifndef GL_ARB_fragment_shader
    #define GL_ARB_fragment_shader 1
    public const uint GL_FRAGMENT_SHADER_ARB = 0x8B30;
    public const uint GL_MAX_FRAGMENT_UNIFORM_COMPONENTS_ARB = 0x8B49;
    public const uint GL_FRAGMENT_SHADER_DERIVATIVE_HINT_ARB = 0x8B8B;
    #endif /* GL_ARB_fragment_shader */

    #ifndef GL_ARB_framebuffer_no_attachments
    #define GL_ARB_framebuffer_no_attachments 1
    #endif /* GL_ARB_framebuffer_no_attachments */

    #ifndef GL_ARB_framebuffer_object
    #define GL_ARB_framebuffer_object 1
    #endif /* GL_ARB_framebuffer_object */

    #ifndef GL_ARB_framebuffer_sRGB
    #define GL_ARB_framebuffer_sRGB 1
    #endif /* GL_ARB_framebuffer_sRGB */

    #ifndef GL_ARB_geometry_shader4
    #define GL_ARB_geometry_shader4 1
    public const uint GL_LINES_ADJACENCY_ARB = 0x000A;
    public const uint GL_LINE_STRIP_ADJACENCY_ARB = 0x000B;
    public const uint GL_TRIANGLES_ADJACENCY_ARB = 0x000C;
    public const uint GL_TRIANGLE_STRIP_ADJACENCY_ARB = 0x000D;
    public const uint GL_PROGRAM_POINT_SIZE_ARB = 0x8642;
    public const uint GL_MAX_GEOMETRY_TEXTURE_IMAGE_UNITS_ARB = 0x8C29;
    public const uint GL_FRAMEBUFFER_ATTACHMENT_LAYERED_ARB = 0x8DA7;
    public const uint GL_FRAMEBUFFER_INCOMPLETE_LAYER_TARGETS_ARB = 0x8DA8;
    public const uint GL_FRAMEBUFFER_INCOMPLETE_LAYER_COUNT_ARB = 0x8DA9;
    public const uint GL_GEOMETRY_SHADER_ARB = 0x8DD9;
    public const uint GL_GEOMETRY_VERTICES_OUT_ARB = 0x8DDA;
    public const uint GL_GEOMETRY_INPUT_TYPE_ARB = 0x8DDB;
    public const uint GL_GEOMETRY_OUTPUT_TYPE_ARB = 0x8DDC;
    public const uint GL_MAX_GEOMETRY_VARYING_COMPONENTS_ARB = 0x8DDD;
    public const uint GL_MAX_VERTEX_VARYING_COMPONENTS_ARB = 0x8DDE;
    public const uint GL_MAX_GEOMETRY_UNIFORM_COMPONENTS_ARB = 0x8DDF;
    public const uint GL_MAX_GEOMETRY_OUTPUT_VERTICES_ARB = 0x8DE0;
    public const uint GL_MAX_GEOMETRY_TOTAL_OUTPUT_COMPONENTS_ARB = 0x8DE1;
    private delegate void PFNGLPROGRAMPARAMETERIARBPROC(uint program, uint pname, int value);
    private delegate void PFNGLFRAMEBUFFERTEXTUREARBPROC(uint target, uint attachment, uint texture, int level);
    private delegate void PFNGLFRAMEBUFFERTEXTURELAYERARBPROC(uint target, uint attachment, uint texture, int level, int layer);
    private delegate void PFNGLFRAMEBUFFERTEXTUREFACEARBPROC(uint target, uint attachment, uint texture, int level, uint face);
    #ifdef GL_GLEXT_PROTOTYPES
    public static void glProgramParameteriARB(uint program, uint pname, int value);
    public static void glFramebufferTextureARB(uint target, uint attachment, uint texture, int level);
    public static void glFramebufferTextureLayerARB(uint target, uint attachment, uint texture, int level, int layer);
    public static void glFramebufferTextureFaceARB(uint target, uint attachment, uint texture, int level, uint face);
    #endif
    #endif /* GL_ARB_geometry_shader4 */

    #ifndef GL_ARB_get_program_binary
    #define GL_ARB_get_program_binary 1
    #endif /* GL_ARB_get_program_binary */

    #ifndef GL_ARB_gpu_shader5
    #define GL_ARB_gpu_shader5 1
    #endif /* GL_ARB_gpu_shader5 */

    #ifndef GL_ARB_gpu_shader_fp64
    #define GL_ARB_gpu_shader_fp64 1
    #endif /* GL_ARB_gpu_shader_fp64 */

    #ifndef GL_ARB_half_float_pixel
    #define GL_ARB_half_float_pixel 1
    typedef unsigned short ushortARB;
    public const uint GL_HALF_FLOAT_ARB = 0x140B;
    #endif /* GL_ARB_half_float_pixel */

    #ifndef GL_ARB_half_float_vertex
    #define GL_ARB_half_float_vertex 1
    #endif /* GL_ARB_half_float_vertex */

    #ifndef GL_ARB_imaging
    #define GL_ARB_imaging 1
    public const uint GL_BLEND_COLOR = 0x8005;
    public const uint GL_BLEND_EQUATION = 0x8009;
    public const uint GL_CONVOLUTION_1D = 0x8010;
    public const uint GL_CONVOLUTION_2D = 0x8011;
    public const uint GL_SEPARABLE_2D = 0x8012;
    public const uint GL_CONVOLUTION_BORDER_MODE = 0x8013;
    public const uint GL_CONVOLUTION_FILTER_SCALE = 0x8014;
    public const uint GL_CONVOLUTION_FILTER_BIAS = 0x8015;
    public const uint GL_REDUCE = 0x8016;
    public const uint GL_CONVOLUTION_FORMAT = 0x8017;
    public const uint GL_CONVOLUTION_WIDTH = 0x8018;
    public const uint GL_CONVOLUTION_HEIGHT = 0x8019;
    public const uint GL_MAX_CONVOLUTION_WIDTH = 0x801A;
    public const uint GL_MAX_CONVOLUTION_HEIGHT = 0x801B;
    public const uint GL_POST_CONVOLUTION_RED_SCALE = 0x801C;
    public const uint GL_POST_CONVOLUTION_GREEN_SCALE = 0x801D;
    public const uint GL_POST_CONVOLUTION_BLUE_SCALE = 0x801E;
    public const uint GL_POST_CONVOLUTION_ALPHA_SCALE = 0x801F;
    public const uint GL_POST_CONVOLUTION_RED_BIAS = 0x8020;
    public const uint GL_POST_CONVOLUTION_GREEN_BIAS = 0x8021;
    public const uint GL_POST_CONVOLUTION_BLUE_BIAS = 0x8022;
    public const uint GL_POST_CONVOLUTION_ALPHA_BIAS = 0x8023;
    public const uint GL_HISTOGRAM = 0x8024;
    public const uint GL_PROXY_HISTOGRAM = 0x8025;
    public const uint GL_HISTOGRAM_WIDTH = 0x8026;
    public const uint GL_HISTOGRAM_FORMAT = 0x8027;
    public const uint GL_HISTOGRAM_RED_SIZE = 0x8028;
    public const uint GL_HISTOGRAM_GREEN_SIZE = 0x8029;
    public const uint GL_HISTOGRAM_BLUE_SIZE = 0x802A;
    public const uint GL_HISTOGRAM_ALPHA_SIZE = 0x802B;
    public const uint GL_HISTOGRAM_LUMINANCE_SIZE = 0x802C;
    public const uint GL_HISTOGRAM_SINK = 0x802D;
    public const uint GL_MINMAX = 0x802E;
    public const uint GL_MINMAX_FORMAT = 0x802F;
    public const uint GL_MINMAX_SINK = 0x8030;
    public const uint GL_TABLE_TOO_LARGE = 0x8031;
    public const uint GL_COLOR_MATRIX = 0x80B1;
    public const uint GL_COLOR_MATRIX_STACK_DEPTH = 0x80B2;
    public const uint GL_MAX_COLOR_MATRIX_STACK_DEPTH = 0x80B3;
    public const uint GL_POST_COLOR_MATRIX_RED_SCALE = 0x80B4;
    public const uint GL_POST_COLOR_MATRIX_GREEN_SCALE = 0x80B5;
    public const uint GL_POST_COLOR_MATRIX_BLUE_SCALE = 0x80B6;
    public const uint GL_POST_COLOR_MATRIX_ALPHA_SCALE = 0x80B7;
    public const uint GL_POST_COLOR_MATRIX_RED_BIAS = 0x80B8;
    public const uint GL_POST_COLOR_MATRIX_GREEN_BIAS = 0x80B9;
    public const uint GL_POST_COLOR_MATRIX_BLUE_BIAS = 0x80BA;
    public const uint GL_POST_COLOR_MATRIX_ALPHA_BIAS = 0x80BB;
    public const uint GL_COLOR_TABLE = 0x80D0;
    public const uint GL_POST_CONVOLUTION_COLOR_TABLE = 0x80D1;
    public const uint GL_POST_COLOR_MATRIX_COLOR_TABLE = 0x80D2;
    public const uint GL_PROXY_COLOR_TABLE = 0x80D3;
    public const uint GL_PROXY_POST_CONVOLUTION_COLOR_TABLE = 0x80D4;
    public const uint GL_PROXY_POST_COLOR_MATRIX_COLOR_TABLE = 0x80D5;
    public const uint GL_COLOR_TABLE_SCALE = 0x80D6;
    public const uint GL_COLOR_TABLE_BIAS = 0x80D7;
    public const uint GL_COLOR_TABLE_FORMAT = 0x80D8;
    public const uint GL_COLOR_TABLE_WIDTH = 0x80D9;
    public const uint GL_COLOR_TABLE_RED_SIZE = 0x80DA;
    public const uint GL_COLOR_TABLE_GREEN_SIZE = 0x80DB;
    public const uint GL_COLOR_TABLE_BLUE_SIZE = 0x80DC;
    public const uint GL_COLOR_TABLE_ALPHA_SIZE = 0x80DD;
    public const uint GL_COLOR_TABLE_LUMINANCE_SIZE = 0x80DE;
    public const uint GL_COLOR_TABLE_INTENSITY_SIZE = 0x80DF;
    public const uint GL_CONSTANT_BORDER = 0x8151;
    public const uint GL_REPLICATE_BORDER = 0x8153;
    public const uint GL_CONVOLUTION_BORDER_COLOR = 0x8154;
    private delegate void PFNGLCOLORTABLEPROC(uint target, uint internalformat, uint width, uint format, uint type, const void *table);
    private delegate void PFNGLCOLORTABLEPARAMETERFVPROC(uint target, uint pname, const float *params);
    private delegate void PFNGLCOLORTABLEPARAMETERIVPROC(uint target, uint pname, const int *params);
    private delegate void PFNGLCOPYCOLORTABLEPROC(uint target, uint internalformat, int x, int y, uint width);
    private delegate void PFNGLGETCOLORTABLEPROC(uint target, uint format, uint type, void *table);
    private delegate void PFNGLGETCOLORTABLEPARAMETERFVPROC(uint target, uint pname, float *params);
    private delegate void PFNGLGETCOLORTABLEPARAMETERIVPROC(uint target, uint pname, int *params);
    private delegate void PFNGLCOLORSUBTABLEPROC(uint target, uint start, uint count, uint format, uint type, const void *data);
    private delegate void PFNGLCOPYCOLORSUBTABLEPROC(uint target, uint start, int x, int y, uint width);
    private delegate void PFNGLCONVOLUTIONFILTER1DPROC(uint target, uint internalformat, uint width, uint format, uint type, const void *image);
    private delegate void PFNGLCONVOLUTIONFILTER2DPROC(uint target, uint internalformat, uint width, uint height, uint format, uint type, const void *image);
    private delegate void PFNGLCONVOLUTIONPARAMETERFPROC(uint target, uint pname, float params);
    private delegate void PFNGLCONVOLUTIONPARAMETERFVPROC(uint target, uint pname, const float *params);
    private delegate void PFNGLCONVOLUTIONPARAMETERIPROC(uint target, uint pname, int params);
    private delegate void PFNGLCONVOLUTIONPARAMETERIVPROC(uint target, uint pname, const int *params);
    private delegate void PFNGLCOPYCONVOLUTIONFILTER1DPROC(uint target, uint internalformat, int x, int y, uint width);
    private delegate void PFNGLCOPYCONVOLUTIONFILTER2DPROC(uint target, uint internalformat, int x, int y, uint width, uint height);
    private delegate void PFNGLGETCONVOLUTIONFILTERPROC(uint target, uint format, uint type, void *image);
    private delegate void PFNGLGETCONVOLUTIONPARAMETERFVPROC(uint target, uint pname, float *params);
    private delegate void PFNGLGETCONVOLUTIONPARAMETERIVPROC(uint target, uint pname, int *params);
    private delegate void PFNGLGETSEPARABLEFILTERPROC(uint target, uint format, uint type, void *row, void *column, void *span);
    private delegate void PFNGLSEPARABLEFILTER2DPROC(uint target, uint internalformat, uint width, uint height, uint format, uint type, const void *row, const void *column);
    private delegate void PFNGLGETHISTOGRAMPROC(uint target, bool reset, uint format, uint type, void *values);
    private delegate void PFNGLGETHISTOGRAMPARAMETERFVPROC(uint target, uint pname, float *params);
    private delegate void PFNGLGETHISTOGRAMPARAMETERIVPROC(uint target, uint pname, int *params);
    private delegate void PFNGLGETMINMAXPROC(uint target, bool reset, uint format, uint type, void *values);
    private delegate void PFNGLGETMINMAXPARAMETERFVPROC(uint target, uint pname, float *params);
    private delegate void PFNGLGETMINMAXPARAMETERIVPROC(uint target, uint pname, int *params);
    private delegate void PFNGLHISTOGRAMPROC(uint target, uint width, uint internalformat, bool sink);
    private delegate void PFNGLMINMAXPROC(uint target, uint internalformat, bool sink);
    private delegate void PFNGLRESETHISTOGRAMPROC(uint target);
    private delegate void PFNGLRESETMINMAXPROC(uint target);
    #ifdef GL_GLEXT_PROTOTYPES
    public static void glColorTable(uint target, uint internalformat, uint width, uint format, uint type, const void *table);
    public static void glColorTableParameterfv(uint target, uint pname, const float *params);
    public static void glColorTableParameteriv(uint target, uint pname, const int *params);
    public static void glCopyColorTable(uint target, uint internalformat, int x, int y, uint width);
    public static void glGetColorTable(uint target, uint format, uint type, void *table);
    public static void glGetColorTableParameterfv(uint target, uint pname, float *params);
    public static void glGetColorTableParameteriv(uint target, uint pname, int *params);
    public static void glColorSubTable(uint target, uint start, uint count, uint format, uint type, const void *data);
    public static void glCopyColorSubTable(uint target, uint start, int x, int y, uint width);
    public static void glConvolutionFilter1D(uint target, uint internalformat, uint width, uint format, uint type, const void *image);
    public static void glConvolutionFilter2D(uint target, uint internalformat, uint width, uint height, uint format, uint type, const void *image);
    public static void glConvolutionParameterf(uint target, uint pname, float params);
    public static void glConvolutionParameterfv(uint target, uint pname, const float *params);
    public static void glConvolutionParameteri(uint target, uint pname, int params);
    public static void glConvolutionParameteriv(uint target, uint pname, const int *params);
    public static void glCopyConvolutionFilter1D(uint target, uint internalformat, int x, int y, uint width);
    public static void glCopyConvolutionFilter2D(uint target, uint internalformat, int x, int y, uint width, uint height);
    public static void glGetConvolutionFilter(uint target, uint format, uint type, void *image);
    public static void glGetConvolutionParameterfv(uint target, uint pname, float *params);
    public static void glGetConvolutionParameteriv(uint target, uint pname, int *params);
    public static void glGetSeparableFilter(uint target, uint format, uint type, void *row, void *column, void *span);
    public static void glSeparableFilter2D(uint target, uint internalformat, uint width, uint height, uint format, uint type, const void *row, const void *column);
    public static void glGetHistogram(uint target, bool reset, uint format, uint type, void *values);
    public static void glGetHistogramParameterfv(uint target, uint pname, float *params);
    public static void glGetHistogramParameteriv(uint target, uint pname, int *params);
    public static void glGetMinmax(uint target, bool reset, uint format, uint type, void *values);
    public static void glGetMinmaxParameterfv(uint target, uint pname, float *params);
    public static void glGetMinmaxParameteriv(uint target, uint pname, int *params);
    public static void glHistogram(uint target, uint width, uint internalformat, bool sink);
    public static void glMinmax(uint target, uint internalformat, bool sink);
    public static void glResetHistogram(uint target);
    public static void glResetMinmax(uint target);
    #endif
    #endif /* GL_ARB_imaging */

    #ifndef GL_ARB_indirect_parameters
    #define GL_ARB_indirect_parameters 1
    public const uint GL_PARAMETER_BUFFER_ARB = 0x80EE;
    public const uint GL_PARAMETER_BUFFER_BINDING_ARB = 0x80EF;
    private delegate void PFNGLMULTIDRAWARRAYSINDIRECTCOUNTARBPROC(uint mode, intptr indirect, intptr drawcount, uint maxdrawcount, uint stride);
    private delegate void PFNGLMULTIDRAWELEMENTSINDIRECTCOUNTARBPROC(uint mode, uint type, intptr indirect, intptr drawcount, uint maxdrawcount, uint stride);
    #ifdef GL_GLEXT_PROTOTYPES
    public static void glMultiDrawArraysIndirectCountARB(uint mode, intptr indirect, intptr drawcount, uint maxdrawcount, uint stride);
    public static void glMultiDrawElementsIndirectCountARB(uint mode, uint type, intptr indirect, intptr drawcount, uint maxdrawcount, uint stride);
    #endif
    #endif /* GL_ARB_indirect_parameters */

    #ifndef GL_ARB_instanced_arrays
    #define GL_ARB_instanced_arrays 1
    public const uint GL_VERTEX_ATTRIB_ARRAY_DIVISOR_ARB = 0x88FE;
    private delegate void PFNGLVERTEXATTRIBDIVISORARBPROC(uint index, uint divisor);
    #ifdef GL_GLEXT_PROTOTYPES
    public static void glVertexAttribDivisorARB(uint index, uint divisor);
    #endif
    #endif /* GL_ARB_instanced_arrays */

    #ifndef GL_ARB_internalformat_query
    #define GL_ARB_internalformat_query 1
    #endif /* GL_ARB_internalformat_query */

    #ifndef GL_ARB_internalformat_query2
    #define GL_ARB_internalformat_query2 1
    public const uint GL_SRGB_DECODE_ARB = 0x8299;
    #endif /* GL_ARB_internalformat_query2 */

    #ifndef GL_ARB_invalidate_subdata
    #define GL_ARB_invalidate_subdata 1
    #endif /* GL_ARB_invalidate_subdata */

    #ifndef GL_ARB_map_buffer_alignment
    #define GL_ARB_map_buffer_alignment 1
    #endif /* GL_ARB_map_buffer_alignment */

    #ifndef GL_ARB_map_buffer_range
    #define GL_ARB_map_buffer_range 1
    #endif /* GL_ARB_map_buffer_range */

    #ifndef GL_ARB_matrix_palette
    #define GL_ARB_matrix_palette 1
    public const uint GL_MATRIX_PALETTE_ARB = 0x8840;
    public const uint GL_MAX_MATRIX_PALETTE_STACK_DEPTH_ARB = 0x8841;
    public const uint GL_MAX_PALETTE_MATRICES_ARB = 0x8842;
    public const uint GL_CURRENT_PALETTE_MATRIX_ARB = 0x8843;
    public const uint GL_MATRIX_INDEX_ARRAY_ARB = 0x8844;
    public const uint GL_CURRENT_MATRIX_INDEX_ARB = 0x8845;
    public const uint GL_MATRIX_INDEX_ARRAY_SIZE_ARB = 0x8846;
    public const uint GL_MATRIX_INDEX_ARRAY_TYPE_ARB = 0x8847;
    public const uint GL_MATRIX_INDEX_ARRAY_STRIDE_ARB = 0x8848;
    public const uint GL_MATRIX_INDEX_ARRAY_POINTER_ARB = 0x8849;
    private delegate void PFNGLCURRENTPALETTEMATRIXARBPROC(int index);
    private delegate void PFNGLMATRIXINDEXUBVARBPROC(int size, const byte *indices);
    private delegate void PFNGLMATRIXINDEXUSVARBPROC(int size, const ushort *indices);
    private delegate void PFNGLMATRIXINDEXUIVARBPROC(int size, const uint *indices);
    private delegate void PFNGLMATRIXINDEXPOINTERARBPROC(int size, uint type, uint stride, const void *pointer);
    #ifdef GL_GLEXT_PROTOTYPES
    public static void glCurrentPaletteMatrixARB(int index);
    public static void glMatrixIndexubvARB(int size, const byte *indices);
    public static void glMatrixIndexusvARB(int size, const ushort *indices);
    public static void glMatrixIndexuivARB(int size, const uint *indices);
    public static void glMatrixIndexPointerARB(int size, uint type, uint stride, const void *pointer);
    #endif
    #endif /* GL_ARB_matrix_palette */

    #ifndef GL_ARB_multi_bind
    #define GL_ARB_multi_bind 1
    #endif /* GL_ARB_multi_bind */

    #ifndef GL_ARB_multi_draw_indirect
    #define GL_ARB_multi_draw_indirect 1
    #endif /* GL_ARB_multi_draw_indirect */

    #ifndef GL_ARB_multisample
    #define GL_ARB_multisample 1
    public const uint GL_MULTISAMPLE_ARB = 0x809D;
    public const uint GL_SAMPLE_ALPHA_TO_COVERAGE_ARB = 0x809E;
    public const uint GL_SAMPLE_ALPHA_TO_ONE_ARB = 0x809F;
    public const uint GL_SAMPLE_COVERAGE_ARB = 0x80A0;
    public const uint GL_SAMPLE_BUFFERS_ARB = 0x80A8;
    public const uint GL_SAMPLES_ARB = 0x80A9;
    public const uint GL_SAMPLE_COVERAGE_VALUE_ARB = 0x80AA;
    public const uint GL_SAMPLE_COVERAGE_INVERT_ARB = 0x80AB;
    public const uint GL_MULTISAMPLE_BIT_ARB = 0x20000000;
    private delegate void PFNGLSAMPLECOVERAGEARBPROC(float value, bool invert);
    #ifdef GL_GLEXT_PROTOTYPES
    public static void glSampleCoverageARB(float value, bool invert);
    #endif
    #endif /* GL_ARB_multisample */

    #ifndef GL_ARB_multitexture
    #define GL_ARB_multitexture 1
    public const uint GL_TEXTURE0_ARB = 0x84C0;
    public const uint GL_TEXTURE1_ARB = 0x84C1;
    public const uint GL_TEXTURE2_ARB = 0x84C2;
    public const uint GL_TEXTURE3_ARB = 0x84C3;
    public const uint GL_TEXTURE4_ARB = 0x84C4;
    public const uint GL_TEXTURE5_ARB = 0x84C5;
    public const uint GL_TEXTURE6_ARB = 0x84C6;
    public const uint GL_TEXTURE7_ARB = 0x84C7;
    public const uint GL_TEXTURE8_ARB = 0x84C8;
    public const uint GL_TEXTURE9_ARB = 0x84C9;
    public const uint GL_TEXTURE10_ARB = 0x84CA;
    public const uint GL_TEXTURE11_ARB = 0x84CB;
    public const uint GL_TEXTURE12_ARB = 0x84CC;
    public const uint GL_TEXTURE13_ARB = 0x84CD;
    public const uint GL_TEXTURE14_ARB = 0x84CE;
    public const uint GL_TEXTURE15_ARB = 0x84CF;
    public const uint GL_TEXTURE16_ARB = 0x84D0;
    public const uint GL_TEXTURE17_ARB = 0x84D1;
    public const uint GL_TEXTURE18_ARB = 0x84D2;
    public const uint GL_TEXTURE19_ARB = 0x84D3;
    public const uint GL_TEXTURE20_ARB = 0x84D4;
    public const uint GL_TEXTURE21_ARB = 0x84D5;
    public const uint GL_TEXTURE22_ARB = 0x84D6;
    public const uint GL_TEXTURE23_ARB = 0x84D7;
    public const uint GL_TEXTURE24_ARB = 0x84D8;
    public const uint GL_TEXTURE25_ARB = 0x84D9;
    public const uint GL_TEXTURE26_ARB = 0x84DA;
    public const uint GL_TEXTURE27_ARB = 0x84DB;
    public const uint GL_TEXTURE28_ARB = 0x84DC;
    public const uint GL_TEXTURE29_ARB = 0x84DD;
    public const uint GL_TEXTURE30_ARB = 0x84DE;
    public const uint GL_TEXTURE31_ARB = 0x84DF;
    public const uint GL_ACTIVE_TEXTURE_ARB = 0x84E0;
    public const uint GL_CLIENT_ACTIVE_TEXTURE_ARB = 0x84E1;
    public const uint GL_MAX_TEXTURE_UNITS_ARB = 0x84E2;
    private delegate void PFNGLACTIVETEXTUREARBPROC(uint texture);
    private delegate void PFNGLCLIENTACTIVETEXTUREARBPROC(uint texture);
    private delegate void PFNGLMULTITEXCOORD1DARBPROC(uint target, double s);
    private delegate void PFNGLMULTITEXCOORD1DVARBPROC(uint target, const double *v);
    private delegate void PFNGLMULTITEXCOORD1FARBPROC(uint target, float s);
    private delegate void PFNGLMULTITEXCOORD1FVARBPROC(uint target, const float *v);
    private delegate void PFNGLMULTITEXCOORD1IARBPROC(uint target, int s);
    private delegate void PFNGLMULTITEXCOORD1IVARBPROC(uint target, const int *v);
    private delegate void PFNGLMULTITEXCOORD1SARBPROC(uint target, short s);
    private delegate void PFNGLMULTITEXCOORD1SVARBPROC(uint target, const short *v);
    private delegate void PFNGLMULTITEXCOORD2DARBPROC(uint target, double s, double t);
    private delegate void PFNGLMULTITEXCOORD2DVARBPROC(uint target, const double *v);
    private delegate void PFNGLMULTITEXCOORD2FARBPROC(uint target, float s, float t);
    private delegate void PFNGLMULTITEXCOORD2FVARBPROC(uint target, const float *v);
    private delegate void PFNGLMULTITEXCOORD2IARBPROC(uint target, int s, int t);
    private delegate void PFNGLMULTITEXCOORD2IVARBPROC(uint target, const int *v);
    private delegate void PFNGLMULTITEXCOORD2SARBPROC(uint target, short s, short t);
    private delegate void PFNGLMULTITEXCOORD2SVARBPROC(uint target, const short *v);
    private delegate void PFNGLMULTITEXCOORD3DARBPROC(uint target, double s, double t, double r);
    private delegate void PFNGLMULTITEXCOORD3DVARBPROC(uint target, const double *v);
    private delegate void PFNGLMULTITEXCOORD3FARBPROC(uint target, float s, float t, float r);
    private delegate void PFNGLMULTITEXCOORD3FVARBPROC(uint target, const float *v);
    private delegate void PFNGLMULTITEXCOORD3IARBPROC(uint target, int s, int t, int r);
    private delegate void PFNGLMULTITEXCOORD3IVARBPROC(uint target, const int *v);
    private delegate void PFNGLMULTITEXCOORD3SARBPROC(uint target, short s, short t, short r);
    private delegate void PFNGLMULTITEXCOORD3SVARBPROC(uint target, const short *v);
    private delegate void PFNGLMULTITEXCOORD4DARBPROC(uint target, double s, double t, double r, double q);
    private delegate void PFNGLMULTITEXCOORD4DVARBPROC(uint target, const double *v);
    private delegate void PFNGLMULTITEXCOORD4FARBPROC(uint target, float s, float t, float r, float q);
    private delegate void PFNGLMULTITEXCOORD4FVARBPROC(uint target, const float *v);
    private delegate void PFNGLMULTITEXCOORD4IARBPROC(uint target, int s, int t, int r, int q);
    private delegate void PFNGLMULTITEXCOORD4IVARBPROC(uint target, const int *v);
    private delegate void PFNGLMULTITEXCOORD4SARBPROC(uint target, short s, short t, short r, short q);
    private delegate void PFNGLMULTITEXCOORD4SVARBPROC(uint target, const short *v);
    #ifdef GL_GLEXT_PROTOTYPES
    public static void glActiveTextureARB(uint texture);
    public static void glClientActiveTextureARB(uint texture);
    public static void glMultiTexCoord1dARB(uint target, double s);
    public static void glMultiTexCoord1dvARB(uint target, const double *v);
    public static void glMultiTexCoord1fARB(uint target, float s);
    public static void glMultiTexCoord1fvARB(uint target, const float *v);
    public static void glMultiTexCoord1iARB(uint target, int s);
    public static void glMultiTexCoord1ivARB(uint target, const int *v);
    public static void glMultiTexCoord1sARB(uint target, short s);
    public static void glMultiTexCoord1svARB(uint target, const short *v);
    public static void glMultiTexCoord2dARB(uint target, double s, double t);
    public static void glMultiTexCoord2dvARB(uint target, const double *v);
    public static void glMultiTexCoord2fARB(uint target, float s, float t);
    public static void glMultiTexCoord2fvARB(uint target, const float *v);
    public static void glMultiTexCoord2iARB(uint target, int s, int t);
    public static void glMultiTexCoord2ivARB(uint target, const int *v);
    public static void glMultiTexCoord2sARB(uint target, short s, short t);
    public static void glMultiTexCoord2svARB(uint target, const short *v);
    public static void glMultiTexCoord3dARB(uint target, double s, double t, double r);
    public static void glMultiTexCoord3dvARB(uint target, const double *v);
    public static void glMultiTexCoord3fARB(uint target, float s, float t, float r);
    public static void glMultiTexCoord3fvARB(uint target, const float *v);
    public static void glMultiTexCoord3iARB(uint target, int s, int t, int r);
    public static void glMultiTexCoord3ivARB(uint target, const int *v);
    public static void glMultiTexCoord3sARB(uint target, short s, short t, short r);
    public static void glMultiTexCoord3svARB(uint target, const short *v);
    public static void glMultiTexCoord4dARB(uint target, double s, double t, double r, double q);
    public static void glMultiTexCoord4dvARB(uint target, const double *v);
    public static void glMultiTexCoord4fARB(uint target, float s, float t, float r, float q);
    public static void glMultiTexCoord4fvARB(uint target, const float *v);
    public static void glMultiTexCoord4iARB(uint target, int s, int t, int r, int q);
    public static void glMultiTexCoord4ivARB(uint target, const int *v);
    public static void glMultiTexCoord4sARB(uint target, short s, short t, short r, short q);
    public static void glMultiTexCoord4svARB(uint target, const short *v);
    #endif
    #endif /* GL_ARB_multitexture */

    #ifndef GL_ARB_occlusion_query
    #define GL_ARB_occlusion_query 1
    public const uint GL_QUERY_COUNTER_BITS_ARB = 0x8864;
    public const uint GL_CURRENT_QUERY_ARB = 0x8865;
    public const uint GL_QUERY_RESULT_ARB = 0x8866;
    public const uint GL_QUERY_RESULT_AVAILABLE_ARB = 0x8867;
    public const uint GL_SAMPLES_PASSED_ARB = 0x8914;
    private delegate void PFNGLGENQUERIESARBPROC(uint n, uint *ids);
    private delegate void PFNGLDELETEQUERIESARBPROC(uint n, const uint *ids);
    private delegate bool PFNGLISQUERYARBPROC(uint id);
    private delegate void PFNGLBEGINQUERYARBPROC(uint target, uint id);
    private delegate void PFNGLENDQUERYARBPROC(uint target);
    private delegate void PFNGLGETQUERYIVARBPROC(uint target, uint pname, int *params);
    private delegate void PFNGLGETQUERYOBJECTIVARBPROC(uint id, uint pname, int *params);
    private delegate void PFNGLGETQUERYOBJECTUIVARBPROC(uint id, uint pname, uint *params);
    #ifdef GL_GLEXT_PROTOTYPES
    public static void glGenQueriesARB(uint n, uint *ids);
    public static void glDeleteQueriesARB(uint n, const uint *ids);
    public static bool glIsQueryARB(uint id);
    public static void glBeginQueryARB(uint target, uint id);
    public static void glEndQueryARB(uint target);
    public static void glGetQueryivARB(uint target, uint pname, int *params);
    public static void glGetQueryObjectivARB(uint id, uint pname, int *params);
    public static void glGetQueryObjectuivARB(uint id, uint pname, uint *params);
    #endif
    #endif /* GL_ARB_occlusion_query */

    #ifndef GL_ARB_occlusion_query2
    #define GL_ARB_occlusion_query2 1
    #endif /* GL_ARB_occlusion_query2 */

    #ifndef GL_ARB_pixel_buffer_object
    #define GL_ARB_pixel_buffer_object 1
    public const uint GL_PIXEL_PACK_BUFFER_ARB = 0x88EB;
    public const uint GL_PIXEL_UNPACK_BUFFER_ARB = 0x88EC;
    public const uint GL_PIXEL_PACK_BUFFER_BINDING_ARB = 0x88ED;
    public const uint GL_PIXEL_UNPACK_BUFFER_BINDING_ARB = 0x88EF;
    #endif /* GL_ARB_pixel_buffer_object */

    #ifndef GL_ARB_point_parameters
    #define GL_ARB_point_parameters 1
    public const uint GL_POINT_SIZE_MIN_ARB = 0x8126;
    public const uint GL_POINT_SIZE_MAX_ARB = 0x8127;
    public const uint GL_POINT_FADE_THRESHOLD_SIZE_ARB = 0x8128;
    public const uint GL_POINT_DISTANCE_ATTENUATION_ARB = 0x8129;
    private delegate void PFNGLPOINTPARAMETERFARBPROC(uint pname, float param);
    private delegate void PFNGLPOINTPARAMETERFVARBPROC(uint pname, const float *params);
    #ifdef GL_GLEXT_PROTOTYPES
    public static void glPointParameterfARB(uint pname, float param);
    public static void glPointParameterfvARB(uint pname, const float *params);
    #endif
    #endif /* GL_ARB_point_parameters */

    #ifndef GL_ARB_point_sprite
    #define GL_ARB_point_sprite 1
    public const uint GL_POINT_SPRITE_ARB = 0x8861;
    public const uint GL_COORD_REPLACE_ARB = 0x8862;
    #endif /* GL_ARB_point_sprite */

    #ifndef GL_ARB_program_interface_query
    #define GL_ARB_program_interface_query 1
    #endif /* GL_ARB_program_interface_query */

    #ifndef GL_ARB_provoking_vertex
    #define GL_ARB_provoking_vertex 1
    #endif /* GL_ARB_provoking_vertex */

    #ifndef GL_ARB_query_buffer_object
    #define GL_ARB_query_buffer_object 1
    #endif /* GL_ARB_query_buffer_object */

    #ifndef GL_ARB_robust_buffer_access_behavior
    #define GL_ARB_robust_buffer_access_behavior 1
    #endif /* GL_ARB_robust_buffer_access_behavior */

    #ifndef GL_ARB_robustness
    #define GL_ARB_robustness 1
    public const uint GL_CONTEXT_FLAG_ROBUST_ACCESS_BIT_ARB = 0x00000004;
    public const uint GL_LOSE_CONTEXT_ON_RESET_ARB = 0x8252;
    public const uint GL_GUILTY_CONTEXT_RESET_ARB = 0x8253;
    public const uint GL_INNOCENT_CONTEXT_RESET_ARB = 0x8254;
    public const uint GL_UNKNOWN_CONTEXT_RESET_ARB = 0x8255;
    public const uint GL_RESET_NOTIFICATION_STRATEGY_ARB = 0x8256;
    public const uint GL_NO_RESET_NOTIFICATION_ARB = 0x8261;
    private delegate uint PFNGLGETGRAPHICSRESETSTATUSARBPROC(void);
    private delegate void PFNGLGETNTEXIMAGEARBPROC(uint target, int level, uint format, uint type, uint bufSize, void *img);
    private delegate void PFNGLREADNPIXELSARBPROC(int x, int y, uint width, uint height, uint format, uint type, uint bufSize, void *data);
    private delegate void PFNGLGETNCOMPRESSEDTEXIMAGEARBPROC(uint target, int lod, uint bufSize, void *img);
    private delegate void PFNGLGETNUNIFORMFVARBPROC(uint program, int location, uint bufSize, float *params);
    private delegate void PFNGLGETNUNIFORMIVARBPROC(uint program, int location, uint bufSize, int *params);
    private delegate void PFNGLGETNUNIFORMUIVARBPROC(uint program, int location, uint bufSize, uint *params);
    private delegate void PFNGLGETNUNIFORMDVARBPROC(uint program, int location, uint bufSize, double *params);
    private delegate void PFNGLGETNMAPDVARBPROC(uint target, uint query, uint bufSize, double *v);
    private delegate void PFNGLGETNMAPFVARBPROC(uint target, uint query, uint bufSize, float *v);
    private delegate void PFNGLGETNMAPIVARBPROC(uint target, uint query, uint bufSize, int *v);
    private delegate void PFNGLGETNPIXELMAPFVARBPROC(uint map, uint bufSize, float *values);
    private delegate void PFNGLGETNPIXELMAPUIVARBPROC(uint map, uint bufSize, uint *values);
    private delegate void PFNGLGETNPIXELMAPUSVARBPROC(uint map, uint bufSize, ushort *values);
    private delegate void PFNGLGETNPOLYGONSTIPPLEARBPROC(uint bufSize, byte *pattern);
    private delegate void PFNGLGETNCOLORTABLEARBPROC(uint target, uint format, uint type, uint bufSize, void *table);
    private delegate void PFNGLGETNCONVOLUTIONFILTERARBPROC(uint target, uint format, uint type, uint bufSize, void *image);
    private delegate void PFNGLGETNSEPARABLEFILTERARBPROC(uint target, uint format, uint type, uint rowBufSize, void *row, uint columnBufSize, void *column, void *span);
    private delegate void PFNGLGETNHISTOGRAMARBPROC(uint target, bool reset, uint format, uint type, uint bufSize, void *values);
    private delegate void PFNGLGETNMINMAXARBPROC(uint target, bool reset, uint format, uint type, uint bufSize, void *values);
    #ifdef GL_GLEXT_PROTOTYPES
    public static uint glGetGraphicsResetStatusARB(void);
    public static void glGetnTexImageARB(uint target, int level, uint format, uint type, uint bufSize, void *img);
    public static void glReadnPixelsARB(int x, int y, uint width, uint height, uint format, uint type, uint bufSize, void *data);
    public static void glGetnCompressedTexImageARB(uint target, int lod, uint bufSize, void *img);
    public static void glGetnUniformfvARB(uint program, int location, uint bufSize, float *params);
    public static void glGetnUniformivARB(uint program, int location, uint bufSize, int *params);
    public static void glGetnUniformuivARB(uint program, int location, uint bufSize, uint *params);
    public static void glGetnUniformdvARB(uint program, int location, uint bufSize, double *params);
    public static void glGetnMapdvARB(uint target, uint query, uint bufSize, double *v);
    public static void glGetnMapfvARB(uint target, uint query, uint bufSize, float *v);
    public static void glGetnMapivARB(uint target, uint query, uint bufSize, int *v);
    public static void glGetnPixelMapfvARB(uint map, uint bufSize, float *values);
    public static void glGetnPixelMapuivARB(uint map, uint bufSize, uint *values);
    public static void glGetnPixelMapusvARB(uint map, uint bufSize, ushort *values);
    public static void glGetnPolygonStippleARB(uint bufSize, byte *pattern);
    public static void glGetnColorTableARB(uint target, uint format, uint type, uint bufSize, void *table);
    public static void glGetnConvolutionFilterARB(uint target, uint format, uint type, uint bufSize, void *image);
    public static void glGetnSeparableFilterARB(uint target, uint format, uint type, uint rowBufSize, void *row, uint columnBufSize, void *column, void *span);
    public static void glGetnHistogramARB(uint target, bool reset, uint format, uint type, uint bufSize, void *values);
    public static void glGetnMinmaxARB(uint target, bool reset, uint format, uint type, uint bufSize, void *values);
    #endif
    #endif /* GL_ARB_robustness */

    #ifndef GL_ARB_robustness_isolation
    #define GL_ARB_robustness_isolation 1
    #endif /* GL_ARB_robustness_isolation */

    #ifndef GL_ARB_sample_shading
    #define GL_ARB_sample_shading 1
    public const uint GL_SAMPLE_SHADING_ARB = 0x8C36;
    public const uint GL_MIN_SAMPLE_SHADING_VALUE_ARB = 0x8C37;
    private delegate void PFNGLMINSAMPLESHADINGARBPROC(float value);
    #ifdef GL_GLEXT_PROTOTYPES
    public static void glMinSampleShadingARB(float value);
    #endif
    #endif /* GL_ARB_sample_shading */

    #ifndef GL_ARB_sampler_objects
    #define GL_ARB_sampler_objects 1
    #endif /* GL_ARB_sampler_objects */

    #ifndef GL_ARB_seamless_cube_map
    #define GL_ARB_seamless_cube_map 1
    #endif /* GL_ARB_seamless_cube_map */

    #ifndef GL_ARB_seamless_cubemap_per_texture
    #define GL_ARB_seamless_cubemap_per_texture 1
    #endif /* GL_ARB_seamless_cubemap_per_texture */

    #ifndef GL_ARB_separate_shader_objects
    #define GL_ARB_separate_shader_objects 1
    #endif /* GL_ARB_separate_shader_objects */

    #ifndef GL_ARB_shader_atomic_counters
    #define GL_ARB_shader_atomic_counters 1
    #endif /* GL_ARB_shader_atomic_counters */

    #ifndef GL_ARB_shader_bit_encoding
    #define GL_ARB_shader_bit_encoding 1
    #endif /* GL_ARB_shader_bit_encoding */

    #ifndef GL_ARB_shader_draw_parameters
    #define GL_ARB_shader_draw_parameters 1
    #endif /* GL_ARB_shader_draw_parameters */

    #ifndef GL_ARB_shader_group_vote
    #define GL_ARB_shader_group_vote 1
    #endif /* GL_ARB_shader_group_vote */

    #ifndef GL_ARB_shader_image_load_store
    #define GL_ARB_shader_image_load_store 1
    #endif /* GL_ARB_shader_image_load_store */

    #ifndef GL_ARB_shader_image_size
    #define GL_ARB_shader_image_size 1
    #endif /* GL_ARB_shader_image_size */

    #ifndef GL_ARB_shader_objects
    #define GL_ARB_shader_objects 1
    #ifdef __APPLE__
    typedef void *GLhandleARB;
    #else
    typedef unsigned int GLhandleARB;
    #endif
    typedef char byteARB;
    public const uint GL_PROGRAM_OBJECT_ARB = 0x8B40;
    public const uint GL_SHADER_OBJECT_ARB = 0x8B48;
    public const uint GL_OBJECT_TYPE_ARB = 0x8B4E;
    public const uint GL_OBJECT_SUBTYPE_ARB = 0x8B4F;
    public const uint GL_FLOAT_VEC2_ARB = 0x8B50;
    public const uint GL_FLOAT_VEC3_ARB = 0x8B51;
    public const uint GL_FLOAT_VEC4_ARB = 0x8B52;
    public const uint GL_INT_VEC2_ARB = 0x8B53;
    public const uint GL_INT_VEC3_ARB = 0x8B54;
    public const uint GL_INT_VEC4_ARB = 0x8B55;
    public const uint GL_BOOL_ARB = 0x8B56;
    public const uint GL_BOOL_VEC2_ARB = 0x8B57;
    public const uint GL_BOOL_VEC3_ARB = 0x8B58;
    public const uint GL_BOOL_VEC4_ARB = 0x8B59;
    public const uint GL_FLOAT_MAT2_ARB = 0x8B5A;
    public const uint GL_FLOAT_MAT3_ARB = 0x8B5B;
    public const uint GL_FLOAT_MAT4_ARB = 0x8B5C;
    public const uint GL_SAMPLER_1D_ARB = 0x8B5D;
    public const uint GL_SAMPLER_2D_ARB = 0x8B5E;
    public const uint GL_SAMPLER_3D_ARB = 0x8B5F;
    public const uint GL_SAMPLER_CUBE_ARB = 0x8B60;
    public const uint GL_SAMPLER_1D_SHADOW_ARB = 0x8B61;
    public const uint GL_SAMPLER_2D_SHADOW_ARB = 0x8B62;
    public const uint GL_SAMPLER_2D_RECT_ARB = 0x8B63;
    public const uint GL_SAMPLER_2D_RECT_SHADOW_ARB = 0x8B64;
    public const uint GL_OBJECT_DELETE_STATUS_ARB = 0x8B80;
    public const uint GL_OBJECT_COMPILE_STATUS_ARB = 0x8B81;
    public const uint GL_OBJECT_LINK_STATUS_ARB = 0x8B82;
    public const uint GL_OBJECT_VALIDATE_STATUS_ARB = 0x8B83;
    public const uint GL_OBJECT_INFO_LOG_LENGTH_ARB = 0x8B84;
    public const uint GL_OBJECT_ATTACHED_OBJECTS_ARB = 0x8B85;
    public const uint GL_OBJECT_ACTIVE_UNIFORMS_ARB = 0x8B86;
    public const uint GL_OBJECT_ACTIVE_UNIFORM_MAX_LENGTH_ARB = 0x8B87;
    public const uint GL_OBJECT_SHADER_SOURCE_LENGTH_ARB = 0x8B88;
    private delegate void PFNGLDELETEOBJECTARBPROC(GLhandleARB obj);
    private delegate GLhandleARB PFNGLGETHANDLEARBPROC(uint pname);
    private delegate void PFNGLDETACHOBJECTARBPROC(GLhandleARB containerObj, GLhandleARB attachedObj);
    private delegate GLhandleARB PFNGLCREATESHADEROBJECTARBPROC(uint shaderType);
    private delegate void PFNGLSHADERSOURCEARBPROC(GLhandleARB shaderObj, uint count, const byteARB **string, const int *length);
    private delegate void PFNGLCOMPILESHADERARBPROC(GLhandleARB shaderObj);
    private delegate GLhandleARB PFNGLCREATEPROGRAMOBJECTARBPROC(void);
    private delegate void PFNGLATTACHOBJECTARBPROC(GLhandleARB containerObj, GLhandleARB obj);
    private delegate void PFNGLLINKPROGRAMARBPROC(GLhandleARB programObj);
    private delegate void PFNGLUSEPROGRAMOBJECTARBPROC(GLhandleARB programObj);
    private delegate void PFNGLVALIDATEPROGRAMARBPROC(GLhandleARB programObj);
    private delegate void PFNGLUNIFORM1FARBPROC(int location, float v0);
    private delegate void PFNGLUNIFORM2FARBPROC(int location, float v0, float v1);
    private delegate void PFNGLUNIFORM3FARBPROC(int location, float v0, float v1, float v2);
    private delegate void PFNGLUNIFORM4FARBPROC(int location, float v0, float v1, float v2, float v3);
    private delegate void PFNGLUNIFORM1IARBPROC(int location, int v0);
    private delegate void PFNGLUNIFORM2IARBPROC(int location, int v0, int v1);
    private delegate void PFNGLUNIFORM3IARBPROC(int location, int v0, int v1, int v2);
    private delegate void PFNGLUNIFORM4IARBPROC(int location, int v0, int v1, int v2, int v3);
    private delegate void PFNGLUNIFORM1FVARBPROC(int location, uint count, const float *value);
    private delegate void PFNGLUNIFORM2FVARBPROC(int location, uint count, const float *value);
    private delegate void PFNGLUNIFORM3FVARBPROC(int location, uint count, const float *value);
    private delegate void PFNGLUNIFORM4FVARBPROC(int location, uint count, const float *value);
    private delegate void PFNGLUNIFORM1IVARBPROC(int location, uint count, const int *value);
    private delegate void PFNGLUNIFORM2IVARBPROC(int location, uint count, const int *value);
    private delegate void PFNGLUNIFORM3IVARBPROC(int location, uint count, const int *value);
    private delegate void PFNGLUNIFORM4IVARBPROC(int location, uint count, const int *value);
    private delegate void PFNGLUNIFORMMATRIX2FVARBPROC(int location, uint count, bool transpose, const float *value);
    private delegate void PFNGLUNIFORMMATRIX3FVARBPROC(int location, uint count, bool transpose, const float *value);
    private delegate void PFNGLUNIFORMMATRIX4FVARBPROC(int location, uint count, bool transpose, const float *value);
    private delegate void PFNGLGETOBJECTPARAMETERFVARBPROC(GLhandleARB obj, uint pname, float *params);
    private delegate void PFNGLGETOBJECTPARAMETERIVARBPROC(GLhandleARB obj, uint pname, int *params);
    private delegate void PFNGLGETINFOLOGARBPROC(GLhandleARB obj, uint maxLength, uint *length, byteARB *infoLog);
    private delegate void PFNGLGETATTACHEDOBJECTSARBPROC(GLhandleARB containerObj, uint maxCount, uint *count, GLhandleARB *obj);
    private delegate int PFNGLGETUNIFORMLOCATIONARBPROC(GLhandleARB programObj, const byteARB *name);
    private delegate void PFNGLGETACTIVEUNIFORMARBPROC(GLhandleARB programObj, uint index, uint maxLength, uint *length, int *size, uint *type, byteARB *name);
    private delegate void PFNGLGETUNIFORMFVARBPROC(GLhandleARB programObj, int location, float *params);
    private delegate void PFNGLGETUNIFORMIVARBPROC(GLhandleARB programObj, int location, int *params);
    private delegate void PFNGLGETSHADERSOURCEARBPROC(GLhandleARB obj, uint maxLength, uint *length, byteARB *source);
    #ifdef GL_GLEXT_PROTOTYPES
    public static void glDeleteObjectARB(GLhandleARB obj);
    public static GLhandleARB glGetHandleARB(uint pname);
    public static void glDetachObjectARB(GLhandleARB containerObj, GLhandleARB attachedObj);
    public static GLhandleARB glCreateShaderObjectARB(uint shaderType);
    public static void glShaderSourceARB(GLhandleARB shaderObj, uint count, const byteARB **string, const int *length);
    public static void glCompileShaderARB(GLhandleARB shaderObj);
    public static GLhandleARB glCreateProgramObjectARB(void);
    public static void glAttachObjectARB(GLhandleARB containerObj, GLhandleARB obj);
    public static void glLinkProgramARB(GLhandleARB programObj);
    public static void glUseProgramObjectARB(GLhandleARB programObj);
    public static void glValidateProgramARB(GLhandleARB programObj);
    public static void glUniform1fARB(int location, float v0);
    public static void glUniform2fARB(int location, float v0, float v1);
    public static void glUniform3fARB(int location, float v0, float v1, float v2);
    public static void glUniform4fARB(int location, float v0, float v1, float v2, float v3);
    public static void glUniform1iARB(int location, int v0);
    public static void glUniform2iARB(int location, int v0, int v1);
    public static void glUniform3iARB(int location, int v0, int v1, int v2);
    public static void glUniform4iARB(int location, int v0, int v1, int v2, int v3);
    public static void glUniform1fvARB(int location, uint count, const float *value);
    public static void glUniform2fvARB(int location, uint count, const float *value);
    public static void glUniform3fvARB(int location, uint count, const float *value);
    public static void glUniform4fvARB(int location, uint count, const float *value);
    public static void glUniform1ivARB(int location, uint count, const int *value);
    public static void glUniform2ivARB(int location, uint count, const int *value);
    public static void glUniform3ivARB(int location, uint count, const int *value);
    public static void glUniform4ivARB(int location, uint count, const int *value);
    public static void glUniformMatrix2fvARB(int location, uint count, bool transpose, const float *value);
    public static void glUniformMatrix3fvARB(int location, uint count, bool transpose, const float *value);
    public static void glUniformMatrix4fvARB(int location, uint count, bool transpose, const float *value);
    public static void glGetObjectParameterfvARB(GLhandleARB obj, uint pname, float *params);
    public static void glGetObjectParameterivARB(GLhandleARB obj, uint pname, int *params);
    public static void glGetInfoLogARB(GLhandleARB obj, uint maxLength, uint *length, byteARB *infoLog);
    public static void glGetAttachedObjectsARB(GLhandleARB containerObj, uint maxCount, uint *count, GLhandleARB *obj);
    public static int glGetUniformLocationARB(GLhandleARB programObj, const byteARB *name);
    public static void glGetActiveUniformARB(GLhandleARB programObj, uint index, uint maxLength, uint *length, int *size, uint *type, byteARB *name);
    public static void glGetUniformfvARB(GLhandleARB programObj, int location, float *params);
    public static void glGetUniformivARB(GLhandleARB programObj, int location, int *params);
    public static void glGetShaderSourceARB(GLhandleARB obj, uint maxLength, uint *length, byteARB *source);
    #endif
    #endif /* GL_ARB_shader_objects */

    #ifndef GL_ARB_shader_precision
    #define GL_ARB_shader_precision 1
    #endif /* GL_ARB_shader_precision */

    #ifndef GL_ARB_shader_stencil_export
    #define GL_ARB_shader_stencil_export 1
    #endif /* GL_ARB_shader_stencil_export */

    #ifndef GL_ARB_shader_storage_buffer_object
    #define GL_ARB_shader_storage_buffer_object 1
    #endif /* GL_ARB_shader_storage_buffer_object */

    #ifndef GL_ARB_shader_subroutine
    #define GL_ARB_shader_subroutine 1
    #endif /* GL_ARB_shader_subroutine */

    #ifndef GL_ARB_shader_texture_lod
    #define GL_ARB_shader_texture_lod 1
    #endif /* GL_ARB_shader_texture_lod */

    #ifndef GL_ARB_shading_language_100
    #define GL_ARB_shading_language_100 1
    public const uint GL_SHADING_LANGUAGE_VERSION_ARB = 0x8B8C;
    #endif /* GL_ARB_shading_language_100 */

    #ifndef GL_ARB_shading_language_420pack
    #define GL_ARB_shading_language_420pack 1
    #endif /* GL_ARB_shading_language_420pack */

    #ifndef GL_ARB_shading_language_include
    #define GL_ARB_shading_language_include 1
    public const uint GL_SHADER_INCLUDE_ARB = 0x8DAE;
    public const uint GL_NAMED_STRING_LENGTH_ARB = 0x8DE9;
    public const uint GL_NAMED_STRING_TYPE_ARB = 0x8DEA;
    private delegate void PFNGLNAMEDSTRINGARBPROC(uint type, int namelen, const byte *name, int stringlen, const byte *string);
    private delegate void PFNGLDELETENAMEDSTRINGARBPROC(int namelen, const byte *name);
    private delegate void PFNGLCOMPILESHADERINCLUDEARBPROC(uint shader, uint count, const byte *const*path, const int *length);
    private delegate bool PFNGLISNAMEDSTRINGARBPROC(int namelen, const byte *name);
    private delegate void PFNGLGETNAMEDSTRINGARBPROC(int namelen, const byte *name, uint bufSize, int *stringlen, byte *string);
    private delegate void PFNGLGETNAMEDSTRINGIVARBPROC(int namelen, const byte *name, uint pname, int *params);
    #ifdef GL_GLEXT_PROTOTYPES
    public static void glNamedStringARB(uint type, int namelen, const byte *name, int stringlen, const byte *string);
    public static void glDeleteNamedStringARB(int namelen, const byte *name);
    public static void glCompileShaderIncludeARB(uint shader, uint count, const byte *const*path, const int *length);
    public static bool glIsNamedStringARB(int namelen, const byte *name);
    public static void glGetNamedStringARB(int namelen, const byte *name, uint bufSize, int *stringlen, byte *string);
    public static void glGetNamedStringivARB(int namelen, const byte *name, uint pname, int *params);
    #endif
    #endif /* GL_ARB_shading_language_include */

    #ifndef GL_ARB_shading_language_packing
    #define GL_ARB_shading_language_packing 1
    #endif /* GL_ARB_shading_language_packing */

    #ifndef GL_ARB_shadow
    #define GL_ARB_shadow 1
    public const uint GL_TEXTURE_COMPARE_MODE_ARB = 0x884C;
    public const uint GL_TEXTURE_COMPARE_FUNC_ARB = 0x884D;
    public const uint GL_COMPARE_R_TO_TEXTURE_ARB = 0x884E;
    #endif /* GL_ARB_shadow */

    #ifndef GL_ARB_shadow_ambient
    #define GL_ARB_shadow_ambient 1
    public const uint GL_TEXTURE_COMPARE_FAIL_VALUE_ARB = 0x80BF;
    #endif /* GL_ARB_shadow_ambient */

    #ifndef GL_ARB_sparse_texture
    #define GL_ARB_sparse_texture 1
    public const uint GL_TEXTURE_SPARSE_ARB = 0x91A6;
    public const uint GL_VIRTUAL_PAGE_SIZE_INDEX_ARB = 0x91A7;
    public const uint GL_MIN_SPARSE_LEVEL_ARB = 0x919B;
    public const uint GL_NUM_VIRTUAL_PAGE_SIZES_ARB = 0x91A8;
    public const uint GL_VIRTUAL_PAGE_SIZE_X_ARB = 0x9195;
    public const uint GL_VIRTUAL_PAGE_SIZE_Y_ARB = 0x9196;
    public const uint GL_VIRTUAL_PAGE_SIZE_Z_ARB = 0x9197;
    public const uint GL_MAX_SPARSE_TEXTURE_SIZE_ARB = 0x9198;
    public const uint GL_MAX_SPARSE_3D_TEXTURE_SIZE_ARB = 0x9199;
    public const uint GL_MAX_SPARSE_ARRAY_TEXTURE_LAYERS_ARB = 0x919A;
    public const uint GL_SPARSE_TEXTURE_FULL_ARRAY_CUBE_MIPMAPS_ARB = 0x91A9;
    private delegate void PFNGLTEXPAGECOMMITMENTARBPROC(uint target, int level, int xoffset, int yoffset, int zoffset, uint width, uint height, uint depth, bool resident);
    #ifdef GL_GLEXT_PROTOTYPES
    public static void glTexPageCommitmentARB(uint target, int level, int xoffset, int yoffset, int zoffset, uint width, uint height, uint depth, bool resident);
    #endif
    #endif /* GL_ARB_sparse_texture */

    #ifndef GL_ARB_stencil_texturing
    #define GL_ARB_stencil_texturing 1
    #endif /* GL_ARB_stencil_texturing */

    #ifndef GL_ARB_sync
    #define GL_ARB_sync 1
    #endif /* GL_ARB_sync */

    #ifndef GL_ARB_tessellation_shader
    #define GL_ARB_tessellation_shader 1
    #endif /* GL_ARB_tessellation_shader */

    #ifndef GL_ARB_texture_border_clamp
    #define GL_ARB_texture_border_clamp 1
    public const uint GL_CLAMP_TO_BORDER_ARB = 0x812D;
    #endif /* GL_ARB_texture_border_clamp */

    #ifndef GL_ARB_texture_buffer_object
    #define GL_ARB_texture_buffer_object 1
    public const uint GL_TEXTURE_BUFFER_ARB = 0x8C2A;
    public const uint GL_MAX_TEXTURE_BUFFER_SIZE_ARB = 0x8C2B;
    public const uint GL_TEXTURE_BINDING_BUFFER_ARB = 0x8C2C;
    public const uint GL_TEXTURE_BUFFER_DATA_STORE_BINDING_ARB = 0x8C2D;
    public const uint GL_TEXTURE_BUFFER_FORMAT_ARB = 0x8C2E;
    private delegate void PFNGLTEXBUFFERARBPROC(uint target, uint internalformat, uint buffer);
    #ifdef GL_GLEXT_PROTOTYPES
    public static void glTexBufferARB(uint target, uint internalformat, uint buffer);
    #endif
    #endif /* GL_ARB_texture_buffer_object */

    #ifndef GL_ARB_texture_buffer_object_rgb32
    #define GL_ARB_texture_buffer_object_rgb32 1
    #endif /* GL_ARB_texture_buffer_object_rgb32 */

    #ifndef GL_ARB_texture_buffer_range
    #define GL_ARB_texture_buffer_range 1
    #endif /* GL_ARB_texture_buffer_range */

    #ifndef GL_ARB_texture_compression
    #define GL_ARB_texture_compression 1
    public const uint GL_COMPRESSED_ALPHA_ARB = 0x84E9;
    public const uint GL_COMPRESSED_LUMINANCE_ARB = 0x84EA;
    public const uint GL_COMPRESSED_LUMINANCE_ALPHA_ARB = 0x84EB;
    public const uint GL_COMPRESSED_INTENSITY_ARB = 0x84EC;
    public const uint GL_COMPRESSED_RGB_ARB = 0x84ED;
    public const uint GL_COMPRESSED_RGBA_ARB = 0x84EE;
    public const uint GL_TEXTURE_COMPRESSION_HINT_ARB = 0x84EF;
    public const uint GL_TEXTURE_COMPRESSED_IMAGE_SIZE_ARB = 0x86A0;
    public const uint GL_TEXTURE_COMPRESSED_ARB = 0x86A1;
    public const uint GL_NUM_COMPRESSED_TEXTURE_FORMATS_ARB = 0x86A2;
    public const uint GL_COMPRESSED_TEXTURE_FORMATS_ARB = 0x86A3;
    private delegate void PFNGLCOMPRESSEDTEXIMAGE3DARBPROC(uint target, int level, uint internalformat, uint width, uint height, uint depth, int border, uint imageSize, const void *data);
    private delegate void PFNGLCOMPRESSEDTEXIMAGE2DARBPROC(uint target, int level, uint internalformat, uint width, uint height, int border, uint imageSize, const void *data);
    private delegate void PFNGLCOMPRESSEDTEXIMAGE1DARBPROC(uint target, int level, uint internalformat, uint width, int border, uint imageSize, const void *data);
    private delegate void PFNGLCOMPRESSEDTEXSUBIMAGE3DARBPROC(uint target, int level, int xoffset, int yoffset, int zoffset, uint width, uint height, uint depth, uint format, uint imageSize, const void *data);
    private delegate void PFNGLCOMPRESSEDTEXSUBIMAGE2DARBPROC(uint target, int level, int xoffset, int yoffset, uint width, uint height, uint format, uint imageSize, const void *data);
    private delegate void PFNGLCOMPRESSEDTEXSUBIMAGE1DARBPROC(uint target, int level, int xoffset, uint width, uint format, uint imageSize, const void *data);
    private delegate void PFNGLGETCOMPRESSEDTEXIMAGEARBPROC(uint target, int level, void *img);
    #ifdef GL_GLEXT_PROTOTYPES
    public static void glCompressedTexImage3DARB(uint target, int level, uint internalformat, uint width, uint height, uint depth, int border, uint imageSize, const void *data);
    public static void glCompressedTexImage2DARB(uint target, int level, uint internalformat, uint width, uint height, int border, uint imageSize, const void *data);
    public static void glCompressedTexImage1DARB(uint target, int level, uint internalformat, uint width, int border, uint imageSize, const void *data);
    public static void glCompressedTexSubImage3DARB(uint target, int level, int xoffset, int yoffset, int zoffset, uint width, uint height, uint depth, uint format, uint imageSize, const void *data);
    public static void glCompressedTexSubImage2DARB(uint target, int level, int xoffset, int yoffset, uint width, uint height, uint format, uint imageSize, const void *data);
    public static void glCompressedTexSubImage1DARB(uint target, int level, int xoffset, uint width, uint format, uint imageSize, const void *data);
    public static void glGetCompressedTexImageARB(uint target, int level, void *img);
    #endif
    #endif /* GL_ARB_texture_compression */

    #ifndef GL_ARB_texture_compression_bptc
    #define GL_ARB_texture_compression_bptc 1
    public const uint GL_COMPRESSED_RGBA_BPTC_UNORM_ARB = 0x8E8C;
    public const uint GL_COMPRESSED_SRGB_ALPHA_BPTC_UNORM_ARB = 0x8E8D;
    public const uint GL_COMPRESSED_RGB_BPTC_SIGNED_FLOAT_ARB = 0x8E8E;
    public const uint GL_COMPRESSED_RGB_BPTC_UNSIGNED_FLOAT_ARB = 0x8E8F;
    #endif /* GL_ARB_texture_compression_bptc */

    #ifndef GL_ARB_texture_compression_rgtc
    #define GL_ARB_texture_compression_rgtc 1
    #endif /* GL_ARB_texture_compression_rgtc */

    #ifndef GL_ARB_texture_cube_map
    #define GL_ARB_texture_cube_map 1
    public const uint GL_NORMAL_MAP_ARB = 0x8511;
    public const uint GL_REFLECTION_MAP_ARB = 0x8512;
    public const uint GL_TEXTURE_CUBE_MAP_ARB = 0x8513;
    public const uint GL_TEXTURE_BINDING_CUBE_MAP_ARB = 0x8514;
    public const uint GL_TEXTURE_CUBE_MAP_POSITIVE_X_ARB = 0x8515;
    public const uint GL_TEXTURE_CUBE_MAP_NEGATIVE_X_ARB = 0x8516;
    public const uint GL_TEXTURE_CUBE_MAP_POSITIVE_Y_ARB = 0x8517;
    public const uint GL_TEXTURE_CUBE_MAP_NEGATIVE_Y_ARB = 0x8518;
    public const uint GL_TEXTURE_CUBE_MAP_POSITIVE_Z_ARB = 0x8519;
    public const uint GL_TEXTURE_CUBE_MAP_NEGATIVE_Z_ARB = 0x851A;
    public const uint GL_PROXY_TEXTURE_CUBE_MAP_ARB = 0x851B;
    public const uint GL_MAX_CUBE_MAP_TEXTURE_SIZE_ARB = 0x851C;
    #endif /* GL_ARB_texture_cube_map */

    #ifndef GL_ARB_texture_cube_map_array
    #define GL_ARB_texture_cube_map_array 1
    public const uint GL_TEXTURE_CUBE_MAP_ARRAY_ARB = 0x9009;
    public const uint GL_TEXTURE_BINDING_CUBE_MAP_ARRAY_ARB = 0x900A;
    public const uint GL_PROXY_TEXTURE_CUBE_MAP_ARRAY_ARB = 0x900B;
    public const uint GL_SAMPLER_CUBE_MAP_ARRAY_ARB = 0x900C;
    public const uint GL_SAMPLER_CUBE_MAP_ARRAY_SHADOW_ARB = 0x900D;
    public const uint GL_INT_SAMPLER_CUBE_MAP_ARRAY_ARB = 0x900E;
    public const uint GL_UNSIGNED_INT_SAMPLER_CUBE_MAP_ARRAY_ARB = 0x900F;
    #endif /* GL_ARB_texture_cube_map_array */

    #ifndef GL_ARB_texture_env_add
    #define GL_ARB_texture_env_add 1
    #endif /* GL_ARB_texture_env_add */

    #ifndef GL_ARB_texture_env_combine
    #define GL_ARB_texture_env_combine 1
    public const uint GL_COMBINE_ARB = 0x8570;
    public const uint GL_COMBINE_RGB_ARB = 0x8571;
    public const uint GL_COMBINE_ALPHA_ARB = 0x8572;
    public const uint GL_SOURCE0_RGB_ARB = 0x8580;
    public const uint GL_SOURCE1_RGB_ARB = 0x8581;
    public const uint GL_SOURCE2_RGB_ARB = 0x8582;
    public const uint GL_SOURCE0_ALPHA_ARB = 0x8588;
    public const uint GL_SOURCE1_ALPHA_ARB = 0x8589;
    public const uint GL_SOURCE2_ALPHA_ARB = 0x858A;
    public const uint GL_OPERAND0_RGB_ARB = 0x8590;
    public const uint GL_OPERAND1_RGB_ARB = 0x8591;
    public const uint GL_OPERAND2_RGB_ARB = 0x8592;
    public const uint GL_OPERAND0_ALPHA_ARB = 0x8598;
    public const uint GL_OPERAND1_ALPHA_ARB = 0x8599;
    public const uint GL_OPERAND2_ALPHA_ARB = 0x859A;
    public const uint GL_RGB_SCALE_ARB = 0x8573;
    public const uint GL_ADD_SIGNED_ARB = 0x8574;
    public const uint GL_INTERPOLATE_ARB = 0x8575;
    public const uint GL_SUBTRACT_ARB = 0x84E7;
    public const uint GL_CONSTANT_ARB = 0x8576;
    public const uint GL_PRIMARY_COLOR_ARB = 0x8577;
    public const uint GL_PREVIOUS_ARB = 0x8578;
    #endif /* GL_ARB_texture_env_combine */

    #ifndef GL_ARB_texture_env_crossbar
    #define GL_ARB_texture_env_crossbar 1
    #endif /* GL_ARB_texture_env_crossbar */

    #ifndef GL_ARB_texture_env_dot3
    #define GL_ARB_texture_env_dot3 1
    public const uint GL_DOT3_RGB_ARB = 0x86AE;
    public const uint GL_DOT3_RGBA_ARB = 0x86AF;
    #endif /* GL_ARB_texture_env_dot3 */

    #ifndef GL_ARB_texture_float
    #define GL_ARB_texture_float 1
    public const uint GL_TEXTURE_RED_TYPE_ARB = 0x8C10;
    public const uint GL_TEXTURE_GREEN_TYPE_ARB = 0x8C11;
    public const uint GL_TEXTURE_BLUE_TYPE_ARB = 0x8C12;
    public const uint GL_TEXTURE_ALPHA_TYPE_ARB = 0x8C13;
    public const uint GL_TEXTURE_LUMINANCE_TYPE_ARB = 0x8C14;
    public const uint GL_TEXTURE_INTENSITY_TYPE_ARB = 0x8C15;
    public const uint GL_TEXTURE_DEPTH_TYPE_ARB = 0x8C16;
    public const uint GL_UNSIGNED_NORMALIZED_ARB = 0x8C17;
    public const uint GL_RGBA32F_ARB = 0x8814;
    public const uint GL_RGB32F_ARB = 0x8815;
    public const uint GL_ALPHA32F_ARB = 0x8816;
    public const uint GL_INTENSITY32F_ARB = 0x8817;
    public const uint GL_LUMINANCE32F_ARB = 0x8818;
    public const uint GL_LUMINANCE_ALPHA32F_ARB = 0x8819;
    public const uint GL_RGBA16F_ARB = 0x881A;
    public const uint GL_RGB16F_ARB = 0x881B;
    public const uint GL_ALPHA16F_ARB = 0x881C;
    public const uint GL_INTENSITY16F_ARB = 0x881D;
    public const uint GL_LUMINANCE16F_ARB = 0x881E;
    public const uint GL_LUMINANCE_ALPHA16F_ARB = 0x881F;
    #endif /* GL_ARB_texture_float */

    #ifndef GL_ARB_texture_gather
    #define GL_ARB_texture_gather 1
    public const uint GL_MIN_PROGRAM_TEXTURE_GATHER_OFFSET_ARB = 0x8E5E;
    public const uint GL_MAX_PROGRAM_TEXTURE_GATHER_OFFSET_ARB = 0x8E5F;
    public const uint GL_MAX_PROGRAM_TEXTURE_GATHER_COMPONENTS_ARB = 0x8F9F;
    #endif /* GL_ARB_texture_gather */

    #ifndef GL_ARB_texture_mirror_clamp_to_edge
    #define GL_ARB_texture_mirror_clamp_to_edge 1
    #endif /* GL_ARB_texture_mirror_clamp_to_edge */

    #ifndef GL_ARB_texture_mirrored_repeat
    #define GL_ARB_texture_mirrored_repeat 1
    public const uint GL_MIRRORED_REPEAT_ARB = 0x8370;
    #endif /* GL_ARB_texture_mirrored_repeat */

    #ifndef GL_ARB_texture_multisample
    #define GL_ARB_texture_multisample 1
    #endif /* GL_ARB_texture_multisample */

    #ifndef GL_ARB_texture_non_power_of_two
    #define GL_ARB_texture_non_power_of_two 1
    #endif /* GL_ARB_texture_non_power_of_two */

    #ifndef GL_ARB_texture_query_levels
    #define GL_ARB_texture_query_levels 1
    #endif /* GL_ARB_texture_query_levels */

    #ifndef GL_ARB_texture_query_lod
    #define GL_ARB_texture_query_lod 1
    #endif /* GL_ARB_texture_query_lod */

    #ifndef GL_ARB_texture_rectangle
    #define GL_ARB_texture_rectangle 1
    public const uint GL_TEXTURE_RECTANGLE_ARB = 0x84F5;
    public const uint GL_TEXTURE_BINDING_RECTANGLE_ARB = 0x84F6;
    public const uint GL_PROXY_TEXTURE_RECTANGLE_ARB = 0x84F7;
    public const uint GL_MAX_RECTANGLE_TEXTURE_SIZE_ARB = 0x84F8;
    #endif /* GL_ARB_texture_rectangle */

    #ifndef GL_ARB_texture_rg
    #define GL_ARB_texture_rg 1
    #endif /* GL_ARB_texture_rg */

    #ifndef GL_ARB_texture_rgb10_a2ui
    #define GL_ARB_texture_rgb10_a2ui 1
    #endif /* GL_ARB_texture_rgb10_a2ui */

    #ifndef GL_ARB_texture_stencil8
    #define GL_ARB_texture_stencil8 1
    #endif /* GL_ARB_texture_stencil8 */

    #ifndef GL_ARB_texture_storage
    #define GL_ARB_texture_storage 1
    #endif /* GL_ARB_texture_storage */

    #ifndef GL_ARB_texture_storage_multisample
    #define GL_ARB_texture_storage_multisample 1
    #endif /* GL_ARB_texture_storage_multisample */

    #ifndef GL_ARB_texture_swizzle
    #define GL_ARB_texture_swizzle 1
    #endif /* GL_ARB_texture_swizzle */

    #ifndef GL_ARB_texture_view
    #define GL_ARB_texture_view 1
    #endif /* GL_ARB_texture_view */

    #ifndef GL_ARB_timer_query
    #define GL_ARB_timer_query 1
    #endif /* GL_ARB_timer_query */

    #ifndef GL_ARB_transform_feedback2
    #define GL_ARB_transform_feedback2 1
    public const uint GL_TRANSFORM_FEEDBACK_PAUSED = 0x8E23;
    public const uint GL_TRANSFORM_FEEDBACK_ACTIVE = 0x8E24;
    #endif /* GL_ARB_transform_feedback2 */

    #ifndef GL_ARB_transform_feedback3
    #define GL_ARB_transform_feedback3 1
    #endif /* GL_ARB_transform_feedback3 */

    #ifndef GL_ARB_transform_feedback_instanced
    #define GL_ARB_transform_feedback_instanced 1
    #endif /* GL_ARB_transform_feedback_instanced */

    #ifndef GL_ARB_transpose_matrix
    #define GL_ARB_transpose_matrix 1
    public const uint GL_TRANSPOSE_MODELVIEW_MATRIX_ARB = 0x84E3;
    public const uint GL_TRANSPOSE_PROJECTION_MATRIX_ARB = 0x84E4;
    public const uint GL_TRANSPOSE_TEXTURE_MATRIX_ARB = 0x84E5;
    public const uint GL_TRANSPOSE_COLOR_MATRIX_ARB = 0x84E6;
    private delegate void PFNGLLOADTRANSPOSEMATRIXFARBPROC(const float *m);
    private delegate void PFNGLLOADTRANSPOSEMATRIXDARBPROC(const double *m);
    private delegate void PFNGLMULTTRANSPOSEMATRIXFARBPROC(const float *m);
    private delegate void PFNGLMULTTRANSPOSEMATRIXDARBPROC(const double *m);
    #ifdef GL_GLEXT_PROTOTYPES
    public static void glLoadTransposeMatrixfARB(const float *m);
    public static void glLoadTransposeMatrixdARB(const double *m);
    public static void glMultTransposeMatrixfARB(const float *m);
    public static void glMultTransposeMatrixdARB(const double *m);
    #endif
    #endif /* GL_ARB_transpose_matrix */

    #ifndef GL_ARB_uniform_buffer_object
    #define GL_ARB_uniform_buffer_object 1
    public const uint GL_MAX_GEOMETRY_UNIFORM_BLOCKS = 0x8A2C;
    public const uint GL_MAX_COMBINED_GEOMETRY_UNIFORM_COMPONENTS = 0x8A32;
    public const uint GL_UNIFORM_BLOCK_REFERENCED_BY_GEOMETRY_SHADER = 0x8A45;
    #endif /* GL_ARB_uniform_buffer_object */

    #ifndef GL_ARB_vertex_array_bgra
    #define GL_ARB_vertex_array_bgra 1
    #endif /* GL_ARB_vertex_array_bgra */

    #ifndef GL_ARB_vertex_array_object
    #define GL_ARB_vertex_array_object 1
    #endif /* GL_ARB_vertex_array_object */

    #ifndef GL_ARB_vertex_attrib_64bit
    #define GL_ARB_vertex_attrib_64bit 1
    #endif /* GL_ARB_vertex_attrib_64bit */

    #ifndef GL_ARB_vertex_attrib_binding
    #define GL_ARB_vertex_attrib_binding 1
    #endif /* GL_ARB_vertex_attrib_binding */

    #ifndef GL_ARB_vertex_blend
    #define GL_ARB_vertex_blend 1
    public const uint GL_MAX_VERTEX_UNITS_ARB = 0x86A4;
    public const uint GL_ACTIVE_VERTEX_UNITS_ARB = 0x86A5;
    public const uint GL_WEIGHT_SUM_UNITY_ARB = 0x86A6;
    public const uint GL_VERTEX_BLEND_ARB = 0x86A7;
    public const uint GL_CURRENT_WEIGHT_ARB = 0x86A8;
    public const uint GL_WEIGHT_ARRAY_TYPE_ARB = 0x86A9;
    public const uint GL_WEIGHT_ARRAY_STRIDE_ARB = 0x86AA;
    public const uint GL_WEIGHT_ARRAY_SIZE_ARB = 0x86AB;
    public const uint GL_WEIGHT_ARRAY_POINTER_ARB = 0x86AC;
    public const uint GL_WEIGHT_ARRAY_ARB = 0x86AD;
    public const uint GL_MODELVIEW0_ARB = 0x1700;
    public const uint GL_MODELVIEW1_ARB = 0x850A;
    public const uint GL_MODELVIEW2_ARB = 0x8722;
    public const uint GL_MODELVIEW3_ARB = 0x8723;
    public const uint GL_MODELVIEW4_ARB = 0x8724;
    public const uint GL_MODELVIEW5_ARB = 0x8725;
    public const uint GL_MODELVIEW6_ARB = 0x8726;
    public const uint GL_MODELVIEW7_ARB = 0x8727;
    public const uint GL_MODELVIEW8_ARB = 0x8728;
    public const uint GL_MODELVIEW9_ARB = 0x8729;
    public const uint GL_MODELVIEW10_ARB = 0x872A;
    public const uint GL_MODELVIEW11_ARB = 0x872B;
    public const uint GL_MODELVIEW12_ARB = 0x872C;
    public const uint GL_MODELVIEW13_ARB = 0x872D;
    public const uint GL_MODELVIEW14_ARB = 0x872E;
    public const uint GL_MODELVIEW15_ARB = 0x872F;
    public const uint GL_MODELVIEW16_ARB = 0x8730;
    public const uint GL_MODELVIEW17_ARB = 0x8731;
    public const uint GL_MODELVIEW18_ARB = 0x8732;
    public const uint GL_MODELVIEW19_ARB = 0x8733;
    public const uint GL_MODELVIEW20_ARB = 0x8734;
    public const uint GL_MODELVIEW21_ARB = 0x8735;
    public const uint GL_MODELVIEW22_ARB = 0x8736;
    public const uint GL_MODELVIEW23_ARB = 0x8737;
    public const uint GL_MODELVIEW24_ARB = 0x8738;
    public const uint GL_MODELVIEW25_ARB = 0x8739;
    public const uint GL_MODELVIEW26_ARB = 0x873A;
    public const uint GL_MODELVIEW27_ARB = 0x873B;
    public const uint GL_MODELVIEW28_ARB = 0x873C;
    public const uint GL_MODELVIEW29_ARB = 0x873D;
    public const uint GL_MODELVIEW30_ARB = 0x873E;
    public const uint GL_MODELVIEW31_ARB = 0x873F;
    private delegate void PFNGLWEIGHTBVARBPROC(int size, const sbyte *weights);
    private delegate void PFNGLWEIGHTSVARBPROC(int size, const short *weights);
    private delegate void PFNGLWEIGHTIVARBPROC(int size, const int *weights);
    private delegate void PFNGLWEIGHTFVARBPROC(int size, const float *weights);
    private delegate void PFNGLWEIGHTDVARBPROC(int size, const double *weights);
    private delegate void PFNGLWEIGHTUBVARBPROC(int size, const byte *weights);
    private delegate void PFNGLWEIGHTUSVARBPROC(int size, const ushort *weights);
    private delegate void PFNGLWEIGHTUIVARBPROC(int size, const uint *weights);
    private delegate void PFNGLWEIGHTPOINTERARBPROC(int size, uint type, uint stride, const void *pointer);
    private delegate void PFNGLVERTEXBLENDARBPROC(int count);
    #ifdef GL_GLEXT_PROTOTYPES
    public static void glWeightbvARB(int size, const sbyte *weights);
    public static void glWeightsvARB(int size, const short *weights);
    public static void glWeightivARB(int size, const int *weights);
    public static void glWeightfvARB(int size, const float *weights);
    public static void glWeightdvARB(int size, const double *weights);
    public static void glWeightubvARB(int size, const byte *weights);
    public static void glWeightusvARB(int size, const ushort *weights);
    public static void glWeightuivARB(int size, const uint *weights);
    public static void glWeightPointerARB(int size, uint type, uint stride, const void *pointer);
    public static void glVertexBlendARB(int count);
    #endif
    #endif /* GL_ARB_vertex_blend */

    #ifndef GL_ARB_vertex_buffer_object
    #define GL_ARB_vertex_buffer_object 1
    typedef ptrdiff_t uintptrARB;
    typedef ptrdiff_t intptrARB;
    public const uint GL_BUFFER_SIZE_ARB = 0x8764;
    public const uint GL_BUFFER_USAGE_ARB = 0x8765;
    public const uint GL_ARRAY_BUFFER_ARB = 0x8892;
    public const uint GL_ELEMENT_ARRAY_BUFFER_ARB = 0x8893;
    public const uint GL_ARRAY_BUFFER_BINDING_ARB = 0x8894;
    public const uint GL_ELEMENT_ARRAY_BUFFER_BINDING_ARB = 0x8895;
    public const uint GL_VERTEX_ARRAY_BUFFER_BINDING_ARB = 0x8896;
    public const uint GL_NORMAL_ARRAY_BUFFER_BINDING_ARB = 0x8897;
    public const uint GL_COLOR_ARRAY_BUFFER_BINDING_ARB = 0x8898;
    public const uint GL_INDEX_ARRAY_BUFFER_BINDING_ARB = 0x8899;
    public const uint GL_TEXTURE_COORD_ARRAY_BUFFER_BINDING_ARB = 0x889A;
    public const uint GL_EDGE_FLAG_ARRAY_BUFFER_BINDING_ARB = 0x889B;
    public const uint GL_SECONDARY_COLOR_ARRAY_BUFFER_BINDING_ARB = 0x889C;
    public const uint GL_FOG_COORDINATE_ARRAY_BUFFER_BINDING_ARB = 0x889D;
    public const uint GL_WEIGHT_ARRAY_BUFFER_BINDING_ARB = 0x889E;
    public const uint GL_VERTEX_ATTRIB_ARRAY_BUFFER_BINDING_ARB = 0x889F;
    public const uint GL_READ_ONLY_ARB = 0x88B8;
    public const uint GL_WRITE_ONLY_ARB = 0x88B9;
    public const uint GL_READ_WRITE_ARB = 0x88BA;
    public const uint GL_BUFFER_ACCESS_ARB = 0x88BB;
    public const uint GL_BUFFER_MAPPED_ARB = 0x88BC;
    public const uint GL_BUFFER_MAP_POINTER_ARB = 0x88BD;
    public const uint GL_STREAM_DRAW_ARB = 0x88E0;
    public const uint GL_STREAM_READ_ARB = 0x88E1;
    public const uint GL_STREAM_COPY_ARB = 0x88E2;
    public const uint GL_STATIC_DRAW_ARB = 0x88E4;
    public const uint GL_STATIC_READ_ARB = 0x88E5;
    public const uint GL_STATIC_COPY_ARB = 0x88E6;
    public const uint GL_DYNAMIC_DRAW_ARB = 0x88E8;
    public const uint GL_DYNAMIC_READ_ARB = 0x88E9;
    public const uint GL_DYNAMIC_COPY_ARB = 0x88EA;
    private delegate void PFNGLBINDBUFFERARBPROC(uint target, uint buffer);
    private delegate void PFNGLDELETEBUFFERSARBPROC(uint n, const uint *buffers);
    private delegate void PFNGLGENBUFFERSARBPROC(uint n, uint *buffers);
    private delegate bool PFNGLISBUFFERARBPROC(uint buffer);
    private delegate void PFNGLBUFFERDATAARBPROC(uint target, uintptrARB size, const void *data, uint usage);
    private delegate void PFNGLBUFFERSUBDATAARBPROC(uint target, intptrARB offset, uintptrARB size, const void *data);
    private delegate void PFNGLGETBUFFERSUBDATAARBPROC(uint target, intptrARB offset, uintptrARB size, void *data);
    private delegate void* PFNGLMAPBUFFERARBPROC(uint target, uint access);
    private delegate bool PFNGLUNMAPBUFFERARBPROC(uint target);
    private delegate void PFNGLGETBUFFERPARAMETERIVARBPROC(uint target, uint pname, int *params);
    private delegate void PFNGLGETBUFFERPOINTERVARBPROC(uint target, uint pname, void **params);
    #ifdef GL_GLEXT_PROTOTYPES
    public static void glBindBufferARB(uint target, uint buffer);
    public static void glDeleteBuffersARB(uint n, const uint *buffers);
    public static void glGenBuffersARB(uint n, uint *buffers);
    public static bool glIsBufferARB(uint buffer);
    public static void glBufferDataARB(uint target, uintptrARB size, const void *data, uint usage);
    public static void glBufferSubDataARB(uint target, intptrARB offset, uintptrARB size, const void *data);
    public static void glGetBufferSubDataARB(uint target, intptrARB offset, uintptrARB size, void *data);
    public static void* glMapBufferARB(uint target, uint access);
    public static bool glUnmapBufferARB(uint target);
    public static void glGetBufferParameterivARB(uint target, uint pname, int *params);
    public static void glGetBufferPointervARB(uint target, uint pname, void **params);
    #endif
    #endif /* GL_ARB_vertex_buffer_object */

    #ifndef GL_ARB_vertex_program
    #define GL_ARB_vertex_program 1
    public const uint GL_COLOR_SUM_ARB = 0x8458;
    public const uint GL_VERTEX_PROGRAM_ARB = 0x8620;
    public const uint GL_VERTEX_ATTRIB_ARRAY_ENABLED_ARB = 0x8622;
    public const uint GL_VERTEX_ATTRIB_ARRAY_SIZE_ARB = 0x8623;
    public const uint GL_VERTEX_ATTRIB_ARRAY_STRIDE_ARB = 0x8624;
    public const uint GL_VERTEX_ATTRIB_ARRAY_TYPE_ARB = 0x8625;
    public const uint GL_CURRENT_VERTEX_ATTRIB_ARB = 0x8626;
    public const uint GL_VERTEX_PROGRAM_POINT_SIZE_ARB = 0x8642;
    public const uint GL_VERTEX_PROGRAM_TWO_SIDE_ARB = 0x8643;
    public const uint GL_VERTEX_ATTRIB_ARRAY_POINTER_ARB = 0x8645;
    public const uint GL_MAX_VERTEX_ATTRIBS_ARB = 0x8869;
    public const uint GL_VERTEX_ATTRIB_ARRAY_NORMALIZED_ARB = 0x886A;
    public const uint GL_PROGRAM_ADDRESS_REGISTERS_ARB = 0x88B0;
    public const uint GL_MAX_PROGRAM_ADDRESS_REGISTERS_ARB = 0x88B1;
    public const uint GL_PROGRAM_NATIVE_ADDRESS_REGISTERS_ARB = 0x88B2;
    public const uint GL_MAX_PROGRAM_NATIVE_ADDRESS_REGISTERS_ARB = 0x88B3;
    private delegate void PFNGLVERTEXATTRIB1DARBPROC(uint index, double x);
    private delegate void PFNGLVERTEXATTRIB1DVARBPROC(uint index, const double *v);
    private delegate void PFNGLVERTEXATTRIB1FARBPROC(uint index, float x);
    private delegate void PFNGLVERTEXATTRIB1FVARBPROC(uint index, const float *v);
    private delegate void PFNGLVERTEXATTRIB1SARBPROC(uint index, short x);
    private delegate void PFNGLVERTEXATTRIB1SVARBPROC(uint index, const short *v);
    private delegate void PFNGLVERTEXATTRIB2DARBPROC(uint index, double x, double y);
    private delegate void PFNGLVERTEXATTRIB2DVARBPROC(uint index, const double *v);
    private delegate void PFNGLVERTEXATTRIB2FARBPROC(uint index, float x, float y);
    private delegate void PFNGLVERTEXATTRIB2FVARBPROC(uint index, const float *v);
    private delegate void PFNGLVERTEXATTRIB2SARBPROC(uint index, short x, short y);
    private delegate void PFNGLVERTEXATTRIB2SVARBPROC(uint index, const short *v);
    private delegate void PFNGLVERTEXATTRIB3DARBPROC(uint index, double x, double y, double z);
    private delegate void PFNGLVERTEXATTRIB3DVARBPROC(uint index, const double *v);
    private delegate void PFNGLVERTEXATTRIB3FARBPROC(uint index, float x, float y, float z);
    private delegate void PFNGLVERTEXATTRIB3FVARBPROC(uint index, const float *v);
    private delegate void PFNGLVERTEXATTRIB3SARBPROC(uint index, short x, short y, short z);
    private delegate void PFNGLVERTEXATTRIB3SVARBPROC(uint index, const short *v);
    private delegate void PFNGLVERTEXATTRIB4NBVARBPROC(uint index, const sbyte *v);
    private delegate void PFNGLVERTEXATTRIB4NIVARBPROC(uint index, const int *v);
    private delegate void PFNGLVERTEXATTRIB4NSVARBPROC(uint index, const short *v);
    private delegate void PFNGLVERTEXATTRIB4NUBARBPROC(uint index, byte x, byte y, byte z, byte w);
    private delegate void PFNGLVERTEXATTRIB4NUBVARBPROC(uint index, const byte *v);
    private delegate void PFNGLVERTEXATTRIB4NUIVARBPROC(uint index, const uint *v);
    private delegate void PFNGLVERTEXATTRIB4NUSVARBPROC(uint index, const ushort *v);
    private delegate void PFNGLVERTEXATTRIB4BVARBPROC(uint index, const sbyte *v);
    private delegate void PFNGLVERTEXATTRIB4DARBPROC(uint index, double x, double y, double z, double w);
    private delegate void PFNGLVERTEXATTRIB4DVARBPROC(uint index, const double *v);
    private delegate void PFNGLVERTEXATTRIB4FARBPROC(uint index, float x, float y, float z, float w);
    private delegate void PFNGLVERTEXATTRIB4FVARBPROC(uint index, const float *v);
    private delegate void PFNGLVERTEXATTRIB4IVARBPROC(uint index, const int *v);
    private delegate void PFNGLVERTEXATTRIB4SARBPROC(uint index, short x, short y, short z, short w);
    private delegate void PFNGLVERTEXATTRIB4SVARBPROC(uint index, const short *v);
    private delegate void PFNGLVERTEXATTRIB4UBVARBPROC(uint index, const byte *v);
    private delegate void PFNGLVERTEXATTRIB4UIVARBPROC(uint index, const uint *v);
    private delegate void PFNGLVERTEXATTRIB4USVARBPROC(uint index, const ushort *v);
    private delegate void PFNGLVERTEXATTRIBPOINTERARBPROC(uint index, int size, uint type, bool normalized, uint stride, const void *pointer);
    private delegate void PFNGLENABLEVERTEXATTRIBARRAYARBPROC(uint index);
    private delegate void PFNGLDISABLEVERTEXATTRIBARRAYARBPROC(uint index);
    private delegate void PFNGLGETVERTEXATTRIBDVARBPROC(uint index, uint pname, double *params);
    private delegate void PFNGLGETVERTEXATTRIBFVARBPROC(uint index, uint pname, float *params);
    private delegate void PFNGLGETVERTEXATTRIBIVARBPROC(uint index, uint pname, int *params);
    private delegate void PFNGLGETVERTEXATTRIBPOINTERVARBPROC(uint index, uint pname, void **pointer);
    #ifdef GL_GLEXT_PROTOTYPES
    public static void glVertexAttrib1dARB(uint index, double x);
    public static void glVertexAttrib1dvARB(uint index, const double *v);
    public static void glVertexAttrib1fARB(uint index, float x);
    public static void glVertexAttrib1fvARB(uint index, const float *v);
    public static void glVertexAttrib1sARB(uint index, short x);
    public static void glVertexAttrib1svARB(uint index, const short *v);
    public static void glVertexAttrib2dARB(uint index, double x, double y);
    public static void glVertexAttrib2dvARB(uint index, const double *v);
    public static void glVertexAttrib2fARB(uint index, float x, float y);
    public static void glVertexAttrib2fvARB(uint index, const float *v);
    public static void glVertexAttrib2sARB(uint index, short x, short y);
    public static void glVertexAttrib2svARB(uint index, const short *v);
    public static void glVertexAttrib3dARB(uint index, double x, double y, double z);
    public static void glVertexAttrib3dvARB(uint index, const double *v);
    public static void glVertexAttrib3fARB(uint index, float x, float y, float z);
    public static void glVertexAttrib3fvARB(uint index, const float *v);
    public static void glVertexAttrib3sARB(uint index, short x, short y, short z);
    public static void glVertexAttrib3svARB(uint index, const short *v);
    public static void glVertexAttrib4NbvARB(uint index, const sbyte *v);
    public static void glVertexAttrib4NivARB(uint index, const int *v);
    public static void glVertexAttrib4NsvARB(uint index, const short *v);
    public static void glVertexAttrib4NubARB(uint index, byte x, byte y, byte z, byte w);
    public static void glVertexAttrib4NubvARB(uint index, const byte *v);
    public static void glVertexAttrib4NuivARB(uint index, const uint *v);
    public static void glVertexAttrib4NusvARB(uint index, const ushort *v);
    public static void glVertexAttrib4bvARB(uint index, const sbyte *v);
    public static void glVertexAttrib4dARB(uint index, double x, double y, double z, double w);
    public static void glVertexAttrib4dvARB(uint index, const double *v);
    public static void glVertexAttrib4fARB(uint index, float x, float y, float z, float w);
    public static void glVertexAttrib4fvARB(uint index, const float *v);
    public static void glVertexAttrib4ivARB(uint index, const int *v);
    public static void glVertexAttrib4sARB(uint index, short x, short y, short z, short w);
    public static void glVertexAttrib4svARB(uint index, const short *v);
    public static void glVertexAttrib4ubvARB(uint index, const byte *v);
    public static void glVertexAttrib4uivARB(uint index, const uint *v);
    public static void glVertexAttrib4usvARB(uint index, const ushort *v);
    public static void glVertexAttribPointerARB(uint index, int size, uint type, bool normalized, uint stride, const void *pointer);
    public static void glEnableVertexAttribArrayARB(uint index);
    public static void glDisableVertexAttribArrayARB(uint index);
    public static void glGetVertexAttribdvARB(uint index, uint pname, double *params);
    public static void glGetVertexAttribfvARB(uint index, uint pname, float *params);
    public static void glGetVertexAttribivARB(uint index, uint pname, int *params);
    public static void glGetVertexAttribPointervARB(uint index, uint pname, void **pointer);
    #endif
    #endif /* GL_ARB_vertex_program */

    #ifndef GL_ARB_vertex_shader
    #define GL_ARB_vertex_shader 1
    public const uint GL_VERTEX_SHADER_ARB = 0x8B31;
    public const uint GL_MAX_VERTEX_UNIFORM_COMPONENTS_ARB = 0x8B4A;
    public const uint GL_MAX_VARYING_FLOATS_ARB = 0x8B4B;
    public const uint GL_MAX_VERTEX_TEXTURE_IMAGE_UNITS_ARB = 0x8B4C;
    public const uint GL_MAX_COMBINED_TEXTURE_IMAGE_UNITS_ARB = 0x8B4D;
    public const uint GL_OBJECT_ACTIVE_ATTRIBUTES_ARB = 0x8B89;
    public const uint GL_OBJECT_ACTIVE_ATTRIBUTE_MAX_LENGTH_ARB = 0x8B8A;
    private delegate void PFNGLBINDATTRIBLOCATIONARBPROC(GLhandleARB programObj, uint index, const byteARB *name);
    private delegate void PFNGLGETACTIVEATTRIBARBPROC(GLhandleARB programObj, uint index, uint maxLength, uint *length, int *size, uint *type, byteARB *name);
    private delegate int PFNGLGETATTRIBLOCATIONARBPROC(GLhandleARB programObj, const byteARB *name);
    #ifdef GL_GLEXT_PROTOTYPES
    public static void glBindAttribLocationARB(GLhandleARB programObj, uint index, const byteARB *name);
    public static void glGetActiveAttribARB(GLhandleARB programObj, uint index, uint maxLength, uint *length, int *size, uint *type, byteARB *name);
    public static int glGetAttribLocationARB(GLhandleARB programObj, const byteARB *name);
    #endif
    #endif /* GL_ARB_vertex_shader */

    #ifndef GL_ARB_vertex_type_10f_11f_11f_rev
    #define GL_ARB_vertex_type_10f_11f_11f_rev 1
    #endif /* GL_ARB_vertex_type_10f_11f_11f_rev */

    #ifndef GL_ARB_vertex_type_2_10_10_10_rev
    #define GL_ARB_vertex_type_2_10_10_10_rev 1
    #endif /* GL_ARB_vertex_type_2_10_10_10_rev */

    #ifndef GL_ARB_viewport_array
    #define GL_ARB_viewport_array 1
    #endif /* GL_ARB_viewport_array */

    #ifndef GL_ARB_window_pos
    #define GL_ARB_window_pos 1
    private delegate void PFNGLWINDOWPOS2DARBPROC(double x, double y);
    private delegate void PFNGLWINDOWPOS2DVARBPROC(const double *v);
    private delegate void PFNGLWINDOWPOS2FARBPROC(float x, float y);
    private delegate void PFNGLWINDOWPOS2FVARBPROC(const float *v);
    private delegate void PFNGLWINDOWPOS2IARBPROC(int x, int y);
    private delegate void PFNGLWINDOWPOS2IVARBPROC(const int *v);
    private delegate void PFNGLWINDOWPOS2SARBPROC(short x, short y);
    private delegate void PFNGLWINDOWPOS2SVARBPROC(const short *v);
    private delegate void PFNGLWINDOWPOS3DARBPROC(double x, double y, double z);
    private delegate void PFNGLWINDOWPOS3DVARBPROC(const double *v);
    private delegate void PFNGLWINDOWPOS3FARBPROC(float x, float y, float z);
    private delegate void PFNGLWINDOWPOS3FVARBPROC(const float *v);
    private delegate void PFNGLWINDOWPOS3IARBPROC(int x, int y, int z);
    private delegate void PFNGLWINDOWPOS3IVARBPROC(const int *v);
    private delegate void PFNGLWINDOWPOS3SARBPROC(short x, short y, short z);
    private delegate void PFNGLWINDOWPOS3SVARBPROC(const short *v);
    #ifdef GL_GLEXT_PROTOTYPES
    public static void glWindowPos2dARB(double x, double y);
    public static void glWindowPos2dvARB(const double *v);
    public static void glWindowPos2fARB(float x, float y);
    public static void glWindowPos2fvARB(const float *v);
    public static void glWindowPos2iARB(int x, int y);
    public static void glWindowPos2ivARB(const int *v);
    public static void glWindowPos2sARB(short x, short y);
    public static void glWindowPos2svARB(const short *v);
    public static void glWindowPos3dARB(double x, double y, double z);
    public static void glWindowPos3dvARB(const double *v);
    public static void glWindowPos3fARB(float x, float y, float z);
    public static void glWindowPos3fvARB(const float *v);
    public static void glWindowPos3iARB(int x, int y, int z);
    public static void glWindowPos3ivARB(const int *v);
    public static void glWindowPos3sARB(short x, short y, short z);
    public static void glWindowPos3svARB(const short *v);
    #endif
    #endif /* GL_ARB_window_pos */

    #ifndef GL_KHR_debug
    #define GL_KHR_debug 1
    #endif /* GL_KHR_debug */

    #ifndef GL_KHR_texture_compression_astc_hdr
    #define GL_KHR_texture_compression_astc_hdr 1
    public const uint GL_COMPRESSED_RGBA_ASTC_4x4_KHR = 0x93B0;
    public const uint GL_COMPRESSED_RGBA_ASTC_5x4_KHR = 0x93B1;
    public const uint GL_COMPRESSED_RGBA_ASTC_5x5_KHR = 0x93B2;
    public const uint GL_COMPRESSED_RGBA_ASTC_6x5_KHR = 0x93B3;
    public const uint GL_COMPRESSED_RGBA_ASTC_6x6_KHR = 0x93B4;
    public const uint GL_COMPRESSED_RGBA_ASTC_8x5_KHR = 0x93B5;
    public const uint GL_COMPRESSED_RGBA_ASTC_8x6_KHR = 0x93B6;
    public const uint GL_COMPRESSED_RGBA_ASTC_8x8_KHR = 0x93B7;
    public const uint GL_COMPRESSED_RGBA_ASTC_10x5_KHR = 0x93B8;
    public const uint GL_COMPRESSED_RGBA_ASTC_10x6_KHR = 0x93B9;
    public const uint GL_COMPRESSED_RGBA_ASTC_10x8_KHR = 0x93BA;
    public const uint GL_COMPRESSED_RGBA_ASTC_10x10_KHR = 0x93BB;
    public const uint GL_COMPRESSED_RGBA_ASTC_12x10_KHR = 0x93BC;
    public const uint GL_COMPRESSED_RGBA_ASTC_12x12_KHR = 0x93BD;
    public const uint GL_COMPRESSED_SRGB8_ALPHA8_ASTC_4x4_KHR = 0x93D0;
    public const uint GL_COMPRESSED_SRGB8_ALPHA8_ASTC_5x4_KHR = 0x93D1;
    public const uint GL_COMPRESSED_SRGB8_ALPHA8_ASTC_5x5_KHR = 0x93D2;
    public const uint GL_COMPRESSED_SRGB8_ALPHA8_ASTC_6x5_KHR = 0x93D3;
    public const uint GL_COMPRESSED_SRGB8_ALPHA8_ASTC_6x6_KHR = 0x93D4;
    public const uint GL_COMPRESSED_SRGB8_ALPHA8_ASTC_8x5_KHR = 0x93D5;
    public const uint GL_COMPRESSED_SRGB8_ALPHA8_ASTC_8x6_KHR = 0x93D6;
    public const uint GL_COMPRESSED_SRGB8_ALPHA8_ASTC_8x8_KHR = 0x93D7;
    public const uint GL_COMPRESSED_SRGB8_ALPHA8_ASTC_10x5_KHR = 0x93D8;
    public const uint GL_COMPRESSED_SRGB8_ALPHA8_ASTC_10x6_KHR = 0x93D9;
    public const uint GL_COMPRESSED_SRGB8_ALPHA8_ASTC_10x8_KHR = 0x93DA;
    public const uint GL_COMPRESSED_SRGB8_ALPHA8_ASTC_10x10_KHR = 0x93DB;
    public const uint GL_COMPRESSED_SRGB8_ALPHA8_ASTC_12x10_KHR = 0x93DC;
    public const uint GL_COMPRESSED_SRGB8_ALPHA8_ASTC_12x12_KHR = 0x93DD;
    #endif /* GL_KHR_texture_compression_astc_hdr */

    #ifndef GL_KHR_texture_compression_astc_ldr
    #define GL_KHR_texture_compression_astc_ldr 1
    #endif /* GL_KHR_texture_compression_astc_ldr */

    #ifndef GL_OES_byte_coordinates
    #define GL_OES_byte_coordinates 1
    private delegate void PFNGLMULTITEXCOORD1BOESPROC(uint texture, sbyte s);
    private delegate void PFNGLMULTITEXCOORD1BVOESPROC(uint texture, const sbyte *coords);
    private delegate void PFNGLMULTITEXCOORD2BOESPROC(uint texture, sbyte s, sbyte t);
    private delegate void PFNGLMULTITEXCOORD2BVOESPROC(uint texture, const sbyte *coords);
    private delegate void PFNGLMULTITEXCOORD3BOESPROC(uint texture, sbyte s, sbyte t, sbyte r);
    private delegate void PFNGLMULTITEXCOORD3BVOESPROC(uint texture, const sbyte *coords);
    private delegate void PFNGLMULTITEXCOORD4BOESPROC(uint texture, sbyte s, sbyte t, sbyte r, sbyte q);
    private delegate void PFNGLMULTITEXCOORD4BVOESPROC(uint texture, const sbyte *coords);
    private delegate void PFNGLTEXCOORD1BOESPROC(sbyte s);
    private delegate void PFNGLTEXCOORD1BVOESPROC(const sbyte *coords);
    private delegate void PFNGLTEXCOORD2BOESPROC(sbyte s, sbyte t);
    private delegate void PFNGLTEXCOORD2BVOESPROC(const sbyte *coords);
    private delegate void PFNGLTEXCOORD3BOESPROC(sbyte s, sbyte t, sbyte r);
    private delegate void PFNGLTEXCOORD3BVOESPROC(const sbyte *coords);
    private delegate void PFNGLTEXCOORD4BOESPROC(sbyte s, sbyte t, sbyte r, sbyte q);
    private delegate void PFNGLTEXCOORD4BVOESPROC(const sbyte *coords);
    private delegate void PFNGLVERTEX2BOESPROC(sbyte x);
    private delegate void PFNGLVERTEX2BVOESPROC(const sbyte *coords);
    private delegate void PFNGLVERTEX3BOESPROC(sbyte x, sbyte y);
    private delegate void PFNGLVERTEX3BVOESPROC(const sbyte *coords);
    private delegate void PFNGLVERTEX4BOESPROC(sbyte x, sbyte y, sbyte z);
    private delegate void PFNGLVERTEX4BVOESPROC(const sbyte *coords);
    #ifdef GL_GLEXT_PROTOTYPES
    public static void glMultiTexCoord1bOES(uint texture, sbyte s);
    public static void glMultiTexCoord1bvOES(uint texture, const sbyte *coords);
    public static void glMultiTexCoord2bOES(uint texture, sbyte s, sbyte t);
    public static void glMultiTexCoord2bvOES(uint texture, const sbyte *coords);
    public static void glMultiTexCoord3bOES(uint texture, sbyte s, sbyte t, sbyte r);
    public static void glMultiTexCoord3bvOES(uint texture, const sbyte *coords);
    public static void glMultiTexCoord4bOES(uint texture, sbyte s, sbyte t, sbyte r, sbyte q);
    public static void glMultiTexCoord4bvOES(uint texture, const sbyte *coords);
    public static void glTexCoord1bOES(sbyte s);
    public static void glTexCoord1bvOES(const sbyte *coords);
    public static void glTexCoord2bOES(sbyte s, sbyte t);
    public static void glTexCoord2bvOES(const sbyte *coords);
    public static void glTexCoord3bOES(sbyte s, sbyte t, sbyte r);
    public static void glTexCoord3bvOES(const sbyte *coords);
    public static void glTexCoord4bOES(sbyte s, sbyte t, sbyte r, sbyte q);
    public static void glTexCoord4bvOES(const sbyte *coords);
    public static void glVertex2bOES(sbyte x);
    public static void glVertex2bvOES(const sbyte *coords);
    public static void glVertex3bOES(sbyte x, sbyte y);
    public static void glVertex3bvOES(const sbyte *coords);
    public static void glVertex4bOES(sbyte x, sbyte y, sbyte z);
    public static void glVertex4bvOES(const sbyte *coords);
    #endif
    #endif /* GL_OES_byte_coordinates */

    #ifndef GL_OES_compressed_paletted_texture
    #define GL_OES_compressed_paletted_texture 1
    public const uint GL_PALETTE4_RGB8_OES = 0x8B90;
    public const uint GL_PALETTE4_RGBA8_OES = 0x8B91;
    public const uint GL_PALETTE4_R5_G6_B5_OES = 0x8B92;
    public const uint GL_PALETTE4_RGBA4_OES = 0x8B93;
    public const uint GL_PALETTE4_RGB5_A1_OES = 0x8B94;
    public const uint GL_PALETTE8_RGB8_OES = 0x8B95;
    public const uint GL_PALETTE8_RGBA8_OES = 0x8B96;
    public const uint GL_PALETTE8_R5_G6_B5_OES = 0x8B97;
    public const uint GL_PALETTE8_RGBA4_OES = 0x8B98;
    public const uint GL_PALETTE8_RGB5_A1_OES = 0x8B99;
    #endif /* GL_OES_compressed_paletted_texture */

    #ifndef GL_OES_fixed_point
    #define GL_OES_fixed_point 1
    typedef int GLfixed;
    public const uint GL_FIXED_OES = 0x140C;
    private delegate void PFNGLALPHAFUNCXOESPROC(uint func, GLfixed ref);
    private delegate void PFNGLCLEARCOLORXOESPROC(GLfixed red, GLfixed green, GLfixed blue, GLfixed alpha);
    private delegate void PFNGLCLEARDEPTHXOESPROC(GLfixed depth);
    private delegate void PFNGLCLIPPLANEXOESPROC(uint plane, const GLfixed *equation);
    private delegate void PFNGLCOLOR4XOESPROC(GLfixed red, GLfixed green, GLfixed blue, GLfixed alpha);
    private delegate void PFNGLDEPTHRANGEXOESPROC(GLfixed n, GLfixed f);
    private delegate void PFNGLFOGXOESPROC(uint pname, GLfixed param);
    private delegate void PFNGLFOGXVOESPROC(uint pname, const GLfixed *param);
    private delegate void PFNGLFRUSTUMXOESPROC(GLfixed l, GLfixed r, GLfixed b, GLfixed t, GLfixed n, GLfixed f);
    private delegate void PFNGLGETCLIPPLANEXOESPROC(uint plane, GLfixed *equation);
    private delegate void PFNGLGETFIXEDVOESPROC(uint pname, GLfixed *params);
    private delegate void PFNGLGETTEXENVXVOESPROC(uint target, uint pname, GLfixed *params);
    private delegate void PFNGLGETTEXPARAMETERXVOESPROC(uint target, uint pname, GLfixed *params);
    private delegate void PFNGLLIGHTMODELXOESPROC(uint pname, GLfixed param);
    private delegate void PFNGLLIGHTMODELXVOESPROC(uint pname, const GLfixed *param);
    private delegate void PFNGLLIGHTXOESPROC(uint light, uint pname, GLfixed param);
    private delegate void PFNGLLIGHTXVOESPROC(uint light, uint pname, const GLfixed *params);
    private delegate void PFNGLLINEWIDTHXOESPROC(GLfixed width);
    private delegate void PFNGLLOADMATRIXXOESPROC(const GLfixed *m);
    private delegate void PFNGLMATERIALXOESPROC(uint face, uint pname, GLfixed param);
    private delegate void PFNGLMATERIALXVOESPROC(uint face, uint pname, const GLfixed *param);
    private delegate void PFNGLMULTMATRIXXOESPROC(const GLfixed *m);
    private delegate void PFNGLMULTITEXCOORD4XOESPROC(uint texture, GLfixed s, GLfixed t, GLfixed r, GLfixed q);
    private delegate void PFNGLNORMAL3XOESPROC(GLfixed nx, GLfixed ny, GLfixed nz);
    private delegate void PFNGLORTHOXOESPROC(GLfixed l, GLfixed r, GLfixed b, GLfixed t, GLfixed n, GLfixed f);
    private delegate void PFNGLPOINTPARAMETERXVOESPROC(uint pname, const GLfixed *params);
    private delegate void PFNGLPOINTSIZEXOESPROC(GLfixed size);
    private delegate void PFNGLPOLYGONOFFSETXOESPROC(GLfixed factor, GLfixed units);
    private delegate void PFNGLROTATEXOESPROC(GLfixed angle, GLfixed x, GLfixed y, GLfixed z);
    private delegate void PFNGLSAMPLECOVERAGEOESPROC(GLfixed value, bool invert);
    private delegate void PFNGLSCALEXOESPROC(GLfixed x, GLfixed y, GLfixed z);
    private delegate void PFNGLTEXENVXOESPROC(uint target, uint pname, GLfixed param);
    private delegate void PFNGLTEXENVXVOESPROC(uint target, uint pname, const GLfixed *params);
    private delegate void PFNGLTEXPARAMETERXOESPROC(uint target, uint pname, GLfixed param);
    private delegate void PFNGLTEXPARAMETERXVOESPROC(uint target, uint pname, const GLfixed *params);
    private delegate void PFNGLTRANSLATEXOESPROC(GLfixed x, GLfixed y, GLfixed z);
    private delegate void PFNGLACCUMXOESPROC(uint op, GLfixed value);
    private delegate void PFNGLBITMAPXOESPROC(uint width, uint height, GLfixed xorig, GLfixed yorig, GLfixed xmove, GLfixed ymove, const byte *bitmap);
    private delegate void PFNGLBLENDCOLORXOESPROC(GLfixed red, GLfixed green, GLfixed blue, GLfixed alpha);
    private delegate void PFNGLCLEARACCUMXOESPROC(GLfixed red, GLfixed green, GLfixed blue, GLfixed alpha);
    private delegate void PFNGLCOLOR3XOESPROC(GLfixed red, GLfixed green, GLfixed blue);
    private delegate void PFNGLCOLOR3XVOESPROC(const GLfixed *components);
    private delegate void PFNGLCOLOR4XVOESPROC(const GLfixed *components);
    private delegate void PFNGLCONVOLUTIONPARAMETERXOESPROC(uint target, uint pname, GLfixed param);
    private delegate void PFNGLCONVOLUTIONPARAMETERXVOESPROC(uint target, uint pname, const GLfixed *params);
    private delegate void PFNGLEVALCOORD1XOESPROC(GLfixed u);
    private delegate void PFNGLEVALCOORD1XVOESPROC(const GLfixed *coords);
    private delegate void PFNGLEVALCOORD2XOESPROC(GLfixed u, GLfixed v);
    private delegate void PFNGLEVALCOORD2XVOESPROC(const GLfixed *coords);
    private delegate void PFNGLFEEDBACKBUFFERXOESPROC(uint n, uint type, const GLfixed *buffer);
    private delegate void PFNGLGETCONVOLUTIONPARAMETERXVOESPROC(uint target, uint pname, GLfixed *params);
    private delegate void PFNGLGETHISTOGRAMPARAMETERXVOESPROC(uint target, uint pname, GLfixed *params);
    private delegate void PFNGLGETLIGHTXOESPROC(uint light, uint pname, GLfixed *params);
    private delegate void PFNGLGETMAPXVOESPROC(uint target, uint query, GLfixed *v);
    private delegate void PFNGLGETMATERIALXOESPROC(uint face, uint pname, GLfixed param);
    private delegate void PFNGLGETPIXELMAPXVPROC(uint map, int size, GLfixed *values);
    private delegate void PFNGLGETTEXGENXVOESPROC(uint coord, uint pname, GLfixed *params);
    private delegate void PFNGLGETTEXLEVELPARAMETERXVOESPROC(uint target, int level, uint pname, GLfixed *params);
    private delegate void PFNGLINDEXXOESPROC(GLfixed component);
    private delegate void PFNGLINDEXXVOESPROC(const GLfixed *component);
    private delegate void PFNGLLOADTRANSPOSEMATRIXXOESPROC(const GLfixed *m);
    private delegate void PFNGLMAP1XOESPROC(uint target, GLfixed u1, GLfixed u2, int stride, int order, GLfixed points);
    private delegate void PFNGLMAP2XOESPROC(uint target, GLfixed u1, GLfixed u2, int ustride, int uorder, GLfixed v1, GLfixed v2, int vstride, int vorder, GLfixed points);
    private delegate void PFNGLMAPGRID1XOESPROC(int n, GLfixed u1, GLfixed u2);
    private delegate void PFNGLMAPGRID2XOESPROC(int n, GLfixed u1, GLfixed u2, GLfixed v1, GLfixed v2);
    private delegate void PFNGLMULTTRANSPOSEMATRIXXOESPROC(const GLfixed *m);
    private delegate void PFNGLMULTITEXCOORD1XOESPROC(uint texture, GLfixed s);
    private delegate void PFNGLMULTITEXCOORD1XVOESPROC(uint texture, const GLfixed *coords);
    private delegate void PFNGLMULTITEXCOORD2XOESPROC(uint texture, GLfixed s, GLfixed t);
    private delegate void PFNGLMULTITEXCOORD2XVOESPROC(uint texture, const GLfixed *coords);
    private delegate void PFNGLMULTITEXCOORD3XOESPROC(uint texture, GLfixed s, GLfixed t, GLfixed r);
    private delegate void PFNGLMULTITEXCOORD3XVOESPROC(uint texture, const GLfixed *coords);
    private delegate void PFNGLMULTITEXCOORD4XVOESPROC(uint texture, const GLfixed *coords);
    private delegate void PFNGLNORMAL3XVOESPROC(const GLfixed *coords);
    private delegate void PFNGLPASSTHROUGHXOESPROC(GLfixed token);
    private delegate void PFNGLPIXELMAPXPROC(uint map, int size, const GLfixed *values);
    private delegate void PFNGLPIXELSTOREXPROC(uint pname, GLfixed param);
    private delegate void PFNGLPIXELTRANSFERXOESPROC(uint pname, GLfixed param);
    private delegate void PFNGLPIXELZOOMXOESPROC(GLfixed xfactor, GLfixed yfactor);
    private delegate void PFNGLPRIORITIZETEXTURESXOESPROC(uint n, const uint *textures, const GLfixed *priorities);
    private delegate void PFNGLRASTERPOS2XOESPROC(GLfixed x, GLfixed y);
    private delegate void PFNGLRASTERPOS2XVOESPROC(const GLfixed *coords);
    private delegate void PFNGLRASTERPOS3XOESPROC(GLfixed x, GLfixed y, GLfixed z);
    private delegate void PFNGLRASTERPOS3XVOESPROC(const GLfixed *coords);
    private delegate void PFNGLRASTERPOS4XOESPROC(GLfixed x, GLfixed y, GLfixed z, GLfixed w);
    private delegate void PFNGLRASTERPOS4XVOESPROC(const GLfixed *coords);
    private delegate void PFNGLRECTXOESPROC(GLfixed x1, GLfixed y1, GLfixed x2, GLfixed y2);
    private delegate void PFNGLRECTXVOESPROC(const GLfixed *v1, const GLfixed *v2);
    private delegate void PFNGLTEXCOORD1XOESPROC(GLfixed s);
    private delegate void PFNGLTEXCOORD1XVOESPROC(const GLfixed *coords);
    private delegate void PFNGLTEXCOORD2XOESPROC(GLfixed s, GLfixed t);
    private delegate void PFNGLTEXCOORD2XVOESPROC(const GLfixed *coords);
    private delegate void PFNGLTEXCOORD3XOESPROC(GLfixed s, GLfixed t, GLfixed r);
    private delegate void PFNGLTEXCOORD3XVOESPROC(const GLfixed *coords);
    private delegate void PFNGLTEXCOORD4XOESPROC(GLfixed s, GLfixed t, GLfixed r, GLfixed q);
    private delegate void PFNGLTEXCOORD4XVOESPROC(const GLfixed *coords);
    private delegate void PFNGLTEXGENXOESPROC(uint coord, uint pname, GLfixed param);
    private delegate void PFNGLTEXGENXVOESPROC(uint coord, uint pname, const GLfixed *params);
    private delegate void PFNGLVERTEX2XOESPROC(GLfixed x);
    private delegate void PFNGLVERTEX2XVOESPROC(const GLfixed *coords);
    private delegate void PFNGLVERTEX3XOESPROC(GLfixed x, GLfixed y);
    private delegate void PFNGLVERTEX3XVOESPROC(const GLfixed *coords);
    private delegate void PFNGLVERTEX4XOESPROC(GLfixed x, GLfixed y, GLfixed z);
    private delegate void PFNGLVERTEX4XVOESPROC(const GLfixed *coords);
    #ifdef GL_GLEXT_PROTOTYPES
    public static void glAlphaFuncxOES(uint func, GLfixed ref);
    public static void glClearColorxOES(GLfixed red, GLfixed green, GLfixed blue, GLfixed alpha);
    public static void glClearDepthxOES(GLfixed depth);
    public static void glClipPlanexOES(uint plane, const GLfixed *equation);
    public static void glColor4xOES(GLfixed red, GLfixed green, GLfixed blue, GLfixed alpha);
    public static void glDepthRangexOES(GLfixed n, GLfixed f);
    public static void glFogxOES(uint pname, GLfixed param);
    public static void glFogxvOES(uint pname, const GLfixed *param);
    public static void glFrustumxOES(GLfixed l, GLfixed r, GLfixed b, GLfixed t, GLfixed n, GLfixed f);
    public static void glGetClipPlanexOES(uint plane, GLfixed *equation);
    public static void glGetFixedvOES(uint pname, GLfixed *params);
    public static void glGetTexEnvxvOES(uint target, uint pname, GLfixed *params);
    public static void glGetTexParameterxvOES(uint target, uint pname, GLfixed *params);
    public static void glLightModelxOES(uint pname, GLfixed param);
    public static void glLightModelxvOES(uint pname, const GLfixed *param);
    public static void glLightxOES(uint light, uint pname, GLfixed param);
    public static void glLightxvOES(uint light, uint pname, const GLfixed *params);
    public static void glLineWidthxOES(GLfixed width);
    public static void glLoadMatrixxOES(const GLfixed *m);
    public static void glMaterialxOES(uint face, uint pname, GLfixed param);
    public static void glMaterialxvOES(uint face, uint pname, const GLfixed *param);
    public static void glMultMatrixxOES(const GLfixed *m);
    public static void glMultiTexCoord4xOES(uint texture, GLfixed s, GLfixed t, GLfixed r, GLfixed q);
    public static void glNormal3xOES(GLfixed nx, GLfixed ny, GLfixed nz);
    public static void glOrthoxOES(GLfixed l, GLfixed r, GLfixed b, GLfixed t, GLfixed n, GLfixed f);
    public static void glPointParameterxvOES(uint pname, const GLfixed *params);
    public static void glPointSizexOES(GLfixed size);
    public static void glPolygonOffsetxOES(GLfixed factor, GLfixed units);
    public static void glRotatexOES(GLfixed angle, GLfixed x, GLfixed y, GLfixed z);
    public static void glSampleCoverageOES(GLfixed value, bool invert);
    public static void glScalexOES(GLfixed x, GLfixed y, GLfixed z);
    public static void glTexEnvxOES(uint target, uint pname, GLfixed param);
    public static void glTexEnvxvOES(uint target, uint pname, const GLfixed *params);
    public static void glTexParameterxOES(uint target, uint pname, GLfixed param);
    public static void glTexParameterxvOES(uint target, uint pname, const GLfixed *params);
    public static void glTranslatexOES(GLfixed x, GLfixed y, GLfixed z);
    public static void glAccumxOES(uint op, GLfixed value);
    public static void glBitmapxOES(uint width, uint height, GLfixed xorig, GLfixed yorig, GLfixed xmove, GLfixed ymove, const byte *bitmap);
    public static void glBlendColorxOES(GLfixed red, GLfixed green, GLfixed blue, GLfixed alpha);
    public static void glClearAccumxOES(GLfixed red, GLfixed green, GLfixed blue, GLfixed alpha);
    public static void glColor3xOES(GLfixed red, GLfixed green, GLfixed blue);
    public static void glColor3xvOES(const GLfixed *components);
    public static void glColor4xvOES(const GLfixed *components);
    public static void glConvolutionParameterxOES(uint target, uint pname, GLfixed param);
    public static void glConvolutionParameterxvOES(uint target, uint pname, const GLfixed *params);
    public static void glEvalCoord1xOES(GLfixed u);
    public static void glEvalCoord1xvOES(const GLfixed *coords);
    public static void glEvalCoord2xOES(GLfixed u, GLfixed v);
    public static void glEvalCoord2xvOES(const GLfixed *coords);
    public static void glFeedbackBufferxOES(uint n, uint type, const GLfixed *buffer);
    public static void glGetConvolutionParameterxvOES(uint target, uint pname, GLfixed *params);
    public static void glGetHistogramParameterxvOES(uint target, uint pname, GLfixed *params);
    public static void glGetLightxOES(uint light, uint pname, GLfixed *params);
    public static void glGetMapxvOES(uint target, uint query, GLfixed *v);
    public static void glGetMaterialxOES(uint face, uint pname, GLfixed param);
    public static void glGetPixelMapxv(uint map, int size, GLfixed *values);
    public static void glGetTexGenxvOES(uint coord, uint pname, GLfixed *params);
    public static void glGetTexLevelParameterxvOES(uint target, int level, uint pname, GLfixed *params);
    public static void glIndexxOES(GLfixed component);
    public static void glIndexxvOES(const GLfixed *component);
    public static void glLoadTransposeMatrixxOES(const GLfixed *m);
    public static void glMap1xOES(uint target, GLfixed u1, GLfixed u2, int stride, int order, GLfixed points);
    public static void glMap2xOES(uint target, GLfixed u1, GLfixed u2, int ustride, int uorder, GLfixed v1, GLfixed v2, int vstride, int vorder, GLfixed points);
    public static void glMapGrid1xOES(int n, GLfixed u1, GLfixed u2);
    public static void glMapGrid2xOES(int n, GLfixed u1, GLfixed u2, GLfixed v1, GLfixed v2);
    public static void glMultTransposeMatrixxOES(const GLfixed *m);
    public static void glMultiTexCoord1xOES(uint texture, GLfixed s);
    public static void glMultiTexCoord1xvOES(uint texture, const GLfixed *coords);
    public static void glMultiTexCoord2xOES(uint texture, GLfixed s, GLfixed t);
    public static void glMultiTexCoord2xvOES(uint texture, const GLfixed *coords);
    public static void glMultiTexCoord3xOES(uint texture, GLfixed s, GLfixed t, GLfixed r);
    public static void glMultiTexCoord3xvOES(uint texture, const GLfixed *coords);
    public static void glMultiTexCoord4xvOES(uint texture, const GLfixed *coords);
    public static void glNormal3xvOES(const GLfixed *coords);
    public static void glPassThroughxOES(GLfixed token);
    public static void glPixelMapx(uint map, int size, const GLfixed *values);
    public static void glPixelStorex(uint pname, GLfixed param);
    public static void glPixelTransferxOES(uint pname, GLfixed param);
    public static void glPixelZoomxOES(GLfixed xfactor, GLfixed yfactor);
    public static void glPrioritizeTexturesxOES(uint n, const uint *textures, const GLfixed *priorities);
    public static void glRasterPos2xOES(GLfixed x, GLfixed y);
    public static void glRasterPos2xvOES(const GLfixed *coords);
    public static void glRasterPos3xOES(GLfixed x, GLfixed y, GLfixed z);
    public static void glRasterPos3xvOES(const GLfixed *coords);
    public static void glRasterPos4xOES(GLfixed x, GLfixed y, GLfixed z, GLfixed w);
    public static void glRasterPos4xvOES(const GLfixed *coords);
    public static void glRectxOES(GLfixed x1, GLfixed y1, GLfixed x2, GLfixed y2);
    public static void glRectxvOES(const GLfixed *v1, const GLfixed *v2);
    public static void glTexCoord1xOES(GLfixed s);
    public static void glTexCoord1xvOES(const GLfixed *coords);
    public static void glTexCoord2xOES(GLfixed s, GLfixed t);
    public static void glTexCoord2xvOES(const GLfixed *coords);
    public static void glTexCoord3xOES(GLfixed s, GLfixed t, GLfixed r);
    public static void glTexCoord3xvOES(const GLfixed *coords);
    public static void glTexCoord4xOES(GLfixed s, GLfixed t, GLfixed r, GLfixed q);
    public static void glTexCoord4xvOES(const GLfixed *coords);
    public static void glTexGenxOES(uint coord, uint pname, GLfixed param);
    public static void glTexGenxvOES(uint coord, uint pname, const GLfixed *params);
    public static void glVertex2xOES(GLfixed x);
    public static void glVertex2xvOES(const GLfixed *coords);
    public static void glVertex3xOES(GLfixed x, GLfixed y);
    public static void glVertex3xvOES(const GLfixed *coords);
    public static void glVertex4xOES(GLfixed x, GLfixed y, GLfixed z);
    public static void glVertex4xvOES(const GLfixed *coords);
    #endif
    #endif /* GL_OES_fixed_point */

    #ifndef GL_OES_query_matrix
    #define GL_OES_query_matrix 1
    private delegate uint PFNGLQUERYMATRIXXOESPROC(GLfixed *mantissa, int *exponent);
    #ifdef GL_GLEXT_PROTOTYPES
    public static uint glQueryMatrixxOES(GLfixed *mantissa, int *exponent);
    #endif
    #endif /* GL_OES_query_matrix */

    #ifndef GL_OES_read_format
    #define GL_OES_read_format 1
    public const uint GL_IMPLEMENTATION_COLOR_READ_TYPE_OES = 0x8B9A;
    public const uint GL_IMPLEMENTATION_COLOR_READ_FORMAT_OES = 0x8B9B;
    #endif /* GL_OES_read_format */

    #ifndef GL_OES_single_precision
    #define GL_OES_single_precision 1
    private delegate void PFNGLCLEARDEPTHFOESPROC(float depth);
    private delegate void PFNGLCLIPPLANEFOESPROC(uint plane, const float *equation);
    private delegate void PFNGLDEPTHRANGEFOESPROC(float n, float f);
    private delegate void PFNGLFRUSTUMFOESPROC(float l, float r, float b, float t, float n, float f);
    private delegate void PFNGLGETCLIPPLANEFOESPROC(uint plane, float *equation);
    private delegate void PFNGLORTHOFOESPROC(float l, float r, float b, float t, float n, float f);
    #ifdef GL_GLEXT_PROTOTYPES
    public static void glClearDepthfOES(float depth);
    public static void glClipPlanefOES(uint plane, const float *equation);
    public static void glDepthRangefOES(float n, float f);
    public static void glFrustumfOES(float l, float r, float b, float t, float n, float f);
    public static void glGetClipPlanefOES(uint plane, float *equation);
    public static void glOrthofOES(float l, float r, float b, float t, float n, float f);
    #endif
    #endif /* GL_OES_single_precision */

    #ifndef GL_3DFX_multisample
    #define GL_3DFX_multisample 1
    public const uint GL_MULTISAMPLE_3DFX = 0x86B2;
    public const uint GL_SAMPLE_BUFFERS_3DFX = 0x86B3;
    public const uint GL_SAMPLES_3DFX = 0x86B4;
    public const uint GL_MULTISAMPLE_BIT_3DFX = 0x20000000;
    #endif /* GL_3DFX_multisample */

    #ifndef GL_3DFX_tbuffer
    #define GL_3DFX_tbuffer 1
    private delegate void PFNGLTBUFFERMASK3DFXPROC(uint mask);
    #ifdef GL_GLEXT_PROTOTYPES
    public static void glTbufferMask3DFX(uint mask);
    #endif
    #endif /* GL_3DFX_tbuffer */

    #ifndef GL_3DFX_texture_compression_FXT1
    #define GL_3DFX_texture_compression_FXT1 1
    public const uint GL_COMPRESSED_RGB_FXT1_3DFX = 0x86B0;
    public const uint GL_COMPRESSED_RGBA_FXT1_3DFX = 0x86B1;
    #endif /* GL_3DFX_texture_compression_FXT1 */

    #ifndef GL_AMD_blend_minmax_factor
    #define GL_AMD_blend_minmax_factor 1
    public const uint GL_FACTOR_MIN_AMD = 0x901C;
    public const uint GL_FACTOR_MAX_AMD = 0x901D;
    #endif /* GL_AMD_blend_minmax_factor */

    #ifndef GL_AMD_conservative_depth
    #define GL_AMD_conservative_depth 1
    #endif /* GL_AMD_conservative_depth */

    #ifndef GL_AMD_debug_output
    #define GL_AMD_debug_output 1
    typedef void (APIENTRY  *GLDEBUGPROCAMD)(uint id,uint category,uint severity,uint length,const byte *message,void *userParam);
    public const uint GL_MAX_DEBUG_MESSAGE_LENGTH_AMD = 0x9143;
    public const uint GL_MAX_DEBUG_LOGGED_MESSAGES_AMD = 0x9144;
    public const uint GL_DEBUG_LOGGED_MESSAGES_AMD = 0x9145;
    public const uint GL_DEBUG_SEVERITY_HIGH_AMD = 0x9146;
    public const uint GL_DEBUG_SEVERITY_MEDIUM_AMD = 0x9147;
    public const uint GL_DEBUG_SEVERITY_LOW_AMD = 0x9148;
    public const uint GL_DEBUG_CATEGORY_API_ERROR_AMD = 0x9149;
    public const uint GL_DEBUG_CATEGORY_WINDOW_SYSTEM_AMD = 0x914A;
    public const uint GL_DEBUG_CATEGORY_DEPRECATION_AMD = 0x914B;
    public const uint GL_DEBUG_CATEGORY_UNDEFINED_BEHAVIOR_AMD = 0x914C;
    public const uint GL_DEBUG_CATEGORY_PERFORMANCE_AMD = 0x914D;
    public const uint GL_DEBUG_CATEGORY_SHADER_COMPILER_AMD = 0x914E;
    public const uint GL_DEBUG_CATEGORY_APPLICATION_AMD = 0x914F;
    public const uint GL_DEBUG_CATEGORY_OTHER_AMD = 0x9150;
    private delegate void PFNGLDEBUGMESSAGEENABLEAMDPROC(uint category, uint severity, uint count, const uint *ids, bool enabled);
    private delegate void PFNGLDEBUGMESSAGEINSERTAMDPROC(uint category, uint severity, uint id, uint length, const byte *buf);
    private delegate void PFNGLDEBUGMESSAGECALLBACKAMDPROC(GLDEBUGPROCAMD callback, void *userParam);
    private delegate uint PFNGLGETDEBUGMESSAGELOGAMDPROC(uint count, uint bufsize, uint *categories, uint *severities, uint *ids, uint *lengths, byte *message);
    #ifdef GL_GLEXT_PROTOTYPES
    public static void glDebugMessageEnableAMD(uint category, uint severity, uint count, const uint *ids, bool enabled);
    public static void glDebugMessageInsertAMD(uint category, uint severity, uint id, uint length, const byte *buf);
    public static void glDebugMessageCallbackAMD(GLDEBUGPROCAMD callback, void *userParam);
    public static uint glGetDebugMessageLogAMD(uint count, uint bufsize, uint *categories, uint *severities, uint *ids, uint *lengths, byte *message);
    #endif
    #endif /* GL_AMD_debug_output */

    #ifndef GL_AMD_depth_clamp_separate
    #define GL_AMD_depth_clamp_separate 1
    public const uint GL_DEPTH_CLAMP_NEAR_AMD = 0x901E;
    public const uint GL_DEPTH_CLAMP_FAR_AMD = 0x901F;
    #endif /* GL_AMD_depth_clamp_separate */

    #ifndef GL_AMD_draw_buffers_blend
    #define GL_AMD_draw_buffers_blend 1
    private delegate void PFNGLBLENDFUNCINDEXEDAMDPROC(uint buf, uint src, uint dst);
    private delegate void PFNGLBLENDFUNCSEPARATEINDEXEDAMDPROC(uint buf, uint srcRGB, uint dstRGB, uint srcAlpha, uint dstAlpha);
    private delegate void PFNGLBLENDEQUATIONINDEXEDAMDPROC(uint buf, uint mode);
    private delegate void PFNGLBLENDEQUATIONSEPARATEINDEXEDAMDPROC(uint buf, uint modeRGB, uint modeAlpha);
    #ifdef GL_GLEXT_PROTOTYPES
    public static void glBlendFuncIndexedAMD(uint buf, uint src, uint dst);
    public static void glBlendFuncSeparateIndexedAMD(uint buf, uint srcRGB, uint dstRGB, uint srcAlpha, uint dstAlpha);
    public static void glBlendEquationIndexedAMD(uint buf, uint mode);
    public static void glBlendEquationSeparateIndexedAMD(uint buf, uint modeRGB, uint modeAlpha);
    #endif
    #endif /* GL_AMD_draw_buffers_blend */

    #ifndef GL_AMD_interleaved_elements
    #define GL_AMD_interleaved_elements 1
    public const uint GL_VERTEX_ELEMENT_SWIZZLE_AMD = 0x91A4;
    public const uint GL_VERTEX_ID_SWIZZLE_AMD = 0x91A5;
    private delegate void PFNGLVERTEXATTRIBPARAMETERIAMDPROC(uint index, uint pname, int param);
    #ifdef GL_GLEXT_PROTOTYPES
    public static void glVertexAttribParameteriAMD(uint index, uint pname, int param);
    #endif
    #endif /* GL_AMD_interleaved_elements */

    #ifndef GL_AMD_multi_draw_indirect
    #define GL_AMD_multi_draw_indirect 1
    private delegate void PFNGLMULTIDRAWARRAYSINDIRECTAMDPROC(uint mode, const void *indirect, uint primcount, uint stride);
    private delegate void PFNGLMULTIDRAWELEMENTSINDIRECTAMDPROC(uint mode, uint type, const void *indirect, uint primcount, uint stride);
    #ifdef GL_GLEXT_PROTOTYPES
    public static void glMultiDrawArraysIndirectAMD(uint mode, const void *indirect, uint primcount, uint stride);
    public static void glMultiDrawElementsIndirectAMD(uint mode, uint type, const void *indirect, uint primcount, uint stride);
    #endif
    #endif /* GL_AMD_multi_draw_indirect */

    #ifndef GL_AMD_name_gen_delete
    #define GL_AMD_name_gen_delete 1
    public const uint GL_DATA_BUFFER_AMD = 0x9151;
    public const uint GL_PERFORMANCE_MONITOR_AMD = 0x9152;
    public const uint GL_QUERY_OBJECT_AMD = 0x9153;
    public const uint GL_VERTEX_ARRAY_OBJECT_AMD = 0x9154;
    public const uint GL_SAMPLER_OBJECT_AMD = 0x9155;
    private delegate void PFNGLGENNAMESAMDPROC(uint identifier, uint num, uint *names);
    private delegate void PFNGLDELETENAMESAMDPROC(uint identifier, uint num, const uint *names);
    private delegate bool PFNGLISNAMEAMDPROC(uint identifier, uint name);
    #ifdef GL_GLEXT_PROTOTYPES
    public static void glGenNamesAMD(uint identifier, uint num, uint *names);
    public static void glDeleteNamesAMD(uint identifier, uint num, const uint *names);
    public static bool glIsNameAMD(uint identifier, uint name);
    #endif
    #endif /* GL_AMD_name_gen_delete */

    #ifndef GL_AMD_performance_monitor
    #define GL_AMD_performance_monitor 1
    public const uint GL_COUNTER_TYPE_AMD = 0x8BC0;
    public const uint GL_COUNTER_RANGE_AMD = 0x8BC1;
    public const uint GL_UNSIGNED_long_AMD = 0x8BC2;
    public const uint GL_PERCENTAGE_AMD = 0x8BC3;
    public const uint GL_PERFMON_RESULT_AVAILABLE_AMD = 0x8BC4;
    public const uint GL_PERFMON_RESULT_SIZE_AMD = 0x8BC5;
    public const uint GL_PERFMON_RESULT_AMD = 0x8BC6;
    private delegate void PFNGLGETPERFMONITORGROUPSAMDPROC(int *numGroups, uint groupsSize, uint *groups);
    private delegate void PFNGLGETPERFMONITORCOUNTERSAMDPROC(uint group, int *numCounters, int *maxActiveCounters, uint counterSize, uint *counters);
    private delegate void PFNGLGETPERFMONITORGROUPSTRINGAMDPROC(uint group, uint bufSize, uint *length, byte *groupString);
    private delegate void PFNGLGETPERFMONITORCOUNTERSTRINGAMDPROC(uint group, uint counter, uint bufSize, uint *length, byte *counterString);
    private delegate void PFNGLGETPERFMONITORCOUNTERINFOAMDPROC(uint group, uint counter, uint pname, void *data);
    private delegate void PFNGLGENPERFMONITORSAMDPROC(uint n, uint *monitors);
    private delegate void PFNGLDELETEPERFMONITORSAMDPROC(uint n, uint *monitors);
    private delegate void PFNGLSELECTPERFMONITORCOUNTERSAMDPROC(uint monitor, bool enable, uint group, int numCounters, uint *counterList);
    private delegate void PFNGLBEGINPERFMONITORAMDPROC(uint monitor);
    private delegate void PFNGLENDPERFMONITORAMDPROC(uint monitor);
    private delegate void PFNGLGETPERFMONITORCOUNTERDATAAMDPROC(uint monitor, uint pname, uint dataSize, uint *data, int *bytesWritten);
    #ifdef GL_GLEXT_PROTOTYPES
    public static void glGetPerfMonitorGroupsAMD(int *numGroups, uint groupsSize, uint *groups);
    public static void glGetPerfMonitorCountersAMD(uint group, int *numCounters, int *maxActiveCounters, uint counterSize, uint *counters);
    public static void glGetPerfMonitorGroupStringAMD(uint group, uint bufSize, uint *length, byte *groupString);
    public static void glGetPerfMonitorCounterStringAMD(uint group, uint counter, uint bufSize, uint *length, byte *counterString);
    public static void glGetPerfMonitorCounterInfoAMD(uint group, uint counter, uint pname, void *data);
    public static void glGenPerfMonitorsAMD(uint n, uint *monitors);
    public static void glDeletePerfMonitorsAMD(uint n, uint *monitors);
    public static void glSelectPerfMonitorCountersAMD(uint monitor, bool enable, uint group, int numCounters, uint *counterList);
    public static void glBeginPerfMonitorAMD(uint monitor);
    public static void glEndPerfMonitorAMD(uint monitor);
    public static void glGetPerfMonitorCounterDataAMD(uint monitor, uint pname, uint dataSize, uint *data, int *bytesWritten);
    #endif
    #endif /* GL_AMD_performance_monitor */

    #ifndef GL_AMD_pinned_memory
    #define GL_AMD_pinned_memory 1
    public const uint GL_EXTERNAL_VIRTUAL_MEMORY_BUFFER_AMD = 0x9160;
    #endif /* GL_AMD_pinned_memory */

    #ifndef GL_AMD_query_buffer_object
    #define GL_AMD_query_buffer_object 1
    public const uint GL_QUERY_BUFFER_AMD = 0x9192;
    public const uint GL_QUERY_BUFFER_BINDING_AMD = 0x9193;
    public const uint GL_QUERY_RESULT_NO_WAIT_AMD = 0x9194;
    #endif /* GL_AMD_query_buffer_object */

    #ifndef GL_AMD_sample_positions
    #define GL_AMD_sample_positions 1
    public const uint GL_SUBSAMPLE_DISTANCE_AMD = 0x883F;
    private delegate void PFNGLSETMULTISAMPLEFVAMDPROC(uint pname, uint index, const float *val);
    #ifdef GL_GLEXT_PROTOTYPES
    public static void glSetMultisamplefvAMD(uint pname, uint index, const float *val);
    #endif
    #endif /* GL_AMD_sample_positions */

    #ifndef GL_AMD_seamless_cubemap_per_texture
    #define GL_AMD_seamless_cubemap_per_texture 1
    #endif /* GL_AMD_seamless_cubemap_per_texture */

    #ifndef GL_AMD_shader_atomic_counter_ops
    #define GL_AMD_shader_atomic_counter_ops 1
    #endif /* GL_AMD_shader_atomic_counter_ops */

    #ifndef GL_AMD_shader_stencil_export
    #define GL_AMD_shader_stencil_export 1
    #endif /* GL_AMD_shader_stencil_export */

    #ifndef GL_AMD_shader_trinary_minmax
    #define GL_AMD_shader_trinary_minmax 1
    #endif /* GL_AMD_shader_trinary_minmax */

    #ifndef GL_AMD_sparse_texture
    #define GL_AMD_sparse_texture 1
    public const uint GL_VIRTUAL_PAGE_SIZE_X_AMD = 0x9195;
    public const uint GL_VIRTUAL_PAGE_SIZE_Y_AMD = 0x9196;
    public const uint GL_VIRTUAL_PAGE_SIZE_Z_AMD = 0x9197;
    public const uint GL_MAX_SPARSE_TEXTURE_SIZE_AMD = 0x9198;
    public const uint GL_MAX_SPARSE_3D_TEXTURE_SIZE_AMD = 0x9199;
    public const uint GL_MAX_SPARSE_ARRAY_TEXTURE_LAYERS = 0x919A;
    public const uint GL_MIN_SPARSE_LEVEL_AMD = 0x919B;
    public const uint GL_MIN_LOD_WARNING_AMD = 0x919C;
    public const uint GL_TEXTURE_STORAGE_SPARSE_BIT_AMD = 0x00000001;
    private delegate void PFNGLTEXSTORAGESPARSEAMDPROC(uint target, uint internalFormat, uint width, uint height, uint depth, uint layers, uint flags);
    private delegate void PFNGLTEXTURESTORAGESPARSEAMDPROC(uint texture, uint target, uint internalFormat, uint width, uint height, uint depth, uint layers, uint flags);
    #ifdef GL_GLEXT_PROTOTYPES
    public static void glTexStorageSparseAMD(uint target, uint internalFormat, uint width, uint height, uint depth, uint layers, uint flags);
    public static void glTextureStorageSparseAMD(uint texture, uint target, uint internalFormat, uint width, uint height, uint depth, uint layers, uint flags);
    #endif
    #endif /* GL_AMD_sparse_texture */

    #ifndef GL_AMD_stencil_operation_extended
    #define GL_AMD_stencil_operation_extended 1
    public const uint GL_SET_AMD = 0x874A;
    public const uint GL_REPLACE_VALUE_AMD = 0x874B;
    public const uint GL_STENCIL_OP_VALUE_AMD = 0x874C;
    public const uint GL_STENCIL_BACK_OP_VALUE_AMD = 0x874D;
    private delegate void PFNGLSTENCILOPVALUEAMDPROC(uint face, uint value);
    #ifdef GL_GLEXT_PROTOTYPES
    public static void glStencilOpValueAMD(uint face, uint value);
    #endif
    #endif /* GL_AMD_stencil_operation_extended */

    #ifndef GL_AMD_texture_texture4
    #define GL_AMD_texture_texture4 1
    #endif /* GL_AMD_texture_texture4 */

    #ifndef GL_AMD_transform_feedback3_lines_triangles
    #define GL_AMD_transform_feedback3_lines_triangles 1
    #endif /* GL_AMD_transform_feedback3_lines_triangles */

    #ifndef GL_AMD_vertex_shader_layer
    #define GL_AMD_vertex_shader_layer 1
    #endif /* GL_AMD_vertex_shader_layer */

    #ifndef GL_AMD_vertex_shader_tessellator
    #define GL_AMD_vertex_shader_tessellator 1
    public const uint GL_SAMPLER_BUFFER_AMD = 0x9001;
    public const uint GL_INT_SAMPLER_BUFFER_AMD = 0x9002;
    public const uint GL_UNSIGNED_INT_SAMPLER_BUFFER_AMD = 0x9003;
    public const uint GL_TESSELLATION_MODE_AMD = 0x9004;
    public const uint GL_TESSELLATION_FACTOR_AMD = 0x9005;
    public const uint GL_DISCRETE_AMD = 0x9006;
    public const uint GL_CONTINUOUS_AMD = 0x9007;
    private delegate void PFNGLTESSELLATIONFACTORAMDPROC(float factor);
    private delegate void PFNGLTESSELLATIONMODEAMDPROC(uint mode);
    #ifdef GL_GLEXT_PROTOTYPES
    public static void glTessellationFactorAMD(float factor);
    public static void glTessellationModeAMD(uint mode);
    #endif
    #endif /* GL_AMD_vertex_shader_tessellator */

    #ifndef GL_AMD_vertex_shader_viewport_index
    #define GL_AMD_vertex_shader_viewport_index 1
    #endif /* GL_AMD_vertex_shader_viewport_index */

    #ifndef GL_APPLE_aux_depth_stencil
    #define GL_APPLE_aux_depth_stencil 1
    public const uint GL_AUX_DEPTH_STENCIL_APPLE = 0x8A14;
    #endif /* GL_APPLE_aux_depth_stencil */

    #ifndef GL_APPLE_client_storage
    #define GL_APPLE_client_storage 1
    public const uint GL_UNPACK_CLIENT_STORAGE_APPLE = 0x85B2;
    #endif /* GL_APPLE_client_storage */

    #ifndef GL_APPLE_element_array
    #define GL_APPLE_element_array 1
    public const uint GL_ELEMENT_ARRAY_APPLE = 0x8A0C;
    public const uint GL_ELEMENT_ARRAY_TYPE_APPLE = 0x8A0D;
    public const uint GL_ELEMENT_ARRAY_POINTER_APPLE = 0x8A0E;
    private delegate void PFNGLELEMENTPOINTERAPPLEPROC(uint type, const void *pointer);
    private delegate void PFNGLDRAWELEMENTARRAYAPPLEPROC(uint mode, int first, uint count);
    private delegate void PFNGLDRAWRANGEELEMENTARRAYAPPLEPROC(uint mode, uint start, uint end, int first, uint count);
    private delegate void PFNGLMULTIDRAWELEMENTARRAYAPPLEPROC(uint mode, const int *first, const uint *count, uint primcount);
    private delegate void PFNGLMULTIDRAWRANGEELEMENTARRAYAPPLEPROC(uint mode, uint start, uint end, const int *first, const uint *count, uint primcount);
    #ifdef GL_GLEXT_PROTOTYPES
    public static void glElementPointerAPPLE(uint type, const void *pointer);
    public static void glDrawElementArrayAPPLE(uint mode, int first, uint count);
    public static void glDrawRangeElementArrayAPPLE(uint mode, uint start, uint end, int first, uint count);
    public static void glMultiDrawElementArrayAPPLE(uint mode, const int *first, const uint *count, uint primcount);
    public static void glMultiDrawRangeElementArrayAPPLE(uint mode, uint start, uint end, const int *first, const uint *count, uint primcount);
    #endif
    #endif /* GL_APPLE_element_array */

    #ifndef GL_APPLE_fence
    #define GL_APPLE_fence 1
    public const uint GL_DRAW_PIXELS_APPLE = 0x8A0A;
    public const uint GL_FENCE_APPLE = 0x8A0B;
    private delegate void PFNGLGENFENCESAPPLEPROC(uint n, uint *fences);
    private delegate void PFNGLDELETEFENCESAPPLEPROC(uint n, const uint *fences);
    private delegate void PFNGLSETFENCEAPPLEPROC(uint fence);
    private delegate bool PFNGLISFENCEAPPLEPROC(uint fence);
    private delegate bool PFNGLTESTFENCEAPPLEPROC(uint fence);
    private delegate void PFNGLFINISHFENCEAPPLEPROC(uint fence);
    private delegate bool PFNGLTESTOBJECTAPPLEPROC(uint object, uint name);
    private delegate void PFNGLFINISHOBJECTAPPLEPROC(uint object, int name);
    #ifdef GL_GLEXT_PROTOTYPES
    public static void glGenFencesAPPLE(uint n, uint *fences);
    public static void glDeleteFencesAPPLE(uint n, const uint *fences);
    public static void glSetFenceAPPLE(uint fence);
    public static bool glIsFenceAPPLE(uint fence);
    public static bool glTestFenceAPPLE(uint fence);
    public static void glFinishFenceAPPLE(uint fence);
    public static bool glTestObjectAPPLE(uint object, uint name);
    public static void glFinishObjectAPPLE(uint object, int name);
    #endif
    #endif /* GL_APPLE_fence */

    #ifndef GL_APPLE_float_pixels
    #define GL_APPLE_float_pixels 1
    public const uint GL_HALF_APPLE = 0x140B;
    public const uint GL_RGBA_FLOAT32_APPLE = 0x8814;
    public const uint GL_RGB_FLOAT32_APPLE = 0x8815;
    public const uint GL_ALPHA_FLOAT32_APPLE = 0x8816;
    public const uint GL_INTENSITY_FLOAT32_APPLE = 0x8817;
    public const uint GL_LUMINANCE_FLOAT32_APPLE = 0x8818;
    public const uint GL_LUMINANCE_ALPHA_FLOAT32_APPLE = 0x8819;
    public const uint GL_RGBA_FLOAT16_APPLE = 0x881A;
    public const uint GL_RGB_FLOAT16_APPLE = 0x881B;
    public const uint GL_ALPHA_FLOAT16_APPLE = 0x881C;
    public const uint GL_INTENSITY_FLOAT16_APPLE = 0x881D;
    public const uint GL_LUMINANCE_FLOAT16_APPLE = 0x881E;
    public const uint GL_LUMINANCE_ALPHA_FLOAT16_APPLE = 0x881F;
    public const uint GL_COLOR_FLOAT_APPLE = 0x8A0F;
    #endif /* GL_APPLE_float_pixels */

    #ifndef GL_APPLE_flush_buffer_range
    #define GL_APPLE_flush_buffer_range 1
    public const uint GL_BUFFER_SERIALIZED_MODIFY_APPLE = 0x8A12;
    public const uint GL_BUFFER_FLUSHING_UNMAP_APPLE = 0x8A13;
    private delegate void PFNGLBUFFERPARAMETERIAPPLEPROC(uint target, uint pname, int param);
    private delegate void PFNGLFLUSHMAPPEDBUFFERRANGEAPPLEPROC(uint target, intptr offset, uintptr size);
    #ifdef GL_GLEXT_PROTOTYPES
    public static void glBufferParameteriAPPLE(uint target, uint pname, int param);
    public static void glFlushMappedBufferRangeAPPLE(uint target, intptr offset, uintptr size);
    #endif
    #endif /* GL_APPLE_flush_buffer_range */

    #ifndef GL_APPLE_object_purgeable
    #define GL_APPLE_object_purgeable 1
    public const uint GL_BUFFER_OBJECT_APPLE = 0x85B3;
    public const uint GL_RELEASED_APPLE = 0x8A19;
    public const uint GL_VOLATILE_APPLE = 0x8A1A;
    public const uint GL_RETAINED_APPLE = 0x8A1B;
    public const uint GL_UNDEFINED_APPLE = 0x8A1C;
    public const uint GL_PURGEABLE_APPLE = 0x8A1D;
    private delegate uint PFNGLOBJECTPURGEABLEAPPLEPROC(uint objectType, uint name, uint option);
    private delegate uint PFNGLOBJECTUNPURGEABLEAPPLEPROC(uint objectType, uint name, uint option);
    private delegate void PFNGLGETOBJECTPARAMETERIVAPPLEPROC(uint objectType, uint name, uint pname, int *params);
    #ifdef GL_GLEXT_PROTOTYPES
    public static uint glObjectPurgeableAPPLE(uint objectType, uint name, uint option);
    public static uint glObjectUnpurgeableAPPLE(uint objectType, uint name, uint option);
    public static void glGetObjectParameterivAPPLE(uint objectType, uint name, uint pname, int *params);
    #endif
    #endif /* GL_APPLE_object_purgeable */

    #ifndef GL_APPLE_rgb_422
    #define GL_APPLE_rgb_422 1
    public const uint GL_RGB_422_APPLE = 0x8A1F;
    public const uint GL_UNSIGNED_SHORT_8_8_APPLE = 0x85BA;
    public const uint GL_UNSIGNED_SHORT_8_8_REV_APPLE = 0x85BB;
    public const uint GL_RGB_RAW_422_APPLE = 0x8A51;
    #endif /* GL_APPLE_rgb_422 */

    #ifndef GL_APPLE_row_bytes
    #define GL_APPLE_row_bytes 1
    public const uint GL_PACK_ROW_BYTES_APPLE = 0x8A15;
    public const uint GL_UNPACK_ROW_BYTES_APPLE = 0x8A16;
    #endif /* GL_APPLE_row_bytes */

    #ifndef GL_APPLE_specular_vector
    #define GL_APPLE_specular_vector 1
    public const uint GL_LIGHT_MODEL_SPECULAR_VECTOR_APPLE = 0x85B0;
    #endif /* GL_APPLE_specular_vector */

    #ifndef GL_APPLE_texture_range
    #define GL_APPLE_texture_range 1
    public const uint GL_TEXTURE_RANGE_LENGTH_APPLE = 0x85B7;
    public const uint GL_TEXTURE_RANGE_POINTER_APPLE = 0x85B8;
    public const uint GL_TEXTURE_STORAGE_HINT_APPLE = 0x85BC;
    public const uint GL_STORAGE_PRIVATE_APPLE = 0x85BD;
    public const uint GL_STORAGE_CACHED_APPLE = 0x85BE;
    public const uint GL_STORAGE_SHARED_APPLE = 0x85BF;
    private delegate void PFNGLTEXTURERANGEAPPLEPROC(uint target, uint length, const void *pointer);
    private delegate void PFNGLGETTEXPARAMETERPOINTERVAPPLEPROC(uint target, uint pname, void **params);
    #ifdef GL_GLEXT_PROTOTYPES
    public static void glTextureRangeAPPLE(uint target, uint length, const void *pointer);
    public static void glGetTexParameterPointervAPPLE(uint target, uint pname, void **params);
    #endif
    #endif /* GL_APPLE_texture_range */

    #ifndef GL_APPLE_transform_hint
    #define GL_APPLE_transform_hint 1
    public const uint GL_TRANSFORM_HINT_APPLE = 0x85B1;
    #endif /* GL_APPLE_transform_hint */

    #ifndef GL_APPLE_vertex_array_object
    #define GL_APPLE_vertex_array_object 1
    public const uint GL_VERTEX_ARRAY_BINDING_APPLE = 0x85B5;
    private delegate void PFNGLBINDVERTEXARRAYAPPLEPROC(uint array);
    private delegate void PFNGLDELETEVERTEXARRAYSAPPLEPROC(uint n, const uint *arrays);
    private delegate void PFNGLGENVERTEXARRAYSAPPLEPROC(uint n, uint *arrays);
    private delegate bool PFNGLISVERTEXARRAYAPPLEPROC(uint array);
    #ifdef GL_GLEXT_PROTOTYPES
    public static void glBindVertexArrayAPPLE(uint array);
    public static void glDeleteVertexArraysAPPLE(uint n, const uint *arrays);
    public static void glGenVertexArraysAPPLE(uint n, uint *arrays);
    public static bool glIsVertexArrayAPPLE(uint array);
    #endif
    #endif /* GL_APPLE_vertex_array_object */

    #ifndef GL_APPLE_vertex_array_range
    #define GL_APPLE_vertex_array_range 1
    public const uint GL_VERTEX_ARRAY_RANGE_APPLE = 0x851D;
    public const uint GL_VERTEX_ARRAY_RANGE_LENGTH_APPLE = 0x851E;
    public const uint GL_VERTEX_ARRAY_STORAGE_HINT_APPLE = 0x851F;
    public const uint GL_VERTEX_ARRAY_RANGE_POINTER_APPLE = 0x8521;
    public const uint GL_STORAGE_CLIENT_APPLE = 0x85B4;
    private delegate void PFNGLVERTEXARRAYRANGEAPPLEPROC(uint length, void *pointer);
    private delegate void PFNGLFLUSHVERTEXARRAYRANGEAPPLEPROC(uint length, void *pointer);
    private delegate void PFNGLVERTEXARRAYPARAMETERIAPPLEPROC(uint pname, int param);
    #ifdef GL_GLEXT_PROTOTYPES
    public static void glVertexArrayRangeAPPLE(uint length, void *pointer);
    public static void glFlushVertexArrayRangeAPPLE(uint length, void *pointer);
    public static void glVertexArrayParameteriAPPLE(uint pname, int param);
    #endif
    #endif /* GL_APPLE_vertex_array_range */

    #ifndef GL_APPLE_vertex_program_evaluators
    #define GL_APPLE_vertex_program_evaluators 1
    public const uint GL_VERTEX_ATTRIB_MAP1_APPLE = 0x8A00;
    public const uint GL_VERTEX_ATTRIB_MAP2_APPLE = 0x8A01;
    public const uint GL_VERTEX_ATTRIB_MAP1_SIZE_APPLE = 0x8A02;
    public const uint GL_VERTEX_ATTRIB_MAP1_COEFF_APPLE = 0x8A03;
    public const uint GL_VERTEX_ATTRIB_MAP1_ORDER_APPLE = 0x8A04;
    public const uint GL_VERTEX_ATTRIB_MAP1_DOMAIN_APPLE = 0x8A05;
    public const uint GL_VERTEX_ATTRIB_MAP2_SIZE_APPLE = 0x8A06;
    public const uint GL_VERTEX_ATTRIB_MAP2_COEFF_APPLE = 0x8A07;
    public const uint GL_VERTEX_ATTRIB_MAP2_ORDER_APPLE = 0x8A08;
    public const uint GL_VERTEX_ATTRIB_MAP2_DOMAIN_APPLE = 0x8A09;
    private delegate void PFNGLENABLEVERTEXATTRIBAPPLEPROC(uint index, uint pname);
    private delegate void PFNGLDISABLEVERTEXATTRIBAPPLEPROC(uint index, uint pname);
    private delegate bool PFNGLISVERTEXATTRIBENABLEDAPPLEPROC(uint index, uint pname);
    private delegate void PFNGLMAPVERTEXATTRIB1DAPPLEPROC(uint index, uint size, double u1, double u2, int stride, int order, const double *points);
    private delegate void PFNGLMAPVERTEXATTRIB1FAPPLEPROC(uint index, uint size, float u1, float u2, int stride, int order, const float *points);
    private delegate void PFNGLMAPVERTEXATTRIB2DAPPLEPROC(uint index, uint size, double u1, double u2, int ustride, int uorder, double v1, double v2, int vstride, int vorder, const double *points);
    private delegate void PFNGLMAPVERTEXATTRIB2FAPPLEPROC(uint index, uint size, float u1, float u2, int ustride, int uorder, float v1, float v2, int vstride, int vorder, const float *points);
    #ifdef GL_GLEXT_PROTOTYPES
    public static void glEnableVertexAttribAPPLE(uint index, uint pname);
    public static void glDisableVertexAttribAPPLE(uint index, uint pname);
    public static bool glIsVertexAttribEnabledAPPLE(uint index, uint pname);
    public static void glMapVertexAttrib1dAPPLE(uint index, uint size, double u1, double u2, int stride, int order, const double *points);
    public static void glMapVertexAttrib1fAPPLE(uint index, uint size, float u1, float u2, int stride, int order, const float *points);
    public static void glMapVertexAttrib2dAPPLE(uint index, uint size, double u1, double u2, int ustride, int uorder, double v1, double v2, int vstride, int vorder, const double *points);
    public static void glMapVertexAttrib2fAPPLE(uint index, uint size, float u1, float u2, int ustride, int uorder, float v1, float v2, int vstride, int vorder, const float *points);
    #endif
    #endif /* GL_APPLE_vertex_program_evaluators */

    #ifndef GL_APPLE_ycbcr_422
    #define GL_APPLE_ycbcr_422 1
    public const uint GL_YCBCR_422_APPLE = 0x85B9;
    #endif /* GL_APPLE_ycbcr_422 */

    #ifndef GL_ATI_draw_buffers
    #define GL_ATI_draw_buffers 1
    public const uint GL_MAX_DRAW_BUFFERS_ATI = 0x8824;
    public const uint GL_DRAW_BUFFER0_ATI = 0x8825;
    public const uint GL_DRAW_BUFFER1_ATI = 0x8826;
    public const uint GL_DRAW_BUFFER2_ATI = 0x8827;
    public const uint GL_DRAW_BUFFER3_ATI = 0x8828;
    public const uint GL_DRAW_BUFFER4_ATI = 0x8829;
    public const uint GL_DRAW_BUFFER5_ATI = 0x882A;
    public const uint GL_DRAW_BUFFER6_ATI = 0x882B;
    public const uint GL_DRAW_BUFFER7_ATI = 0x882C;
    public const uint GL_DRAW_BUFFER8_ATI = 0x882D;
    public const uint GL_DRAW_BUFFER9_ATI = 0x882E;
    public const uint GL_DRAW_BUFFER10_ATI = 0x882F;
    public const uint GL_DRAW_BUFFER11_ATI = 0x8830;
    public const uint GL_DRAW_BUFFER12_ATI = 0x8831;
    public const uint GL_DRAW_BUFFER13_ATI = 0x8832;
    public const uint GL_DRAW_BUFFER14_ATI = 0x8833;
    public const uint GL_DRAW_BUFFER15_ATI = 0x8834;
    private delegate void PFNGLDRAWBUFFERSATIPROC(uint n, const uint *bufs);
    #ifdef GL_GLEXT_PROTOTYPES
    public static void glDrawBuffersATI(uint n, const uint *bufs);
    #endif
    #endif /* GL_ATI_draw_buffers */

    #ifndef GL_ATI_element_array
    #define GL_ATI_element_array 1
    public const uint GL_ELEMENT_ARRAY_ATI = 0x8768;
    public const uint GL_ELEMENT_ARRAY_TYPE_ATI = 0x8769;
    public const uint GL_ELEMENT_ARRAY_POINTER_ATI = 0x876A;
    private delegate void PFNGLELEMENTPOINTERATIPROC(uint type, const void *pointer);
    private delegate void PFNGLDRAWELEMENTARRAYATIPROC(uint mode, uint count);
    private delegate void PFNGLDRAWRANGEELEMENTARRAYATIPROC(uint mode, uint start, uint end, uint count);
    #ifdef GL_GLEXT_PROTOTYPES
    public static void glElementPointerATI(uint type, const void *pointer);
    public static void glDrawElementArrayATI(uint mode, uint count);
    public static void glDrawRangeElementArrayATI(uint mode, uint start, uint end, uint count);
    #endif
    #endif /* GL_ATI_element_array */

    #ifndef GL_ATI_envmap_bumpmap
    #define GL_ATI_envmap_bumpmap 1
    public const uint GL_BUMP_ROT_MATRIX_ATI = 0x8775;
    public const uint GL_BUMP_ROT_MATRIX_SIZE_ATI = 0x8776;
    public const uint GL_BUMP_NUM_TEX_UNITS_ATI = 0x8777;
    public const uint GL_BUMP_TEX_UNITS_ATI = 0x8778;
    public const uint GL_DUDV_ATI = 0x8779;
    public const uint GL_DU8DV8_ATI = 0x877A;
    public const uint GL_BUMP_ENVMAP_ATI = 0x877B;
    public const uint GL_BUMP_TARGET_ATI = 0x877C;
    private delegate void PFNGLTEXBUMPPARAMETERIVATIPROC(uint pname, const int *param);
    private delegate void PFNGLTEXBUMPPARAMETERFVATIPROC(uint pname, const float *param);
    private delegate void PFNGLGETTEXBUMPPARAMETERIVATIPROC(uint pname, int *param);
    private delegate void PFNGLGETTEXBUMPPARAMETERFVATIPROC(uint pname, float *param);
    #ifdef GL_GLEXT_PROTOTYPES
    public static void glTexBumpParameterivATI(uint pname, const int *param);
    public static void glTexBumpParameterfvATI(uint pname, const float *param);
    public static void glGetTexBumpParameterivATI(uint pname, int *param);
    public static void glGetTexBumpParameterfvATI(uint pname, float *param);
    #endif
    #endif /* GL_ATI_envmap_bumpmap */

    #ifndef GL_ATI_fragment_shader
    #define GL_ATI_fragment_shader 1
    public const uint GL_FRAGMENT_SHADER_ATI = 0x8920;
    public const uint GL_REG_0_ATI = 0x8921;
    public const uint GL_REG_1_ATI = 0x8922;
    public const uint GL_REG_2_ATI = 0x8923;
    public const uint GL_REG_3_ATI = 0x8924;
    public const uint GL_REG_4_ATI = 0x8925;
    public const uint GL_REG_5_ATI = 0x8926;
    public const uint GL_REG_6_ATI = 0x8927;
    public const uint GL_REG_7_ATI = 0x8928;
    public const uint GL_REG_8_ATI = 0x8929;
    public const uint GL_REG_9_ATI = 0x892A;
    public const uint GL_REG_10_ATI = 0x892B;
    public const uint GL_REG_11_ATI = 0x892C;
    public const uint GL_REG_12_ATI = 0x892D;
    public const uint GL_REG_13_ATI = 0x892E;
    public const uint GL_REG_14_ATI = 0x892F;
    public const uint GL_REG_15_ATI = 0x8930;
    public const uint GL_REG_16_ATI = 0x8931;
    public const uint GL_REG_17_ATI = 0x8932;
    public const uint GL_REG_18_ATI = 0x8933;
    public const uint GL_REG_19_ATI = 0x8934;
    public const uint GL_REG_20_ATI = 0x8935;
    public const uint GL_REG_21_ATI = 0x8936;
    public const uint GL_REG_22_ATI = 0x8937;
    public const uint GL_REG_23_ATI = 0x8938;
    public const uint GL_REG_24_ATI = 0x8939;
    public const uint GL_REG_25_ATI = 0x893A;
    public const uint GL_REG_26_ATI = 0x893B;
    public const uint GL_REG_27_ATI = 0x893C;
    public const uint GL_REG_28_ATI = 0x893D;
    public const uint GL_REG_29_ATI = 0x893E;
    public const uint GL_REG_30_ATI = 0x893F;
    public const uint GL_REG_31_ATI = 0x8940;
    public const uint GL_CON_0_ATI = 0x8941;
    public const uint GL_CON_1_ATI = 0x8942;
    public const uint GL_CON_2_ATI = 0x8943;
    public const uint GL_CON_3_ATI = 0x8944;
    public const uint GL_CON_4_ATI = 0x8945;
    public const uint GL_CON_5_ATI = 0x8946;
    public const uint GL_CON_6_ATI = 0x8947;
    public const uint GL_CON_7_ATI = 0x8948;
    public const uint GL_CON_8_ATI = 0x8949;
    public const uint GL_CON_9_ATI = 0x894A;
    public const uint GL_CON_10_ATI = 0x894B;
    public const uint GL_CON_11_ATI = 0x894C;
    public const uint GL_CON_12_ATI = 0x894D;
    public const uint GL_CON_13_ATI = 0x894E;
    public const uint GL_CON_14_ATI = 0x894F;
    public const uint GL_CON_15_ATI = 0x8950;
    public const uint GL_CON_16_ATI = 0x8951;
    public const uint GL_CON_17_ATI = 0x8952;
    public const uint GL_CON_18_ATI = 0x8953;
    public const uint GL_CON_19_ATI = 0x8954;
    public const uint GL_CON_20_ATI = 0x8955;
    public const uint GL_CON_21_ATI = 0x8956;
    public const uint GL_CON_22_ATI = 0x8957;
    public const uint GL_CON_23_ATI = 0x8958;
    public const uint GL_CON_24_ATI = 0x8959;
    public const uint GL_CON_25_ATI = 0x895A;
    public const uint GL_CON_26_ATI = 0x895B;
    public const uint GL_CON_27_ATI = 0x895C;
    public const uint GL_CON_28_ATI = 0x895D;
    public const uint GL_CON_29_ATI = 0x895E;
    public const uint GL_CON_30_ATI = 0x895F;
    public const uint GL_CON_31_ATI = 0x8960;
    public const uint GL_MOV_ATI = 0x8961;
    public const uint GL_ADD_ATI = 0x8963;
    public const uint GL_MUL_ATI = 0x8964;
    public const uint GL_SUB_ATI = 0x8965;
    public const uint GL_DOT3_ATI = 0x8966;
    public const uint GL_DOT4_ATI = 0x8967;
    public const uint GL_MAD_ATI = 0x8968;
    public const uint GL_LERP_ATI = 0x8969;
    public const uint GL_CND_ATI = 0x896A;
    public const uint GL_CND0_ATI = 0x896B;
    public const uint GL_DOT2_ADD_ATI = 0x896C;
    public const uint GL_SECONDARY_INTERPOLATOR_ATI = 0x896D;
    public const uint GL_NUM_FRAGMENT_REGISTERS_ATI = 0x896E;
    public const uint GL_NUM_FRAGMENT_CONSTANTS_ATI = 0x896F;
    public const uint GL_NUM_PASSES_ATI = 0x8970;
    public const uint GL_NUM_INSTRUCTIONS_PER_PASS_ATI = 0x8971;
    public const uint GL_NUM_INSTRUCTIONS_TOTAL_ATI = 0x8972;
    public const uint GL_NUM_INPUT_INTERPOLATOR_COMPONENTS_ATI = 0x8973;
    public const uint GL_NUM_LOOPBACK_COMPONENTS_ATI = 0x8974;
    public const uint GL_COLOR_ALPHA_PAIRING_ATI = 0x8975;
    public const uint GL_SWIZZLE_STR_ATI = 0x8976;
    public const uint GL_SWIZZLE_STQ_ATI = 0x8977;
    public const uint GL_SWIZZLE_STR_DR_ATI = 0x8978;
    public const uint GL_SWIZZLE_STQ_DQ_ATI = 0x8979;
    public const uint GL_SWIZZLE_STRQ_ATI = 0x897A;
    public const uint GL_SWIZZLE_STRQ_DQ_ATI = 0x897B;
    public const uint GL_RED_BIT_ATI = 0x00000001;
    public const uint GL_GREEN_BIT_ATI = 0x00000002;
    public const uint GL_BLUE_BIT_ATI = 0x00000004;
    public const uint GL_2X_BIT_ATI = 0x00000001;
    public const uint GL_4X_BIT_ATI = 0x00000002;
    public const uint GL_8X_BIT_ATI = 0x00000004;
    public const uint GL_HALF_BIT_ATI = 0x00000008;
    public const uint GL_QUARTER_BIT_ATI = 0x00000010;
    public const uint GL_EIGHTH_BIT_ATI = 0x00000020;
    public const uint GL_SATURATE_BIT_ATI = 0x00000040;
    public const uint GL_COMP_BIT_ATI = 0x00000002;
    public const uint GL_NEGATE_BIT_ATI = 0x00000004;
    public const uint GL_BIAS_BIT_ATI = 0x00000008;
    private delegate uint PFNGLGENFRAGMENTSHADERSATIPROC(uint range);
    private delegate void PFNGLBINDFRAGMENTSHADERATIPROC(uint id);
    private delegate void PFNGLDELETEFRAGMENTSHADERATIPROC(uint id);
    private delegate void PFNGLBEGINFRAGMENTSHADERATIPROC(void);
    private delegate void PFNGLENDFRAGMENTSHADERATIPROC(void);
    private delegate void PFNGLPASSTEXCOORDATIPROC(uint dst, uint coord, uint swizzle);
    private delegate void PFNGLSAMPLEMAPATIPROC(uint dst, uint interp, uint swizzle);
    private delegate void PFNGLCOLORFRAGMENTOP1ATIPROC(uint op, uint dst, uint dstMask, uint dstMod, uint arg1, uint arg1Rep, uint arg1Mod);
    private delegate void PFNGLCOLORFRAGMENTOP2ATIPROC(uint op, uint dst, uint dstMask, uint dstMod, uint arg1, uint arg1Rep, uint arg1Mod, uint arg2, uint arg2Rep, uint arg2Mod);
    private delegate void PFNGLCOLORFRAGMENTOP3ATIPROC(uint op, uint dst, uint dstMask, uint dstMod, uint arg1, uint arg1Rep, uint arg1Mod, uint arg2, uint arg2Rep, uint arg2Mod, uint arg3, uint arg3Rep, uint arg3Mod);
    private delegate void PFNGLALPHAFRAGMENTOP1ATIPROC(uint op, uint dst, uint dstMod, uint arg1, uint arg1Rep, uint arg1Mod);
    private delegate void PFNGLALPHAFRAGMENTOP2ATIPROC(uint op, uint dst, uint dstMod, uint arg1, uint arg1Rep, uint arg1Mod, uint arg2, uint arg2Rep, uint arg2Mod);
    private delegate void PFNGLALPHAFRAGMENTOP3ATIPROC(uint op, uint dst, uint dstMod, uint arg1, uint arg1Rep, uint arg1Mod, uint arg2, uint arg2Rep, uint arg2Mod, uint arg3, uint arg3Rep, uint arg3Mod);
    private delegate void PFNGLSETFRAGMENTSHADERCONSTANTATIPROC(uint dst, const float *value);
    #ifdef GL_GLEXT_PROTOTYPES
    public static uint glGenFragmentShadersATI(uint range);
    public static void glBindFragmentShaderATI(uint id);
    public static void glDeleteFragmentShaderATI(uint id);
    public static void glBeginFragmentShaderATI(void);
    public static void glEndFragmentShaderATI(void);
    public static void glPassTexCoordATI(uint dst, uint coord, uint swizzle);
    public static void glSampleMapATI(uint dst, uint interp, uint swizzle);
    public static void glColorFragmentOp1ATI(uint op, uint dst, uint dstMask, uint dstMod, uint arg1, uint arg1Rep, uint arg1Mod);
    public static void glColorFragmentOp2ATI(uint op, uint dst, uint dstMask, uint dstMod, uint arg1, uint arg1Rep, uint arg1Mod, uint arg2, uint arg2Rep, uint arg2Mod);
    public static void glColorFragmentOp3ATI(uint op, uint dst, uint dstMask, uint dstMod, uint arg1, uint arg1Rep, uint arg1Mod, uint arg2, uint arg2Rep, uint arg2Mod, uint arg3, uint arg3Rep, uint arg3Mod);
    public static void glAlphaFragmentOp1ATI(uint op, uint dst, uint dstMod, uint arg1, uint arg1Rep, uint arg1Mod);
    public static void glAlphaFragmentOp2ATI(uint op, uint dst, uint dstMod, uint arg1, uint arg1Rep, uint arg1Mod, uint arg2, uint arg2Rep, uint arg2Mod);
    public static void glAlphaFragmentOp3ATI(uint op, uint dst, uint dstMod, uint arg1, uint arg1Rep, uint arg1Mod, uint arg2, uint arg2Rep, uint arg2Mod, uint arg3, uint arg3Rep, uint arg3Mod);
    public static void glSetFragmentShaderConstantATI(uint dst, const float *value);
    #endif
    #endif /* GL_ATI_fragment_shader */

    #ifndef GL_ATI_map_object_buffer
    #define GL_ATI_map_object_buffer 1
    private delegate void* PFNGLMAPOBJECTBUFFERATIPROC(uint buffer);
    private delegate void PFNGLUNMAPOBJECTBUFFERATIPROC(uint buffer);
    #ifdef GL_GLEXT_PROTOTYPES
    public static void* glMapObjectBufferATI(uint buffer);
    public static void glUnmapObjectBufferATI(uint buffer);
    #endif
    #endif /* GL_ATI_map_object_buffer */

    #ifndef GL_ATI_meminfo
    #define GL_ATI_meminfo 1
    public const uint GL_VBO_FREE_MEMORY_ATI = 0x87FB;
    public const uint GL_TEXTURE_FREE_MEMORY_ATI = 0x87FC;
    public const uint GL_RENDERBUFFER_FREE_MEMORY_ATI = 0x87FD;
    #endif /* GL_ATI_meminfo */

    #ifndef GL_ATI_pixel_format_float
    #define GL_ATI_pixel_format_float 1
    public const uint GL_RGBA_FLOAT_MODE_ATI = 0x8820;
    public const uint GL_COLOR_CLEAR_UNCLAMPED_VALUE_ATI = 0x8835;
    #endif /* GL_ATI_pixel_format_float */

    #ifndef GL_ATI_pn_triangles
    #define GL_ATI_pn_triangles 1
    public const uint GL_PN_TRIANGLES_ATI = 0x87F0;
    public const uint GL_MAX_PN_TRIANGLES_TESSELATION_LEVEL_ATI = 0x87F1;
    public const uint GL_PN_TRIANGLES_POINT_MODE_ATI = 0x87F2;
    public const uint GL_PN_TRIANGLES_NORMAL_MODE_ATI = 0x87F3;
    public const uint GL_PN_TRIANGLES_TESSELATION_LEVEL_ATI = 0x87F4;
    public const uint GL_PN_TRIANGLES_POINT_MODE_LINEAR_ATI = 0x87F5;
    public const uint GL_PN_TRIANGLES_POINT_MODE_CUBIC_ATI = 0x87F6;
    public const uint GL_PN_TRIANGLES_NORMAL_MODE_LINEAR_ATI = 0x87F7;
    public const uint GL_PN_TRIANGLES_NORMAL_MODE_QUADRATIC_ATI = 0x87F8;
    private delegate void PFNGLPNTRIANGLESIATIPROC(uint pname, int param);
    private delegate void PFNGLPNTRIANGLESFATIPROC(uint pname, float param);
    #ifdef GL_GLEXT_PROTOTYPES
    public static void glPNTrianglesiATI(uint pname, int param);
    public static void glPNTrianglesfATI(uint pname, float param);
    #endif
    #endif /* GL_ATI_pn_triangles */

    #ifndef GL_ATI_separate_stencil
    #define GL_ATI_separate_stencil 1
    public const uint GL_STENCIL_BACK_FUNC_ATI = 0x8800;
    public const uint GL_STENCIL_BACK_FAIL_ATI = 0x8801;
    public const uint GL_STENCIL_BACK_PASS_DEPTH_FAIL_ATI = 0x8802;
    public const uint GL_STENCIL_BACK_PASS_DEPTH_PASS_ATI = 0x8803;
    private delegate void PFNGLSTENCILOPSEPARATEATIPROC(uint face, uint sfail, uint dpfail, uint dppass);
    private delegate void PFNGLSTENCILFUNCSEPARATEATIPROC(uint frontfunc, uint backfunc, int ref, uint mask);
    #ifdef GL_GLEXT_PROTOTYPES
    public static void glStencilOpSeparateATI(uint face, uint sfail, uint dpfail, uint dppass);
    public static void glStencilFuncSeparateATI(uint frontfunc, uint backfunc, int ref, uint mask);
    #endif
    #endif /* GL_ATI_separate_stencil */

    #ifndef GL_ATI_text_fragment_shader
    #define GL_ATI_text_fragment_shader 1
    public const uint GL_TEXT_FRAGMENT_SHADER_ATI = 0x8200;
    #endif /* GL_ATI_text_fragment_shader */

    #ifndef GL_ATI_texture_env_combine3
    #define GL_ATI_texture_env_combine3 1
    public const uint GL_MODULATE_ADD_ATI = 0x8744;
    public const uint GL_MODULATE_SIGNED_ADD_ATI = 0x8745;
    public const uint GL_MODULATE_SUBTRACT_ATI = 0x8746;
    #endif /* GL_ATI_texture_env_combine3 */

    #ifndef GL_ATI_texture_float
    #define GL_ATI_texture_float 1
    public const uint GL_RGBA_FLOAT32_ATI = 0x8814;
    public const uint GL_RGB_FLOAT32_ATI = 0x8815;
    public const uint GL_ALPHA_FLOAT32_ATI = 0x8816;
    public const uint GL_INTENSITY_FLOAT32_ATI = 0x8817;
    public const uint GL_LUMINANCE_FLOAT32_ATI = 0x8818;
    public const uint GL_LUMINANCE_ALPHA_FLOAT32_ATI = 0x8819;
    public const uint GL_RGBA_FLOAT16_ATI = 0x881A;
    public const uint GL_RGB_FLOAT16_ATI = 0x881B;
    public const uint GL_ALPHA_FLOAT16_ATI = 0x881C;
    public const uint GL_INTENSITY_FLOAT16_ATI = 0x881D;
    public const uint GL_LUMINANCE_FLOAT16_ATI = 0x881E;
    public const uint GL_LUMINANCE_ALPHA_FLOAT16_ATI = 0x881F;
    #endif /* GL_ATI_texture_float */

    #ifndef GL_ATI_texture_mirror_once
    #define GL_ATI_texture_mirror_once 1
    public const uint GL_MIRROR_CLAMP_ATI = 0x8742;
    public const uint GL_MIRROR_CLAMP_TO_EDGE_ATI = 0x8743;
    #endif /* GL_ATI_texture_mirror_once */

    #ifndef GL_ATI_vertex_array_object
    #define GL_ATI_vertex_array_object 1
    public const uint GL_STATIC_ATI = 0x8760;
    public const uint GL_DYNAMIC_ATI = 0x8761;
    public const uint GL_PRESERVE_ATI = 0x8762;
    public const uint GL_DISCARD_ATI = 0x8763;
    public const uint GL_OBJECT_BUFFER_SIZE_ATI = 0x8764;
    public const uint GL_OBJECT_BUFFER_USAGE_ATI = 0x8765;
    public const uint GL_ARRAY_OBJECT_BUFFER_ATI = 0x8766;
    public const uint GL_ARRAY_OBJECT_OFFSET_ATI = 0x8767;
    private delegate uint PFNGLNEWOBJECTBUFFERATIPROC(uint size, const void *pointer, uint usage);
    private delegate bool PFNGLISOBJECTBUFFERATIPROC(uint buffer);
    private delegate void PFNGLUPDATEOBJECTBUFFERATIPROC(uint buffer, uint offset, uint size, const void *pointer, uint preserve);
    private delegate void PFNGLGETOBJECTBUFFERFVATIPROC(uint buffer, uint pname, float *params);
    private delegate void PFNGLGETOBJECTBUFFERIVATIPROC(uint buffer, uint pname, int *params);
    private delegate void PFNGLFREEOBJECTBUFFERATIPROC(uint buffer);
    private delegate void PFNGLARRAYOBJECTATIPROC(uint array, int size, uint type, uint stride, uint buffer, uint offset);
    private delegate void PFNGLGETARRAYOBJECTFVATIPROC(uint array, uint pname, float *params);
    private delegate void PFNGLGETARRAYOBJECTIVATIPROC(uint array, uint pname, int *params);
    private delegate void PFNGLVARIANTARRAYOBJECTATIPROC(uint id, uint type, uint stride, uint buffer, uint offset);
    private delegate void PFNGLGETVARIANTARRAYOBJECTFVATIPROC(uint id, uint pname, float *params);
    private delegate void PFNGLGETVARIANTARRAYOBJECTIVATIPROC(uint id, uint pname, int *params);
    #ifdef GL_GLEXT_PROTOTYPES
    public static uint glNewObjectBufferATI(uint size, const void *pointer, uint usage);
    public static bool glIsObjectBufferATI(uint buffer);
    public static void glUpdateObjectBufferATI(uint buffer, uint offset, uint size, const void *pointer, uint preserve);
    public static void glGetObjectBufferfvATI(uint buffer, uint pname, float *params);
    public static void glGetObjectBufferivATI(uint buffer, uint pname, int *params);
    public static void glFreeObjectBufferATI(uint buffer);
    public static void glArrayObjectATI(uint array, int size, uint type, uint stride, uint buffer, uint offset);
    public static void glGetArrayObjectfvATI(uint array, uint pname, float *params);
    public static void glGetArrayObjectivATI(uint array, uint pname, int *params);
    public static void glVariantArrayObjectATI(uint id, uint type, uint stride, uint buffer, uint offset);
    public static void glGetVariantArrayObjectfvATI(uint id, uint pname, float *params);
    public static void glGetVariantArrayObjectivATI(uint id, uint pname, int *params);
    #endif
    #endif /* GL_ATI_vertex_array_object */

    #ifndef GL_ATI_vertex_attrib_array_object
    #define GL_ATI_vertex_attrib_array_object 1
    private delegate void PFNGLVERTEXATTRIBARRAYOBJECTATIPROC(uint index, int size, uint type, bool normalized, uint stride, uint buffer, uint offset);
    private delegate void PFNGLGETVERTEXATTRIBARRAYOBJECTFVATIPROC(uint index, uint pname, float *params);
    private delegate void PFNGLGETVERTEXATTRIBARRAYOBJECTIVATIPROC(uint index, uint pname, int *params);
    #ifdef GL_GLEXT_PROTOTYPES
    public static void glVertexAttribArrayObjectATI(uint index, int size, uint type, bool normalized, uint stride, uint buffer, uint offset);
    public static void glGetVertexAttribArrayObjectfvATI(uint index, uint pname, float *params);
    public static void glGetVertexAttribArrayObjectivATI(uint index, uint pname, int *params);
    #endif
    #endif /* GL_ATI_vertex_attrib_array_object */

    #ifndef GL_ATI_vertex_streams
    #define GL_ATI_vertex_streams 1
    public const uint GL_MAX_VERTEX_STREAMS_ATI = 0x876B;
    public const uint GL_VERTEX_STREAM0_ATI = 0x876C;
    public const uint GL_VERTEX_STREAM1_ATI = 0x876D;
    public const uint GL_VERTEX_STREAM2_ATI = 0x876E;
    public const uint GL_VERTEX_STREAM3_ATI = 0x876F;
    public const uint GL_VERTEX_STREAM4_ATI = 0x8770;
    public const uint GL_VERTEX_STREAM5_ATI = 0x8771;
    public const uint GL_VERTEX_STREAM6_ATI = 0x8772;
    public const uint GL_VERTEX_STREAM7_ATI = 0x8773;
    public const uint GL_VERTEX_SOURCE_ATI = 0x8774;
    private delegate void PFNGLVERTEXSTREAM1SATIPROC(uint stream, short x);
    private delegate void PFNGLVERTEXSTREAM1SVATIPROC(uint stream, const short *coords);
    private delegate void PFNGLVERTEXSTREAM1IATIPROC(uint stream, int x);
    private delegate void PFNGLVERTEXSTREAM1IVATIPROC(uint stream, const int *coords);
    private delegate void PFNGLVERTEXSTREAM1FATIPROC(uint stream, float x);
    private delegate void PFNGLVERTEXSTREAM1FVATIPROC(uint stream, const float *coords);
    private delegate void PFNGLVERTEXSTREAM1DATIPROC(uint stream, double x);
    private delegate void PFNGLVERTEXSTREAM1DVATIPROC(uint stream, const double *coords);
    private delegate void PFNGLVERTEXSTREAM2SATIPROC(uint stream, short x, short y);
    private delegate void PFNGLVERTEXSTREAM2SVATIPROC(uint stream, const short *coords);
    private delegate void PFNGLVERTEXSTREAM2IATIPROC(uint stream, int x, int y);
    private delegate void PFNGLVERTEXSTREAM2IVATIPROC(uint stream, const int *coords);
    private delegate void PFNGLVERTEXSTREAM2FATIPROC(uint stream, float x, float y);
    private delegate void PFNGLVERTEXSTREAM2FVATIPROC(uint stream, const float *coords);
    private delegate void PFNGLVERTEXSTREAM2DATIPROC(uint stream, double x, double y);
    private delegate void PFNGLVERTEXSTREAM2DVATIPROC(uint stream, const double *coords);
    private delegate void PFNGLVERTEXSTREAM3SATIPROC(uint stream, short x, short y, short z);
    private delegate void PFNGLVERTEXSTREAM3SVATIPROC(uint stream, const short *coords);
    private delegate void PFNGLVERTEXSTREAM3IATIPROC(uint stream, int x, int y, int z);
    private delegate void PFNGLVERTEXSTREAM3IVATIPROC(uint stream, const int *coords);
    private delegate void PFNGLVERTEXSTREAM3FATIPROC(uint stream, float x, float y, float z);
    private delegate void PFNGLVERTEXSTREAM3FVATIPROC(uint stream, const float *coords);
    private delegate void PFNGLVERTEXSTREAM3DATIPROC(uint stream, double x, double y, double z);
    private delegate void PFNGLVERTEXSTREAM3DVATIPROC(uint stream, const double *coords);
    private delegate void PFNGLVERTEXSTREAM4SATIPROC(uint stream, short x, short y, short z, short w);
    private delegate void PFNGLVERTEXSTREAM4SVATIPROC(uint stream, const short *coords);
    private delegate void PFNGLVERTEXSTREAM4IATIPROC(uint stream, int x, int y, int z, int w);
    private delegate void PFNGLVERTEXSTREAM4IVATIPROC(uint stream, const int *coords);
    private delegate void PFNGLVERTEXSTREAM4FATIPROC(uint stream, float x, float y, float z, float w);
    private delegate void PFNGLVERTEXSTREAM4FVATIPROC(uint stream, const float *coords);
    private delegate void PFNGLVERTEXSTREAM4DATIPROC(uint stream, double x, double y, double z, double w);
    private delegate void PFNGLVERTEXSTREAM4DVATIPROC(uint stream, const double *coords);
    private delegate void PFNGLNORMALSTREAM3BATIPROC(uint stream, sbyte nx, sbyte ny, sbyte nz);
    private delegate void PFNGLNORMALSTREAM3BVATIPROC(uint stream, const sbyte *coords);
    private delegate void PFNGLNORMALSTREAM3SATIPROC(uint stream, short nx, short ny, short nz);
    private delegate void PFNGLNORMALSTREAM3SVATIPROC(uint stream, const short *coords);
    private delegate void PFNGLNORMALSTREAM3IATIPROC(uint stream, int nx, int ny, int nz);
    private delegate void PFNGLNORMALSTREAM3IVATIPROC(uint stream, const int *coords);
    private delegate void PFNGLNORMALSTREAM3FATIPROC(uint stream, float nx, float ny, float nz);
    private delegate void PFNGLNORMALSTREAM3FVATIPROC(uint stream, const float *coords);
    private delegate void PFNGLNORMALSTREAM3DATIPROC(uint stream, double nx, double ny, double nz);
    private delegate void PFNGLNORMALSTREAM3DVATIPROC(uint stream, const double *coords);
    private delegate void PFNGLCLIENTACTIVEVERTEXSTREAMATIPROC(uint stream);
    private delegate void PFNGLVERTEXBLENDENVIATIPROC(uint pname, int param);
    private delegate void PFNGLVERTEXBLENDENVFATIPROC(uint pname, float param);
    #ifdef GL_GLEXT_PROTOTYPES
    public static void glVertexStream1sATI(uint stream, short x);
    public static void glVertexStream1svATI(uint stream, const short *coords);
    public static void glVertexStream1iATI(uint stream, int x);
    public static void glVertexStream1ivATI(uint stream, const int *coords);
    public static void glVertexStream1fATI(uint stream, float x);
    public static void glVertexStream1fvATI(uint stream, const float *coords);
    public static void glVertexStream1dATI(uint stream, double x);
    public static void glVertexStream1dvATI(uint stream, const double *coords);
    public static void glVertexStream2sATI(uint stream, short x, short y);
    public static void glVertexStream2svATI(uint stream, const short *coords);
    public static void glVertexStream2iATI(uint stream, int x, int y);
    public static void glVertexStream2ivATI(uint stream, const int *coords);
    public static void glVertexStream2fATI(uint stream, float x, float y);
    public static void glVertexStream2fvATI(uint stream, const float *coords);
    public static void glVertexStream2dATI(uint stream, double x, double y);
    public static void glVertexStream2dvATI(uint stream, const double *coords);
    public static void glVertexStream3sATI(uint stream, short x, short y, short z);
    public static void glVertexStream3svATI(uint stream, const short *coords);
    public static void glVertexStream3iATI(uint stream, int x, int y, int z);
    public static void glVertexStream3ivATI(uint stream, const int *coords);
    public static void glVertexStream3fATI(uint stream, float x, float y, float z);
    public static void glVertexStream3fvATI(uint stream, const float *coords);
    public static void glVertexStream3dATI(uint stream, double x, double y, double z);
    public static void glVertexStream3dvATI(uint stream, const double *coords);
    public static void glVertexStream4sATI(uint stream, short x, short y, short z, short w);
    public static void glVertexStream4svATI(uint stream, const short *coords);
    public static void glVertexStream4iATI(uint stream, int x, int y, int z, int w);
    public static void glVertexStream4ivATI(uint stream, const int *coords);
    public static void glVertexStream4fATI(uint stream, float x, float y, float z, float w);
    public static void glVertexStream4fvATI(uint stream, const float *coords);
    public static void glVertexStream4dATI(uint stream, double x, double y, double z, double w);
    public static void glVertexStream4dvATI(uint stream, const double *coords);
    public static void glNormalStream3bATI(uint stream, sbyte nx, sbyte ny, sbyte nz);
    public static void glNormalStream3bvATI(uint stream, const sbyte *coords);
    public static void glNormalStream3sATI(uint stream, short nx, short ny, short nz);
    public static void glNormalStream3svATI(uint stream, const short *coords);
    public static void glNormalStream3iATI(uint stream, int nx, int ny, int nz);
    public static void glNormalStream3ivATI(uint stream, const int *coords);
    public static void glNormalStream3fATI(uint stream, float nx, float ny, float nz);
    public static void glNormalStream3fvATI(uint stream, const float *coords);
    public static void glNormalStream3dATI(uint stream, double nx, double ny, double nz);
    public static void glNormalStream3dvATI(uint stream, const double *coords);
    public static void glClientActiveVertexStreamATI(uint stream);
    public static void glVertexBlendEnviATI(uint pname, int param);
    public static void glVertexBlendEnvfATI(uint pname, float param);
    #endif
    #endif /* GL_ATI_vertex_streams */

    #ifndef GL_EXT_422_pixels
    #define GL_EXT_422_pixels 1
    public const uint GL_422_EXT = 0x80CC;
    public const uint GL_422_REV_EXT = 0x80CD;
    public const uint GL_422_AVERAGE_EXT = 0x80CE;
    public const uint GL_422_REV_AVERAGE_EXT = 0x80CF;
    #endif /* GL_EXT_422_pixels */

    #ifndef GL_EXT_abgr
    #define GL_EXT_abgr 1
    public const uint GL_ABGR_EXT = 0x8000;
    #endif /* GL_EXT_abgr */

    #ifndef GL_EXT_bgra
    #define GL_EXT_bgra 1
    public const uint GL_BGR_EXT = 0x80E0;
    public const uint GL_BGRA_EXT = 0x80E1;
    #endif /* GL_EXT_bgra */

    #ifndef GL_EXT_bindable_uniform
    #define GL_EXT_bindable_uniform 1
    public const uint GL_MAX_VERTEX_BINDABLE_UNIFORMS_EXT = 0x8DE2;
    public const uint GL_MAX_FRAGMENT_BINDABLE_UNIFORMS_EXT = 0x8DE3;
    public const uint GL_MAX_GEOMETRY_BINDABLE_UNIFORMS_EXT = 0x8DE4;
    public const uint GL_MAX_BINDABLE_UNIFORM_SIZE_EXT = 0x8DED;
    public const uint GL_UNIFORM_BUFFER_EXT = 0x8DEE;
    public const uint GL_UNIFORM_BUFFER_BINDING_EXT = 0x8DEF;
    private delegate void PFNGLUNIFORMBUFFEREXTPROC(uint program, int location, uint buffer);
    private delegate int PFNGLGETUNIFORMBUFFERSIZEEXTPROC(uint program, int location);
    private delegate intptr PFNGLGETUNIFORMOFFSETEXTPROC(uint program, int location);
    #ifdef GL_GLEXT_PROTOTYPES
    public static void glUniformBufferEXT(uint program, int location, uint buffer);
    public static int glGetUniformBufferSizeEXT(uint program, int location);
    public static intptr glGetUniformOffsetEXT(uint program, int location);
    #endif
    #endif /* GL_EXT_bindable_uniform */

    #ifndef GL_EXT_blend_color
    #define GL_EXT_blend_color 1
    public const uint GL_CONSTANT_COLOR_EXT = 0x8001;
    public const uint GL_ONE_MINUS_CONSTANT_COLOR_EXT = 0x8002;
    public const uint GL_CONSTANT_ALPHA_EXT = 0x8003;
    public const uint GL_ONE_MINUS_CONSTANT_ALPHA_EXT = 0x8004;
    public const uint GL_BLEND_COLOR_EXT = 0x8005;
    private delegate void PFNGLBLENDCOLOREXTPROC(float red, float green, float blue, float alpha);
    #ifdef GL_GLEXT_PROTOTYPES
    public static void glBlendColorEXT(float red, float green, float blue, float alpha);
    #endif
    #endif /* GL_EXT_blend_color */

    #ifndef GL_EXT_blend_equation_separate
    #define GL_EXT_blend_equation_separate 1
    public const uint GL_BLEND_EQUATION_RGB_EXT = 0x8009;
    public const uint GL_BLEND_EQUATION_ALPHA_EXT = 0x883D;
    private delegate void PFNGLBLENDEQUATIONSEPARATEEXTPROC(uint modeRGB, uint modeAlpha);
    #ifdef GL_GLEXT_PROTOTYPES
    public static void glBlendEquationSeparateEXT(uint modeRGB, uint modeAlpha);
    #endif
    #endif /* GL_EXT_blend_equation_separate */

    #ifndef GL_EXT_blend_func_separate
    #define GL_EXT_blend_func_separate 1
    public const uint GL_BLEND_DST_RGB_EXT = 0x80C8;
    public const uint GL_BLEND_SRC_RGB_EXT = 0x80C9;
    public const uint GL_BLEND_DST_ALPHA_EXT = 0x80CA;
    public const uint GL_BLEND_SRC_ALPHA_EXT = 0x80CB;
    private delegate void PFNGLBLENDFUNCSEPARATEEXTPROC(uint sfactorRGB, uint dfactorRGB, uint sfactorAlpha, uint dfactorAlpha);
    #ifdef GL_GLEXT_PROTOTYPES
    public static void glBlendFuncSeparateEXT(uint sfactorRGB, uint dfactorRGB, uint sfactorAlpha, uint dfactorAlpha);
    #endif
    #endif /* GL_EXT_blend_func_separate */

    #ifndef GL_EXT_blend_logic_op
    #define GL_EXT_blend_logic_op 1
    #endif /* GL_EXT_blend_logic_op */

    #ifndef GL_EXT_blend_minmax
    #define GL_EXT_blend_minmax 1
    public const uint GL_MIN_EXT = 0x8007;
    public const uint GL_MAX_EXT = 0x8008;
    public const uint GL_FUNC_ADD_EXT = 0x8006;
    public const uint GL_BLEND_EQUATION_EXT = 0x8009;
    private delegate void PFNGLBLENDEQUATIONEXTPROC(uint mode);
    #ifdef GL_GLEXT_PROTOTYPES
    public static void glBlendEquationEXT(uint mode);
    #endif
    #endif /* GL_EXT_blend_minmax */

    #ifndef GL_EXT_blend_subtract
    #define GL_EXT_blend_subtract 1
    public const uint GL_FUNC_SUBTRACT_EXT = 0x800A;
    public const uint GL_FUNC_REVERSE_SUBTRACT_EXT = 0x800B;
    #endif /* GL_EXT_blend_subtract */

    #ifndef GL_EXT_clip_volume_hint
    #define GL_EXT_clip_volume_hint 1
    public const uint GL_CLIP_VOLUME_CLIPPING_HINT_EXT = 0x80F0;
    #endif /* GL_EXT_clip_volume_hint */

    #ifndef GL_EXT_cmyka
    #define GL_EXT_cmyka 1
    public const uint GL_CMYK_EXT = 0x800C;
    public const uint GL_CMYKA_EXT = 0x800D;
    public const uint GL_PACK_CMYK_HINT_EXT = 0x800E;
    public const uint GL_UNPACK_CMYK_HINT_EXT = 0x800F;
    #endif /* GL_EXT_cmyka */

    #ifndef GL_EXT_color_subtable
    #define GL_EXT_color_subtable 1
    private delegate void PFNGLCOLORSUBTABLEEXTPROC(uint target, uint start, uint count, uint format, uint type, const void *data);
    private delegate void PFNGLCOPYCOLORSUBTABLEEXTPROC(uint target, uint start, int x, int y, uint width);
    #ifdef GL_GLEXT_PROTOTYPES
    public static void glColorSubTableEXT(uint target, uint start, uint count, uint format, uint type, const void *data);
    public static void glCopyColorSubTableEXT(uint target, uint start, int x, int y, uint width);
    #endif
    #endif /* GL_EXT_color_subtable */

    #ifndef GL_EXT_compiled_vertex_array
    #define GL_EXT_compiled_vertex_array 1
    public const uint GL_ARRAY_ELEMENT_LOCK_FIRST_EXT = 0x81A8;
    public const uint GL_ARRAY_ELEMENT_LOCK_COUNT_EXT = 0x81A9;
    private delegate void PFNGLLOCKARRAYSEXTPROC(int first, uint count);
    private delegate void PFNGLUNLOCKARRAYSEXTPROC(void);
    #ifdef GL_GLEXT_PROTOTYPES
    public static void glLockArraysEXT(int first, uint count);
    public static void glUnlockArraysEXT(void);
    #endif
    #endif /* GL_EXT_compiled_vertex_array */

    #ifndef GL_EXT_convolution
    #define GL_EXT_convolution 1
    public const uint GL_CONVOLUTION_1D_EXT = 0x8010;
    public const uint GL_CONVOLUTION_2D_EXT = 0x8011;
    public const uint GL_SEPARABLE_2D_EXT = 0x8012;
    public const uint GL_CONVOLUTION_BORDER_MODE_EXT = 0x8013;
    public const uint GL_CONVOLUTION_FILTER_SCALE_EXT = 0x8014;
    public const uint GL_CONVOLUTION_FILTER_BIAS_EXT = 0x8015;
    public const uint GL_REDUCE_EXT = 0x8016;
    public const uint GL_CONVOLUTION_FORMAT_EXT = 0x8017;
    public const uint GL_CONVOLUTION_WIDTH_EXT = 0x8018;
    public const uint GL_CONVOLUTION_HEIGHT_EXT = 0x8019;
    public const uint GL_MAX_CONVOLUTION_WIDTH_EXT = 0x801A;
    public const uint GL_MAX_CONVOLUTION_HEIGHT_EXT = 0x801B;
    public const uint GL_POST_CONVOLUTION_RED_SCALE_EXT = 0x801C;
    public const uint GL_POST_CONVOLUTION_GREEN_SCALE_EXT = 0x801D;
    public const uint GL_POST_CONVOLUTION_BLUE_SCALE_EXT = 0x801E;
    public const uint GL_POST_CONVOLUTION_ALPHA_SCALE_EXT = 0x801F;
    public const uint GL_POST_CONVOLUTION_RED_BIAS_EXT = 0x8020;
    public const uint GL_POST_CONVOLUTION_GREEN_BIAS_EXT = 0x8021;
    public const uint GL_POST_CONVOLUTION_BLUE_BIAS_EXT = 0x8022;
    public const uint GL_POST_CONVOLUTION_ALPHA_BIAS_EXT = 0x8023;
    private delegate void PFNGLCONVOLUTIONFILTER1DEXTPROC(uint target, uint internalformat, uint width, uint format, uint type, const void *image);
    private delegate void PFNGLCONVOLUTIONFILTER2DEXTPROC(uint target, uint internalformat, uint width, uint height, uint format, uint type, const void *image);
    private delegate void PFNGLCONVOLUTIONPARAMETERFEXTPROC(uint target, uint pname, float params);
    private delegate void PFNGLCONVOLUTIONPARAMETERFVEXTPROC(uint target, uint pname, const float *params);
    private delegate void PFNGLCONVOLUTIONPARAMETERIEXTPROC(uint target, uint pname, int params);
    private delegate void PFNGLCONVOLUTIONPARAMETERIVEXTPROC(uint target, uint pname, const int *params);
    private delegate void PFNGLCOPYCONVOLUTIONFILTER1DEXTPROC(uint target, uint internalformat, int x, int y, uint width);
    private delegate void PFNGLCOPYCONVOLUTIONFILTER2DEXTPROC(uint target, uint internalformat, int x, int y, uint width, uint height);
    private delegate void PFNGLGETCONVOLUTIONFILTEREXTPROC(uint target, uint format, uint type, void *image);
    private delegate void PFNGLGETCONVOLUTIONPARAMETERFVEXTPROC(uint target, uint pname, float *params);
    private delegate void PFNGLGETCONVOLUTIONPARAMETERIVEXTPROC(uint target, uint pname, int *params);
    private delegate void PFNGLGETSEPARABLEFILTEREXTPROC(uint target, uint format, uint type, void *row, void *column, void *span);
    private delegate void PFNGLSEPARABLEFILTER2DEXTPROC(uint target, uint internalformat, uint width, uint height, uint format, uint type, const void *row, const void *column);
    #ifdef GL_GLEXT_PROTOTYPES
    public static void glConvolutionFilter1DEXT(uint target, uint internalformat, uint width, uint format, uint type, const void *image);
    public static void glConvolutionFilter2DEXT(uint target, uint internalformat, uint width, uint height, uint format, uint type, const void *image);
    public static void glConvolutionParameterfEXT(uint target, uint pname, float params);
    public static void glConvolutionParameterfvEXT(uint target, uint pname, const float *params);
    public static void glConvolutionParameteriEXT(uint target, uint pname, int params);
    public static void glConvolutionParameterivEXT(uint target, uint pname, const int *params);
    public static void glCopyConvolutionFilter1DEXT(uint target, uint internalformat, int x, int y, uint width);
    public static void glCopyConvolutionFilter2DEXT(uint target, uint internalformat, int x, int y, uint width, uint height);
    public static void glGetConvolutionFilterEXT(uint target, uint format, uint type, void *image);
    public static void glGetConvolutionParameterfvEXT(uint target, uint pname, float *params);
    public static void glGetConvolutionParameterivEXT(uint target, uint pname, int *params);
    public static void glGetSeparableFilterEXT(uint target, uint format, uint type, void *row, void *column, void *span);
    public static void glSeparableFilter2DEXT(uint target, uint internalformat, uint width, uint height, uint format, uint type, const void *row, const void *column);
    #endif
    #endif /* GL_EXT_convolution */

    #ifndef GL_EXT_coordinate_frame
    #define GL_EXT_coordinate_frame 1
    public const uint GL_TANGENT_ARRAY_EXT = 0x8439;
    public const uint GL_BINORMAL_ARRAY_EXT = 0x843A;
    public const uint GL_CURRENT_TANGENT_EXT = 0x843B;
    public const uint GL_CURRENT_BINORMAL_EXT = 0x843C;
    public const uint GL_TANGENT_ARRAY_TYPE_EXT = 0x843E;
    public const uint GL_TANGENT_ARRAY_STRIDE_EXT = 0x843F;
    public const uint GL_BINORMAL_ARRAY_TYPE_EXT = 0x8440;
    public const uint GL_BINORMAL_ARRAY_STRIDE_EXT = 0x8441;
    public const uint GL_TANGENT_ARRAY_POINTER_EXT = 0x8442;
    public const uint GL_BINORMAL_ARRAY_POINTER_EXT = 0x8443;
    public const uint GL_MAP1_TANGENT_EXT = 0x8444;
    public const uint GL_MAP2_TANGENT_EXT = 0x8445;
    public const uint GL_MAP1_BINORMAL_EXT = 0x8446;
    public const uint GL_MAP2_BINORMAL_EXT = 0x8447;
    private delegate void PFNGLTANGENT3BEXTPROC(sbyte tx, sbyte ty, sbyte tz);
    private delegate void PFNGLTANGENT3BVEXTPROC(const sbyte *v);
    private delegate void PFNGLTANGENT3DEXTPROC(double tx, double ty, double tz);
    private delegate void PFNGLTANGENT3DVEXTPROC(const double *v);
    private delegate void PFNGLTANGENT3FEXTPROC(float tx, float ty, float tz);
    private delegate void PFNGLTANGENT3FVEXTPROC(const float *v);
    private delegate void PFNGLTANGENT3IEXTPROC(int tx, int ty, int tz);
    private delegate void PFNGLTANGENT3IVEXTPROC(const int *v);
    private delegate void PFNGLTANGENT3SEXTPROC(short tx, short ty, short tz);
    private delegate void PFNGLTANGENT3SVEXTPROC(const short *v);
    private delegate void PFNGLBINORMAL3BEXTPROC(sbyte bx, sbyte by, sbyte bz);
    private delegate void PFNGLBINORMAL3BVEXTPROC(const sbyte *v);
    private delegate void PFNGLBINORMAL3DEXTPROC(double bx, double by, double bz);
    private delegate void PFNGLBINORMAL3DVEXTPROC(const double *v);
    private delegate void PFNGLBINORMAL3FEXTPROC(float bx, float by, float bz);
    private delegate void PFNGLBINORMAL3FVEXTPROC(const float *v);
    private delegate void PFNGLBINORMAL3IEXTPROC(int bx, int by, int bz);
    private delegate void PFNGLBINORMAL3IVEXTPROC(const int *v);
    private delegate void PFNGLBINORMAL3SEXTPROC(short bx, short by, short bz);
    private delegate void PFNGLBINORMAL3SVEXTPROC(const short *v);
    private delegate void PFNGLTANGENTPOINTEREXTPROC(uint type, uint stride, const void *pointer);
    private delegate void PFNGLBINORMALPOINTEREXTPROC(uint type, uint stride, const void *pointer);
    #ifdef GL_GLEXT_PROTOTYPES
    public static void glTangent3bEXT(sbyte tx, sbyte ty, sbyte tz);
    public static void glTangent3bvEXT(const sbyte *v);
    public static void glTangent3dEXT(double tx, double ty, double tz);
    public static void glTangent3dvEXT(const double *v);
    public static void glTangent3fEXT(float tx, float ty, float tz);
    public static void glTangent3fvEXT(const float *v);
    public static void glTangent3iEXT(int tx, int ty, int tz);
    public static void glTangent3ivEXT(const int *v);
    public static void glTangent3sEXT(short tx, short ty, short tz);
    public static void glTangent3svEXT(const short *v);
    public static void glBinormal3bEXT(sbyte bx, sbyte by, sbyte bz);
    public static void glBinormal3bvEXT(const sbyte *v);
    public static void glBinormal3dEXT(double bx, double by, double bz);
    public static void glBinormal3dvEXT(const double *v);
    public static void glBinormal3fEXT(float bx, float by, float bz);
    public static void glBinormal3fvEXT(const float *v);
    public static void glBinormal3iEXT(int bx, int by, int bz);
    public static void glBinormal3ivEXT(const int *v);
    public static void glBinormal3sEXT(short bx, short by, short bz);
    public static void glBinormal3svEXT(const short *v);
    public static void glTangentPointerEXT(uint type, uint stride, const void *pointer);
    public static void glBinormalPointerEXT(uint type, uint stride, const void *pointer);
    #endif
    #endif /* GL_EXT_coordinate_frame */

    #ifndef GL_EXT_copy_texture
    #define GL_EXT_copy_texture 1
    private delegate void PFNGLCOPYTEXIMAGE1DEXTPROC(uint target, int level, uint internalformat, int x, int y, uint width, int border);
    private delegate void PFNGLCOPYTEXIMAGE2DEXTPROC(uint target, int level, uint internalformat, int x, int y, uint width, uint height, int border);
    private delegate void PFNGLCOPYTEXSUBIMAGE1DEXTPROC(uint target, int level, int xoffset, int x, int y, uint width);
    private delegate void PFNGLCOPYTEXSUBIMAGE2DEXTPROC(uint target, int level, int xoffset, int yoffset, int x, int y, uint width, uint height);
    private delegate void PFNGLCOPYTEXSUBIMAGE3DEXTPROC(uint target, int level, int xoffset, int yoffset, int zoffset, int x, int y, uint width, uint height);
    #ifdef GL_GLEXT_PROTOTYPES
    public static void glCopyTexImage1DEXT(uint target, int level, uint internalformat, int x, int y, uint width, int border);
    public static void glCopyTexImage2DEXT(uint target, int level, uint internalformat, int x, int y, uint width, uint height, int border);
    public static void glCopyTexSubImage1DEXT(uint target, int level, int xoffset, int x, int y, uint width);
    public static void glCopyTexSubImage2DEXT(uint target, int level, int xoffset, int yoffset, int x, int y, uint width, uint height);
    public static void glCopyTexSubImage3DEXT(uint target, int level, int xoffset, int yoffset, int zoffset, int x, int y, uint width, uint height);
    #endif
    #endif /* GL_EXT_copy_texture */

    #ifndef GL_EXT_cull_vertex
    #define GL_EXT_cull_vertex 1
    public const uint GL_CULL_VERTEX_EXT = 0x81AA;
    public const uint GL_CULL_VERTEX_EYE_POSITION_EXT = 0x81AB;
    public const uint GL_CULL_VERTEX_OBJECT_POSITION_EXT = 0x81AC;
    private delegate void PFNGLCULLPARAMETERDVEXTPROC(uint pname, double *params);
    private delegate void PFNGLCULLPARAMETERFVEXTPROC(uint pname, float *params);
    #ifdef GL_GLEXT_PROTOTYPES
    public static void glCullParameterdvEXT(uint pname, double *params);
    public static void glCullParameterfvEXT(uint pname, float *params);
    #endif
    #endif /* GL_EXT_cull_vertex */

    #ifndef GL_EXT_depth_bounds_test
    #define GL_EXT_depth_bounds_test 1
    public const uint GL_DEPTH_BOUNDS_TEST_EXT = 0x8890;
    public const uint GL_DEPTH_BOUNDS_EXT = 0x8891;
    private delegate void PFNGLDEPTHBOUNDSEXTPROC(double zmin, double zmax);
    #ifdef GL_GLEXT_PROTOTYPES
    public static void glDepthBoundsEXT(double zmin, double zmax);
    #endif
    #endif /* GL_EXT_depth_bounds_test */

    #ifndef GL_EXT_direct_state_access
    #define GL_EXT_direct_state_access 1
    public const uint GL_PROGRAM_MATRIX_EXT = 0x8E2D;
    public const uint GL_TRANSPOSE_PROGRAM_MATRIX_EXT = 0x8E2E;
    public const uint GL_PROGRAM_MATRIX_STACK_DEPTH_EXT = 0x8E2F;
    private delegate void PFNGLMATRIXLOADFEXTPROC(uint mode, const float *m);
    private delegate void PFNGLMATRIXLOADDEXTPROC(uint mode, const double *m);
    private delegate void PFNGLMATRIXMULTFEXTPROC(uint mode, const float *m);
    private delegate void PFNGLMATRIXMULTDEXTPROC(uint mode, const double *m);
    private delegate void PFNGLMATRIXLOADIDENTITYEXTPROC(uint mode);
    private delegate void PFNGLMATRIXROTATEFEXTPROC(uint mode, float angle, float x, float y, float z);
    private delegate void PFNGLMATRIXROTATEDEXTPROC(uint mode, double angle, double x, double y, double z);
    private delegate void PFNGLMATRIXSCALEFEXTPROC(uint mode, float x, float y, float z);
    private delegate void PFNGLMATRIXSCALEDEXTPROC(uint mode, double x, double y, double z);
    private delegate void PFNGLMATRIXTRANSLATEFEXTPROC(uint mode, float x, float y, float z);
    private delegate void PFNGLMATRIXTRANSLATEDEXTPROC(uint mode, double x, double y, double z);
    private delegate void PFNGLMATRIXFRUSTUMEXTPROC(uint mode, double left, double right, double bottom, double top, double zNear, double zFar);
    private delegate void PFNGLMATRIXORTHOEXTPROC(uint mode, double left, double right, double bottom, double top, double zNear, double zFar);
    private delegate void PFNGLMATRIXPOPEXTPROC(uint mode);
    private delegate void PFNGLMATRIXPUSHEXTPROC(uint mode);
    private delegate void PFNGLCLIENTATTRIBDEFAULTEXTPROC(uint mask);
    private delegate void PFNGLPUSHCLIENTATTRIBDEFAULTEXTPROC(uint mask);
    private delegate void PFNGLTEXTUREPARAMETERFEXTPROC(uint texture, uint target, uint pname, float param);
    private delegate void PFNGLTEXTUREPARAMETERFVEXTPROC(uint texture, uint target, uint pname, const float *params);
    private delegate void PFNGLTEXTUREPARAMETERIEXTPROC(uint texture, uint target, uint pname, int param);
    private delegate void PFNGLTEXTUREPARAMETERIVEXTPROC(uint texture, uint target, uint pname, const int *params);
    private delegate void PFNGLTEXTUREIMAGE1DEXTPROC(uint texture, uint target, int level, int internalformat, uint width, int border, uint format, uint type, const void *pixels);
    private delegate void PFNGLTEXTUREIMAGE2DEXTPROC(uint texture, uint target, int level, int internalformat, uint width, uint height, int border, uint format, uint type, const void *pixels);
    private delegate void PFNGLTEXTURESUBIMAGE1DEXTPROC(uint texture, uint target, int level, int xoffset, uint width, uint format, uint type, const void *pixels);
    private delegate void PFNGLTEXTURESUBIMAGE2DEXTPROC(uint texture, uint target, int level, int xoffset, int yoffset, uint width, uint height, uint format, uint type, const void *pixels);
    private delegate void PFNGLCOPYTEXTUREIMAGE1DEXTPROC(uint texture, uint target, int level, uint internalformat, int x, int y, uint width, int border);
    private delegate void PFNGLCOPYTEXTUREIMAGE2DEXTPROC(uint texture, uint target, int level, uint internalformat, int x, int y, uint width, uint height, int border);
    private delegate void PFNGLCOPYTEXTURESUBIMAGE1DEXTPROC(uint texture, uint target, int level, int xoffset, int x, int y, uint width);
    private delegate void PFNGLCOPYTEXTURESUBIMAGE2DEXTPROC(uint texture, uint target, int level, int xoffset, int yoffset, int x, int y, uint width, uint height);
    private delegate void PFNGLGETTEXTUREIMAGEEXTPROC(uint texture, uint target, int level, uint format, uint type, void *pixels);
    private delegate void PFNGLGETTEXTUREPARAMETERFVEXTPROC(uint texture, uint target, uint pname, float *params);
    private delegate void PFNGLGETTEXTUREPARAMETERIVEXTPROC(uint texture, uint target, uint pname, int *params);
    private delegate void PFNGLGETTEXTURELEVELPARAMETERFVEXTPROC(uint texture, uint target, int level, uint pname, float *params);
    private delegate void PFNGLGETTEXTURELEVELPARAMETERIVEXTPROC(uint texture, uint target, int level, uint pname, int *params);
    private delegate void PFNGLTEXTUREIMAGE3DEXTPROC(uint texture, uint target, int level, int internalformat, uint width, uint height, uint depth, int border, uint format, uint type, const void *pixels);
    private delegate void PFNGLTEXTURESUBIMAGE3DEXTPROC(uint texture, uint target, int level, int xoffset, int yoffset, int zoffset, uint width, uint height, uint depth, uint format, uint type, const void *pixels);
    private delegate void PFNGLCOPYTEXTURESUBIMAGE3DEXTPROC(uint texture, uint target, int level, int xoffset, int yoffset, int zoffset, int x, int y, uint width, uint height);
    private delegate void PFNGLBINDMULTITEXTUREEXTPROC(uint texunit, uint target, uint texture);
    private delegate void PFNGLMULTITEXCOORDPOINTEREXTPROC(uint texunit, int size, uint type, uint stride, const void *pointer);
    private delegate void PFNGLMULTITEXENVFEXTPROC(uint texunit, uint target, uint pname, float param);
    private delegate void PFNGLMULTITEXENVFVEXTPROC(uint texunit, uint target, uint pname, const float *params);
    private delegate void PFNGLMULTITEXENVIEXTPROC(uint texunit, uint target, uint pname, int param);
    private delegate void PFNGLMULTITEXENVIVEXTPROC(uint texunit, uint target, uint pname, const int *params);
    private delegate void PFNGLMULTITEXGENDEXTPROC(uint texunit, uint coord, uint pname, double param);
    private delegate void PFNGLMULTITEXGENDVEXTPROC(uint texunit, uint coord, uint pname, const double *params);
    private delegate void PFNGLMULTITEXGENFEXTPROC(uint texunit, uint coord, uint pname, float param);
    private delegate void PFNGLMULTITEXGENFVEXTPROC(uint texunit, uint coord, uint pname, const float *params);
    private delegate void PFNGLMULTITEXGENIEXTPROC(uint texunit, uint coord, uint pname, int param);
    private delegate void PFNGLMULTITEXGENIVEXTPROC(uint texunit, uint coord, uint pname, const int *params);
    private delegate void PFNGLGETMULTITEXENVFVEXTPROC(uint texunit, uint target, uint pname, float *params);
    private delegate void PFNGLGETMULTITEXENVIVEXTPROC(uint texunit, uint target, uint pname, int *params);
    private delegate void PFNGLGETMULTITEXGENDVEXTPROC(uint texunit, uint coord, uint pname, double *params);
    private delegate void PFNGLGETMULTITEXGENFVEXTPROC(uint texunit, uint coord, uint pname, float *params);
    private delegate void PFNGLGETMULTITEXGENIVEXTPROC(uint texunit, uint coord, uint pname, int *params);
    private delegate void PFNGLMULTITEXPARAMETERIEXTPROC(uint texunit, uint target, uint pname, int param);
    private delegate void PFNGLMULTITEXPARAMETERIVEXTPROC(uint texunit, uint target, uint pname, const int *params);
    private delegate void PFNGLMULTITEXPARAMETERFEXTPROC(uint texunit, uint target, uint pname, float param);
    private delegate void PFNGLMULTITEXPARAMETERFVEXTPROC(uint texunit, uint target, uint pname, const float *params);
    private delegate void PFNGLMULTITEXIMAGE1DEXTPROC(uint texunit, uint target, int level, int internalformat, uint width, int border, uint format, uint type, const void *pixels);
    private delegate void PFNGLMULTITEXIMAGE2DEXTPROC(uint texunit, uint target, int level, int internalformat, uint width, uint height, int border, uint format, uint type, const void *pixels);
    private delegate void PFNGLMULTITEXSUBIMAGE1DEXTPROC(uint texunit, uint target, int level, int xoffset, uint width, uint format, uint type, const void *pixels);
    private delegate void PFNGLMULTITEXSUBIMAGE2DEXTPROC(uint texunit, uint target, int level, int xoffset, int yoffset, uint width, uint height, uint format, uint type, const void *pixels);
    private delegate void PFNGLCOPYMULTITEXIMAGE1DEXTPROC(uint texunit, uint target, int level, uint internalformat, int x, int y, uint width, int border);
    private delegate void PFNGLCOPYMULTITEXIMAGE2DEXTPROC(uint texunit, uint target, int level, uint internalformat, int x, int y, uint width, uint height, int border);
    private delegate void PFNGLCOPYMULTITEXSUBIMAGE1DEXTPROC(uint texunit, uint target, int level, int xoffset, int x, int y, uint width);
    private delegate void PFNGLCOPYMULTITEXSUBIMAGE2DEXTPROC(uint texunit, uint target, int level, int xoffset, int yoffset, int x, int y, uint width, uint height);
    private delegate void PFNGLGETMULTITEXIMAGEEXTPROC(uint texunit, uint target, int level, uint format, uint type, void *pixels);
    private delegate void PFNGLGETMULTITEXPARAMETERFVEXTPROC(uint texunit, uint target, uint pname, float *params);
    private delegate void PFNGLGETMULTITEXPARAMETERIVEXTPROC(uint texunit, uint target, uint pname, int *params);
    private delegate void PFNGLGETMULTITEXLEVELPARAMETERFVEXTPROC(uint texunit, uint target, int level, uint pname, float *params);
    private delegate void PFNGLGETMULTITEXLEVELPARAMETERIVEXTPROC(uint texunit, uint target, int level, uint pname, int *params);
    private delegate void PFNGLMULTITEXIMAGE3DEXTPROC(uint texunit, uint target, int level, int internalformat, uint width, uint height, uint depth, int border, uint format, uint type, const void *pixels);
    private delegate void PFNGLMULTITEXSUBIMAGE3DEXTPROC(uint texunit, uint target, int level, int xoffset, int yoffset, int zoffset, uint width, uint height, uint depth, uint format, uint type, const void *pixels);
    private delegate void PFNGLCOPYMULTITEXSUBIMAGE3DEXTPROC(uint texunit, uint target, int level, int xoffset, int yoffset, int zoffset, int x, int y, uint width, uint height);
    private delegate void PFNGLENABLECLIENTSTATEINDEXEDEXTPROC(uint array, uint index);
    private delegate void PFNGLDISABLECLIENTSTATEINDEXEDEXTPROC(uint array, uint index);
    private delegate void PFNGLGETFLOATINDEXEDVEXTPROC(uint target, uint index, float *data);
    private delegate void PFNGLGETDOUBLEINDEXEDVEXTPROC(uint target, uint index, double *data);
    private delegate void PFNGLGETPOINTERINDEXEDVEXTPROC(uint target, uint index, void **data);
    private delegate void PFNGLENABLEINDEXEDEXTPROC(uint target, uint index);
    private delegate void PFNGLDISABLEINDEXEDEXTPROC(uint target, uint index);
    private delegate bool PFNGLISENABLEDINDEXEDEXTPROC(uint target, uint index);
    private delegate void PFNGLGETINTEGERINDEXEDVEXTPROC(uint target, uint index, int *data);
    private delegate void PFNGLGETBOOLEANINDEXEDVEXTPROC(uint target, uint index, bool *data);
    private delegate void PFNGLCOMPRESSEDTEXTUREIMAGE3DEXTPROC(uint texture, uint target, int level, uint internalformat, uint width, uint height, uint depth, int border, uint imageSize, const void *bits);
    private delegate void PFNGLCOMPRESSEDTEXTUREIMAGE2DEXTPROC(uint texture, uint target, int level, uint internalformat, uint width, uint height, int border, uint imageSize, const void *bits);
    private delegate void PFNGLCOMPRESSEDTEXTUREIMAGE1DEXTPROC(uint texture, uint target, int level, uint internalformat, uint width, int border, uint imageSize, const void *bits);
    private delegate void PFNGLCOMPRESSEDTEXTURESUBIMAGE3DEXTPROC(uint texture, uint target, int level, int xoffset, int yoffset, int zoffset, uint width, uint height, uint depth, uint format, uint imageSize, const void *bits);
    private delegate void PFNGLCOMPRESSEDTEXTURESUBIMAGE2DEXTPROC(uint texture, uint target, int level, int xoffset, int yoffset, uint width, uint height, uint format, uint imageSize, const void *bits);
    private delegate void PFNGLCOMPRESSEDTEXTURESUBIMAGE1DEXTPROC(uint texture, uint target, int level, int xoffset, uint width, uint format, uint imageSize, const void *bits);
    private delegate void PFNGLGETCOMPRESSEDTEXTUREIMAGEEXTPROC(uint texture, uint target, int lod, void *img);
    private delegate void PFNGLCOMPRESSEDMULTITEXIMAGE3DEXTPROC(uint texunit, uint target, int level, uint internalformat, uint width, uint height, uint depth, int border, uint imageSize, const void *bits);
    private delegate void PFNGLCOMPRESSEDMULTITEXIMAGE2DEXTPROC(uint texunit, uint target, int level, uint internalformat, uint width, uint height, int border, uint imageSize, const void *bits);
    private delegate void PFNGLCOMPRESSEDMULTITEXIMAGE1DEXTPROC(uint texunit, uint target, int level, uint internalformat, uint width, int border, uint imageSize, const void *bits);
    private delegate void PFNGLCOMPRESSEDMULTITEXSUBIMAGE3DEXTPROC(uint texunit, uint target, int level, int xoffset, int yoffset, int zoffset, uint width, uint height, uint depth, uint format, uint imageSize, const void *bits);
    private delegate void PFNGLCOMPRESSEDMULTITEXSUBIMAGE2DEXTPROC(uint texunit, uint target, int level, int xoffset, int yoffset, uint width, uint height, uint format, uint imageSize, const void *bits);
    private delegate void PFNGLCOMPRESSEDMULTITEXSUBIMAGE1DEXTPROC(uint texunit, uint target, int level, int xoffset, uint width, uint format, uint imageSize, const void *bits);
    private delegate void PFNGLGETCOMPRESSEDMULTITEXIMAGEEXTPROC(uint texunit, uint target, int lod, void *img);
    private delegate void PFNGLMATRIXLOADTRANSPOSEFEXTPROC(uint mode, const float *m);
    private delegate void PFNGLMATRIXLOADTRANSPOSEDEXTPROC(uint mode, const double *m);
    private delegate void PFNGLMATRIXMULTTRANSPOSEFEXTPROC(uint mode, const float *m);
    private delegate void PFNGLMATRIXMULTTRANSPOSEDEXTPROC(uint mode, const double *m);
    private delegate void PFNGLNAMEDBUFFERDATAEXTPROC(uint buffer, uintptr size, const void *data, uint usage);
    private delegate void PFNGLNAMEDBUFFERSUBDATAEXTPROC(uint buffer, intptr offset, uintptr size, const void *data);
    private delegate void* PFNGLMAPNAMEDBUFFEREXTPROC(uint buffer, uint access);
    private delegate bool PFNGLUNMAPNAMEDBUFFEREXTPROC(uint buffer);
    private delegate void PFNGLGETNAMEDBUFFERPARAMETERIVEXTPROC(uint buffer, uint pname, int *params);
    private delegate void PFNGLGETNAMEDBUFFERPOINTERVEXTPROC(uint buffer, uint pname, void **params);
    private delegate void PFNGLGETNAMEDBUFFERSUBDATAEXTPROC(uint buffer, intptr offset, uintptr size, void *data);
    private delegate void PFNGLPROGRAMUNIFORM1FEXTPROC(uint program, int location, float v0);
    private delegate void PFNGLPROGRAMUNIFORM2FEXTPROC(uint program, int location, float v0, float v1);
    private delegate void PFNGLPROGRAMUNIFORM3FEXTPROC(uint program, int location, float v0, float v1, float v2);
    private delegate void PFNGLPROGRAMUNIFORM4FEXTPROC(uint program, int location, float v0, float v1, float v2, float v3);
    private delegate void PFNGLPROGRAMUNIFORM1IEXTPROC(uint program, int location, int v0);
    private delegate void PFNGLPROGRAMUNIFORM2IEXTPROC(uint program, int location, int v0, int v1);
    private delegate void PFNGLPROGRAMUNIFORM3IEXTPROC(uint program, int location, int v0, int v1, int v2);
    private delegate void PFNGLPROGRAMUNIFORM4IEXTPROC(uint program, int location, int v0, int v1, int v2, int v3);
    private delegate void PFNGLPROGRAMUNIFORM1FVEXTPROC(uint program, int location, uint count, const float *value);
    private delegate void PFNGLPROGRAMUNIFORM2FVEXTPROC(uint program, int location, uint count, const float *value);
    private delegate void PFNGLPROGRAMUNIFORM3FVEXTPROC(uint program, int location, uint count, const float *value);
    private delegate void PFNGLPROGRAMUNIFORM4FVEXTPROC(uint program, int location, uint count, const float *value);
    private delegate void PFNGLPROGRAMUNIFORM1IVEXTPROC(uint program, int location, uint count, const int *value);
    private delegate void PFNGLPROGRAMUNIFORM2IVEXTPROC(uint program, int location, uint count, const int *value);
    private delegate void PFNGLPROGRAMUNIFORM3IVEXTPROC(uint program, int location, uint count, const int *value);
    private delegate void PFNGLPROGRAMUNIFORM4IVEXTPROC(uint program, int location, uint count, const int *value);
    private delegate void PFNGLPROGRAMUNIFORMMATRIX2FVEXTPROC(uint program, int location, uint count, bool transpose, const float *value);
    private delegate void PFNGLPROGRAMUNIFORMMATRIX3FVEXTPROC(uint program, int location, uint count, bool transpose, const float *value);
    private delegate void PFNGLPROGRAMUNIFORMMATRIX4FVEXTPROC(uint program, int location, uint count, bool transpose, const float *value);
    private delegate void PFNGLPROGRAMUNIFORMMATRIX2X3FVEXTPROC(uint program, int location, uint count, bool transpose, const float *value);
    private delegate void PFNGLPROGRAMUNIFORMMATRIX3X2FVEXTPROC(uint program, int location, uint count, bool transpose, const float *value);
    private delegate void PFNGLPROGRAMUNIFORMMATRIX2X4FVEXTPROC(uint program, int location, uint count, bool transpose, const float *value);
    private delegate void PFNGLPROGRAMUNIFORMMATRIX4X2FVEXTPROC(uint program, int location, uint count, bool transpose, const float *value);
    private delegate void PFNGLPROGRAMUNIFORMMATRIX3X4FVEXTPROC(uint program, int location, uint count, bool transpose, const float *value);
    private delegate void PFNGLPROGRAMUNIFORMMATRIX4X3FVEXTPROC(uint program, int location, uint count, bool transpose, const float *value);
    private delegate void PFNGLTEXTUREBUFFEREXTPROC(uint texture, uint target, uint internalformat, uint buffer);
    private delegate void PFNGLMULTITEXBUFFEREXTPROC(uint texunit, uint target, uint internalformat, uint buffer);
    private delegate void PFNGLTEXTUREPARAMETERIIVEXTPROC(uint texture, uint target, uint pname, const int *params);
    private delegate void PFNGLTEXTUREPARAMETERIUIVEXTPROC(uint texture, uint target, uint pname, const uint *params);
    private delegate void PFNGLGETTEXTUREPARAMETERIIVEXTPROC(uint texture, uint target, uint pname, int *params);
    private delegate void PFNGLGETTEXTUREPARAMETERIUIVEXTPROC(uint texture, uint target, uint pname, uint *params);
    private delegate void PFNGLMULTITEXPARAMETERIIVEXTPROC(uint texunit, uint target, uint pname, const int *params);
    private delegate void PFNGLMULTITEXPARAMETERIUIVEXTPROC(uint texunit, uint target, uint pname, const uint *params);
    private delegate void PFNGLGETMULTITEXPARAMETERIIVEXTPROC(uint texunit, uint target, uint pname, int *params);
    private delegate void PFNGLGETMULTITEXPARAMETERIUIVEXTPROC(uint texunit, uint target, uint pname, uint *params);
    private delegate void PFNGLPROGRAMUNIFORM1UIEXTPROC(uint program, int location, uint v0);
    private delegate void PFNGLPROGRAMUNIFORM2UIEXTPROC(uint program, int location, uint v0, uint v1);
    private delegate void PFNGLPROGRAMUNIFORM3UIEXTPROC(uint program, int location, uint v0, uint v1, uint v2);
    private delegate void PFNGLPROGRAMUNIFORM4UIEXTPROC(uint program, int location, uint v0, uint v1, uint v2, uint v3);
    private delegate void PFNGLPROGRAMUNIFORM1UIVEXTPROC(uint program, int location, uint count, const uint *value);
    private delegate void PFNGLPROGRAMUNIFORM2UIVEXTPROC(uint program, int location, uint count, const uint *value);
    private delegate void PFNGLPROGRAMUNIFORM3UIVEXTPROC(uint program, int location, uint count, const uint *value);
    private delegate void PFNGLPROGRAMUNIFORM4UIVEXTPROC(uint program, int location, uint count, const uint *value);
    private delegate void PFNGLNAMEDPROGRAMLOCALPARAMETERS4FVEXTPROC(uint program, uint target, uint index, uint count, const float *params);
    private delegate void PFNGLNAMEDPROGRAMLOCALPARAMETERI4IEXTPROC(uint program, uint target, uint index, int x, int y, int z, int w);
    private delegate void PFNGLNAMEDPROGRAMLOCALPARAMETERI4IVEXTPROC(uint program, uint target, uint index, const int *params);
    private delegate void PFNGLNAMEDPROGRAMLOCALPARAMETERSI4IVEXTPROC(uint program, uint target, uint index, uint count, const int *params);
    private delegate void PFNGLNAMEDPROGRAMLOCALPARAMETERI4UIEXTPROC(uint program, uint target, uint index, uint x, uint y, uint z, uint w);
    private delegate void PFNGLNAMEDPROGRAMLOCALPARAMETERI4UIVEXTPROC(uint program, uint target, uint index, const uint *params);
    private delegate void PFNGLNAMEDPROGRAMLOCALPARAMETERSI4UIVEXTPROC(uint program, uint target, uint index, uint count, const uint *params);
    private delegate void PFNGLGETNAMEDPROGRAMLOCALPARAMETERIIVEXTPROC(uint program, uint target, uint index, int *params);
    private delegate void PFNGLGETNAMEDPROGRAMLOCALPARAMETERIUIVEXTPROC(uint program, uint target, uint index, uint *params);
    private delegate void PFNGLENABLECLIENTSTATEIEXTPROC(uint array, uint index);
    private delegate void PFNGLDISABLECLIENTSTATEIEXTPROC(uint array, uint index);
    private delegate void PFNGLGETFLOATI_VEXTPROC(uint pname, uint index, float *params);
    private delegate void PFNGLGETDOUBLEI_VEXTPROC(uint pname, uint index, double *params);
    private delegate void PFNGLGETPOINTERI_VEXTPROC(uint pname, uint index, void **params);
    private delegate void PFNGLNAMEDPROGRAMSTRINGEXTPROC(uint program, uint target, uint format, uint len, const void *string);
    private delegate void PFNGLNAMEDPROGRAMLOCALPARAMETER4DEXTPROC(uint program, uint target, uint index, double x, double y, double z, double w);
    private delegate void PFNGLNAMEDPROGRAMLOCALPARAMETER4DVEXTPROC(uint program, uint target, uint index, const double *params);
    private delegate void PFNGLNAMEDPROGRAMLOCALPARAMETER4FEXTPROC(uint program, uint target, uint index, float x, float y, float z, float w);
    private delegate void PFNGLNAMEDPROGRAMLOCALPARAMETER4FVEXTPROC(uint program, uint target, uint index, const float *params);
    private delegate void PFNGLGETNAMEDPROGRAMLOCALPARAMETERDVEXTPROC(uint program, uint target, uint index, double *params);
    private delegate void PFNGLGETNAMEDPROGRAMLOCALPARAMETERFVEXTPROC(uint program, uint target, uint index, float *params);
    private delegate void PFNGLGETNAMEDPROGRAMIVEXTPROC(uint program, uint target, uint pname, int *params);
    private delegate void PFNGLGETNAMEDPROGRAMSTRINGEXTPROC(uint program, uint target, uint pname, void *string);
    private delegate void PFNGLNAMEDRENDERBUFFERSTORAGEEXTPROC(uint renderbuffer, uint internalformat, uint width, uint height);
    private delegate void PFNGLGETNAMEDRENDERBUFFERPARAMETERIVEXTPROC(uint renderbuffer, uint pname, int *params);
    private delegate void PFNGLNAMEDRENDERBUFFERSTORAGEMULTISAMPLEEXTPROC(uint renderbuffer, uint samples, uint internalformat, uint width, uint height);
    private delegate void PFNGLNAMEDRENDERBUFFERSTORAGEMULTISAMPLECOVERAGEEXTPROC(uint renderbuffer, uint coverageSamples, uint colorSamples, uint internalformat, uint width, uint height);
    private delegate uint PFNGLCHECKNAMEDFRAMEBUFFERSTATUSEXTPROC(uint framebuffer, uint target);
    private delegate void PFNGLNAMEDFRAMEBUFFERTEXTURE1DEXTPROC(uint framebuffer, uint attachment, uint textarget, uint texture, int level);
    private delegate void PFNGLNAMEDFRAMEBUFFERTEXTURE2DEXTPROC(uint framebuffer, uint attachment, uint textarget, uint texture, int level);
    private delegate void PFNGLNAMEDFRAMEBUFFERTEXTURE3DEXTPROC(uint framebuffer, uint attachment, uint textarget, uint texture, int level, int zoffset);
    private delegate void PFNGLNAMEDFRAMEBUFFERRENDERBUFFEREXTPROC(uint framebuffer, uint attachment, uint renderbuffertarget, uint renderbuffer);
    private delegate void PFNGLGETNAMEDFRAMEBUFFERATTACHMENTPARAMETERIVEXTPROC(uint framebuffer, uint attachment, uint pname, int *params);
    private delegate void PFNGLGENERATETEXTUREMIPMAPEXTPROC(uint texture, uint target);
    private delegate void PFNGLGENERATEMULTITEXMIPMAPEXTPROC(uint texunit, uint target);
    private delegate void PFNGLFRAMEBUFFERDRAWBUFFEREXTPROC(uint framebuffer, uint mode);
    private delegate void PFNGLFRAMEBUFFERDRAWBUFFERSEXTPROC(uint framebuffer, uint n, const uint *bufs);
    private delegate void PFNGLFRAMEBUFFERREADBUFFEREXTPROC(uint framebuffer, uint mode);
    private delegate void PFNGLGETFRAMEBUFFERPARAMETERIVEXTPROC(uint framebuffer, uint pname, int *params);
    private delegate void PFNGLNAMEDCOPYBUFFERSUBDATAEXTPROC(uint readBuffer, uint writeBuffer, intptr readOffset, intptr writeOffset, uintptr size);
    private delegate void PFNGLNAMEDFRAMEBUFFERTEXTUREEXTPROC(uint framebuffer, uint attachment, uint texture, int level);
    private delegate void PFNGLNAMEDFRAMEBUFFERTEXTURELAYEREXTPROC(uint framebuffer, uint attachment, uint texture, int level, int layer);
    private delegate void PFNGLNAMEDFRAMEBUFFERTEXTUREFACEEXTPROC(uint framebuffer, uint attachment, uint texture, int level, uint face);
    private delegate void PFNGLTEXTURERENDERBUFFEREXTPROC(uint texture, uint target, uint renderbuffer);
    private delegate void PFNGLMULTITEXRENDERBUFFEREXTPROC(uint texunit, uint target, uint renderbuffer);
    private delegate void PFNGLVERTEXARRAYVERTEXOFFSETEXTPROC(uint vaobj, uint buffer, int size, uint type, uint stride, intptr offset);
    private delegate void PFNGLVERTEXARRAYCOLOROFFSETEXTPROC(uint vaobj, uint buffer, int size, uint type, uint stride, intptr offset);
    private delegate void PFNGLVERTEXARRAYEDGEFLAGOFFSETEXTPROC(uint vaobj, uint buffer, uint stride, intptr offset);
    private delegate void PFNGLVERTEXARRAYINDEXOFFSETEXTPROC(uint vaobj, uint buffer, uint type, uint stride, intptr offset);
    private delegate void PFNGLVERTEXARRAYNORMALOFFSETEXTPROC(uint vaobj, uint buffer, uint type, uint stride, intptr offset);
    private delegate void PFNGLVERTEXARRAYTEXCOORDOFFSETEXTPROC(uint vaobj, uint buffer, int size, uint type, uint stride, intptr offset);
    private delegate void PFNGLVERTEXARRAYMULTITEXCOORDOFFSETEXTPROC(uint vaobj, uint buffer, uint texunit, int size, uint type, uint stride, intptr offset);
    private delegate void PFNGLVERTEXARRAYFOGCOORDOFFSETEXTPROC(uint vaobj, uint buffer, uint type, uint stride, intptr offset);
    private delegate void PFNGLVERTEXARRAYSECONDARYCOLOROFFSETEXTPROC(uint vaobj, uint buffer, int size, uint type, uint stride, intptr offset);
    private delegate void PFNGLVERTEXARRAYVERTEXATTRIBOFFSETEXTPROC(uint vaobj, uint buffer, uint index, int size, uint type, bool normalized, uint stride, intptr offset);
    private delegate void PFNGLVERTEXARRAYVERTEXATTRIBIOFFSETEXTPROC(uint vaobj, uint buffer, uint index, int size, uint type, uint stride, intptr offset);
    private delegate void PFNGLENABLEVERTEXARRAYEXTPROC(uint vaobj, uint array);
    private delegate void PFNGLDISABLEVERTEXARRAYEXTPROC(uint vaobj, uint array);
    private delegate void PFNGLENABLEVERTEXARRAYATTRIBEXTPROC(uint vaobj, uint index);
    private delegate void PFNGLDISABLEVERTEXARRAYATTRIBEXTPROC(uint vaobj, uint index);
    private delegate void PFNGLGETVERTEXARRAYINTEGERVEXTPROC(uint vaobj, uint pname, int *param);
    private delegate void PFNGLGETVERTEXARRAYPOINTERVEXTPROC(uint vaobj, uint pname, void **param);
    private delegate void PFNGLGETVERTEXARRAYINTEGERI_VEXTPROC(uint vaobj, uint index, uint pname, int *param);
    private delegate void PFNGLGETVERTEXARRAYPOINTERI_VEXTPROC(uint vaobj, uint index, uint pname, void **param);
    private delegate void* PFNGLMAPNAMEDBUFFERRANGEEXTPROC(uint buffer, intptr offset, uintptr length, uint access);
    private delegate void PFNGLFLUSHMAPPEDNAMEDBUFFERRANGEEXTPROC(uint buffer, intptr offset, uintptr length);
    private delegate void PFNGLNAMEDBUFFERSTORAGEEXTPROC(uint buffer, uintptr size, const void *data, uint flags);
    private delegate void PFNGLCLEARNAMEDBUFFERDATAEXTPROC(uint buffer, uint internalformat, uint format, uint type, const void *data);
    private delegate void PFNGLCLEARNAMEDBUFFERSUBDATAEXTPROC(uint buffer, uint internalformat, uint format, uint type, uintptr offset, uintptr size, const void *data);
    private delegate void PFNGLNAMEDFRAMEBUFFERPARAMETERIEXTPROC(uint framebuffer, uint pname, int param);
    private delegate void PFNGLGETNAMEDFRAMEBUFFERPARAMETERIVEXTPROC(uint framebuffer, uint pname, int *params);
    private delegate void PFNGLPROGRAMUNIFORM1DEXTPROC(uint program, int location, double x);
    private delegate void PFNGLPROGRAMUNIFORM2DEXTPROC(uint program, int location, double x, double y);
    private delegate void PFNGLPROGRAMUNIFORM3DEXTPROC(uint program, int location, double x, double y, double z);
    private delegate void PFNGLPROGRAMUNIFORM4DEXTPROC(uint program, int location, double x, double y, double z, double w);
    private delegate void PFNGLPROGRAMUNIFORM1DVEXTPROC(uint program, int location, uint count, const double *value);
    private delegate void PFNGLPROGRAMUNIFORM2DVEXTPROC(uint program, int location, uint count, const double *value);
    private delegate void PFNGLPROGRAMUNIFORM3DVEXTPROC(uint program, int location, uint count, const double *value);
    private delegate void PFNGLPROGRAMUNIFORM4DVEXTPROC(uint program, int location, uint count, const double *value);
    private delegate void PFNGLPROGRAMUNIFORMMATRIX2DVEXTPROC(uint program, int location, uint count, bool transpose, const double *value);
    private delegate void PFNGLPROGRAMUNIFORMMATRIX3DVEXTPROC(uint program, int location, uint count, bool transpose, const double *value);
    private delegate void PFNGLPROGRAMUNIFORMMATRIX4DVEXTPROC(uint program, int location, uint count, bool transpose, const double *value);
    private delegate void PFNGLPROGRAMUNIFORMMATRIX2X3DVEXTPROC(uint program, int location, uint count, bool transpose, const double *value);
    private delegate void PFNGLPROGRAMUNIFORMMATRIX2X4DVEXTPROC(uint program, int location, uint count, bool transpose, const double *value);
    private delegate void PFNGLPROGRAMUNIFORMMATRIX3X2DVEXTPROC(uint program, int location, uint count, bool transpose, const double *value);
    private delegate void PFNGLPROGRAMUNIFORMMATRIX3X4DVEXTPROC(uint program, int location, uint count, bool transpose, const double *value);
    private delegate void PFNGLPROGRAMUNIFORMMATRIX4X2DVEXTPROC(uint program, int location, uint count, bool transpose, const double *value);
    private delegate void PFNGLPROGRAMUNIFORMMATRIX4X3DVEXTPROC(uint program, int location, uint count, bool transpose, const double *value);
    private delegate void PFNGLTEXTUREBUFFERRANGEEXTPROC(uint texture, uint target, uint internalformat, uint buffer, intptr offset, uintptr size);
    private delegate void PFNGLTEXTURESTORAGE1DEXTPROC(uint texture, uint target, uint levels, uint internalformat, uint width);
    private delegate void PFNGLTEXTURESTORAGE2DEXTPROC(uint texture, uint target, uint levels, uint internalformat, uint width, uint height);
    private delegate void PFNGLTEXTURESTORAGE3DEXTPROC(uint texture, uint target, uint levels, uint internalformat, uint width, uint height, uint depth);
    private delegate void PFNGLTEXTURESTORAGE2DMULTISAMPLEEXTPROC(uint texture, uint target, uint samples, uint internalformat, uint width, uint height, bool fixedsamplelocations);
    private delegate void PFNGLTEXTURESTORAGE3DMULTISAMPLEEXTPROC(uint texture, uint target, uint samples, uint internalformat, uint width, uint height, uint depth, bool fixedsamplelocations);
    private delegate void PFNGLVERTEXARRAYBINDVERTEXBUFFEREXTPROC(uint vaobj, uint bindingindex, uint buffer, intptr offset, uint stride);
    private delegate void PFNGLVERTEXARRAYVERTEXATTRIBFORMATEXTPROC(uint vaobj, uint attribindex, int size, uint type, bool normalized, uint relativeoffset);
    private delegate void PFNGLVERTEXARRAYVERTEXATTRIBIFORMATEXTPROC(uint vaobj, uint attribindex, int size, uint type, uint relativeoffset);
    private delegate void PFNGLVERTEXARRAYVERTEXATTRIBLFORMATEXTPROC(uint vaobj, uint attribindex, int size, uint type, uint relativeoffset);
    private delegate void PFNGLVERTEXARRAYVERTEXATTRIBBINDINGEXTPROC(uint vaobj, uint attribindex, uint bindingindex);
    private delegate void PFNGLVERTEXARRAYVERTEXBINDINGDIVISOREXTPROC(uint vaobj, uint bindingindex, uint divisor);
    private delegate void PFNGLVERTEXARRAYVERTEXATTRIBLOFFSETEXTPROC(uint vaobj, uint buffer, uint index, int size, uint type, uint stride, intptr offset);
    private delegate void PFNGLTEXTUREPAGECOMMITMENTEXTPROC(uint texture, int level, int xoffset, int yoffset, int zoffset, uint width, uint height, uint depth, bool resident);
    private delegate void PFNGLVERTEXARRAYVERTEXATTRIBDIVISOREXTPROC(uint vaobj, uint index, uint divisor);
    #ifdef GL_GLEXT_PROTOTYPES
    public static void glMatrixLoadfEXT(uint mode, const float *m);
    public static void glMatrixLoaddEXT(uint mode, const double *m);
    public static void glMatrixMultfEXT(uint mode, const float *m);
    public static void glMatrixMultdEXT(uint mode, const double *m);
    public static void glMatrixLoadIdentityEXT(uint mode);
    public static void glMatrixRotatefEXT(uint mode, float angle, float x, float y, float z);
    public static void glMatrixRotatedEXT(uint mode, double angle, double x, double y, double z);
    public static void glMatrixScalefEXT(uint mode, float x, float y, float z);
    public static void glMatrixScaledEXT(uint mode, double x, double y, double z);
    public static void glMatrixTranslatefEXT(uint mode, float x, float y, float z);
    public static void glMatrixTranslatedEXT(uint mode, double x, double y, double z);
    public static void glMatrixFrustumEXT(uint mode, double left, double right, double bottom, double top, double zNear, double zFar);
    public static void glMatrixOrthoEXT(uint mode, double left, double right, double bottom, double top, double zNear, double zFar);
    public static void glMatrixPopEXT(uint mode);
    public static void glMatrixPushEXT(uint mode);
    public static void glClientAttribDefaultEXT(uint mask);
    public static void glPushClientAttribDefaultEXT(uint mask);
    public static void glTextureParameterfEXT(uint texture, uint target, uint pname, float param);
    public static void glTextureParameterfvEXT(uint texture, uint target, uint pname, const float *params);
    public static void glTextureParameteriEXT(uint texture, uint target, uint pname, int param);
    public static void glTextureParameterivEXT(uint texture, uint target, uint pname, const int *params);
    public static void glTextureImage1DEXT(uint texture, uint target, int level, int internalformat, uint width, int border, uint format, uint type, const void *pixels);
    public static void glTextureImage2DEXT(uint texture, uint target, int level, int internalformat, uint width, uint height, int border, uint format, uint type, const void *pixels);
    public static void glTextureSubImage1DEXT(uint texture, uint target, int level, int xoffset, uint width, uint format, uint type, const void *pixels);
    public static void glTextureSubImage2DEXT(uint texture, uint target, int level, int xoffset, int yoffset, uint width, uint height, uint format, uint type, const void *pixels);
    public static void glCopyTextureImage1DEXT(uint texture, uint target, int level, uint internalformat, int x, int y, uint width, int border);
    public static void glCopyTextureImage2DEXT(uint texture, uint target, int level, uint internalformat, int x, int y, uint width, uint height, int border);
    public static void glCopyTextureSubImage1DEXT(uint texture, uint target, int level, int xoffset, int x, int y, uint width);
    public static void glCopyTextureSubImage2DEXT(uint texture, uint target, int level, int xoffset, int yoffset, int x, int y, uint width, uint height);
    public static void glGetTextureImageEXT(uint texture, uint target, int level, uint format, uint type, void *pixels);
    public static void glGetTextureParameterfvEXT(uint texture, uint target, uint pname, float *params);
    public static void glGetTextureParameterivEXT(uint texture, uint target, uint pname, int *params);
    public static void glGetTextureLevelParameterfvEXT(uint texture, uint target, int level, uint pname, float *params);
    public static void glGetTextureLevelParameterivEXT(uint texture, uint target, int level, uint pname, int *params);
    public static void glTextureImage3DEXT(uint texture, uint target, int level, int internalformat, uint width, uint height, uint depth, int border, uint format, uint type, const void *pixels);
    public static void glTextureSubImage3DEXT(uint texture, uint target, int level, int xoffset, int yoffset, int zoffset, uint width, uint height, uint depth, uint format, uint type, const void *pixels);
    public static void glCopyTextureSubImage3DEXT(uint texture, uint target, int level, int xoffset, int yoffset, int zoffset, int x, int y, uint width, uint height);
    public static void glBindMultiTextureEXT(uint texunit, uint target, uint texture);
    public static void glMultiTexCoordPointerEXT(uint texunit, int size, uint type, uint stride, const void *pointer);
    public static void glMultiTexEnvfEXT(uint texunit, uint target, uint pname, float param);
    public static void glMultiTexEnvfvEXT(uint texunit, uint target, uint pname, const float *params);
    public static void glMultiTexEnviEXT(uint texunit, uint target, uint pname, int param);
    public static void glMultiTexEnvivEXT(uint texunit, uint target, uint pname, const int *params);
    public static void glMultiTexGendEXT(uint texunit, uint coord, uint pname, double param);
    public static void glMultiTexGendvEXT(uint texunit, uint coord, uint pname, const double *params);
    public static void glMultiTexGenfEXT(uint texunit, uint coord, uint pname, float param);
    public static void glMultiTexGenfvEXT(uint texunit, uint coord, uint pname, const float *params);
    public static void glMultiTexGeniEXT(uint texunit, uint coord, uint pname, int param);
    public static void glMultiTexGenivEXT(uint texunit, uint coord, uint pname, const int *params);
    public static void glGetMultiTexEnvfvEXT(uint texunit, uint target, uint pname, float *params);
    public static void glGetMultiTexEnvivEXT(uint texunit, uint target, uint pname, int *params);
    public static void glGetMultiTexGendvEXT(uint texunit, uint coord, uint pname, double *params);
    public static void glGetMultiTexGenfvEXT(uint texunit, uint coord, uint pname, float *params);
    public static void glGetMultiTexGenivEXT(uint texunit, uint coord, uint pname, int *params);
    public static void glMultiTexParameteriEXT(uint texunit, uint target, uint pname, int param);
    public static void glMultiTexParameterivEXT(uint texunit, uint target, uint pname, const int *params);
    public static void glMultiTexParameterfEXT(uint texunit, uint target, uint pname, float param);
    public static void glMultiTexParameterfvEXT(uint texunit, uint target, uint pname, const float *params);
    public static void glMultiTexImage1DEXT(uint texunit, uint target, int level, int internalformat, uint width, int border, uint format, uint type, const void *pixels);
    public static void glMultiTexImage2DEXT(uint texunit, uint target, int level, int internalformat, uint width, uint height, int border, uint format, uint type, const void *pixels);
    public static void glMultiTexSubImage1DEXT(uint texunit, uint target, int level, int xoffset, uint width, uint format, uint type, const void *pixels);
    public static void glMultiTexSubImage2DEXT(uint texunit, uint target, int level, int xoffset, int yoffset, uint width, uint height, uint format, uint type, const void *pixels);
    public static void glCopyMultiTexImage1DEXT(uint texunit, uint target, int level, uint internalformat, int x, int y, uint width, int border);
    public static void glCopyMultiTexImage2DEXT(uint texunit, uint target, int level, uint internalformat, int x, int y, uint width, uint height, int border);
    public static void glCopyMultiTexSubImage1DEXT(uint texunit, uint target, int level, int xoffset, int x, int y, uint width);
    public static void glCopyMultiTexSubImage2DEXT(uint texunit, uint target, int level, int xoffset, int yoffset, int x, int y, uint width, uint height);
    public static void glGetMultiTexImageEXT(uint texunit, uint target, int level, uint format, uint type, void *pixels);
    public static void glGetMultiTexParameterfvEXT(uint texunit, uint target, uint pname, float *params);
    public static void glGetMultiTexParameterivEXT(uint texunit, uint target, uint pname, int *params);
    public static void glGetMultiTexLevelParameterfvEXT(uint texunit, uint target, int level, uint pname, float *params);
    public static void glGetMultiTexLevelParameterivEXT(uint texunit, uint target, int level, uint pname, int *params);
    public static void glMultiTexImage3DEXT(uint texunit, uint target, int level, int internalformat, uint width, uint height, uint depth, int border, uint format, uint type, const void *pixels);
    public static void glMultiTexSubImage3DEXT(uint texunit, uint target, int level, int xoffset, int yoffset, int zoffset, uint width, uint height, uint depth, uint format, uint type, const void *pixels);
    public static void glCopyMultiTexSubImage3DEXT(uint texunit, uint target, int level, int xoffset, int yoffset, int zoffset, int x, int y, uint width, uint height);
    public static void glEnableClientStateIndexedEXT(uint array, uint index);
    public static void glDisableClientStateIndexedEXT(uint array, uint index);
    public static void glGetFloatIndexedvEXT(uint target, uint index, float *data);
    public static void glGetDoubleIndexedvEXT(uint target, uint index, double *data);
    public static void glGetPointerIndexedvEXT(uint target, uint index, void **data);
    public static void glEnableIndexedEXT(uint target, uint index);
    public static void glDisableIndexedEXT(uint target, uint index);
    public static bool glIsEnabledIndexedEXT(uint target, uint index);
    public static void glGetIntegerIndexedvEXT(uint target, uint index, int *data);
    public static void glGetBooleanIndexedvEXT(uint target, uint index, bool *data);
    public static void glCompressedTextureImage3DEXT(uint texture, uint target, int level, uint internalformat, uint width, uint height, uint depth, int border, uint imageSize, const void *bits);
    public static void glCompressedTextureImage2DEXT(uint texture, uint target, int level, uint internalformat, uint width, uint height, int border, uint imageSize, const void *bits);
    public static void glCompressedTextureImage1DEXT(uint texture, uint target, int level, uint internalformat, uint width, int border, uint imageSize, const void *bits);
    public static void glCompressedTextureSubImage3DEXT(uint texture, uint target, int level, int xoffset, int yoffset, int zoffset, uint width, uint height, uint depth, uint format, uint imageSize, const void *bits);
    public static void glCompressedTextureSubImage2DEXT(uint texture, uint target, int level, int xoffset, int yoffset, uint width, uint height, uint format, uint imageSize, const void *bits);
    public static void glCompressedTextureSubImage1DEXT(uint texture, uint target, int level, int xoffset, uint width, uint format, uint imageSize, const void *bits);
    public static void glGetCompressedTextureImageEXT(uint texture, uint target, int lod, void *img);
    public static void glCompressedMultiTexImage3DEXT(uint texunit, uint target, int level, uint internalformat, uint width, uint height, uint depth, int border, uint imageSize, const void *bits);
    public static void glCompressedMultiTexImage2DEXT(uint texunit, uint target, int level, uint internalformat, uint width, uint height, int border, uint imageSize, const void *bits);
    public static void glCompressedMultiTexImage1DEXT(uint texunit, uint target, int level, uint internalformat, uint width, int border, uint imageSize, const void *bits);
    public static void glCompressedMultiTexSubImage3DEXT(uint texunit, uint target, int level, int xoffset, int yoffset, int zoffset, uint width, uint height, uint depth, uint format, uint imageSize, const void *bits);
    public static void glCompressedMultiTexSubImage2DEXT(uint texunit, uint target, int level, int xoffset, int yoffset, uint width, uint height, uint format, uint imageSize, const void *bits);
    public static void glCompressedMultiTexSubImage1DEXT(uint texunit, uint target, int level, int xoffset, uint width, uint format, uint imageSize, const void *bits);
    public static void glGetCompressedMultiTexImageEXT(uint texunit, uint target, int lod, void *img);
    public static void glMatrixLoadTransposefEXT(uint mode, const float *m);
    public static void glMatrixLoadTransposedEXT(uint mode, const double *m);
    public static void glMatrixMultTransposefEXT(uint mode, const float *m);
    public static void glMatrixMultTransposedEXT(uint mode, const double *m);
    public static void glNamedBufferDataEXT(uint buffer, uintptr size, const void *data, uint usage);
    public static void glNamedBufferSubDataEXT(uint buffer, intptr offset, uintptr size, const void *data);
    public static void* glMapNamedBufferEXT(uint buffer, uint access);
    public static bool glUnmapNamedBufferEXT(uint buffer);
    public static void glGetNamedBufferParameterivEXT(uint buffer, uint pname, int *params);
    public static void glGetNamedBufferPointervEXT(uint buffer, uint pname, void **params);
    public static void glGetNamedBufferSubDataEXT(uint buffer, intptr offset, uintptr size, void *data);
    public static void glProgramUniform1fEXT(uint program, int location, float v0);
    public static void glProgramUniform2fEXT(uint program, int location, float v0, float v1);
    public static void glProgramUniform3fEXT(uint program, int location, float v0, float v1, float v2);
    public static void glProgramUniform4fEXT(uint program, int location, float v0, float v1, float v2, float v3);
    public static void glProgramUniform1iEXT(uint program, int location, int v0);
    public static void glProgramUniform2iEXT(uint program, int location, int v0, int v1);
    public static void glProgramUniform3iEXT(uint program, int location, int v0, int v1, int v2);
    public static void glProgramUniform4iEXT(uint program, int location, int v0, int v1, int v2, int v3);
    public static void glProgramUniform1fvEXT(uint program, int location, uint count, const float *value);
    public static void glProgramUniform2fvEXT(uint program, int location, uint count, const float *value);
    public static void glProgramUniform3fvEXT(uint program, int location, uint count, const float *value);
    public static void glProgramUniform4fvEXT(uint program, int location, uint count, const float *value);
    public static void glProgramUniform1ivEXT(uint program, int location, uint count, const int *value);
    public static void glProgramUniform2ivEXT(uint program, int location, uint count, const int *value);
    public static void glProgramUniform3ivEXT(uint program, int location, uint count, const int *value);
    public static void glProgramUniform4ivEXT(uint program, int location, uint count, const int *value);
    public static void glProgramUniformMatrix2fvEXT(uint program, int location, uint count, bool transpose, const float *value);
    public static void glProgramUniformMatrix3fvEXT(uint program, int location, uint count, bool transpose, const float *value);
    public static void glProgramUniformMatrix4fvEXT(uint program, int location, uint count, bool transpose, const float *value);
    public static void glProgramUniformMatrix2x3fvEXT(uint program, int location, uint count, bool transpose, const float *value);
    public static void glProgramUniformMatrix3x2fvEXT(uint program, int location, uint count, bool transpose, const float *value);
    public static void glProgramUniformMatrix2x4fvEXT(uint program, int location, uint count, bool transpose, const float *value);
    public static void glProgramUniformMatrix4x2fvEXT(uint program, int location, uint count, bool transpose, const float *value);
    public static void glProgramUniformMatrix3x4fvEXT(uint program, int location, uint count, bool transpose, const float *value);
    public static void glProgramUniformMatrix4x3fvEXT(uint program, int location, uint count, bool transpose, const float *value);
    public static void glTextureBufferEXT(uint texture, uint target, uint internalformat, uint buffer);
    public static void glMultiTexBufferEXT(uint texunit, uint target, uint internalformat, uint buffer);
    public static void glTextureParameterIivEXT(uint texture, uint target, uint pname, const int *params);
    public static void glTextureParameterIuivEXT(uint texture, uint target, uint pname, const uint *params);
    public static void glGetTextureParameterIivEXT(uint texture, uint target, uint pname, int *params);
    public static void glGetTextureParameterIuivEXT(uint texture, uint target, uint pname, uint *params);
    public static void glMultiTexParameterIivEXT(uint texunit, uint target, uint pname, const int *params);
    public static void glMultiTexParameterIuivEXT(uint texunit, uint target, uint pname, const uint *params);
    public static void glGetMultiTexParameterIivEXT(uint texunit, uint target, uint pname, int *params);
    public static void glGetMultiTexParameterIuivEXT(uint texunit, uint target, uint pname, uint *params);
    public static void glProgramUniform1uiEXT(uint program, int location, uint v0);
    public static void glProgramUniform2uiEXT(uint program, int location, uint v0, uint v1);
    public static void glProgramUniform3uiEXT(uint program, int location, uint v0, uint v1, uint v2);
    public static void glProgramUniform4uiEXT(uint program, int location, uint v0, uint v1, uint v2, uint v3);
    public static void glProgramUniform1uivEXT(uint program, int location, uint count, const uint *value);
    public static void glProgramUniform2uivEXT(uint program, int location, uint count, const uint *value);
    public static void glProgramUniform3uivEXT(uint program, int location, uint count, const uint *value);
    public static void glProgramUniform4uivEXT(uint program, int location, uint count, const uint *value);
    public static void glNamedProgramLocalParameters4fvEXT(uint program, uint target, uint index, uint count, const float *params);
    public static void glNamedProgramLocalParameterI4iEXT(uint program, uint target, uint index, int x, int y, int z, int w);
    public static void glNamedProgramLocalParameterI4ivEXT(uint program, uint target, uint index, const int *params);
    public static void glNamedProgramLocalParametersI4ivEXT(uint program, uint target, uint index, uint count, const int *params);
    public static void glNamedProgramLocalParameterI4uiEXT(uint program, uint target, uint index, uint x, uint y, uint z, uint w);
    public static void glNamedProgramLocalParameterI4uivEXT(uint program, uint target, uint index, const uint *params);
    public static void glNamedProgramLocalParametersI4uivEXT(uint program, uint target, uint index, uint count, const uint *params);
    public static void glGetNamedProgramLocalParameterIivEXT(uint program, uint target, uint index, int *params);
    public static void glGetNamedProgramLocalParameterIuivEXT(uint program, uint target, uint index, uint *params);
    public static void glEnableClientStateiEXT(uint array, uint index);
    public static void glDisableClientStateiEXT(uint array, uint index);
    public static void glGetFloati_vEXT(uint pname, uint index, float *params);
    public static void glGetDoublei_vEXT(uint pname, uint index, double *params);
    public static void glGetPointeri_vEXT(uint pname, uint index, void **params);
    public static void glNamedProgramStringEXT(uint program, uint target, uint format, uint len, const void *string);
    public static void glNamedProgramLocalParameter4dEXT(uint program, uint target, uint index, double x, double y, double z, double w);
    public static void glNamedProgramLocalParameter4dvEXT(uint program, uint target, uint index, const double *params);
    public static void glNamedProgramLocalParameter4fEXT(uint program, uint target, uint index, float x, float y, float z, float w);
    public static void glNamedProgramLocalParameter4fvEXT(uint program, uint target, uint index, const float *params);
    public static void glGetNamedProgramLocalParameterdvEXT(uint program, uint target, uint index, double *params);
    public static void glGetNamedProgramLocalParameterfvEXT(uint program, uint target, uint index, float *params);
    public static void glGetNamedProgramivEXT(uint program, uint target, uint pname, int *params);
    public static void glGetNamedProgramStringEXT(uint program, uint target, uint pname, void *string);
    public static void glNamedRenderbufferStorageEXT(uint renderbuffer, uint internalformat, uint width, uint height);
    public static void glGetNamedRenderbufferParameterivEXT(uint renderbuffer, uint pname, int *params);
    public static void glNamedRenderbufferStorageMultisampleEXT(uint renderbuffer, uint samples, uint internalformat, uint width, uint height);
    public static void glNamedRenderbufferStorageMultisampleCoverageEXT(uint renderbuffer, uint coverageSamples, uint colorSamples, uint internalformat, uint width, uint height);
    public static uint glCheckNamedFramebufferStatusEXT(uint framebuffer, uint target);
    public static void glNamedFramebufferTexture1DEXT(uint framebuffer, uint attachment, uint textarget, uint texture, int level);
    public static void glNamedFramebufferTexture2DEXT(uint framebuffer, uint attachment, uint textarget, uint texture, int level);
    public static void glNamedFramebufferTexture3DEXT(uint framebuffer, uint attachment, uint textarget, uint texture, int level, int zoffset);
    public static void glNamedFramebufferRenderbufferEXT(uint framebuffer, uint attachment, uint renderbuffertarget, uint renderbuffer);
    public static void glGetNamedFramebufferAttachmentParameterivEXT(uint framebuffer, uint attachment, uint pname, int *params);
    public static void glGenerateTextureMipmapEXT(uint texture, uint target);
    public static void glGenerateMultiTexMipmapEXT(uint texunit, uint target);
    public static void glFramebufferDrawBufferEXT(uint framebuffer, uint mode);
    public static void glFramebufferDrawBuffersEXT(uint framebuffer, uint n, const uint *bufs);
    public static void glFramebufferReadBufferEXT(uint framebuffer, uint mode);
    public static void glGetFramebufferParameterivEXT(uint framebuffer, uint pname, int *params);
    public static void glNamedCopyBufferSubDataEXT(uint readBuffer, uint writeBuffer, intptr readOffset, intptr writeOffset, uintptr size);
    public static void glNamedFramebufferTextureEXT(uint framebuffer, uint attachment, uint texture, int level);
    public static void glNamedFramebufferTextureLayerEXT(uint framebuffer, uint attachment, uint texture, int level, int layer);
    public static void glNamedFramebufferTextureFaceEXT(uint framebuffer, uint attachment, uint texture, int level, uint face);
    public static void glTextureRenderbufferEXT(uint texture, uint target, uint renderbuffer);
    public static void glMultiTexRenderbufferEXT(uint texunit, uint target, uint renderbuffer);
    public static void glVertexArrayVertexOffsetEXT(uint vaobj, uint buffer, int size, uint type, uint stride, intptr offset);
    public static void glVertexArrayColorOffsetEXT(uint vaobj, uint buffer, int size, uint type, uint stride, intptr offset);
    public static void glVertexArrayEdgeFlagOffsetEXT(uint vaobj, uint buffer, uint stride, intptr offset);
    public static void glVertexArrayIndexOffsetEXT(uint vaobj, uint buffer, uint type, uint stride, intptr offset);
    public static void glVertexArrayNormalOffsetEXT(uint vaobj, uint buffer, uint type, uint stride, intptr offset);
    public static void glVertexArrayTexCoordOffsetEXT(uint vaobj, uint buffer, int size, uint type, uint stride, intptr offset);
    public static void glVertexArrayMultiTexCoordOffsetEXT(uint vaobj, uint buffer, uint texunit, int size, uint type, uint stride, intptr offset);
    public static void glVertexArrayFogCoordOffsetEXT(uint vaobj, uint buffer, uint type, uint stride, intptr offset);
    public static void glVertexArraySecondaryColorOffsetEXT(uint vaobj, uint buffer, int size, uint type, uint stride, intptr offset);
    public static void glVertexArrayVertexAttribOffsetEXT(uint vaobj, uint buffer, uint index, int size, uint type, bool normalized, uint stride, intptr offset);
    public static void glVertexArrayVertexAttribIOffsetEXT(uint vaobj, uint buffer, uint index, int size, uint type, uint stride, intptr offset);
    public static void glEnableVertexArrayEXT(uint vaobj, uint array);
    public static void glDisableVertexArrayEXT(uint vaobj, uint array);
    public static void glEnableVertexArrayAttribEXT(uint vaobj, uint index);
    public static void glDisableVertexArrayAttribEXT(uint vaobj, uint index);
    public static void glGetVertexArrayIntegervEXT(uint vaobj, uint pname, int *param);
    public static void glGetVertexArrayPointervEXT(uint vaobj, uint pname, void **param);
    public static void glGetVertexArrayIntegeri_vEXT(uint vaobj, uint index, uint pname, int *param);
    public static void glGetVertexArrayPointeri_vEXT(uint vaobj, uint index, uint pname, void **param);
    public static void* glMapNamedBufferRangeEXT(uint buffer, intptr offset, uintptr length, uint access);
    public static void glFlushMappedNamedBufferRangeEXT(uint buffer, intptr offset, uintptr length);
    public static void glNamedBufferStorageEXT(uint buffer, uintptr size, const void *data, uint flags);
    public static void glClearNamedBufferDataEXT(uint buffer, uint internalformat, uint format, uint type, const void *data);
    public static void glClearNamedBufferSubDataEXT(uint buffer, uint internalformat, uint format, uint type, uintptr offset, uintptr size, const void *data);
    public static void glNamedFramebufferParameteriEXT(uint framebuffer, uint pname, int param);
    public static void glGetNamedFramebufferParameterivEXT(uint framebuffer, uint pname, int *params);
    public static void glProgramUniform1dEXT(uint program, int location, double x);
    public static void glProgramUniform2dEXT(uint program, int location, double x, double y);
    public static void glProgramUniform3dEXT(uint program, int location, double x, double y, double z);
    public static void glProgramUniform4dEXT(uint program, int location, double x, double y, double z, double w);
    public static void glProgramUniform1dvEXT(uint program, int location, uint count, const double *value);
    public static void glProgramUniform2dvEXT(uint program, int location, uint count, const double *value);
    public static void glProgramUniform3dvEXT(uint program, int location, uint count, const double *value);
    public static void glProgramUniform4dvEXT(uint program, int location, uint count, const double *value);
    public static void glProgramUniformMatrix2dvEXT(uint program, int location, uint count, bool transpose, const double *value);
    public static void glProgramUniformMatrix3dvEXT(uint program, int location, uint count, bool transpose, const double *value);
    public static void glProgramUniformMatrix4dvEXT(uint program, int location, uint count, bool transpose, const double *value);
    public static void glProgramUniformMatrix2x3dvEXT(uint program, int location, uint count, bool transpose, const double *value);
    public static void glProgramUniformMatrix2x4dvEXT(uint program, int location, uint count, bool transpose, const double *value);
    public static void glProgramUniformMatrix3x2dvEXT(uint program, int location, uint count, bool transpose, const double *value);
    public static void glProgramUniformMatrix3x4dvEXT(uint program, int location, uint count, bool transpose, const double *value);
    public static void glProgramUniformMatrix4x2dvEXT(uint program, int location, uint count, bool transpose, const double *value);
    public static void glProgramUniformMatrix4x3dvEXT(uint program, int location, uint count, bool transpose, const double *value);
    public static void glTextureBufferRangeEXT(uint texture, uint target, uint internalformat, uint buffer, intptr offset, uintptr size);
    public static void glTextureStorage1DEXT(uint texture, uint target, uint levels, uint internalformat, uint width);
    public static void glTextureStorage2DEXT(uint texture, uint target, uint levels, uint internalformat, uint width, uint height);
    public static void glTextureStorage3DEXT(uint texture, uint target, uint levels, uint internalformat, uint width, uint height, uint depth);
    public static void glTextureStorage2DMultisampleEXT(uint texture, uint target, uint samples, uint internalformat, uint width, uint height, bool fixedsamplelocations);
    public static void glTextureStorage3DMultisampleEXT(uint texture, uint target, uint samples, uint internalformat, uint width, uint height, uint depth, bool fixedsamplelocations);
    public static void glVertexArrayBindVertexBufferEXT(uint vaobj, uint bindingindex, uint buffer, intptr offset, uint stride);
    public static void glVertexArrayVertexAttribFormatEXT(uint vaobj, uint attribindex, int size, uint type, bool normalized, uint relativeoffset);
    public static void glVertexArrayVertexAttribIFormatEXT(uint vaobj, uint attribindex, int size, uint type, uint relativeoffset);
    public static void glVertexArrayVertexAttribLFormatEXT(uint vaobj, uint attribindex, int size, uint type, uint relativeoffset);
    public static void glVertexArrayVertexAttribBindingEXT(uint vaobj, uint attribindex, uint bindingindex);
    public static void glVertexArrayVertexBindingDivisorEXT(uint vaobj, uint bindingindex, uint divisor);
    public static void glVertexArrayVertexAttribLOffsetEXT(uint vaobj, uint buffer, uint index, int size, uint type, uint stride, intptr offset);
    public static void glTexturePageCommitmentEXT(uint texture, int level, int xoffset, int yoffset, int zoffset, uint width, uint height, uint depth, bool resident);
    public static void glVertexArrayVertexAttribDivisorEXT(uint vaobj, uint index, uint divisor);
    #endif
    #endif /* GL_EXT_direct_state_access */

    #ifndef GL_EXT_draw_buffers2
    #define GL_EXT_draw_buffers2 1
    private delegate void PFNGLCOLORMASKINDEXEDEXTPROC(uint index, bool r, bool g, bool b, bool a);
    #ifdef GL_GLEXT_PROTOTYPES
    public static void glColorMaskIndexedEXT(uint index, bool r, bool g, bool b, bool a);
    #endif
    #endif /* GL_EXT_draw_buffers2 */

    #ifndef GL_EXT_draw_instanced
    #define GL_EXT_draw_instanced 1
    private delegate void PFNGLDRAWARRAYSINSTANCEDEXTPROC(uint mode, int start, uint count, uint primcount);
    private delegate void PFNGLDRAWELEMENTSINSTANCEDEXTPROC(uint mode, uint count, uint type, const void *indices, uint primcount);
    #ifdef GL_GLEXT_PROTOTYPES
    public static void glDrawArraysInstancedEXT(uint mode, int start, uint count, uint primcount);
    public static void glDrawElementsInstancedEXT(uint mode, uint count, uint type, const void *indices, uint primcount);
    #endif
    #endif /* GL_EXT_draw_instanced */

    #ifndef GL_EXT_draw_range_elements
    #define GL_EXT_draw_range_elements 1
    public const uint GL_MAX_ELEMENTS_VERTICES_EXT = 0x80E8;
    public const uint GL_MAX_ELEMENTS_INDICES_EXT = 0x80E9;
    private delegate void PFNGLDRAWRANGEELEMENTSEXTPROC(uint mode, uint start, uint end, uint count, uint type, const void *indices);
    #ifdef GL_GLEXT_PROTOTYPES
    public static void glDrawRangeElementsEXT(uint mode, uint start, uint end, uint count, uint type, const void *indices);
    #endif
    #endif /* GL_EXT_draw_range_elements */

    #ifndef GL_EXT_fog_coord
    #define GL_EXT_fog_coord 1
    public const uint GL_FOG_COORDINATE_SOURCE_EXT = 0x8450;
    public const uint GL_FOG_COORDINATE_EXT = 0x8451;
    public const uint GL_FRAGMENT_DEPTH_EXT = 0x8452;
    public const uint GL_CURRENT_FOG_COORDINATE_EXT = 0x8453;
    public const uint GL_FOG_COORDINATE_ARRAY_TYPE_EXT = 0x8454;
    public const uint GL_FOG_COORDINATE_ARRAY_STRIDE_EXT = 0x8455;
    public const uint GL_FOG_COORDINATE_ARRAY_POINTER_EXT = 0x8456;
    public const uint GL_FOG_COORDINATE_ARRAY_EXT = 0x8457;
    private delegate void PFNGLFOGCOORDFEXTPROC(float coord);
    private delegate void PFNGLFOGCOORDFVEXTPROC(const float *coord);
    private delegate void PFNGLFOGCOORDDEXTPROC(double coord);
    private delegate void PFNGLFOGCOORDDVEXTPROC(const double *coord);
    private delegate void PFNGLFOGCOORDPOINTEREXTPROC(uint type, uint stride, const void *pointer);
    #ifdef GL_GLEXT_PROTOTYPES
    public static void glFogCoordfEXT(float coord);
    public static void glFogCoordfvEXT(const float *coord);
    public static void glFogCoorddEXT(double coord);
    public static void glFogCoorddvEXT(const double *coord);
    public static void glFogCoordPointerEXT(uint type, uint stride, const void *pointer);
    #endif
    #endif /* GL_EXT_fog_coord */

    #ifndef GL_EXT_framebuffer_blit
    #define GL_EXT_framebuffer_blit 1
    public const uint GL_READ_FRAMEBUFFER_EXT = 0x8CA8;
    public const uint GL_DRAW_FRAMEBUFFER_EXT = 0x8CA9;
    public const uint GL_DRAW_FRAMEBUFFER_BINDING_EXT = 0x8CA6;
    public const uint GL_READ_FRAMEBUFFER_BINDING_EXT = 0x8CAA;
    private delegate void PFNGLBLITFRAMEBUFFEREXTPROC(int srcX0, int srcY0, int srcX1, int srcY1, int dstX0, int dstY0, int dstX1, int dstY1, uint mask, uint filter);
    #ifdef GL_GLEXT_PROTOTYPES
    public static void glBlitFramebufferEXT(int srcX0, int srcY0, int srcX1, int srcY1, int dstX0, int dstY0, int dstX1, int dstY1, uint mask, uint filter);
    #endif
    #endif /* GL_EXT_framebuffer_blit */

    #ifndef GL_EXT_framebuffer_multisample
    #define GL_EXT_framebuffer_multisample 1
    public const uint GL_RENDERBUFFER_SAMPLES_EXT = 0x8CAB;
    public const uint GL_FRAMEBUFFER_INCOMPLETE_MULTISAMPLE_EXT = 0x8D56;
    public const uint GL_MAX_SAMPLES_EXT = 0x8D57;
    private delegate void PFNGLRENDERBUFFERSTORAGEMULTISAMPLEEXTPROC(uint target, uint samples, uint internalformat, uint width, uint height);
    #ifdef GL_GLEXT_PROTOTYPES
    public static void glRenderbufferStorageMultisampleEXT(uint target, uint samples, uint internalformat, uint width, uint height);
    #endif
    #endif /* GL_EXT_framebuffer_multisample */

    #ifndef GL_EXT_framebuffer_multisample_blit_scaled
    #define GL_EXT_framebuffer_multisample_blit_scaled 1
    public const uint GL_SCALED_RESOLVE_FASTEST_EXT = 0x90BA;
    public const uint GL_SCALED_RESOLVE_NICEST_EXT = 0x90BB;
    #endif /* GL_EXT_framebuffer_multisample_blit_scaled */

    #ifndef GL_EXT_framebuffer_object
    #define GL_EXT_framebuffer_object 1
    public const uint GL_INVALID_FRAMEBUFFER_OPERATION_EXT = 0x0506;
    public const uint GL_MAX_RENDERBUFFER_SIZE_EXT = 0x84E8;
    public const uint GL_FRAMEBUFFER_BINDING_EXT = 0x8CA6;
    public const uint GL_RENDERBUFFER_BINDING_EXT = 0x8CA7;
    public const uint GL_FRAMEBUFFER_ATTACHMENT_OBJECT_TYPE_EXT = 0x8CD0;
    public const uint GL_FRAMEBUFFER_ATTACHMENT_OBJECT_NAME_EXT = 0x8CD1;
    public const uint GL_FRAMEBUFFER_ATTACHMENT_TEXTURE_LEVEL_EXT = 0x8CD2;
    public const uint GL_FRAMEBUFFER_ATTACHMENT_TEXTURE_CUBE_MAP_FACE_EXT = 0x8CD3;
    public const uint GL_FRAMEBUFFER_ATTACHMENT_TEXTURE_3D_ZOFFSET_EXT = 0x8CD4;
    public const uint GL_FRAMEBUFFER_COMPLETE_EXT = 0x8CD5;
    public const uint GL_FRAMEBUFFER_INCOMPLETE_ATTACHMENT_EXT = 0x8CD6;
    public const uint GL_FRAMEBUFFER_INCOMPLETE_MISSING_ATTACHMENT_EXT = 0x8CD7;
    public const uint GL_FRAMEBUFFER_INCOMPLETE_DIMENSIONS_EXT = 0x8CD9;
    public const uint GL_FRAMEBUFFER_INCOMPLETE_FORMATS_EXT = 0x8CDA;
    public const uint GL_FRAMEBUFFER_INCOMPLETE_DRAW_BUFFER_EXT = 0x8CDB;
    public const uint GL_FRAMEBUFFER_INCOMPLETE_READ_BUFFER_EXT = 0x8CDC;
    public const uint GL_FRAMEBUFFER_UNSUPPORTED_EXT = 0x8CDD;
    public const uint GL_MAX_COLOR_ATTACHMENTS_EXT = 0x8CDF;
    public const uint GL_COLOR_ATTACHMENT0_EXT = 0x8CE0;
    public const uint GL_COLOR_ATTACHMENT1_EXT = 0x8CE1;
    public const uint GL_COLOR_ATTACHMENT2_EXT = 0x8CE2;
    public const uint GL_COLOR_ATTACHMENT3_EXT = 0x8CE3;
    public const uint GL_COLOR_ATTACHMENT4_EXT = 0x8CE4;
    public const uint GL_COLOR_ATTACHMENT5_EXT = 0x8CE5;
    public const uint GL_COLOR_ATTACHMENT6_EXT = 0x8CE6;
    public const uint GL_COLOR_ATTACHMENT7_EXT = 0x8CE7;
    public const uint GL_COLOR_ATTACHMENT8_EXT = 0x8CE8;
    public const uint GL_COLOR_ATTACHMENT9_EXT = 0x8CE9;
    public const uint GL_COLOR_ATTACHMENT10_EXT = 0x8CEA;
    public const uint GL_COLOR_ATTACHMENT11_EXT = 0x8CEB;
    public const uint GL_COLOR_ATTACHMENT12_EXT = 0x8CEC;
    public const uint GL_COLOR_ATTACHMENT13_EXT = 0x8CED;
    public const uint GL_COLOR_ATTACHMENT14_EXT = 0x8CEE;
    public const uint GL_COLOR_ATTACHMENT15_EXT = 0x8CEF;
    public const uint GL_DEPTH_ATTACHMENT_EXT = 0x8D00;
    public const uint GL_STENCIL_ATTACHMENT_EXT = 0x8D20;
    public const uint GL_FRAMEBUFFER_EXT = 0x8D40;
    public const uint GL_RENDERBUFFER_EXT = 0x8D41;
    public const uint GL_RENDERBUFFER_WIDTH_EXT = 0x8D42;
    public const uint GL_RENDERBUFFER_HEIGHT_EXT = 0x8D43;
    public const uint GL_RENDERBUFFER_INTERNAL_FORMAT_EXT = 0x8D44;
    public const uint GL_STENCIL_INDEX1_EXT = 0x8D46;
    public const uint GL_STENCIL_INDEX4_EXT = 0x8D47;
    public const uint GL_STENCIL_INDEX8_EXT = 0x8D48;
    public const uint GL_STENCIL_INDEX16_EXT = 0x8D49;
    public const uint GL_RENDERBUFFER_RED_SIZE_EXT = 0x8D50;
    public const uint GL_RENDERBUFFER_GREEN_SIZE_EXT = 0x8D51;
    public const uint GL_RENDERBUFFER_BLUE_SIZE_EXT = 0x8D52;
    public const uint GL_RENDERBUFFER_ALPHA_SIZE_EXT = 0x8D53;
    public const uint GL_RENDERBUFFER_DEPTH_SIZE_EXT = 0x8D54;
    public const uint GL_RENDERBUFFER_STENCIL_SIZE_EXT = 0x8D55;
    private delegate bool PFNGLISRENDERBUFFEREXTPROC(uint renderbuffer);
    private delegate void PFNGLBINDRENDERBUFFEREXTPROC(uint target, uint renderbuffer);
    private delegate void PFNGLDELETERENDERBUFFERSEXTPROC(uint n, const uint *renderbuffers);
    private delegate void PFNGLGENRENDERBUFFERSEXTPROC(uint n, uint *renderbuffers);
    private delegate void PFNGLRENDERBUFFERSTORAGEEXTPROC(uint target, uint internalformat, uint width, uint height);
    private delegate void PFNGLGETRENDERBUFFERPARAMETERIVEXTPROC(uint target, uint pname, int *params);
    private delegate bool PFNGLISFRAMEBUFFEREXTPROC(uint framebuffer);
    private delegate void PFNGLBINDFRAMEBUFFEREXTPROC(uint target, uint framebuffer);
    private delegate void PFNGLDELETEFRAMEBUFFERSEXTPROC(uint n, const uint *framebuffers);
    private delegate void PFNGLGENFRAMEBUFFERSEXTPROC(uint n, uint *framebuffers);
    private delegate uint PFNGLCHECKFRAMEBUFFERSTATUSEXTPROC(uint target);
    private delegate void PFNGLFRAMEBUFFERTEXTURE1DEXTPROC(uint target, uint attachment, uint textarget, uint texture, int level);
    private delegate void PFNGLFRAMEBUFFERTEXTURE2DEXTPROC(uint target, uint attachment, uint textarget, uint texture, int level);
    private delegate void PFNGLFRAMEBUFFERTEXTURE3DEXTPROC(uint target, uint attachment, uint textarget, uint texture, int level, int zoffset);
    private delegate void PFNGLFRAMEBUFFERRENDERBUFFEREXTPROC(uint target, uint attachment, uint renderbuffertarget, uint renderbuffer);
    private delegate void PFNGLGETFRAMEBUFFERATTACHMENTPARAMETERIVEXTPROC(uint target, uint attachment, uint pname, int *params);
    private delegate void PFNGLGENERATEMIPMAPEXTPROC(uint target);
    #ifdef GL_GLEXT_PROTOTYPES
    public static bool glIsRenderbufferEXT(uint renderbuffer);
    public static void glBindRenderbufferEXT(uint target, uint renderbuffer);
    public static void glDeleteRenderbuffersEXT(uint n, const uint *renderbuffers);
    public static void glGenRenderbuffersEXT(uint n, uint *renderbuffers);
    public static void glRenderbufferStorageEXT(uint target, uint internalformat, uint width, uint height);
    public static void glGetRenderbufferParameterivEXT(uint target, uint pname, int *params);
    public static bool glIsFramebufferEXT(uint framebuffer);
    public static void glBindFramebufferEXT(uint target, uint framebuffer);
    public static void glDeleteFramebuffersEXT(uint n, const uint *framebuffers);
    public static void glGenFramebuffersEXT(uint n, uint *framebuffers);
    public static uint glCheckFramebufferStatusEXT(uint target);
    public static void glFramebufferTexture1DEXT(uint target, uint attachment, uint textarget, uint texture, int level);
    public static void glFramebufferTexture2DEXT(uint target, uint attachment, uint textarget, uint texture, int level);
    public static void glFramebufferTexture3DEXT(uint target, uint attachment, uint textarget, uint texture, int level, int zoffset);
    public static void glFramebufferRenderbufferEXT(uint target, uint attachment, uint renderbuffertarget, uint renderbuffer);
    public static void glGetFramebufferAttachmentParameterivEXT(uint target, uint attachment, uint pname, int *params);
    public static void glGenerateMipmapEXT(uint target);
    #endif
    #endif /* GL_EXT_framebuffer_object */

    #ifndef GL_EXT_framebuffer_sRGB
    #define GL_EXT_framebuffer_sRGB 1
    public const uint GL_FRAMEBUFFER_SRGB_EXT = 0x8DB9;
    public const uint GL_FRAMEBUFFER_SRGB_CAPABLE_EXT = 0x8DBA;
    #endif /* GL_EXT_framebuffer_sRGB */

    #ifndef GL_EXT_geometry_shader4
    #define GL_EXT_geometry_shader4 1
    public const uint GL_GEOMETRY_SHADER_EXT = 0x8DD9;
    public const uint GL_GEOMETRY_VERTICES_OUT_EXT = 0x8DDA;
    public const uint GL_GEOMETRY_INPUT_TYPE_EXT = 0x8DDB;
    public const uint GL_GEOMETRY_OUTPUT_TYPE_EXT = 0x8DDC;
    public const uint GL_MAX_GEOMETRY_TEXTURE_IMAGE_UNITS_EXT = 0x8C29;
    public const uint GL_MAX_GEOMETRY_VARYING_COMPONENTS_EXT = 0x8DDD;
    public const uint GL_MAX_VERTEX_VARYING_COMPONENTS_EXT = 0x8DDE;
    public const uint GL_MAX_VARYING_COMPONENTS_EXT = 0x8B4B;
    public const uint GL_MAX_GEOMETRY_UNIFORM_COMPONENTS_EXT = 0x8DDF;
    public const uint GL_MAX_GEOMETRY_OUTPUT_VERTICES_EXT = 0x8DE0;
    public const uint GL_MAX_GEOMETRY_TOTAL_OUTPUT_COMPONENTS_EXT = 0x8DE1;
    public const uint GL_LINES_ADJACENCY_EXT = 0x000A;
    public const uint GL_LINE_STRIP_ADJACENCY_EXT = 0x000B;
    public const uint GL_TRIANGLES_ADJACENCY_EXT = 0x000C;
    public const uint GL_TRIANGLE_STRIP_ADJACENCY_EXT = 0x000D;
    public const uint GL_FRAMEBUFFER_INCOMPLETE_LAYER_TARGETS_EXT = 0x8DA8;
    public const uint GL_FRAMEBUFFER_INCOMPLETE_LAYER_COUNT_EXT = 0x8DA9;
    public const uint GL_FRAMEBUFFER_ATTACHMENT_LAYERED_EXT = 0x8DA7;
    public const uint GL_FRAMEBUFFER_ATTACHMENT_TEXTURE_LAYER_EXT = 0x8CD4;
    public const uint GL_PROGRAM_POINT_SIZE_EXT = 0x8642;
    private delegate void PFNGLPROGRAMPARAMETERIEXTPROC(uint program, uint pname, int value);
    #ifdef GL_GLEXT_PROTOTYPES
    public static void glProgramParameteriEXT(uint program, uint pname, int value);
    #endif
    #endif /* GL_EXT_geometry_shader4 */

    #ifndef GL_EXT_gpu_program_parameters
    #define GL_EXT_gpu_program_parameters 1
    private delegate void PFNGLPROGRAMENVPARAMETERS4FVEXTPROC(uint target, uint index, uint count, const float *params);
    private delegate void PFNGLPROGRAMLOCALPARAMETERS4FVEXTPROC(uint target, uint index, uint count, const float *params);
    #ifdef GL_GLEXT_PROTOTYPES
    public static void glProgramEnvParameters4fvEXT(uint target, uint index, uint count, const float *params);
    public static void glProgramLocalParameters4fvEXT(uint target, uint index, uint count, const float *params);
    #endif
    #endif /* GL_EXT_gpu_program_parameters */

    #ifndef GL_EXT_gpu_shader4
    #define GL_EXT_gpu_shader4 1
    public const uint GL_VERTEX_ATTRIB_ARRAY_INTEGER_EXT = 0x88FD;
    public const uint GL_SAMPLER_1D_ARRAY_EXT = 0x8DC0;
    public const uint GL_SAMPLER_2D_ARRAY_EXT = 0x8DC1;
    public const uint GL_SAMPLER_BUFFER_EXT = 0x8DC2;
    public const uint GL_SAMPLER_1D_ARRAY_SHADOW_EXT = 0x8DC3;
    public const uint GL_SAMPLER_2D_ARRAY_SHADOW_EXT = 0x8DC4;
    public const uint GL_SAMPLER_CUBE_SHADOW_EXT = 0x8DC5;
    public const uint GL_UNSIGNED_INT_VEC2_EXT = 0x8DC6;
    public const uint GL_UNSIGNED_INT_VEC3_EXT = 0x8DC7;
    public const uint GL_UNSIGNED_INT_VEC4_EXT = 0x8DC8;
    public const uint GL_INT_SAMPLER_1D_EXT = 0x8DC9;
    public const uint GL_INT_SAMPLER_2D_EXT = 0x8DCA;
    public const uint GL_INT_SAMPLER_3D_EXT = 0x8DCB;
    public const uint GL_INT_SAMPLER_CUBE_EXT = 0x8DCC;
    public const uint GL_INT_SAMPLER_2D_RECT_EXT = 0x8DCD;
    public const uint GL_INT_SAMPLER_1D_ARRAY_EXT = 0x8DCE;
    public const uint GL_INT_SAMPLER_2D_ARRAY_EXT = 0x8DCF;
    public const uint GL_INT_SAMPLER_BUFFER_EXT = 0x8DD0;
    public const uint GL_UNSIGNED_INT_SAMPLER_1D_EXT = 0x8DD1;
    public const uint GL_UNSIGNED_INT_SAMPLER_2D_EXT = 0x8DD2;
    public const uint GL_UNSIGNED_INT_SAMPLER_3D_EXT = 0x8DD3;
    public const uint GL_UNSIGNED_INT_SAMPLER_CUBE_EXT = 0x8DD4;
    public const uint GL_UNSIGNED_INT_SAMPLER_2D_RECT_EXT = 0x8DD5;
    public const uint GL_UNSIGNED_INT_SAMPLER_1D_ARRAY_EXT = 0x8DD6;
    public const uint GL_UNSIGNED_INT_SAMPLER_2D_ARRAY_EXT = 0x8DD7;
    public const uint GL_UNSIGNED_INT_SAMPLER_BUFFER_EXT = 0x8DD8;
    public const uint GL_MIN_PROGRAM_TEXEL_OFFSET_EXT = 0x8904;
    public const uint GL_MAX_PROGRAM_TEXEL_OFFSET_EXT = 0x8905;
    private delegate void PFNGLGETUNIFORMUIVEXTPROC(uint program, int location, uint *params);
    private delegate void PFNGLBINDFRAGDATALOCATIONEXTPROC(uint program, uint color, const byte *name);
    private delegate int PFNGLGETFRAGDATALOCATIONEXTPROC(uint program, const byte *name);
    private delegate void PFNGLUNIFORM1UIEXTPROC(int location, uint v0);
    private delegate void PFNGLUNIFORM2UIEXTPROC(int location, uint v0, uint v1);
    private delegate void PFNGLUNIFORM3UIEXTPROC(int location, uint v0, uint v1, uint v2);
    private delegate void PFNGLUNIFORM4UIEXTPROC(int location, uint v0, uint v1, uint v2, uint v3);
    private delegate void PFNGLUNIFORM1UIVEXTPROC(int location, uint count, const uint *value);
    private delegate void PFNGLUNIFORM2UIVEXTPROC(int location, uint count, const uint *value);
    private delegate void PFNGLUNIFORM3UIVEXTPROC(int location, uint count, const uint *value);
    private delegate void PFNGLUNIFORM4UIVEXTPROC(int location, uint count, const uint *value);
    #ifdef GL_GLEXT_PROTOTYPES
    public static void glGetUniformuivEXT(uint program, int location, uint *params);
    public static void glBindFragDataLocationEXT(uint program, uint color, const byte *name);
    public static int glGetFragDataLocationEXT(uint program, const byte *name);
    public static void glUniform1uiEXT(int location, uint v0);
    public static void glUniform2uiEXT(int location, uint v0, uint v1);
    public static void glUniform3uiEXT(int location, uint v0, uint v1, uint v2);
    public static void glUniform4uiEXT(int location, uint v0, uint v1, uint v2, uint v3);
    public static void glUniform1uivEXT(int location, uint count, const uint *value);
    public static void glUniform2uivEXT(int location, uint count, const uint *value);
    public static void glUniform3uivEXT(int location, uint count, const uint *value);
    public static void glUniform4uivEXT(int location, uint count, const uint *value);
    #endif
    #endif /* GL_EXT_gpu_shader4 */

    #ifndef GL_EXT_histogram
    #define GL_EXT_histogram 1
    public const uint GL_HISTOGRAM_EXT = 0x8024;
    public const uint GL_PROXY_HISTOGRAM_EXT = 0x8025;
    public const uint GL_HISTOGRAM_WIDTH_EXT = 0x8026;
    public const uint GL_HISTOGRAM_FORMAT_EXT = 0x8027;
    public const uint GL_HISTOGRAM_RED_SIZE_EXT = 0x8028;
    public const uint GL_HISTOGRAM_GREEN_SIZE_EXT = 0x8029;
    public const uint GL_HISTOGRAM_BLUE_SIZE_EXT = 0x802A;
    public const uint GL_HISTOGRAM_ALPHA_SIZE_EXT = 0x802B;
    public const uint GL_HISTOGRAM_LUMINANCE_SIZE_EXT = 0x802C;
    public const uint GL_HISTOGRAM_SINK_EXT = 0x802D;
    public const uint GL_MINMAX_EXT = 0x802E;
    public const uint GL_MINMAX_FORMAT_EXT = 0x802F;
    public const uint GL_MINMAX_SINK_EXT = 0x8030;
    public const uint GL_TABLE_TOO_LARGE_EXT = 0x8031;
    private delegate void PFNGLGETHISTOGRAMEXTPROC(uint target, bool reset, uint format, uint type, void *values);
    private delegate void PFNGLGETHISTOGRAMPARAMETERFVEXTPROC(uint target, uint pname, float *params);
    private delegate void PFNGLGETHISTOGRAMPARAMETERIVEXTPROC(uint target, uint pname, int *params);
    private delegate void PFNGLGETMINMAXEXTPROC(uint target, bool reset, uint format, uint type, void *values);
    private delegate void PFNGLGETMINMAXPARAMETERFVEXTPROC(uint target, uint pname, float *params);
    private delegate void PFNGLGETMINMAXPARAMETERIVEXTPROC(uint target, uint pname, int *params);
    private delegate void PFNGLHISTOGRAMEXTPROC(uint target, uint width, uint internalformat, bool sink);
    private delegate void PFNGLMINMAXEXTPROC(uint target, uint internalformat, bool sink);
    private delegate void PFNGLRESETHISTOGRAMEXTPROC(uint target);
    private delegate void PFNGLRESETMINMAXEXTPROC(uint target);
    #ifdef GL_GLEXT_PROTOTYPES
    public static void glGetHistogramEXT(uint target, bool reset, uint format, uint type, void *values);
    public static void glGetHistogramParameterfvEXT(uint target, uint pname, float *params);
    public static void glGetHistogramParameterivEXT(uint target, uint pname, int *params);
    public static void glGetMinmaxEXT(uint target, bool reset, uint format, uint type, void *values);
    public static void glGetMinmaxParameterfvEXT(uint target, uint pname, float *params);
    public static void glGetMinmaxParameterivEXT(uint target, uint pname, int *params);
    public static void glHistogramEXT(uint target, uint width, uint internalformat, bool sink);
    public static void glMinmaxEXT(uint target, uint internalformat, bool sink);
    public static void glResetHistogramEXT(uint target);
    public static void glResetMinmaxEXT(uint target);
    #endif
    #endif /* GL_EXT_histogram */

    #ifndef GL_EXT_index_array_formats
    #define GL_EXT_index_array_formats 1
    public const uint GL_IUI_V2F_EXT = 0x81AD;
    public const uint GL_IUI_V3F_EXT = 0x81AE;
    public const uint GL_IUI_N3F_V2F_EXT = 0x81AF;
    public const uint GL_IUI_N3F_V3F_EXT = 0x81B0;
    public const uint GL_T2F_IUI_V2F_EXT = 0x81B1;
    public const uint GL_T2F_IUI_V3F_EXT = 0x81B2;
    public const uint GL_T2F_IUI_N3F_V2F_EXT = 0x81B3;
    public const uint GL_T2F_IUI_N3F_V3F_EXT = 0x81B4;
    #endif /* GL_EXT_index_array_formats */

    #ifndef GL_EXT_index_func
    #define GL_EXT_index_func 1
    public const uint GL_INDEX_TEST_EXT = 0x81B5;
    public const uint GL_INDEX_TEST_FUNC_EXT = 0x81B6;
    public const uint GL_INDEX_TEST_REF_EXT = 0x81B7;
    private delegate void PFNGLINDEXFUNCEXTPROC(uint func, float ref);
    #ifdef GL_GLEXT_PROTOTYPES
    public static void glIndexFuncEXT(uint func, float ref);
    #endif
    #endif /* GL_EXT_index_func */

    #ifndef GL_EXT_index_material
    #define GL_EXT_index_material 1
    public const uint GL_INDEX_MATERIAL_EXT = 0x81B8;
    public const uint GL_INDEX_MATERIAL_PARAMETER_EXT = 0x81B9;
    public const uint GL_INDEX_MATERIAL_FACE_EXT = 0x81BA;
    private delegate void PFNGLINDEXMATERIALEXTPROC(uint face, uint mode);
    #ifdef GL_GLEXT_PROTOTYPES
    public static void glIndexMaterialEXT(uint face, uint mode);
    #endif
    #endif /* GL_EXT_index_material */

    #ifndef GL_EXT_index_texture
    #define GL_EXT_index_texture 1
    #endif /* GL_EXT_index_texture */

    #ifndef GL_EXT_light_texture
    #define GL_EXT_light_texture 1
    public const uint GL_FRAGMENT_MATERIAL_EXT = 0x8349;
    public const uint GL_FRAGMENT_NORMAL_EXT = 0x834A;
    public const uint GL_FRAGMENT_COLOR_EXT = 0x834C;
    public const uint GL_ATTENUATION_EXT = 0x834D;
    public const uint GL_SHADOW_ATTENUATION_EXT = 0x834E;
    public const uint GL_TEXTURE_APPLICATION_MODE_EXT = 0x834F;
    public const uint GL_TEXTURE_LIGHT_EXT = 0x8350;
    public const uint GL_TEXTURE_MATERIAL_FACE_EXT = 0x8351;
    public const uint GL_TEXTURE_MATERIAL_PARAMETER_EXT = 0x8352;
    private delegate void PFNGLAPPLYTEXTUREEXTPROC(uint mode);
    private delegate void PFNGLTEXTURELIGHTEXTPROC(uint pname);
    private delegate void PFNGLTEXTUREMATERIALEXTPROC(uint face, uint mode);
    #ifdef GL_GLEXT_PROTOTYPES
    public static void glApplyTextureEXT(uint mode);
    public static void glTextureLightEXT(uint pname);
    public static void glTextureMaterialEXT(uint face, uint mode);
    #endif
    #endif /* GL_EXT_light_texture */

    #ifndef GL_EXT_misc_attribute
    #define GL_EXT_misc_attribute 1
    #endif /* GL_EXT_misc_attribute */

    #ifndef GL_EXT_multi_draw_arrays
    #define GL_EXT_multi_draw_arrays 1
    private delegate void PFNGLMULTIDRAWARRAYSEXTPROC(uint mode, const int *first, const uint *count, uint primcount);
    private delegate void PFNGLMULTIDRAWELEMENTSEXTPROC(uint mode, const uint *count, uint type, const void *const*indices, uint primcount);
    #ifdef GL_GLEXT_PROTOTYPES
    public static void glMultiDrawArraysEXT(uint mode, const int *first, const uint *count, uint primcount);
    public static void glMultiDrawElementsEXT(uint mode, const uint *count, uint type, const void *const*indices, uint primcount);
    #endif
    #endif /* GL_EXT_multi_draw_arrays */

    #ifndef GL_EXT_multisample
    #define GL_EXT_multisample 1
    public const uint GL_MULTISAMPLE_EXT = 0x809D;
    public const uint GL_SAMPLE_ALPHA_TO_MASK_EXT = 0x809E;
    public const uint GL_SAMPLE_ALPHA_TO_ONE_EXT = 0x809F;
    public const uint GL_SAMPLE_MASK_EXT = 0x80A0;
    public const uint GL_1PASS_EXT = 0x80A1;
    public const uint GL_2PASS_0_EXT = 0x80A2;
    public const uint GL_2PASS_1_EXT = 0x80A3;
    public const uint GL_4PASS_0_EXT = 0x80A4;
    public const uint GL_4PASS_1_EXT = 0x80A5;
    public const uint GL_4PASS_2_EXT = 0x80A6;
    public const uint GL_4PASS_3_EXT = 0x80A7;
    public const uint GL_SAMPLE_BUFFERS_EXT = 0x80A8;
    public const uint GL_SAMPLES_EXT = 0x80A9;
    public const uint GL_SAMPLE_MASK_VALUE_EXT = 0x80AA;
    public const uint GL_SAMPLE_MASK_INVERT_EXT = 0x80AB;
    public const uint GL_SAMPLE_PATTERN_EXT = 0x80AC;
    public const uint GL_MULTISAMPLE_BIT_EXT = 0x20000000;
    private delegate void PFNGLSAMPLEMASKEXTPROC(float value, bool invert);
    private delegate void PFNGLSAMPLEPATTERNEXTPROC(uint pattern);
    #ifdef GL_GLEXT_PROTOTYPES
    public static void glSampleMaskEXT(float value, bool invert);
    public static void glSamplePatternEXT(uint pattern);
    #endif
    #endif /* GL_EXT_multisample */

    #ifndef GL_EXT_packed_depth_stencil
    #define GL_EXT_packed_depth_stencil 1
    public const uint GL_DEPTH_STENCIL_EXT = 0x84F9;
    public const uint GL_UNSIGNED_INT_24_8_EXT = 0x84FA;
    public const uint GL_DEPTH24_STENCIL8_EXT = 0x88F0;
    public const uint GL_TEXTURE_STENCIL_SIZE_EXT = 0x88F1;
    #endif /* GL_EXT_packed_depth_stencil */

    #ifndef GL_EXT_packed_float
    #define GL_EXT_packed_float 1
    public const uint GL_R11F_G11F_B10F_EXT = 0x8C3A;
    public const uint GL_UNSIGNED_INT_10F_11F_11F_REV_EXT = 0x8C3B;
    public const uint GL_RGBA_SIGNED_COMPONENTS_EXT = 0x8C3C;
    #endif /* GL_EXT_packed_float */

    #ifndef GL_EXT_packed_pixels
    #define GL_EXT_packed_pixels 1
    public const uint GL_UNSIGNED_BYTE_3_3_2_EXT = 0x8032;
    public const uint GL_UNSIGNED_SHORT_4_4_4_4_EXT = 0x8033;
    public const uint GL_UNSIGNED_SHORT_5_5_5_1_EXT = 0x8034;
    public const uint GL_UNSIGNED_INT_8_8_8_8_EXT = 0x8035;
    public const uint GL_UNSIGNED_INT_10_10_10_2_EXT = 0x8036;
    #endif /* GL_EXT_packed_pixels */

    #ifndef GL_EXT_paletted_texture
    #define GL_EXT_paletted_texture 1
    public const uint GL_COLOR_INDEX1_EXT = 0x80E2;
    public const uint GL_COLOR_INDEX2_EXT = 0x80E3;
    public const uint GL_COLOR_INDEX4_EXT = 0x80E4;
    public const uint GL_COLOR_INDEX8_EXT = 0x80E5;
    public const uint GL_COLOR_INDEX12_EXT = 0x80E6;
    public const uint GL_COLOR_INDEX16_EXT = 0x80E7;
    public const uint GL_TEXTURE_INDEX_SIZE_EXT = 0x80ED;
    private delegate void PFNGLCOLORTABLEEXTPROC(uint target, uint internalFormat, uint width, uint format, uint type, const void *table);
    private delegate void PFNGLGETCOLORTABLEEXTPROC(uint target, uint format, uint type, void *data);
    private delegate void PFNGLGETCOLORTABLEPARAMETERIVEXTPROC(uint target, uint pname, int *params);
    private delegate void PFNGLGETCOLORTABLEPARAMETERFVEXTPROC(uint target, uint pname, float *params);
    #ifdef GL_GLEXT_PROTOTYPES
    public static void glColorTableEXT(uint target, uint internalFormat, uint width, uint format, uint type, const void *table);
    public static void glGetColorTableEXT(uint target, uint format, uint type, void *data);
    public static void glGetColorTableParameterivEXT(uint target, uint pname, int *params);
    public static void glGetColorTableParameterfvEXT(uint target, uint pname, float *params);
    #endif
    #endif /* GL_EXT_paletted_texture */

    #ifndef GL_EXT_pixel_buffer_object
    #define GL_EXT_pixel_buffer_object 1
    public const uint GL_PIXEL_PACK_BUFFER_EXT = 0x88EB;
    public const uint GL_PIXEL_UNPACK_BUFFER_EXT = 0x88EC;
    public const uint GL_PIXEL_PACK_BUFFER_BINDING_EXT = 0x88ED;
    public const uint GL_PIXEL_UNPACK_BUFFER_BINDING_EXT = 0x88EF;
    #endif /* GL_EXT_pixel_buffer_object */

    #ifndef GL_EXT_pixel_transform
    #define GL_EXT_pixel_transform 1
    public const uint GL_PIXEL_TRANSFORM_2D_EXT = 0x8330;
    public const uint GL_PIXEL_MAG_FILTER_EXT = 0x8331;
    public const uint GL_PIXEL_MIN_FILTER_EXT = 0x8332;
    public const uint GL_PIXEL_CUBIC_WEIGHT_EXT = 0x8333;
    public const uint GL_CUBIC_EXT = 0x8334;
    public const uint GL_AVERAGE_EXT = 0x8335;
    public const uint GL_PIXEL_TRANSFORM_2D_STACK_DEPTH_EXT = 0x8336;
    public const uint GL_MAX_PIXEL_TRANSFORM_2D_STACK_DEPTH_EXT = 0x8337;
    public const uint GL_PIXEL_TRANSFORM_2D_MATRIX_EXT = 0x8338;
    private delegate void PFNGLPIXELTRANSFORMPARAMETERIEXTPROC(uint target, uint pname, int param);
    private delegate void PFNGLPIXELTRANSFORMPARAMETERFEXTPROC(uint target, uint pname, float param);
    private delegate void PFNGLPIXELTRANSFORMPARAMETERIVEXTPROC(uint target, uint pname, const int *params);
    private delegate void PFNGLPIXELTRANSFORMPARAMETERFVEXTPROC(uint target, uint pname, const float *params);
    private delegate void PFNGLGETPIXELTRANSFORMPARAMETERIVEXTPROC(uint target, uint pname, int *params);
    private delegate void PFNGLGETPIXELTRANSFORMPARAMETERFVEXTPROC(uint target, uint pname, float *params);
    #ifdef GL_GLEXT_PROTOTYPES
    public static void glPixelTransformParameteriEXT(uint target, uint pname, int param);
    public static void glPixelTransformParameterfEXT(uint target, uint pname, float param);
    public static void glPixelTransformParameterivEXT(uint target, uint pname, const int *params);
    public static void glPixelTransformParameterfvEXT(uint target, uint pname, const float *params);
    public static void glGetPixelTransformParameterivEXT(uint target, uint pname, int *params);
    public static void glGetPixelTransformParameterfvEXT(uint target, uint pname, float *params);
    #endif
    #endif /* GL_EXT_pixel_transform */

    #ifndef GL_EXT_pixel_transform_color_table
    #define GL_EXT_pixel_transform_color_table 1
    #endif /* GL_EXT_pixel_transform_color_table */

    #ifndef GL_EXT_point_parameters
    #define GL_EXT_point_parameters 1
    public const uint GL_POINT_SIZE_MIN_EXT = 0x8126;
    public const uint GL_POINT_SIZE_MAX_EXT = 0x8127;
    public const uint GL_POINT_FADE_THRESHOLD_SIZE_EXT = 0x8128;
    public const uint GL_DISTANCE_ATTENUATION_EXT = 0x8129;
    private delegate void PFNGLPOINTPARAMETERFEXTPROC(uint pname, float param);
    private delegate void PFNGLPOINTPARAMETERFVEXTPROC(uint pname, const float *params);
    #ifdef GL_GLEXT_PROTOTYPES
    public static void glPointParameterfEXT(uint pname, float param);
    public static void glPointParameterfvEXT(uint pname, const float *params);
    #endif
    #endif /* GL_EXT_point_parameters */

    #ifndef GL_EXT_polygon_offset
    #define GL_EXT_polygon_offset 1
    public const uint GL_POLYGON_OFFSET_EXT = 0x8037;
    public const uint GL_POLYGON_OFFSET_FACTOR_EXT = 0x8038;
    public const uint GL_POLYGON_OFFSET_BIAS_EXT = 0x8039;
    private delegate void PFNGLPOLYGONOFFSETEXTPROC(float factor, float bias);
    #ifdef GL_GLEXT_PROTOTYPES
    public static void glPolygonOffsetEXT(float factor, float bias);
    #endif
    #endif /* GL_EXT_polygon_offset */

    #ifndef GL_EXT_provoking_vertex
    #define GL_EXT_provoking_vertex 1
    public const uint GL_QUADS_FOLLOW_PROVOKING_VERTEX_CONVENTION_EXT = 0x8E4C;
    public const uint GL_FIRST_VERTEX_CONVENTION_EXT = 0x8E4D;
    public const uint GL_LAST_VERTEX_CONVENTION_EXT = 0x8E4E;
    public const uint GL_PROVOKING_VERTEX_EXT = 0x8E4F;
    private delegate void PFNGLPROVOKINGVERTEXEXTPROC(uint mode);
    #ifdef GL_GLEXT_PROTOTYPES
    public static void glProvokingVertexEXT(uint mode);
    #endif
    #endif /* GL_EXT_provoking_vertex */

    #ifndef GL_EXT_rescale_normal
    #define GL_EXT_rescale_normal 1
    public const uint GL_RESCALE_NORMAL_EXT = 0x803A;
    #endif /* GL_EXT_rescale_normal */

    #ifndef GL_EXT_secondary_color
    #define GL_EXT_secondary_color 1
    public const uint GL_COLOR_SUM_EXT = 0x8458;
    public const uint GL_CURRENT_SECONDARY_COLOR_EXT = 0x8459;
    public const uint GL_SECONDARY_COLOR_ARRAY_SIZE_EXT = 0x845A;
    public const uint GL_SECONDARY_COLOR_ARRAY_TYPE_EXT = 0x845B;
    public const uint GL_SECONDARY_COLOR_ARRAY_STRIDE_EXT = 0x845C;
    public const uint GL_SECONDARY_COLOR_ARRAY_POINTER_EXT = 0x845D;
    public const uint GL_SECONDARY_COLOR_ARRAY_EXT = 0x845E;
    private delegate void PFNGLSECONDARYCOLOR3BEXTPROC(sbyte red, sbyte green, sbyte blue);
    private delegate void PFNGLSECONDARYCOLOR3BVEXTPROC(const sbyte *v);
    private delegate void PFNGLSECONDARYCOLOR3DEXTPROC(double red, double green, double blue);
    private delegate void PFNGLSECONDARYCOLOR3DVEXTPROC(const double *v);
    private delegate void PFNGLSECONDARYCOLOR3FEXTPROC(float red, float green, float blue);
    private delegate void PFNGLSECONDARYCOLOR3FVEXTPROC(const float *v);
    private delegate void PFNGLSECONDARYCOLOR3IEXTPROC(int red, int green, int blue);
    private delegate void PFNGLSECONDARYCOLOR3IVEXTPROC(const int *v);
    private delegate void PFNGLSECONDARYCOLOR3SEXTPROC(short red, short green, short blue);
    private delegate void PFNGLSECONDARYCOLOR3SVEXTPROC(const short *v);
    private delegate void PFNGLSECONDARYCOLOR3UBEXTPROC(byte red, byte green, byte blue);
    private delegate void PFNGLSECONDARYCOLOR3UBVEXTPROC(const byte *v);
    private delegate void PFNGLSECONDARYCOLOR3UIEXTPROC(uint red, uint green, uint blue);
    private delegate void PFNGLSECONDARYCOLOR3UIVEXTPROC(const uint *v);
    private delegate void PFNGLSECONDARYCOLOR3USEXTPROC(ushort red, ushort green, ushort blue);
    private delegate void PFNGLSECONDARYCOLOR3USVEXTPROC(const ushort *v);
    private delegate void PFNGLSECONDARYCOLORPOINTEREXTPROC(int size, uint type, uint stride, const void *pointer);
    #ifdef GL_GLEXT_PROTOTYPES
    public static void glSecondaryColor3bEXT(sbyte red, sbyte green, sbyte blue);
    public static void glSecondaryColor3bvEXT(const sbyte *v);
    public static void glSecondaryColor3dEXT(double red, double green, double blue);
    public static void glSecondaryColor3dvEXT(const double *v);
    public static void glSecondaryColor3fEXT(float red, float green, float blue);
    public static void glSecondaryColor3fvEXT(const float *v);
    public static void glSecondaryColor3iEXT(int red, int green, int blue);
    public static void glSecondaryColor3ivEXT(const int *v);
    public static void glSecondaryColor3sEXT(short red, short green, short blue);
    public static void glSecondaryColor3svEXT(const short *v);
    public static void glSecondaryColor3ubEXT(byte red, byte green, byte blue);
    public static void glSecondaryColor3ubvEXT(const byte *v);
    public static void glSecondaryColor3uiEXT(uint red, uint green, uint blue);
    public static void glSecondaryColor3uivEXT(const uint *v);
    public static void glSecondaryColor3usEXT(ushort red, ushort green, ushort blue);
    public static void glSecondaryColor3usvEXT(const ushort *v);
    public static void glSecondaryColorPointerEXT(int size, uint type, uint stride, const void *pointer);
    #endif
    #endif /* GL_EXT_secondary_color */

    #ifndef GL_EXT_separate_shader_objects
    #define GL_EXT_separate_shader_objects 1
    public const uint GL_ACTIVE_PROGRAM_EXT = 0x8B8D;
    private delegate void PFNGLUSESHADERPROGRAMEXTPROC(uint type, uint program);
    private delegate void PFNGLACTIVEPROGRAMEXTPROC(uint program);
    private delegate uint PFNGLCREATESHADERPROGRAMEXTPROC(uint type, const byte *string);
    #ifdef GL_GLEXT_PROTOTYPES
    public static void glUseShaderProgramEXT(uint type, uint program);
    public static void glActiveProgramEXT(uint program);
    public static uint glCreateShaderProgramEXT(uint type, const byte *string);
    #endif
    #endif /* GL_EXT_separate_shader_objects */

    #ifndef GL_EXT_separate_specular_color
    #define GL_EXT_separate_specular_color 1
    public const uint GL_LIGHT_MODEL_COLOR_CONTROL_EXT = 0x81F8;
    public const uint GL_SINGLE_COLOR_EXT = 0x81F9;
    public const uint GL_SEPARATE_SPECULAR_COLOR_EXT = 0x81FA;
    #endif /* GL_EXT_separate_specular_color */

    #ifndef GL_EXT_shader_image_load_store
    #define GL_EXT_shader_image_load_store 1
    public const uint GL_MAX_IMAGE_UNITS_EXT = 0x8F38;
    public const uint GL_MAX_COMBINED_IMAGE_UNITS_AND_FRAGMENT_OUTPUTS_EXT = 0x8F39;
    public const uint GL_IMAGE_BINDING_NAME_EXT = 0x8F3A;
    public const uint GL_IMAGE_BINDING_LEVEL_EXT = 0x8F3B;
    public const uint GL_IMAGE_BINDING_LAYERED_EXT = 0x8F3C;
    public const uint GL_IMAGE_BINDING_LAYER_EXT = 0x8F3D;
    public const uint GL_IMAGE_BINDING_ACCESS_EXT = 0x8F3E;
    public const uint GL_IMAGE_1D_EXT = 0x904C;
    public const uint GL_IMAGE_2D_EXT = 0x904D;
    public const uint GL_IMAGE_3D_EXT = 0x904E;
    public const uint GL_IMAGE_2D_RECT_EXT = 0x904F;
    public const uint GL_IMAGE_CUBE_EXT = 0x9050;
    public const uint GL_IMAGE_BUFFER_EXT = 0x9051;
    public const uint GL_IMAGE_1D_ARRAY_EXT = 0x9052;
    public const uint GL_IMAGE_2D_ARRAY_EXT = 0x9053;
    public const uint GL_IMAGE_CUBE_MAP_ARRAY_EXT = 0x9054;
    public const uint GL_IMAGE_2D_MULTISAMPLE_EXT = 0x9055;
    public const uint GL_IMAGE_2D_MULTISAMPLE_ARRAY_EXT = 0x9056;
    public const uint GL_INT_IMAGE_1D_EXT = 0x9057;
    public const uint GL_INT_IMAGE_2D_EXT = 0x9058;
    public const uint GL_INT_IMAGE_3D_EXT = 0x9059;
    public const uint GL_INT_IMAGE_2D_RECT_EXT = 0x905A;
    public const uint GL_INT_IMAGE_CUBE_EXT = 0x905B;
    public const uint GL_INT_IMAGE_BUFFER_EXT = 0x905C;
    public const uint GL_INT_IMAGE_1D_ARRAY_EXT = 0x905D;
    public const uint GL_INT_IMAGE_2D_ARRAY_EXT = 0x905E;
    public const uint GL_INT_IMAGE_CUBE_MAP_ARRAY_EXT = 0x905F;
    public const uint GL_INT_IMAGE_2D_MULTISAMPLE_EXT = 0x9060;
    public const uint GL_INT_IMAGE_2D_MULTISAMPLE_ARRAY_EXT = 0x9061;
    public const uint GL_UNSIGNED_INT_IMAGE_1D_EXT = 0x9062;
    public const uint GL_UNSIGNED_INT_IMAGE_2D_EXT = 0x9063;
    public const uint GL_UNSIGNED_INT_IMAGE_3D_EXT = 0x9064;
    public const uint GL_UNSIGNED_INT_IMAGE_2D_RECT_EXT = 0x9065;
    public const uint GL_UNSIGNED_INT_IMAGE_CUBE_EXT = 0x9066;
    public const uint GL_UNSIGNED_INT_IMAGE_BUFFER_EXT = 0x9067;
    public const uint GL_UNSIGNED_INT_IMAGE_1D_ARRAY_EXT = 0x9068;
    public const uint GL_UNSIGNED_INT_IMAGE_2D_ARRAY_EXT = 0x9069;
    public const uint GL_UNSIGNED_INT_IMAGE_CUBE_MAP_ARRAY_EXT = 0x906A;
    public const uint GL_UNSIGNED_INT_IMAGE_2D_MULTISAMPLE_EXT = 0x906B;
    public const uint GL_UNSIGNED_INT_IMAGE_2D_MULTISAMPLE_ARRAY_EXT = 0x906C;
    public const uint GL_MAX_IMAGE_SAMPLES_EXT = 0x906D;
    public const uint GL_IMAGE_BINDING_FORMAT_EXT = 0x906E;
    public const uint GL_VERTEX_ATTRIB_ARRAY_BARRIER_BIT_EXT = 0x00000001;
    public const uint GL_ELEMENT_ARRAY_BARRIER_BIT_EXT = 0x00000002;
    public const uint GL_UNIFORM_BARRIER_BIT_EXT = 0x00000004;
    public const uint GL_TEXTURE_FETCH_BARRIER_BIT_EXT = 0x00000008;
    public const uint GL_SHADER_IMAGE_ACCESS_BARRIER_BIT_EXT = 0x00000020;
    public const uint GL_COMMAND_BARRIER_BIT_EXT = 0x00000040;
    public const uint GL_PIXEL_BUFFER_BARRIER_BIT_EXT = 0x00000080;
    public const uint GL_TEXTURE_UPDATE_BARRIER_BIT_EXT = 0x00000100;
    public const uint GL_BUFFER_UPDATE_BARRIER_BIT_EXT = 0x00000200;
    public const uint GL_FRAMEBUFFER_BARRIER_BIT_EXT = 0x00000400;
    public const uint GL_TRANSFORM_FEEDBACK_BARRIER_BIT_EXT = 0x00000800;
    public const uint GL_ATOMIC_COUNTER_BARRIER_BIT_EXT = 0x00001000;
    public const uint GL_ALL_BARRIER_BITS_EXT = 0xFFFFFFFF;
    private delegate void PFNGLBINDIMAGETEXTUREEXTPROC(uint index, uint texture, int level, bool layered, int layer, uint access, int format);
    private delegate void PFNGLMEMORYBARRIEREXTPROC(uint barriers);
    #ifdef GL_GLEXT_PROTOTYPES
    public static void glBindImageTextureEXT(uint index, uint texture, int level, bool layered, int layer, uint access, int format);
    public static void glMemoryBarrierEXT(uint barriers);
    #endif
    #endif /* GL_EXT_shader_image_load_store */

    #ifndef GL_EXT_shader_integer_mix
    #define GL_EXT_shader_integer_mix 1
    #endif /* GL_EXT_shader_integer_mix */

    #ifndef GL_EXT_shadow_funcs
    #define GL_EXT_shadow_funcs 1
    #endif /* GL_EXT_shadow_funcs */

    #ifndef GL_EXT_shared_texture_palette
    #define GL_EXT_shared_texture_palette 1
    public const uint GL_SHARED_TEXTURE_PALETTE_EXT = 0x81FB;
    #endif /* GL_EXT_shared_texture_palette */

    #ifndef GL_EXT_stencil_clear_tag
    #define GL_EXT_stencil_clear_tag 1
    public const uint GL_STENCIL_TAG_BITS_EXT = 0x88F2;
    public const uint GL_STENCIL_CLEAR_TAG_VALUE_EXT = 0x88F3;
    private delegate void PFNGLSTENCILCLEARTAGEXTPROC(uint stencilTagBits, uint stencilClearTag);
    #ifdef GL_GLEXT_PROTOTYPES
    public static void glStencilClearTagEXT(uint stencilTagBits, uint stencilClearTag);
    #endif
    #endif /* GL_EXT_stencil_clear_tag */

    #ifndef GL_EXT_stencil_two_side
    #define GL_EXT_stencil_two_side 1
    public const uint GL_STENCIL_TEST_TWO_SIDE_EXT = 0x8910;
    public const uint GL_ACTIVE_STENCIL_FACE_EXT = 0x8911;
    private delegate void PFNGLACTIVESTENCILFACEEXTPROC(uint face);
    #ifdef GL_GLEXT_PROTOTYPES
    public static void glActiveStencilFaceEXT(uint face);
    #endif
    #endif /* GL_EXT_stencil_two_side */

    #ifndef GL_EXT_stencil_wrap
    #define GL_EXT_stencil_wrap 1
    public const uint GL_INCR_WRAP_EXT = 0x8507;
    public const uint GL_DECR_WRAP_EXT = 0x8508;
    #endif /* GL_EXT_stencil_wrap */

    #ifndef GL_EXT_subtexture
    #define GL_EXT_subtexture 1
    private delegate void PFNGLTEXSUBIMAGE1DEXTPROC(uint target, int level, int xoffset, uint width, uint format, uint type, const void *pixels);
    private delegate void PFNGLTEXSUBIMAGE2DEXTPROC(uint target, int level, int xoffset, int yoffset, uint width, uint height, uint format, uint type, const void *pixels);
    #ifdef GL_GLEXT_PROTOTYPES
    public static void glTexSubImage1DEXT(uint target, int level, int xoffset, uint width, uint format, uint type, const void *pixels);
    public static void glTexSubImage2DEXT(uint target, int level, int xoffset, int yoffset, uint width, uint height, uint format, uint type, const void *pixels);
    #endif
    #endif /* GL_EXT_subtexture */

    #ifndef GL_EXT_texture
    #define GL_EXT_texture 1
    public const uint GL_ALPHA4_EXT = 0x803B;
    public const uint GL_ALPHA8_EXT = 0x803C;
    public const uint GL_ALPHA12_EXT = 0x803D;
    public const uint GL_ALPHA16_EXT = 0x803E;
    public const uint GL_LUMINANCE4_EXT = 0x803F;
    public const uint GL_LUMINANCE8_EXT = 0x8040;
    public const uint GL_LUMINANCE12_EXT = 0x8041;
    public const uint GL_LUMINANCE16_EXT = 0x8042;
    public const uint GL_LUMINANCE4_ALPHA4_EXT = 0x8043;
    public const uint GL_LUMINANCE6_ALPHA2_EXT = 0x8044;
    public const uint GL_LUMINANCE8_ALPHA8_EXT = 0x8045;
    public const uint GL_LUMINANCE12_ALPHA4_EXT = 0x8046;
    public const uint GL_LUMINANCE12_ALPHA12_EXT = 0x8047;
    public const uint GL_LUMINANCE16_ALPHA16_EXT = 0x8048;
    public const uint GL_INTENSITY_EXT = 0x8049;
    public const uint GL_INTENSITY4_EXT = 0x804A;
    public const uint GL_INTENSITY8_EXT = 0x804B;
    public const uint GL_INTENSITY12_EXT = 0x804C;
    public const uint GL_INTENSITY16_EXT = 0x804D;
    public const uint GL_RGB2_EXT = 0x804E;
    public const uint GL_RGB4_EXT = 0x804F;
    public const uint GL_RGB5_EXT = 0x8050;
    public const uint GL_RGB8_EXT = 0x8051;
    public const uint GL_RGB10_EXT = 0x8052;
    public const uint GL_RGB12_EXT = 0x8053;
    public const uint GL_RGB16_EXT = 0x8054;
    public const uint GL_RGBA2_EXT = 0x8055;
    public const uint GL_RGBA4_EXT = 0x8056;
    public const uint GL_RGB5_A1_EXT = 0x8057;
    public const uint GL_RGBA8_EXT = 0x8058;
    public const uint GL_RGB10_A2_EXT = 0x8059;
    public const uint GL_RGBA12_EXT = 0x805A;
    public const uint GL_RGBA16_EXT = 0x805B;
    public const uint GL_TEXTURE_RED_SIZE_EXT = 0x805C;
    public const uint GL_TEXTURE_GREEN_SIZE_EXT = 0x805D;
    public const uint GL_TEXTURE_BLUE_SIZE_EXT = 0x805E;
    public const uint GL_TEXTURE_ALPHA_SIZE_EXT = 0x805F;
    public const uint GL_TEXTURE_LUMINANCE_SIZE_EXT = 0x8060;
    public const uint GL_TEXTURE_INTENSITY_SIZE_EXT = 0x8061;
    public const uint GL_REPLACE_EXT = 0x8062;
    public const uint GL_PROXY_TEXTURE_1D_EXT = 0x8063;
    public const uint GL_PROXY_TEXTURE_2D_EXT = 0x8064;
    public const uint GL_TEXTURE_TOO_LARGE_EXT = 0x8065;
    #endif /* GL_EXT_texture */

    #ifndef GL_EXT_texture3D
    #define GL_EXT_texture3D 1
    public const uint GL_PACK_SKIP_IMAGES_EXT = 0x806B;
    public const uint GL_PACK_IMAGE_HEIGHT_EXT = 0x806C;
    public const uint GL_UNPACK_SKIP_IMAGES_EXT = 0x806D;
    public const uint GL_UNPACK_IMAGE_HEIGHT_EXT = 0x806E;
    public const uint GL_TEXTURE_3D_EXT = 0x806F;
    public const uint GL_PROXY_TEXTURE_3D_EXT = 0x8070;
    public const uint GL_TEXTURE_DEPTH_EXT = 0x8071;
    public const uint GL_TEXTURE_WRAP_R_EXT = 0x8072;
    public const uint GL_MAX_3D_TEXTURE_SIZE_EXT = 0x8073;
    private delegate void PFNGLTEXIMAGE3DEXTPROC(uint target, int level, uint internalformat, uint width, uint height, uint depth, int border, uint format, uint type, const void *pixels);
    private delegate void PFNGLTEXSUBIMAGE3DEXTPROC(uint target, int level, int xoffset, int yoffset, int zoffset, uint width, uint height, uint depth, uint format, uint type, const void *pixels);
    #ifdef GL_GLEXT_PROTOTYPES
    public static void glTexImage3DEXT(uint target, int level, uint internalformat, uint width, uint height, uint depth, int border, uint format, uint type, const void *pixels);
    public static void glTexSubImage3DEXT(uint target, int level, int xoffset, int yoffset, int zoffset, uint width, uint height, uint depth, uint format, uint type, const void *pixels);
    #endif
    #endif /* GL_EXT_texture3D */

    #ifndef GL_EXT_texture_array
    #define GL_EXT_texture_array 1
    public const uint GL_TEXTURE_1D_ARRAY_EXT = 0x8C18;
    public const uint GL_PROXY_TEXTURE_1D_ARRAY_EXT = 0x8C19;
    public const uint GL_TEXTURE_2D_ARRAY_EXT = 0x8C1A;
    public const uint GL_PROXY_TEXTURE_2D_ARRAY_EXT = 0x8C1B;
    public const uint GL_TEXTURE_BINDING_1D_ARRAY_EXT = 0x8C1C;
    public const uint GL_TEXTURE_BINDING_2D_ARRAY_EXT = 0x8C1D;
    public const uint GL_MAX_ARRAY_TEXTURE_LAYERS_EXT = 0x88FF;
    public const uint GL_COMPARE_REF_DEPTH_TO_TEXTURE_EXT = 0x884E;
    #endif /* GL_EXT_texture_array */

    #ifndef GL_EXT_texture_buffer_object
    #define GL_EXT_texture_buffer_object 1
    public const uint GL_TEXTURE_BUFFER_EXT = 0x8C2A;
    public const uint GL_MAX_TEXTURE_BUFFER_SIZE_EXT = 0x8C2B;
    public const uint GL_TEXTURE_BINDING_BUFFER_EXT = 0x8C2C;
    public const uint GL_TEXTURE_BUFFER_DATA_STORE_BINDING_EXT = 0x8C2D;
    public const uint GL_TEXTURE_BUFFER_FORMAT_EXT = 0x8C2E;
    private delegate void PFNGLTEXBUFFEREXTPROC(uint target, uint internalformat, uint buffer);
    #ifdef GL_GLEXT_PROTOTYPES
    public static void glTexBufferEXT(uint target, uint internalformat, uint buffer);
    #endif
    #endif /* GL_EXT_texture_buffer_object */

    #ifndef GL_EXT_texture_compression_latc
    #define GL_EXT_texture_compression_latc 1
    public const uint GL_COMPRESSED_LUMINANCE_LATC1_EXT = 0x8C70;
    public const uint GL_COMPRESSED_SIGNED_LUMINANCE_LATC1_EXT = 0x8C71;
    public const uint GL_COMPRESSED_LUMINANCE_ALPHA_LATC2_EXT = 0x8C72;
    public const uint GL_COMPRESSED_SIGNED_LUMINANCE_ALPHA_LATC2_EXT = 0x8C73;
    #endif /* GL_EXT_texture_compression_latc */

    #ifndef GL_EXT_texture_compression_rgtc
    #define GL_EXT_texture_compression_rgtc 1
    public const uint GL_COMPRESSED_RED_RGTC1_EXT = 0x8DBB;
    public const uint GL_COMPRESSED_SIGNED_RED_RGTC1_EXT = 0x8DBC;
    public const uint GL_COMPRESSED_RED_GREEN_RGTC2_EXT = 0x8DBD;
    public const uint GL_COMPRESSED_SIGNED_RED_GREEN_RGTC2_EXT = 0x8DBE;
    #endif /* GL_EXT_texture_compression_rgtc */

    #ifndef GL_EXT_texture_compression_s3tc
    #define GL_EXT_texture_compression_s3tc 1
    public const uint GL_COMPRESSED_RGB_S3TC_DXT1_EXT = 0x83F0;
    public const uint GL_COMPRESSED_RGBA_S3TC_DXT1_EXT = 0x83F1;
    public const uint GL_COMPRESSED_RGBA_S3TC_DXT3_EXT = 0x83F2;
    public const uint GL_COMPRESSED_RGBA_S3TC_DXT5_EXT = 0x83F3;
    #endif /* GL_EXT_texture_compression_s3tc */

    #ifndef GL_EXT_texture_cube_map
    #define GL_EXT_texture_cube_map 1
    public const uint GL_NORMAL_MAP_EXT = 0x8511;
    public const uint GL_REFLECTION_MAP_EXT = 0x8512;
    public const uint GL_TEXTURE_CUBE_MAP_EXT = 0x8513;
    public const uint GL_TEXTURE_BINDING_CUBE_MAP_EXT = 0x8514;
    public const uint GL_TEXTURE_CUBE_MAP_POSITIVE_X_EXT = 0x8515;
    public const uint GL_TEXTURE_CUBE_MAP_NEGATIVE_X_EXT = 0x8516;
    public const uint GL_TEXTURE_CUBE_MAP_POSITIVE_Y_EXT = 0x8517;
    public const uint GL_TEXTURE_CUBE_MAP_NEGATIVE_Y_EXT = 0x8518;
    public const uint GL_TEXTURE_CUBE_MAP_POSITIVE_Z_EXT = 0x8519;
    public const uint GL_TEXTURE_CUBE_MAP_NEGATIVE_Z_EXT = 0x851A;
    public const uint GL_PROXY_TEXTURE_CUBE_MAP_EXT = 0x851B;
    public const uint GL_MAX_CUBE_MAP_TEXTURE_SIZE_EXT = 0x851C;
    #endif /* GL_EXT_texture_cube_map */

    #ifndef GL_EXT_texture_env_add
    #define GL_EXT_texture_env_add 1
    #endif /* GL_EXT_texture_env_add */

    #ifndef GL_EXT_texture_env_combine
    #define GL_EXT_texture_env_combine 1
    public const uint GL_COMBINE_EXT = 0x8570;
    public const uint GL_COMBINE_RGB_EXT = 0x8571;
    public const uint GL_COMBINE_ALPHA_EXT = 0x8572;
    public const uint GL_RGB_SCALE_EXT = 0x8573;
    public const uint GL_ADD_SIGNED_EXT = 0x8574;
    public const uint GL_INTERPOLATE_EXT = 0x8575;
    public const uint GL_CONSTANT_EXT = 0x8576;
    public const uint GL_PRIMARY_COLOR_EXT = 0x8577;
    public const uint GL_PREVIOUS_EXT = 0x8578;
    public const uint GL_SOURCE0_RGB_EXT = 0x8580;
    public const uint GL_SOURCE1_RGB_EXT = 0x8581;
    public const uint GL_SOURCE2_RGB_EXT = 0x8582;
    public const uint GL_SOURCE0_ALPHA_EXT = 0x8588;
    public const uint GL_SOURCE1_ALPHA_EXT = 0x8589;
    public const uint GL_SOURCE2_ALPHA_EXT = 0x858A;
    public const uint GL_OPERAND0_RGB_EXT = 0x8590;
    public const uint GL_OPERAND1_RGB_EXT = 0x8591;
    public const uint GL_OPERAND2_RGB_EXT = 0x8592;
    public const uint GL_OPERAND0_ALPHA_EXT = 0x8598;
    public const uint GL_OPERAND1_ALPHA_EXT = 0x8599;
    public const uint GL_OPERAND2_ALPHA_EXT = 0x859A;
    #endif /* GL_EXT_texture_env_combine */

    #ifndef GL_EXT_texture_env_dot3
    #define GL_EXT_texture_env_dot3 1
    public const uint GL_DOT3_RGB_EXT = 0x8740;
    public const uint GL_DOT3_RGBA_EXT = 0x8741;
    #endif /* GL_EXT_texture_env_dot3 */

    #ifndef GL_EXT_texture_filter_anisotropic
    #define GL_EXT_texture_filter_anisotropic 1
    public const uint GL_TEXTURE_MAX_ANISOTROPY_EXT = 0x84FE;
    public const uint GL_MAX_TEXTURE_MAX_ANISOTROPY_EXT = 0x84FF;
    #endif /* GL_EXT_texture_filter_anisotropic */

    #ifndef GL_EXT_texture_integer
    #define GL_EXT_texture_integer 1
    public const uint GL_RGBA32UI_EXT = 0x8D70;
    public const uint GL_RGB32UI_EXT = 0x8D71;
    public const uint GL_ALPHA32UI_EXT = 0x8D72;
    public const uint GL_INTENSITY32UI_EXT = 0x8D73;
    public const uint GL_LUMINANCE32UI_EXT = 0x8D74;
    public const uint GL_LUMINANCE_ALPHA32UI_EXT = 0x8D75;
    public const uint GL_RGBA16UI_EXT = 0x8D76;
    public const uint GL_RGB16UI_EXT = 0x8D77;
    public const uint GL_ALPHA16UI_EXT = 0x8D78;
    public const uint GL_INTENSITY16UI_EXT = 0x8D79;
    public const uint GL_LUMINANCE16UI_EXT = 0x8D7A;
    public const uint GL_LUMINANCE_ALPHA16UI_EXT = 0x8D7B;
    public const uint GL_RGBA8UI_EXT = 0x8D7C;
    public const uint GL_RGB8UI_EXT = 0x8D7D;
    public const uint GL_ALPHA8UI_EXT = 0x8D7E;
    public const uint GL_INTENSITY8UI_EXT = 0x8D7F;
    public const uint GL_LUMINANCE8UI_EXT = 0x8D80;
    public const uint GL_LUMINANCE_ALPHA8UI_EXT = 0x8D81;
    public const uint GL_RGBA32I_EXT = 0x8D82;
    public const uint GL_RGB32I_EXT = 0x8D83;
    public const uint GL_ALPHA32I_EXT = 0x8D84;
    public const uint GL_INTENSITY32I_EXT = 0x8D85;
    public const uint GL_LUMINANCE32I_EXT = 0x8D86;
    public const uint GL_LUMINANCE_ALPHA32I_EXT = 0x8D87;
    public const uint GL_RGBA16I_EXT = 0x8D88;
    public const uint GL_RGB16I_EXT = 0x8D89;
    public const uint GL_ALPHA16I_EXT = 0x8D8A;
    public const uint GL_INTENSITY16I_EXT = 0x8D8B;
    public const uint GL_LUMINANCE16I_EXT = 0x8D8C;
    public const uint GL_LUMINANCE_ALPHA16I_EXT = 0x8D8D;
    public const uint GL_RGBA8I_EXT = 0x8D8E;
    public const uint GL_RGB8I_EXT = 0x8D8F;
    public const uint GL_ALPHA8I_EXT = 0x8D90;
    public const uint GL_INTENSITY8I_EXT = 0x8D91;
    public const uint GL_LUMINANCE8I_EXT = 0x8D92;
    public const uint GL_LUMINANCE_ALPHA8I_EXT = 0x8D93;
    public const uint GL_RED_INTEGER_EXT = 0x8D94;
    public const uint GL_GREEN_INTEGER_EXT = 0x8D95;
    public const uint GL_BLUE_INTEGER_EXT = 0x8D96;
    public const uint GL_ALPHA_INTEGER_EXT = 0x8D97;
    public const uint GL_RGB_INTEGER_EXT = 0x8D98;
    public const uint GL_RGBA_INTEGER_EXT = 0x8D99;
    public const uint GL_BGR_INTEGER_EXT = 0x8D9A;
    public const uint GL_BGRA_INTEGER_EXT = 0x8D9B;
    public const uint GL_LUMINANCE_INTEGER_EXT = 0x8D9C;
    public const uint GL_LUMINANCE_ALPHA_INTEGER_EXT = 0x8D9D;
    public const uint GL_RGBA_INTEGER_MODE_EXT = 0x8D9E;
    private delegate void PFNGLTEXPARAMETERIIVEXTPROC(uint target, uint pname, const int *params);
    private delegate void PFNGLTEXPARAMETERIUIVEXTPROC(uint target, uint pname, const uint *params);
    private delegate void PFNGLGETTEXPARAMETERIIVEXTPROC(uint target, uint pname, int *params);
    private delegate void PFNGLGETTEXPARAMETERIUIVEXTPROC(uint target, uint pname, uint *params);
    private delegate void PFNGLCLEARCOLORIIEXTPROC(int red, int green, int blue, int alpha);
    private delegate void PFNGLCLEARCOLORIUIEXTPROC(uint red, uint green, uint blue, uint alpha);
    #ifdef GL_GLEXT_PROTOTYPES
    public static void glTexParameterIivEXT(uint target, uint pname, const int *params);
    public static void glTexParameterIuivEXT(uint target, uint pname, const uint *params);
    public static void glGetTexParameterIivEXT(uint target, uint pname, int *params);
    public static void glGetTexParameterIuivEXT(uint target, uint pname, uint *params);
    public static void glClearColorIiEXT(int red, int green, int blue, int alpha);
    public static void glClearColorIuiEXT(uint red, uint green, uint blue, uint alpha);
    #endif
    #endif /* GL_EXT_texture_integer */

    #ifndef GL_EXT_texture_lod_bias
    #define GL_EXT_texture_lod_bias 1
    public const uint GL_MAX_TEXTURE_LOD_BIAS_EXT = 0x84FD;
    public const uint GL_TEXTURE_FILTER_CONTROL_EXT = 0x8500;
    public const uint GL_TEXTURE_LOD_BIAS_EXT = 0x8501;
    #endif /* GL_EXT_texture_lod_bias */

    #ifndef GL_EXT_texture_mirror_clamp
    #define GL_EXT_texture_mirror_clamp 1
    public const uint GL_MIRROR_CLAMP_EXT = 0x8742;
    public const uint GL_MIRROR_CLAMP_TO_EDGE_EXT = 0x8743;
    public const uint GL_MIRROR_CLAMP_TO_BORDER_EXT = 0x8912;
    #endif /* GL_EXT_texture_mirror_clamp */

    #ifndef GL_EXT_texture_object
    #define GL_EXT_texture_object 1
    public const uint GL_TEXTURE_PRIORITY_EXT = 0x8066;
    public const uint GL_TEXTURE_RESIDENT_EXT = 0x8067;
    public const uint GL_TEXTURE_1D_BINDING_EXT = 0x8068;
    public const uint GL_TEXTURE_2D_BINDING_EXT = 0x8069;
    public const uint GL_TEXTURE_3D_BINDING_EXT = 0x806A;
    private delegate bool PFNGLARETEXTURESRESIDENTEXTPROC(uint n, const uint *textures, bool *residences);
    private delegate void PFNGLBINDTEXTUREEXTPROC(uint target, uint texture);
    private delegate void PFNGLDELETETEXTURESEXTPROC(uint n, const uint *textures);
    private delegate void PFNGLGENTEXTURESEXTPROC(uint n, uint *textures);
    private delegate bool PFNGLISTEXTUREEXTPROC(uint texture);
    private delegate void PFNGLPRIORITIZETEXTURESEXTPROC(uint n, const uint *textures, const float *priorities);
    #ifdef GL_GLEXT_PROTOTYPES
    public static bool glAreTexturesResidentEXT(uint n, const uint *textures, bool *residences);
    public static void glBindTextureEXT(uint target, uint texture);
    public static void glDeleteTexturesEXT(uint n, const uint *textures);
    public static void glGenTexturesEXT(uint n, uint *textures);
    public static bool glIsTextureEXT(uint texture);
    public static void glPrioritizeTexturesEXT(uint n, const uint *textures, const float *priorities);
    #endif
    #endif /* GL_EXT_texture_object */

    #ifndef GL_EXT_texture_perturb_normal
    #define GL_EXT_texture_perturb_normal 1
    public const uint GL_PERTURB_EXT = 0x85AE;
    public const uint GL_TEXTURE_NORMAL_EXT = 0x85AF;
    private delegate void PFNGLTEXTURENORMALEXTPROC(uint mode);
    #ifdef GL_GLEXT_PROTOTYPES
    public static void glTextureNormalEXT(uint mode);
    #endif
    #endif /* GL_EXT_texture_perturb_normal */

    #ifndef GL_EXT_texture_sRGB
    #define GL_EXT_texture_sRGB 1
    public const uint GL_SRGB_EXT = 0x8C40;
    public const uint GL_SRGB8_EXT = 0x8C41;
    public const uint GL_SRGB_ALPHA_EXT = 0x8C42;
    public const uint GL_SRGB8_ALPHA8_EXT = 0x8C43;
    public const uint GL_SLUMINANCE_ALPHA_EXT = 0x8C44;
    public const uint GL_SLUMINANCE8_ALPHA8_EXT = 0x8C45;
    public const uint GL_SLUMINANCE_EXT = 0x8C46;
    public const uint GL_SLUMINANCE8_EXT = 0x8C47;
    public const uint GL_COMPRESSED_SRGB_EXT = 0x8C48;
    public const uint GL_COMPRESSED_SRGB_ALPHA_EXT = 0x8C49;
    public const uint GL_COMPRESSED_SLUMINANCE_EXT = 0x8C4A;
    public const uint GL_COMPRESSED_SLUMINANCE_ALPHA_EXT = 0x8C4B;
    public const uint GL_COMPRESSED_SRGB_S3TC_DXT1_EXT = 0x8C4C;
    public const uint GL_COMPRESSED_SRGB_ALPHA_S3TC_DXT1_EXT = 0x8C4D;
    public const uint GL_COMPRESSED_SRGB_ALPHA_S3TC_DXT3_EXT = 0x8C4E;
    public const uint GL_COMPRESSED_SRGB_ALPHA_S3TC_DXT5_EXT = 0x8C4F;
    #endif /* GL_EXT_texture_sRGB */

    #ifndef GL_EXT_texture_sRGB_decode
    #define GL_EXT_texture_sRGB_decode 1
    public const uint GL_TEXTURE_SRGB_DECODE_EXT = 0x8A48;
    public const uint GL_DECODE_EXT = 0x8A49;
    public const uint GL_SKIP_DECODE_EXT = 0x8A4A;
    #endif /* GL_EXT_texture_sRGB_decode */

    #ifndef GL_EXT_texture_shared_exponent
    #define GL_EXT_texture_shared_exponent 1
    public const uint GL_RGB9_E5_EXT = 0x8C3D;
    public const uint GL_UNSIGNED_INT_5_9_9_9_REV_EXT = 0x8C3E;
    public const uint GL_TEXTURE_SHARED_SIZE_EXT = 0x8C3F;
    #endif /* GL_EXT_texture_shared_exponent */

    #ifndef GL_EXT_texture_snorm
    #define GL_EXT_texture_snorm 1
    public const uint GL_ALPHA_SNORM = 0x9010;
    public const uint GL_LUMINANCE_SNORM = 0x9011;
    public const uint GL_LUMINANCE_ALPHA_SNORM = 0x9012;
    public const uint GL_INTENSITY_SNORM = 0x9013;
    public const uint GL_ALPHA8_SNORM = 0x9014;
    public const uint GL_LUMINANCE8_SNORM = 0x9015;
    public const uint GL_LUMINANCE8_ALPHA8_SNORM = 0x9016;
    public const uint GL_INTENSITY8_SNORM = 0x9017;
    public const uint GL_ALPHA16_SNORM = 0x9018;
    public const uint GL_LUMINANCE16_SNORM = 0x9019;
    public const uint GL_LUMINANCE16_ALPHA16_SNORM = 0x901A;
    public const uint GL_INTENSITY16_SNORM = 0x901B;
    public const uint GL_RED_SNORM = 0x8F90;
    public const uint GL_RG_SNORM = 0x8F91;
    public const uint GL_RGB_SNORM = 0x8F92;
    public const uint GL_RGBA_SNORM = 0x8F93;
    #endif /* GL_EXT_texture_snorm */

    #ifndef GL_EXT_texture_swizzle
    #define GL_EXT_texture_swizzle 1
    public const uint GL_TEXTURE_SWIZZLE_R_EXT = 0x8E42;
    public const uint GL_TEXTURE_SWIZZLE_G_EXT = 0x8E43;
    public const uint GL_TEXTURE_SWIZZLE_B_EXT = 0x8E44;
    public const uint GL_TEXTURE_SWIZZLE_A_EXT = 0x8E45;
    public const uint GL_TEXTURE_SWIZZLE_RGBA_EXT = 0x8E46;
    #endif /* GL_EXT_texture_swizzle */

    #ifndef GL_EXT_timer_query
    #define GL_EXT_timer_query 1
    public const uint GL_TIME_ELAPSED_EXT = 0x88BF;
    private delegate void PFNGLGETQUERYOBJECTI64VEXTPROC(uint id, uint pname, long *params);
    private delegate void PFNGLGETQUERYOBJECTUI64VEXTPROC(uint id, uint pname, ulong *params);
    #ifdef GL_GLEXT_PROTOTYPES
    public static void glGetQueryObjecti64vEXT(uint id, uint pname, long *params);
    public static void glGetQueryObjectui64vEXT(uint id, uint pname, ulong *params);
    #endif
    #endif /* GL_EXT_timer_query */

    #ifndef GL_EXT_transform_feedback
    #define GL_EXT_transform_feedback 1
    public const uint GL_TRANSFORM_FEEDBACK_BUFFER_EXT = 0x8C8E;
    public const uint GL_TRANSFORM_FEEDBACK_BUFFER_START_EXT = 0x8C84;
    public const uint GL_TRANSFORM_FEEDBACK_BUFFER_SIZE_EXT = 0x8C85;
    public const uint GL_TRANSFORM_FEEDBACK_BUFFER_BINDING_EXT = 0x8C8F;
    public const uint GL_INTERLEAVED_ATTRIBS_EXT = 0x8C8C;
    public const uint GL_SEPARATE_ATTRIBS_EXT = 0x8C8D;
    public const uint GL_PRIMITIVES_GENERATED_EXT = 0x8C87;
    public const uint GL_TRANSFORM_FEEDBACK_PRIMITIVES_WRITTEN_EXT = 0x8C88;
    public const uint GL_RASTERIZER_DISCARD_EXT = 0x8C89;
    public const uint GL_MAX_TRANSFORM_FEEDBACK_INTERLEAVED_COMPONENTS_EXT = 0x8C8A;
    public const uint GL_MAX_TRANSFORM_FEEDBACK_SEPARATE_ATTRIBS_EXT = 0x8C8B;
    public const uint GL_MAX_TRANSFORM_FEEDBACK_SEPARATE_COMPONENTS_EXT = 0x8C80;
    public const uint GL_TRANSFORM_FEEDBACK_VARYINGS_EXT = 0x8C83;
    public const uint GL_TRANSFORM_FEEDBACK_BUFFER_MODE_EXT = 0x8C7F;
    public const uint GL_TRANSFORM_FEEDBACK_VARYING_MAX_LENGTH_EXT = 0x8C76;
    private delegate void PFNGLBEGINTRANSFORMFEEDBACKEXTPROC(uint primitiveMode);
    private delegate void PFNGLENDTRANSFORMFEEDBACKEXTPROC(void);
    private delegate void PFNGLBINDBUFFERRANGEEXTPROC(uint target, uint index, uint buffer, intptr offset, uintptr size);
    private delegate void PFNGLBINDBUFFEROFFSETEXTPROC(uint target, uint index, uint buffer, intptr offset);
    private delegate void PFNGLBINDBUFFERBASEEXTPROC(uint target, uint index, uint buffer);
    private delegate void PFNGLTRANSFORMFEEDBACKVARYINGSEXTPROC(uint program, uint count, const byte *const*varyings, uint bufferMode);
    private delegate void PFNGLGETTRANSFORMFEEDBACKVARYINGEXTPROC(uint program, uint index, uint bufSize, uint *length, uint *size, uint *type, byte *name);
    #ifdef GL_GLEXT_PROTOTYPES
    public static void glBeginTransformFeedbackEXT(uint primitiveMode);
    public static void glEndTransformFeedbackEXT(void);
    public static void glBindBufferRangeEXT(uint target, uint index, uint buffer, intptr offset, uintptr size);
    public static void glBindBufferOffsetEXT(uint target, uint index, uint buffer, intptr offset);
    public static void glBindBufferBaseEXT(uint target, uint index, uint buffer);
    public static void glTransformFeedbackVaryingsEXT(uint program, uint count, const byte *const*varyings, uint bufferMode);
    public static void glGetTransformFeedbackVaryingEXT(uint program, uint index, uint bufSize, uint *length, uint *size, uint *type, byte *name);
    #endif
    #endif /* GL_EXT_transform_feedback */

    #ifndef GL_EXT_vertex_array
    #define GL_EXT_vertex_array 1
    public const uint GL_VERTEX_ARRAY_EXT = 0x8074;
    public const uint GL_NORMAL_ARRAY_EXT = 0x8075;
    public const uint GL_COLOR_ARRAY_EXT = 0x8076;
    public const uint GL_INDEX_ARRAY_EXT = 0x8077;
    public const uint GL_TEXTURE_COORD_ARRAY_EXT = 0x8078;
    public const uint GL_EDGE_FLAG_ARRAY_EXT = 0x8079;
    public const uint GL_VERTEX_ARRAY_SIZE_EXT = 0x807A;
    public const uint GL_VERTEX_ARRAY_TYPE_EXT = 0x807B;
    public const uint GL_VERTEX_ARRAY_STRIDE_EXT = 0x807C;
    public const uint GL_VERTEX_ARRAY_COUNT_EXT = 0x807D;
    public const uint GL_NORMAL_ARRAY_TYPE_EXT = 0x807E;
    public const uint GL_NORMAL_ARRAY_STRIDE_EXT = 0x807F;
    public const uint GL_NORMAL_ARRAY_COUNT_EXT = 0x8080;
    public const uint GL_COLOR_ARRAY_SIZE_EXT = 0x8081;
    public const uint GL_COLOR_ARRAY_TYPE_EXT = 0x8082;
    public const uint GL_COLOR_ARRAY_STRIDE_EXT = 0x8083;
    public const uint GL_COLOR_ARRAY_COUNT_EXT = 0x8084;
    public const uint GL_INDEX_ARRAY_TYPE_EXT = 0x8085;
    public const uint GL_INDEX_ARRAY_STRIDE_EXT = 0x8086;
    public const uint GL_INDEX_ARRAY_COUNT_EXT = 0x8087;
    public const uint GL_TEXTURE_COORD_ARRAY_SIZE_EXT = 0x8088;
    public const uint GL_TEXTURE_COORD_ARRAY_TYPE_EXT = 0x8089;
    public const uint GL_TEXTURE_COORD_ARRAY_STRIDE_EXT = 0x808A;
    public const uint GL_TEXTURE_COORD_ARRAY_COUNT_EXT = 0x808B;
    public const uint GL_EDGE_FLAG_ARRAY_STRIDE_EXT = 0x808C;
    public const uint GL_EDGE_FLAG_ARRAY_COUNT_EXT = 0x808D;
    public const uint GL_VERTEX_ARRAY_POINTER_EXT = 0x808E;
    public const uint GL_NORMAL_ARRAY_POINTER_EXT = 0x808F;
    public const uint GL_COLOR_ARRAY_POINTER_EXT = 0x8090;
    public const uint GL_INDEX_ARRAY_POINTER_EXT = 0x8091;
    public const uint GL_TEXTURE_COORD_ARRAY_POINTER_EXT = 0x8092;
    public const uint GL_EDGE_FLAG_ARRAY_POINTER_EXT = 0x8093;
    private delegate void PFNGLARRAYELEMENTEXTPROC(int i);
    private delegate void PFNGLCOLORPOINTEREXTPROC(int size, uint type, uint stride, uint count, const void *pointer);
    private delegate void PFNGLDRAWARRAYSEXTPROC(uint mode, int first, uint count);
    private delegate void PFNGLEDGEFLAGPOINTEREXTPROC(uint stride, uint count, const bool *pointer);
    private delegate void PFNGLGETPOINTERVEXTPROC(uint pname, void **params);
    private delegate void PFNGLINDEXPOINTEREXTPROC(uint type, uint stride, uint count, const void *pointer);
    private delegate void PFNGLNORMALPOINTEREXTPROC(uint type, uint stride, uint count, const void *pointer);
    private delegate void PFNGLTEXCOORDPOINTEREXTPROC(int size, uint type, uint stride, uint count, const void *pointer);
    private delegate void PFNGLVERTEXPOINTEREXTPROC(int size, uint type, uint stride, uint count, const void *pointer);
    #ifdef GL_GLEXT_PROTOTYPES
    public static void glArrayElementEXT(int i);
    public static void glColorPointerEXT(int size, uint type, uint stride, uint count, const void *pointer);
    public static void glDrawArraysEXT(uint mode, int first, uint count);
    public static void glEdgeFlagPointerEXT(uint stride, uint count, const bool *pointer);
    public static void glGetPointervEXT(uint pname, void **params);
    public static void glIndexPointerEXT(uint type, uint stride, uint count, const void *pointer);
    public static void glNormalPointerEXT(uint type, uint stride, uint count, const void *pointer);
    public static void glTexCoordPointerEXT(int size, uint type, uint stride, uint count, const void *pointer);
    public static void glVertexPointerEXT(int size, uint type, uint stride, uint count, const void *pointer);
    #endif
    #endif /* GL_EXT_vertex_array */

    #ifndef GL_EXT_vertex_array_bgra
    #define GL_EXT_vertex_array_bgra 1
    #endif /* GL_EXT_vertex_array_bgra */

    #ifndef GL_EXT_vertex_attrib_64bit
    #define GL_EXT_vertex_attrib_64bit 1
    public const uint GL_DOUBLE_VEC2_EXT = 0x8FFC;
    public const uint GL_DOUBLE_VEC3_EXT = 0x8FFD;
    public const uint GL_DOUBLE_VEC4_EXT = 0x8FFE;
    public const uint GL_DOUBLE_MAT2_EXT = 0x8F46;
    public const uint GL_DOUBLE_MAT3_EXT = 0x8F47;
    public const uint GL_DOUBLE_MAT4_EXT = 0x8F48;
    public const uint GL_DOUBLE_MAT2x3_EXT = 0x8F49;
    public const uint GL_DOUBLE_MAT2x4_EXT = 0x8F4A;
    public const uint GL_DOUBLE_MAT3x2_EXT = 0x8F4B;
    public const uint GL_DOUBLE_MAT3x4_EXT = 0x8F4C;
    public const uint GL_DOUBLE_MAT4x2_EXT = 0x8F4D;
    public const uint GL_DOUBLE_MAT4x3_EXT = 0x8F4E;
    private delegate void PFNGLVERTEXATTRIBL1DEXTPROC(uint index, double x);
    private delegate void PFNGLVERTEXATTRIBL2DEXTPROC(uint index, double x, double y);
    private delegate void PFNGLVERTEXATTRIBL3DEXTPROC(uint index, double x, double y, double z);
    private delegate void PFNGLVERTEXATTRIBL4DEXTPROC(uint index, double x, double y, double z, double w);
    private delegate void PFNGLVERTEXATTRIBL1DVEXTPROC(uint index, const double *v);
    private delegate void PFNGLVERTEXATTRIBL2DVEXTPROC(uint index, const double *v);
    private delegate void PFNGLVERTEXATTRIBL3DVEXTPROC(uint index, const double *v);
    private delegate void PFNGLVERTEXATTRIBL4DVEXTPROC(uint index, const double *v);
    private delegate void PFNGLVERTEXATTRIBLPOINTEREXTPROC(uint index, int size, uint type, uint stride, const void *pointer);
    private delegate void PFNGLGETVERTEXATTRIBLDVEXTPROC(uint index, uint pname, double *params);
    #ifdef GL_GLEXT_PROTOTYPES
    public static void glVertexAttribL1dEXT(uint index, double x);
    public static void glVertexAttribL2dEXT(uint index, double x, double y);
    public static void glVertexAttribL3dEXT(uint index, double x, double y, double z);
    public static void glVertexAttribL4dEXT(uint index, double x, double y, double z, double w);
    public static void glVertexAttribL1dvEXT(uint index, const double *v);
    public static void glVertexAttribL2dvEXT(uint index, const double *v);
    public static void glVertexAttribL3dvEXT(uint index, const double *v);
    public static void glVertexAttribL4dvEXT(uint index, const double *v);
    public static void glVertexAttribLPointerEXT(uint index, int size, uint type, uint stride, const void *pointer);
    public static void glGetVertexAttribLdvEXT(uint index, uint pname, double *params);
    #endif
    #endif /* GL_EXT_vertex_attrib_64bit */

    #ifndef GL_EXT_vertex_shader
    #define GL_EXT_vertex_shader 1
    public const uint GL_VERTEX_SHADER_EXT = 0x8780;
    public const uint GL_VERTEX_SHADER_BINDING_EXT = 0x8781;
    public const uint GL_OP_INDEX_EXT = 0x8782;
    public const uint GL_OP_NEGATE_EXT = 0x8783;
    public const uint GL_OP_DOT3_EXT = 0x8784;
    public const uint GL_OP_DOT4_EXT = 0x8785;
    public const uint GL_OP_MUL_EXT = 0x8786;
    public const uint GL_OP_ADD_EXT = 0x8787;
    public const uint GL_OP_MADD_EXT = 0x8788;
    public const uint GL_OP_FRAC_EXT = 0x8789;
    public const uint GL_OP_MAX_EXT = 0x878A;
    public const uint GL_OP_MIN_EXT = 0x878B;
    public const uint GL_OP_SET_GE_EXT = 0x878C;
    public const uint GL_OP_SET_LT_EXT = 0x878D;
    public const uint GL_OP_CLAMP_EXT = 0x878E;
    public const uint GL_OP_FLOOR_EXT = 0x878F;
    public const uint GL_OP_ROUND_EXT = 0x8790;
    public const uint GL_OP_EXP_BASE_2_EXT = 0x8791;
    public const uint GL_OP_LOG_BASE_2_EXT = 0x8792;
    public const uint GL_OP_POWER_EXT = 0x8793;
    public const uint GL_OP_RECIP_EXT = 0x8794;
    public const uint GL_OP_RECIP_SQRT_EXT = 0x8795;
    public const uint GL_OP_SUB_EXT = 0x8796;
    public const uint GL_OP_CROSS_PRODUCT_EXT = 0x8797;
    public const uint GL_OP_MULTIPLY_MATRIX_EXT = 0x8798;
    public const uint GL_OP_MOV_EXT = 0x8799;
    public const uint GL_OUTPUT_VERTEX_EXT = 0x879A;
    public const uint GL_OUTPUT_COLOR0_EXT = 0x879B;
    public const uint GL_OUTPUT_COLOR1_EXT = 0x879C;
    public const uint GL_OUTPUT_TEXTURE_COORD0_EXT = 0x879D;
    public const uint GL_OUTPUT_TEXTURE_COORD1_EXT = 0x879E;
    public const uint GL_OUTPUT_TEXTURE_COORD2_EXT = 0x879F;
    public const uint GL_OUTPUT_TEXTURE_COORD3_EXT = 0x87A0;
    public const uint GL_OUTPUT_TEXTURE_COORD4_EXT = 0x87A1;
    public const uint GL_OUTPUT_TEXTURE_COORD5_EXT = 0x87A2;
    public const uint GL_OUTPUT_TEXTURE_COORD6_EXT = 0x87A3;
    public const uint GL_OUTPUT_TEXTURE_COORD7_EXT = 0x87A4;
    public const uint GL_OUTPUT_TEXTURE_COORD8_EXT = 0x87A5;
    public const uint GL_OUTPUT_TEXTURE_COORD9_EXT = 0x87A6;
    public const uint GL_OUTPUT_TEXTURE_COORD10_EXT = 0x87A7;
    public const uint GL_OUTPUT_TEXTURE_COORD11_EXT = 0x87A8;
    public const uint GL_OUTPUT_TEXTURE_COORD12_EXT = 0x87A9;
    public const uint GL_OUTPUT_TEXTURE_COORD13_EXT = 0x87AA;
    public const uint GL_OUTPUT_TEXTURE_COORD14_EXT = 0x87AB;
    public const uint GL_OUTPUT_TEXTURE_COORD15_EXT = 0x87AC;
    public const uint GL_OUTPUT_TEXTURE_COORD16_EXT = 0x87AD;
    public const uint GL_OUTPUT_TEXTURE_COORD17_EXT = 0x87AE;
    public const uint GL_OUTPUT_TEXTURE_COORD18_EXT = 0x87AF;
    public const uint GL_OUTPUT_TEXTURE_COORD19_EXT = 0x87B0;
    public const uint GL_OUTPUT_TEXTURE_COORD20_EXT = 0x87B1;
    public const uint GL_OUTPUT_TEXTURE_COORD21_EXT = 0x87B2;
    public const uint GL_OUTPUT_TEXTURE_COORD22_EXT = 0x87B3;
    public const uint GL_OUTPUT_TEXTURE_COORD23_EXT = 0x87B4;
    public const uint GL_OUTPUT_TEXTURE_COORD24_EXT = 0x87B5;
    public const uint GL_OUTPUT_TEXTURE_COORD25_EXT = 0x87B6;
    public const uint GL_OUTPUT_TEXTURE_COORD26_EXT = 0x87B7;
    public const uint GL_OUTPUT_TEXTURE_COORD27_EXT = 0x87B8;
    public const uint GL_OUTPUT_TEXTURE_COORD28_EXT = 0x87B9;
    public const uint GL_OUTPUT_TEXTURE_COORD29_EXT = 0x87BA;
    public const uint GL_OUTPUT_TEXTURE_COORD30_EXT = 0x87BB;
    public const uint GL_OUTPUT_TEXTURE_COORD31_EXT = 0x87BC;
    public const uint GL_OUTPUT_FOG_EXT = 0x87BD;
    public const uint GL_SCALAR_EXT = 0x87BE;
    public const uint GL_VECTOR_EXT = 0x87BF;
    public const uint GL_MATRIX_EXT = 0x87C0;
    public const uint GL_VARIANT_EXT = 0x87C1;
    public const uint GL_INVARIANT_EXT = 0x87C2;
    public const uint GL_LOCAL_CONSTANT_EXT = 0x87C3;
    public const uint GL_LOCAL_EXT = 0x87C4;
    public const uint GL_MAX_VERTEX_SHADER_INSTRUCTIONS_EXT = 0x87C5;
    public const uint GL_MAX_VERTEX_SHADER_VARIANTS_EXT = 0x87C6;
    public const uint GL_MAX_VERTEX_SHADER_INVARIANTS_EXT = 0x87C7;
    public const uint GL_MAX_VERTEX_SHADER_LOCAL_CONSTANTS_EXT = 0x87C8;
    public const uint GL_MAX_VERTEX_SHADER_LOCALS_EXT = 0x87C9;
    public const uint GL_MAX_OPTIMIZED_VERTEX_SHADER_INSTRUCTIONS_EXT = 0x87CA;
    public const uint GL_MAX_OPTIMIZED_VERTEX_SHADER_VARIANTS_EXT = 0x87CB;
    public const uint GL_MAX_OPTIMIZED_VERTEX_SHADER_LOCAL_CONSTANTS_EXT = 0x87CC;
    public const uint GL_MAX_OPTIMIZED_VERTEX_SHADER_INVARIANTS_EXT = 0x87CD;
    public const uint GL_MAX_OPTIMIZED_VERTEX_SHADER_LOCALS_EXT = 0x87CE;
    public const uint GL_VERTEX_SHADER_INSTRUCTIONS_EXT = 0x87CF;
    public const uint GL_VERTEX_SHADER_VARIANTS_EXT = 0x87D0;
    public const uint GL_VERTEX_SHADER_INVARIANTS_EXT = 0x87D1;
    public const uint GL_VERTEX_SHADER_LOCAL_CONSTANTS_EXT = 0x87D2;
    public const uint GL_VERTEX_SHADER_LOCALS_EXT = 0x87D3;
    public const uint GL_VERTEX_SHADER_OPTIMIZED_EXT = 0x87D4;
    public const uint GL_X_EXT = 0x87D5;
    public const uint GL_Y_EXT = 0x87D6;
    public const uint GL_Z_EXT = 0x87D7;
    public const uint GL_W_EXT = 0x87D8;
    public const uint GL_NEGATIVE_X_EXT = 0x87D9;
    public const uint GL_NEGATIVE_Y_EXT = 0x87DA;
    public const uint GL_NEGATIVE_Z_EXT = 0x87DB;
    public const uint GL_NEGATIVE_W_EXT = 0x87DC;
    public const uint GL_ZERO_EXT = 0x87DD;
    public const uint GL_ONE_EXT = 0x87DE;
    public const uint GL_NEGATIVE_ONE_EXT = 0x87DF;
    public const uint GL_NORMALIZED_RANGE_EXT = 0x87E0;
    public const uint GL_FULL_RANGE_EXT = 0x87E1;
    public const uint GL_CURRENT_VERTEX_EXT = 0x87E2;
    public const uint GL_MVP_MATRIX_EXT = 0x87E3;
    public const uint GL_VARIANT_VALUE_EXT = 0x87E4;
    public const uint GL_VARIANT_DATATYPE_EXT = 0x87E5;
    public const uint GL_VARIANT_ARRAY_STRIDE_EXT = 0x87E6;
    public const uint GL_VARIANT_ARRAY_TYPE_EXT = 0x87E7;
    public const uint GL_VARIANT_ARRAY_EXT = 0x87E8;
    public const uint GL_VARIANT_ARRAY_POINTER_EXT = 0x87E9;
    public const uint GL_INVARIANT_VALUE_EXT = 0x87EA;
    public const uint GL_INVARIANT_DATATYPE_EXT = 0x87EB;
    public const uint GL_LOCAL_CONSTANT_VALUE_EXT = 0x87EC;
    public const uint GL_LOCAL_CONSTANT_DATATYPE_EXT = 0x87ED;
    private delegate void PFNGLBEGINVERTEXSHADEREXTPROC(void);
    private delegate void PFNGLENDVERTEXSHADEREXTPROC(void);
    private delegate void PFNGLBINDVERTEXSHADEREXTPROC(uint id);
    private delegate uint PFNGLGENVERTEXSHADERSEXTPROC(uint range);
    private delegate void PFNGLDELETEVERTEXSHADEREXTPROC(uint id);
    private delegate void PFNGLSHADEROP1EXTPROC(uint op, uint res, uint arg1);
    private delegate void PFNGLSHADEROP2EXTPROC(uint op, uint res, uint arg1, uint arg2);
    private delegate void PFNGLSHADEROP3EXTPROC(uint op, uint res, uint arg1, uint arg2, uint arg3);
    private delegate void PFNGLSWIZZLEEXTPROC(uint res, uint in, uint outX, uint outY, uint outZ, uint outW);
    private delegate void PFNGLWRITEMASKEXTPROC(uint res, uint in, uint outX, uint outY, uint outZ, uint outW);
    private delegate void PFNGLINSERTCOMPONENTEXTPROC(uint res, uint src, uint num);
    private delegate void PFNGLEXTRACTCOMPONENTEXTPROC(uint res, uint src, uint num);
    private delegate uint PFNGLGENSYMBOLSEXTPROC(uint datatype, uint storagetype, uint range, uint components);
    private delegate void PFNGLSETINVARIANTEXTPROC(uint id, uint type, const void *addr);
    private delegate void PFNGLSETLOCALCONSTANTEXTPROC(uint id, uint type, const void *addr);
    private delegate void PFNGLVARIANTBVEXTPROC(uint id, const sbyte *addr);
    private delegate void PFNGLVARIANTSVEXTPROC(uint id, const short *addr);
    private delegate void PFNGLVARIANTIVEXTPROC(uint id, const int *addr);
    private delegate void PFNGLVARIANTFVEXTPROC(uint id, const float *addr);
    private delegate void PFNGLVARIANTDVEXTPROC(uint id, const double *addr);
    private delegate void PFNGLVARIANTUBVEXTPROC(uint id, const byte *addr);
    private delegate void PFNGLVARIANTUSVEXTPROC(uint id, const ushort *addr);
    private delegate void PFNGLVARIANTUIVEXTPROC(uint id, const uint *addr);
    private delegate void PFNGLVARIANTPOINTEREXTPROC(uint id, uint type, uint stride, const void *addr);
    private delegate void PFNGLENABLEVARIANTCLIENTSTATEEXTPROC(uint id);
    private delegate void PFNGLDISABLEVARIANTCLIENTSTATEEXTPROC(uint id);
    private delegate uint PFNGLBINDLIGHTPARAMETEREXTPROC(uint light, uint value);
    private delegate uint PFNGLBINDMATERIALPARAMETEREXTPROC(uint face, uint value);
    private delegate uint PFNGLBINDTEXGENPARAMETEREXTPROC(uint unit, uint coord, uint value);
    private delegate uint PFNGLBINDTEXTUREUNITPARAMETEREXTPROC(uint unit, uint value);
    private delegate uint PFNGLBINDPARAMETEREXTPROC(uint value);
    private delegate bool PFNGLISVARIANTENABLEDEXTPROC(uint id, uint cap);
    private delegate void PFNGLGETVARIANTBOOLEANVEXTPROC(uint id, uint value, bool *data);
    private delegate void PFNGLGETVARIANTINTEGERVEXTPROC(uint id, uint value, int *data);
    private delegate void PFNGLGETVARIANTFLOATVEXTPROC(uint id, uint value, float *data);
    private delegate void PFNGLGETVARIANTPOINTERVEXTPROC(uint id, uint value, void **data);
    private delegate void PFNGLGETINVARIANTBOOLEANVEXTPROC(uint id, uint value, bool *data);
    private delegate void PFNGLGETINVARIANTINTEGERVEXTPROC(uint id, uint value, int *data);
    private delegate void PFNGLGETINVARIANTFLOATVEXTPROC(uint id, uint value, float *data);
    private delegate void PFNGLGETLOCALCONSTANTBOOLEANVEXTPROC(uint id, uint value, bool *data);
    private delegate void PFNGLGETLOCALCONSTANTINTEGERVEXTPROC(uint id, uint value, int *data);
    private delegate void PFNGLGETLOCALCONSTANTFLOATVEXTPROC(uint id, uint value, float *data);
    #ifdef GL_GLEXT_PROTOTYPES
    public static void glBeginVertexShaderEXT(void);
    public static void glEndVertexShaderEXT(void);
    public static void glBindVertexShaderEXT(uint id);
    public static uint glGenVertexShadersEXT(uint range);
    public static void glDeleteVertexShaderEXT(uint id);
    public static void glShaderOp1EXT(uint op, uint res, uint arg1);
    public static void glShaderOp2EXT(uint op, uint res, uint arg1, uint arg2);
    public static void glShaderOp3EXT(uint op, uint res, uint arg1, uint arg2, uint arg3);
    public static void glSwizzleEXT(uint res, uint in, uint outX, uint outY, uint outZ, uint outW);
    public static void glWriteMaskEXT(uint res, uint in, uint outX, uint outY, uint outZ, uint outW);
    public static void glInsertComponentEXT(uint res, uint src, uint num);
    public static void glExtractComponentEXT(uint res, uint src, uint num);
    public static uint glGenSymbolsEXT(uint datatype, uint storagetype, uint range, uint components);
    public static void glSetInvariantEXT(uint id, uint type, const void *addr);
    public static void glSetLocalConstantEXT(uint id, uint type, const void *addr);
    public static void glVariantbvEXT(uint id, const sbyte *addr);
    public static void glVariantsvEXT(uint id, const short *addr);
    public static void glVariantivEXT(uint id, const int *addr);
    public static void glVariantfvEXT(uint id, const float *addr);
    public static void glVariantdvEXT(uint id, const double *addr);
    public static void glVariantubvEXT(uint id, const byte *addr);
    public static void glVariantusvEXT(uint id, const ushort *addr);
    public static void glVariantuivEXT(uint id, const uint *addr);
    public static void glVariantPointerEXT(uint id, uint type, uint stride, const void *addr);
    public static void glEnableVariantClientStateEXT(uint id);
    public static void glDisableVariantClientStateEXT(uint id);
    public static uint glBindLightParameterEXT(uint light, uint value);
    public static uint glBindMaterialParameterEXT(uint face, uint value);
    public static uint glBindTexGenParameterEXT(uint unit, uint coord, uint value);
    public static uint glBindTextureUnitParameterEXT(uint unit, uint value);
    public static uint glBindParameterEXT(uint value);
    public static bool glIsVariantEnabledEXT(uint id, uint cap);
    public static void glGetVariantBooleanvEXT(uint id, uint value, bool *data);
    public static void glGetVariantIntegervEXT(uint id, uint value, int *data);
    public static void glGetVariantFloatvEXT(uint id, uint value, float *data);
    public static void glGetVariantPointervEXT(uint id, uint value, void **data);
    public static void glGetInvariantBooleanvEXT(uint id, uint value, bool *data);
    public static void glGetInvariantIntegervEXT(uint id, uint value, int *data);
    public static void glGetInvariantFloatvEXT(uint id, uint value, float *data);
    public static void glGetLocalConstantBooleanvEXT(uint id, uint value, bool *data);
    public static void glGetLocalConstantIntegervEXT(uint id, uint value, int *data);
    public static void glGetLocalConstantFloatvEXT(uint id, uint value, float *data);
    #endif
    #endif /* GL_EXT_vertex_shader */

    #ifndef GL_EXT_vertex_weighting
    #define GL_EXT_vertex_weighting 1
    public const uint GL_MODELVIEW0_STACK_DEPTH_EXT = 0x0BA3;
    public const uint GL_MODELVIEW1_STACK_DEPTH_EXT = 0x8502;
    public const uint GL_MODELVIEW0_MATRIX_EXT = 0x0BA6;
    public const uint GL_MODELVIEW1_MATRIX_EXT = 0x8506;
    public const uint GL_VERTEX_WEIGHTING_EXT = 0x8509;
    public const uint GL_MODELVIEW0_EXT = 0x1700;
    public const uint GL_MODELVIEW1_EXT = 0x850A;
    public const uint GL_CURRENT_VERTEX_WEIGHT_EXT = 0x850B;
    public const uint GL_VERTEX_WEIGHT_ARRAY_EXT = 0x850C;
    public const uint GL_VERTEX_WEIGHT_ARRAY_SIZE_EXT = 0x850D;
    public const uint GL_VERTEX_WEIGHT_ARRAY_TYPE_EXT = 0x850E;
    public const uint GL_VERTEX_WEIGHT_ARRAY_STRIDE_EXT = 0x850F;
    public const uint GL_VERTEX_WEIGHT_ARRAY_POINTER_EXT = 0x8510;
    private delegate void PFNGLVERTEXWEIGHTFEXTPROC(float weight);
    private delegate void PFNGLVERTEXWEIGHTFVEXTPROC(const float *weight);
    private delegate void PFNGLVERTEXWEIGHTPOINTEREXTPROC(int size, uint type, uint stride, const void *pointer);
    #ifdef GL_GLEXT_PROTOTYPES
    public static void glVertexWeightfEXT(float weight);
    public static void glVertexWeightfvEXT(const float *weight);
    public static void glVertexWeightPointerEXT(int size, uint type, uint stride, const void *pointer);
    #endif
    #endif /* GL_EXT_vertex_weighting */

    #ifndef GL_EXT_x11_sync_object
    #define GL_EXT_x11_sync_object 1
    public const uint GL_SYNC_X11_FENCE_EXT = 0x90E1;
    private delegate GLsync PFNGLIMPORTSYNCEXTPROC(uint external_sync_type, intptr external_sync, uint flags);
    #ifdef GL_GLEXT_PROTOTYPES
    public static GLsync glImportSyncEXT(uint external_sync_type, intptr external_sync, uint flags);
    #endif
    #endif /* GL_EXT_x11_sync_object */

    #ifndef GL_GREMEDY_frame_terminator
    #define GL_GREMEDY_frame_terminator 1
    private delegate void PFNGLFRAMETERMINATORGREMEDYPROC(void);
    #ifdef GL_GLEXT_PROTOTYPES
    public static void glFrameTerminatorGREMEDY(void);
    #endif
    #endif /* GL_GREMEDY_frame_terminator */

    #ifndef GL_GREMEDY_string_marker
    #define GL_GREMEDY_string_marker 1
    private delegate void PFNGLSTRINGMARKERGREMEDYPROC(uint len, const void *string);
    #ifdef GL_GLEXT_PROTOTYPES
    public static void glStringMarkerGREMEDY(uint len, const void *string);
    #endif
    #endif /* GL_GREMEDY_string_marker */

    #ifndef GL_HP_convolution_border_modes
    #define GL_HP_convolution_border_modes 1
    public const uint GL_IGNORE_BORDER_HP = 0x8150;
    public const uint GL_CONSTANT_BORDER_HP = 0x8151;
    public const uint GL_REPLICATE_BORDER_HP = 0x8153;
    public const uint GL_CONVOLUTION_BORDER_COLOR_HP = 0x8154;
    #endif /* GL_HP_convolution_border_modes */

    #ifndef GL_HP_image_transform
    #define GL_HP_image_transform 1
    public const uint GL_IMAGE_SCALE_X_HP = 0x8155;
    public const uint GL_IMAGE_SCALE_Y_HP = 0x8156;
    public const uint GL_IMAGE_TRANSLATE_X_HP = 0x8157;
    public const uint GL_IMAGE_TRANSLATE_Y_HP = 0x8158;
    public const uint GL_IMAGE_ROTATE_ANGLE_HP = 0x8159;
    public const uint GL_IMAGE_ROTATE_ORIGIN_X_HP = 0x815A;
    public const uint GL_IMAGE_ROTATE_ORIGIN_Y_HP = 0x815B;
    public const uint GL_IMAGE_MAG_FILTER_HP = 0x815C;
    public const uint GL_IMAGE_MIN_FILTER_HP = 0x815D;
    public const uint GL_IMAGE_CUBIC_WEIGHT_HP = 0x815E;
    public const uint GL_CUBIC_HP = 0x815F;
    public const uint GL_AVERAGE_HP = 0x8160;
    public const uint GL_IMAGE_TRANSFORM_2D_HP = 0x8161;
    public const uint GL_POST_IMAGE_TRANSFORM_COLOR_TABLE_HP = 0x8162;
    public const uint GL_PROXY_POST_IMAGE_TRANSFORM_COLOR_TABLE_HP = 0x8163;
    private delegate void PFNGLIMAGETRANSFORMPARAMETERIHPPROC(uint target, uint pname, int param);
    private delegate void PFNGLIMAGETRANSFORMPARAMETERFHPPROC(uint target, uint pname, float param);
    private delegate void PFNGLIMAGETRANSFORMPARAMETERIVHPPROC(uint target, uint pname, const int *params);
    private delegate void PFNGLIMAGETRANSFORMPARAMETERFVHPPROC(uint target, uint pname, const float *params);
    private delegate void PFNGLGETIMAGETRANSFORMPARAMETERIVHPPROC(uint target, uint pname, int *params);
    private delegate void PFNGLGETIMAGETRANSFORMPARAMETERFVHPPROC(uint target, uint pname, float *params);
    #ifdef GL_GLEXT_PROTOTYPES
    public static void glImageTransformParameteriHP(uint target, uint pname, int param);
    public static void glImageTransformParameterfHP(uint target, uint pname, float param);
    public static void glImageTransformParameterivHP(uint target, uint pname, const int *params);
    public static void glImageTransformParameterfvHP(uint target, uint pname, const float *params);
    public static void glGetImageTransformParameterivHP(uint target, uint pname, int *params);
    public static void glGetImageTransformParameterfvHP(uint target, uint pname, float *params);
    #endif
    #endif /* GL_HP_image_transform */

    #ifndef GL_HP_occlusion_test
    #define GL_HP_occlusion_test 1
    public const uint GL_OCCLUSION_TEST_HP = 0x8165;
    public const uint GL_OCCLUSION_TEST_RESULT_HP = 0x8166;
    #endif /* GL_HP_occlusion_test */

    #ifndef GL_HP_texture_lighting
    #define GL_HP_texture_lighting 1
    public const uint GL_TEXTURE_LIGHTING_MODE_HP = 0x8167;
    public const uint GL_TEXTURE_POST_SPECULAR_HP = 0x8168;
    public const uint GL_TEXTURE_PRE_SPECULAR_HP = 0x8169;
    #endif /* GL_HP_texture_lighting */

    #ifndef GL_IBM_cull_vertex
    #define GL_IBM_cull_vertex 1
    #define GL_CULL_VERTEX_IBM                103050
    #endif /* GL_IBM_cull_vertex */

    #ifndef GL_IBM_multimode_draw_arrays
    #define GL_IBM_multimode_draw_arrays 1
    private delegate void PFNGLMULTIMODEDRAWARRAYSIBMPROC(const uint *mode, const int *first, const uint *count, uint primcount, int modestride);
    private delegate void PFNGLMULTIMODEDRAWELEMENTSIBMPROC(const uint *mode, const uint *count, uint type, const void *const*indices, uint primcount, int modestride);
    #ifdef GL_GLEXT_PROTOTYPES
    public static void glMultiModeDrawArraysIBM(const uint *mode, const int *first, const uint *count, uint primcount, int modestride);
    public static void glMultiModeDrawElementsIBM(const uint *mode, const uint *count, uint type, const void *const*indices, uint primcount, int modestride);
    #endif
    #endif /* GL_IBM_multimode_draw_arrays */

    #ifndef GL_IBM_rasterpos_clip
    #define GL_IBM_rasterpos_clip 1
    public const uint GL_RASTER_POSITION_UNCLIPPED_IBM = 0x19262;
    #endif /* GL_IBM_rasterpos_clip */

    #ifndef GL_IBM_static_data
    #define GL_IBM_static_data 1
    #define GL_ALL_STATIC_DATA_IBM            103060
    #define GL_STATIC_VERTEX_ARRAY_IBM        103061
    private delegate void PFNGLFLUSHSTATICDATAIBMPROC(uint target);
    #ifdef GL_GLEXT_PROTOTYPES
    public static void glFlushStaticDataIBM(uint target);
    #endif
    #endif /* GL_IBM_static_data */

    #ifndef GL_IBM_texture_mirrored_repeat
    #define GL_IBM_texture_mirrored_repeat 1
    public const uint GL_MIRRORED_REPEAT_IBM = 0x8370;
    #endif /* GL_IBM_texture_mirrored_repeat */

    #ifndef GL_IBM_vertex_array_lists
    #define GL_IBM_vertex_array_lists 1
    #define GL_VERTEX_ARRAY_LIST_IBM          103070
    #define GL_NORMAL_ARRAY_LIST_IBM          103071
    #define GL_COLOR_ARRAY_LIST_IBM           103072
    #define GL_INDEX_ARRAY_LIST_IBM           103073
    #define GL_TEXTURE_COORD_ARRAY_LIST_IBM   103074
    #define GL_EDGE_FLAG_ARRAY_LIST_IBM       103075
    #define GL_FOG_COORDINATE_ARRAY_LIST_IBM  103076
    #define GL_SECONDARY_COLOR_ARRAY_LIST_IBM 103077
    #define GL_VERTEX_ARRAY_LIST_STRIDE_IBM   103080
    #define GL_NORMAL_ARRAY_LIST_STRIDE_IBM   103081
    #define GL_COLOR_ARRAY_LIST_STRIDE_IBM    103082
    #define GL_INDEX_ARRAY_LIST_STRIDE_IBM    103083
    #define GL_TEXTURE_COORD_ARRAY_LIST_STRIDE_IBM 103084
    #define GL_EDGE_FLAG_ARRAY_LIST_STRIDE_IBM 103085
    #define GL_FOG_COORDINATE_ARRAY_LIST_STRIDE_IBM 103086
    #define GL_SECONDARY_COLOR_ARRAY_LIST_STRIDE_IBM 103087
    private delegate void PFNGLCOLORPOINTERLISTIBMPROC(int size, uint type, int stride, const void **pointer, int ptrstride);
    private delegate void PFNGLSECONDARYCOLORPOINTERLISTIBMPROC(int size, uint type, int stride, const void **pointer, int ptrstride);
    private delegate void PFNGLEDGEFLAGPOINTERLISTIBMPROC(int stride, const bool **pointer, int ptrstride);
    private delegate void PFNGLFOGCOORDPOINTERLISTIBMPROC(uint type, int stride, const void **pointer, int ptrstride);
    private delegate void PFNGLINDEXPOINTERLISTIBMPROC(uint type, int stride, const void **pointer, int ptrstride);
    private delegate void PFNGLNORMALPOINTERLISTIBMPROC(uint type, int stride, const void **pointer, int ptrstride);
    private delegate void PFNGLTEXCOORDPOINTERLISTIBMPROC(int size, uint type, int stride, const void **pointer, int ptrstride);
    private delegate void PFNGLVERTEXPOINTERLISTIBMPROC(int size, uint type, int stride, const void **pointer, int ptrstride);
    #ifdef GL_GLEXT_PROTOTYPES
    public static void glColorPointerListIBM(int size, uint type, int stride, const void **pointer, int ptrstride);
    public static void glSecondaryColorPointerListIBM(int size, uint type, int stride, const void **pointer, int ptrstride);
    public static void glEdgeFlagPointerListIBM(int stride, const bool **pointer, int ptrstride);
    public static void glFogCoordPointerListIBM(uint type, int stride, const void **pointer, int ptrstride);
    public static void glIndexPointerListIBM(uint type, int stride, const void **pointer, int ptrstride);
    public static void glNormalPointerListIBM(uint type, int stride, const void **pointer, int ptrstride);
    public static void glTexCoordPointerListIBM(int size, uint type, int stride, const void **pointer, int ptrstride);
    public static void glVertexPointerListIBM(int size, uint type, int stride, const void **pointer, int ptrstride);
    #endif
    #endif /* GL_IBM_vertex_array_lists */

    #ifndef GL_INGR_blend_func_separate
    #define GL_INGR_blend_func_separate 1
    private delegate void PFNGLBLENDFUNCSEPARATEINGRPROC(uint sfactorRGB, uint dfactorRGB, uint sfactorAlpha, uint dfactorAlpha);
    #ifdef GL_GLEXT_PROTOTYPES
    public static void glBlendFuncSeparateINGR(uint sfactorRGB, uint dfactorRGB, uint sfactorAlpha, uint dfactorAlpha);
    #endif
    #endif /* GL_INGR_blend_func_separate */

    #ifndef GL_INGR_color_clamp
    #define GL_INGR_color_clamp 1
    public const uint GL_RED_MIN_CLAMP_INGR = 0x8560;
    public const uint GL_GREEN_MIN_CLAMP_INGR = 0x8561;
    public const uint GL_BLUE_MIN_CLAMP_INGR = 0x8562;
    public const uint GL_ALPHA_MIN_CLAMP_INGR = 0x8563;
    public const uint GL_RED_MAX_CLAMP_INGR = 0x8564;
    public const uint GL_GREEN_MAX_CLAMP_INGR = 0x8565;
    public const uint GL_BLUE_MAX_CLAMP_INGR = 0x8566;
    public const uint GL_ALPHA_MAX_CLAMP_INGR = 0x8567;
    #endif /* GL_INGR_color_clamp */

    #ifndef GL_INGR_interlace_read
    #define GL_INGR_interlace_read 1
    public const uint GL_INTERLACE_READ_INGR = 0x8568;
    #endif /* GL_INGR_interlace_read */

    #ifndef GL_INTEL_map_texture
    #define GL_INTEL_map_texture 1
    public const uint GL_TEXTURE_MEMORY_LAYOUT_INTEL = 0x83FF;
    #define GL_LAYOUT_DEFAULT_INTEL           0
    #define GL_LAYOUT_LINEAR_INTEL            1
    #define GL_LAYOUT_LINEAR_CPU_CACHED_INTEL 2
    private delegate void PFNGLSYNCTEXTUREINTELPROC(uint texture);
    private delegate void PFNGLUNMAPTEXTURE2DINTELPROC(uint texture, int level);
    private delegate void* PFNGLMAPTEXTURE2DINTELPROC(uint texture, int level, uint access, int *stride, uint *layout);
    #ifdef GL_GLEXT_PROTOTYPES
    public static void glSyncTextureINTEL(uint texture);
    public static void glUnmapTexture2DINTEL(uint texture, int level);
    public static void* glMapTexture2DINTEL(uint texture, int level, uint access, int *stride, uint *layout);
    #endif
    #endif /* GL_INTEL_map_texture */

    #ifndef GL_INTEL_parallel_arrays
    #define GL_INTEL_parallel_arrays 1
    public const uint GL_PARALLEL_ARRAYS_INTEL = 0x83F4;
    public const uint GL_VERTEX_ARRAY_PARALLEL_POINTERS_INTEL = 0x83F5;
    public const uint GL_NORMAL_ARRAY_PARALLEL_POINTERS_INTEL = 0x83F6;
    public const uint GL_COLOR_ARRAY_PARALLEL_POINTERS_INTEL = 0x83F7;
    public const uint GL_TEXTURE_COORD_ARRAY_PARALLEL_POINTERS_INTEL = 0x83F8;
    private delegate void PFNGLVERTEXPOINTERVINTELPROC(int size, uint type, const void **pointer);
    private delegate void PFNGLNORMALPOINTERVINTELPROC(uint type, const void **pointer);
    private delegate void PFNGLCOLORPOINTERVINTELPROC(int size, uint type, const void **pointer);
    private delegate void PFNGLTEXCOORDPOINTERVINTELPROC(int size, uint type, const void **pointer);
    #ifdef GL_GLEXT_PROTOTYPES
    public static void glVertexPointervINTEL(int size, uint type, const void **pointer);
    public static void glNormalPointervINTEL(uint type, const void **pointer);
    public static void glColorPointervINTEL(int size, uint type, const void **pointer);
    public static void glTexCoordPointervINTEL(int size, uint type, const void **pointer);
    #endif
    #endif /* GL_INTEL_parallel_arrays */

    #ifndef GL_MESAX_texture_stack
    #define GL_MESAX_texture_stack 1
    public const uint GL_TEXTURE_1D_STACK_MESAX = 0x8759;
    public const uint GL_TEXTURE_2D_STACK_MESAX = 0x875A;
    public const uint GL_PROXY_TEXTURE_1D_STACK_MESAX = 0x875B;
    public const uint GL_PROXY_TEXTURE_2D_STACK_MESAX = 0x875C;
    public const uint GL_TEXTURE_1D_STACK_BINDING_MESAX = 0x875D;
    public const uint GL_TEXTURE_2D_STACK_BINDING_MESAX = 0x875E;
    #endif /* GL_MESAX_texture_stack */

    #ifndef GL_MESA_pack_invert
    #define GL_MESA_pack_invert 1
    public const uint GL_PACK_INVERT_MESA = 0x8758;
    #endif /* GL_MESA_pack_invert */

    #ifndef GL_MESA_resize_buffers
    #define GL_MESA_resize_buffers 1
    private delegate void PFNGLRESIZEBUFFERSMESAPROC(void);
    #ifdef GL_GLEXT_PROTOTYPES
    public static void glResizeBuffersMESA(void);
    #endif
    #endif /* GL_MESA_resize_buffers */

    #ifndef GL_MESA_window_pos
    #define GL_MESA_window_pos 1
    private delegate void PFNGLWINDOWPOS2DMESAPROC(double x, double y);
    private delegate void PFNGLWINDOWPOS2DVMESAPROC(const double *v);
    private delegate void PFNGLWINDOWPOS2FMESAPROC(float x, float y);
    private delegate void PFNGLWINDOWPOS2FVMESAPROC(const float *v);
    private delegate void PFNGLWINDOWPOS2IMESAPROC(int x, int y);
    private delegate void PFNGLWINDOWPOS2IVMESAPROC(const int *v);
    private delegate void PFNGLWINDOWPOS2SMESAPROC(short x, short y);
    private delegate void PFNGLWINDOWPOS2SVMESAPROC(const short *v);
    private delegate void PFNGLWINDOWPOS3DMESAPROC(double x, double y, double z);
    private delegate void PFNGLWINDOWPOS3DVMESAPROC(const double *v);
    private delegate void PFNGLWINDOWPOS3FMESAPROC(float x, float y, float z);
    private delegate void PFNGLWINDOWPOS3FVMESAPROC(const float *v);
    private delegate void PFNGLWINDOWPOS3IMESAPROC(int x, int y, int z);
    private delegate void PFNGLWINDOWPOS3IVMESAPROC(const int *v);
    private delegate void PFNGLWINDOWPOS3SMESAPROC(short x, short y, short z);
    private delegate void PFNGLWINDOWPOS3SVMESAPROC(const short *v);
    private delegate void PFNGLWINDOWPOS4DMESAPROC(double x, double y, double z, double w);
    private delegate void PFNGLWINDOWPOS4DVMESAPROC(const double *v);
    private delegate void PFNGLWINDOWPOS4FMESAPROC(float x, float y, float z, float w);
    private delegate void PFNGLWINDOWPOS4FVMESAPROC(const float *v);
    private delegate void PFNGLWINDOWPOS4IMESAPROC(int x, int y, int z, int w);
    private delegate void PFNGLWINDOWPOS4IVMESAPROC(const int *v);
    private delegate void PFNGLWINDOWPOS4SMESAPROC(short x, short y, short z, short w);
    private delegate void PFNGLWINDOWPOS4SVMESAPROC(const short *v);
    #ifdef GL_GLEXT_PROTOTYPES
    public static void glWindowPos2dMESA(double x, double y);
    public static void glWindowPos2dvMESA(const double *v);
    public static void glWindowPos2fMESA(float x, float y);
    public static void glWindowPos2fvMESA(const float *v);
    public static void glWindowPos2iMESA(int x, int y);
    public static void glWindowPos2ivMESA(const int *v);
    public static void glWindowPos2sMESA(short x, short y);
    public static void glWindowPos2svMESA(const short *v);
    public static void glWindowPos3dMESA(double x, double y, double z);
    public static void glWindowPos3dvMESA(const double *v);
    public static void glWindowPos3fMESA(float x, float y, float z);
    public static void glWindowPos3fvMESA(const float *v);
    public static void glWindowPos3iMESA(int x, int y, int z);
    public static void glWindowPos3ivMESA(const int *v);
    public static void glWindowPos3sMESA(short x, short y, short z);
    public static void glWindowPos3svMESA(const short *v);
    public static void glWindowPos4dMESA(double x, double y, double z, double w);
    public static void glWindowPos4dvMESA(const double *v);
    public static void glWindowPos4fMESA(float x, float y, float z, float w);
    public static void glWindowPos4fvMESA(const float *v);
    public static void glWindowPos4iMESA(int x, int y, int z, int w);
    public static void glWindowPos4ivMESA(const int *v);
    public static void glWindowPos4sMESA(short x, short y, short z, short w);
    public static void glWindowPos4svMESA(const short *v);
    #endif
    #endif /* GL_MESA_window_pos */

    #ifndef GL_MESA_ycbcr_texture
    #define GL_MESA_ycbcr_texture 1
    public const uint GL_UNSIGNED_SHORT_8_8_MESA = 0x85BA;
    public const uint GL_UNSIGNED_SHORT_8_8_REV_MESA = 0x85BB;
    public const uint GL_YCBCR_MESA = 0x8757;
    #endif /* GL_MESA_ycbcr_texture */

    #ifndef GL_NVX_conditional_render
    #define GL_NVX_conditional_render 1
    private delegate void PFNGLBEGINCONDITIONALRENDERNVXPROC(uint id);
    private delegate void PFNGLENDCONDITIONALRENDERNVXPROC(void);
    #ifdef GL_GLEXT_PROTOTYPES
    public static void glBeginConditionalRenderNVX(uint id);
    public static void glEndConditionalRenderNVX(void);
    #endif
    #endif /* GL_NVX_conditional_render */

    #ifndef GL_NV_bindless_multi_draw_indirect
    #define GL_NV_bindless_multi_draw_indirect 1
    private delegate void PFNGLMULTIDRAWARRAYSINDIRECTBINDLESSNVPROC(uint mode, const void *indirect, uint drawCount, uint stride, int vertexBufferCount);
    private delegate void PFNGLMULTIDRAWELEMENTSINDIRECTBINDLESSNVPROC(uint mode, uint type, const void *indirect, uint drawCount, uint stride, int vertexBufferCount);
    #ifdef GL_GLEXT_PROTOTYPES
    public static void glMultiDrawArraysIndirectBindlessNV(uint mode, const void *indirect, uint drawCount, uint stride, int vertexBufferCount);
    public static void glMultiDrawElementsIndirectBindlessNV(uint mode, uint type, const void *indirect, uint drawCount, uint stride, int vertexBufferCount);
    #endif
    #endif /* GL_NV_bindless_multi_draw_indirect */

    #ifndef GL_NV_bindless_texture
    #define GL_NV_bindless_texture 1
    private delegate ulong PFNGLGETTEXTUREHANDLENVPROC(uint texture);
    private delegate ulong PFNGLGETTEXTURESAMPLERHANDLENVPROC(uint texture, uint sampler);
    private delegate void PFNGLMAKETEXTUREHANDLERESIDENTNVPROC(ulong handle);
    private delegate void PFNGLMAKETEXTUREHANDLENONRESIDENTNVPROC(ulong handle);
    private delegate ulong PFNGLGETIMAGEHANDLENVPROC(uint texture, int level, bool layered, int layer, uint format);
    private delegate void PFNGLMAKEIMAGEHANDLERESIDENTNVPROC(ulong handle, uint access);
    private delegate void PFNGLMAKEIMAGEHANDLENONRESIDENTNVPROC(ulong handle);
    private delegate void PFNGLUNIFORMHANDLEUI64NVPROC(int location, ulong value);
    private delegate void PFNGLUNIFORMHANDLEUI64VNVPROC(int location, uint count, const ulong *value);
    private delegate void PFNGLPROGRAMUNIFORMHANDLEUI64NVPROC(uint program, int location, ulong value);
    private delegate void PFNGLPROGRAMUNIFORMHANDLEUI64VNVPROC(uint program, int location, uint count, const ulong *values);
    private delegate bool PFNGLISTEXTUREHANDLERESIDENTNVPROC(ulong handle);
    private delegate bool PFNGLISIMAGEHANDLERESIDENTNVPROC(ulong handle);
    #ifdef GL_GLEXT_PROTOTYPES
    public static ulong glGetTextureHandleNV(uint texture);
    public static ulong glGetTextureSamplerHandleNV(uint texture, uint sampler);
    public static void glMakeTextureHandleResidentNV(ulong handle);
    public static void glMakeTextureHandleNonResidentNV(ulong handle);
    public static ulong glGetImageHandleNV(uint texture, int level, bool layered, int layer, uint format);
    public static void glMakeImageHandleResidentNV(ulong handle, uint access);
    public static void glMakeImageHandleNonResidentNV(ulong handle);
    public static void glUniformHandleui64NV(int location, ulong value);
    public static void glUniformHandleui64vNV(int location, uint count, const ulong *value);
    public static void glProgramUniformHandleui64NV(uint program, int location, ulong value);
    public static void glProgramUniformHandleui64vNV(uint program, int location, uint count, const ulong *values);
    public static bool glIsTextureHandleResidentNV(ulong handle);
    public static bool glIsImageHandleResidentNV(ulong handle);
    #endif
    #endif /* GL_NV_bindless_texture */

    #ifndef GL_NV_blend_equation_advanced
    #define GL_NV_blend_equation_advanced 1
    public const uint GL_BLEND_OVERLAP_NV = 0x9281;
    public const uint GL_BLEND_PREMULTIPLIED_SRC_NV = 0x9280;
    public const uint GL_COLORBURN_NV = 0x929A;
    public const uint GL_COLORDODGE_NV = 0x9299;
    public const uint GL_CONJOINT_NV = 0x9284;
    public const uint GL_CONTRAST_NV = 0x92A1;
    public const uint GL_DARKEN_NV = 0x9297;
    public const uint GL_DIFFERENCE_NV = 0x929E;
    public const uint GL_DISJOINT_NV = 0x9283;
    public const uint GL_DST_ATOP_NV = 0x928F;
    public const uint GL_DST_IN_NV = 0x928B;
    public const uint GL_DST_NV = 0x9287;
    public const uint GL_DST_OUT_NV = 0x928D;
    public const uint GL_DST_OVER_NV = 0x9289;
    public const uint GL_EXCLUSION_NV = 0x92A0;
    public const uint GL_HARDLIGHT_NV = 0x929B;
    public const uint GL_HARDMIX_NV = 0x92A9;
    public const uint GL_HSL_COLOR_NV = 0x92AF;
    public const uint GL_HSL_HUE_NV = 0x92AD;
    public const uint GL_HSL_LUMINOSITY_NV = 0x92B0;
    public const uint GL_HSL_SATURATION_NV = 0x92AE;
    public const uint GL_INVERT_OVG_NV = 0x92B4;
    public const uint GL_INVERT_RGB_NV = 0x92A3;
    public const uint GL_LIGHTEN_NV = 0x9298;
    public const uint GL_LINEARBURN_NV = 0x92A5;
    public const uint GL_LINEARDODGE_NV = 0x92A4;
    public const uint GL_LINEARLIGHT_NV = 0x92A7;
    public const uint GL_MINUS_CLAMPED_NV = 0x92B3;
    public const uint GL_MINUS_NV = 0x929F;
    public const uint GL_MULTIPLY_NV = 0x9294;
    public const uint GL_OVERLAY_NV = 0x9296;
    public const uint GL_PINLIGHT_NV = 0x92A8;
    public const uint GL_PLUS_CLAMPED_ALPHA_NV = 0x92B2;
    public const uint GL_PLUS_CLAMPED_NV = 0x92B1;
    public const uint GL_PLUS_DARKER_NV = 0x9292;
    public const uint GL_PLUS_NV = 0x9291;
    public const uint GL_SCREEN_NV = 0x9295;
    public const uint GL_SOFTLIGHT_NV = 0x929C;
    public const uint GL_SRC_ATOP_NV = 0x928E;
    public const uint GL_SRC_IN_NV = 0x928A;
    public const uint GL_SRC_NV = 0x9286;
    public const uint GL_SRC_OUT_NV = 0x928C;
    public const uint GL_SRC_OVER_NV = 0x9288;
    public const uint GL_UNCORRELATED_NV = 0x9282;
    public const uint GL_VIVIDLIGHT_NV = 0x92A6;
    private delegate void PFNGLBLENDPARAMETERINVPROC(uint pname, int value);
    private delegate void PFNGLBLENDBARRIERNVPROC(void);
    #ifdef GL_GLEXT_PROTOTYPES
    public static void glBlendParameteriNV(uint pname, int value);
    public static void glBlendBarrierNV(void);
    #endif
    #endif /* GL_NV_blend_equation_advanced */

    #ifndef GL_NV_blend_equation_advanced_coherent
    #define GL_NV_blend_equation_advanced_coherent 1
    public const uint GL_BLEND_ADVANCED_COHERENT_NV = 0x9285;
    #endif /* GL_NV_blend_equation_advanced_coherent */

    #ifndef GL_NV_blend_square
    #define GL_NV_blend_square 1
    #endif /* GL_NV_blend_square */

    #ifndef GL_NV_compute_program5
    #define GL_NV_compute_program5 1
    public const uint GL_COMPUTE_PROGRAM_NV = 0x90FB;
    public const uint GL_COMPUTE_PROGRAM_PARAMETER_BUFFER_NV = 0x90FC;
    #endif /* GL_NV_compute_program5 */

    #ifndef GL_NV_conditional_render
    #define GL_NV_conditional_render 1
    public const uint GL_QUERY_WAIT_NV = 0x8E13;
    public const uint GL_QUERY_NO_WAIT_NV = 0x8E14;
    public const uint GL_QUERY_BY_REGION_WAIT_NV = 0x8E15;
    public const uint GL_QUERY_BY_REGION_NO_WAIT_NV = 0x8E16;
    private delegate void PFNGLBEGINCONDITIONALRENDERNVPROC(uint id, uint mode);
    private delegate void PFNGLENDCONDITIONALRENDERNVPROC(void);
    #ifdef GL_GLEXT_PROTOTYPES
    public static void glBeginConditionalRenderNV(uint id, uint mode);
    public static void glEndConditionalRenderNV(void);
    #endif
    #endif /* GL_NV_conditional_render */

    #ifndef GL_NV_copy_depth_to_color
    #define GL_NV_copy_depth_to_color 1
    public const uint GL_DEPTH_STENCIL_TO_RGBA_NV = 0x886E;
    public const uint GL_DEPTH_STENCIL_TO_BGRA_NV = 0x886F;
    #endif /* GL_NV_copy_depth_to_color */

    #ifndef GL_NV_copy_image
    #define GL_NV_copy_image 1
    private delegate void PFNGLCOPYIMAGESUBDATANVPROC(uint srcName, uint srcTarget, int srcLevel, int srcX, int srcY, int srcZ, uint dstName, uint dstTarget, int dstLevel, int dstX, int dstY, int dstZ, uint width, uint height, uint depth);
    #ifdef GL_GLEXT_PROTOTYPES
    public static void glCopyImageSubDataNV(uint srcName, uint srcTarget, int srcLevel, int srcX, int srcY, int srcZ, uint dstName, uint dstTarget, int dstLevel, int dstX, int dstY, int dstZ, uint width, uint height, uint depth);
    #endif
    #endif /* GL_NV_copy_image */

    #ifndef GL_NV_deep_texture3D
    #define GL_NV_deep_texture3D 1
    public const uint GL_MAX_DEEP_3D_TEXTURE_WIDTH_HEIGHT_NV = 0x90D0;
    public const uint GL_MAX_DEEP_3D_TEXTURE_DEPTH_NV = 0x90D1;
    #endif /* GL_NV_deep_texture3D */

    #ifndef GL_NV_depth_buffer_float
    #define GL_NV_depth_buffer_float 1
    public const uint GL_DEPTH_COMPONENT32F_NV = 0x8DAB;
    public const uint GL_DEPTH32F_STENCIL8_NV = 0x8DAC;
    public const uint GL_FLOAT_32_UNSIGNED_INT_24_8_REV_NV = 0x8DAD;
    public const uint GL_DEPTH_BUFFER_FLOAT_MODE_NV = 0x8DAF;
    private delegate void PFNGLDEPTHRANGEDNVPROC(double zNear, double zFar);
    private delegate void PFNGLCLEARDEPTHDNVPROC(double depth);
    private delegate void PFNGLDEPTHBOUNDSDNVPROC(double zmin, double zmax);
    #ifdef GL_GLEXT_PROTOTYPES
    public static void glDepthRangedNV(double zNear, double zFar);
    public static void glClearDepthdNV(double depth);
    public static void glDepthBoundsdNV(double zmin, double zmax);
    #endif
    #endif /* GL_NV_depth_buffer_float */

    #ifndef GL_NV_depth_clamp
    #define GL_NV_depth_clamp 1
    public const uint GL_DEPTH_CLAMP_NV = 0x864F;
    #endif /* GL_NV_depth_clamp */

    #ifndef GL_NV_draw_texture
    #define GL_NV_draw_texture 1
    private delegate void PFNGLDRAWTEXTURENVPROC(uint texture, uint sampler, float x0, float y0, float x1, float y1, float z, float s0, float t0, float s1, float t1);
    #ifdef GL_GLEXT_PROTOTYPES
    public static void glDrawTextureNV(uint texture, uint sampler, float x0, float y0, float x1, float y1, float z, float s0, float t0, float s1, float t1);
    #endif
    #endif /* GL_NV_draw_texture */

    #ifndef GL_NV_evaluators
    #define GL_NV_evaluators 1
    public const uint GL_EVAL_2D_NV = 0x86C0;
    public const uint GL_EVAL_TRIANGULAR_2D_NV = 0x86C1;
    public const uint GL_MAP_TESSELLATION_NV = 0x86C2;
    public const uint GL_MAP_ATTRIB_U_ORDER_NV = 0x86C3;
    public const uint GL_MAP_ATTRIB_V_ORDER_NV = 0x86C4;
    public const uint GL_EVAL_FRACTIONAL_TESSELLATION_NV = 0x86C5;
    public const uint GL_EVAL_VERTEX_ATTRIB0_NV = 0x86C6;
    public const uint GL_EVAL_VERTEX_ATTRIB1_NV = 0x86C7;
    public const uint GL_EVAL_VERTEX_ATTRIB2_NV = 0x86C8;
    public const uint GL_EVAL_VERTEX_ATTRIB3_NV = 0x86C9;
    public const uint GL_EVAL_VERTEX_ATTRIB4_NV = 0x86CA;
    public const uint GL_EVAL_VERTEX_ATTRIB5_NV = 0x86CB;
    public const uint GL_EVAL_VERTEX_ATTRIB6_NV = 0x86CC;
    public const uint GL_EVAL_VERTEX_ATTRIB7_NV = 0x86CD;
    public const uint GL_EVAL_VERTEX_ATTRIB8_NV = 0x86CE;
    public const uint GL_EVAL_VERTEX_ATTRIB9_NV = 0x86CF;
    public const uint GL_EVAL_VERTEX_ATTRIB10_NV = 0x86D0;
    public const uint GL_EVAL_VERTEX_ATTRIB11_NV = 0x86D1;
    public const uint GL_EVAL_VERTEX_ATTRIB12_NV = 0x86D2;
    public const uint GL_EVAL_VERTEX_ATTRIB13_NV = 0x86D3;
    public const uint GL_EVAL_VERTEX_ATTRIB14_NV = 0x86D4;
    public const uint GL_EVAL_VERTEX_ATTRIB15_NV = 0x86D5;
    public const uint GL_MAX_MAP_TESSELLATION_NV = 0x86D6;
    public const uint GL_MAX_RATIONAL_EVAL_ORDER_NV = 0x86D7;
    private delegate void PFNGLMAPCONTROLPOINTSNVPROC(uint target, uint index, uint type, uint ustride, uint vstride, int uorder, int vorder, bool packed, const void *points);
    private delegate void PFNGLMAPPARAMETERIVNVPROC(uint target, uint pname, const int *params);
    private delegate void PFNGLMAPPARAMETERFVNVPROC(uint target, uint pname, const float *params);
    private delegate void PFNGLGETMAPCONTROLPOINTSNVPROC(uint target, uint index, uint type, uint ustride, uint vstride, bool packed, void *points);
    private delegate void PFNGLGETMAPPARAMETERIVNVPROC(uint target, uint pname, int *params);
    private delegate void PFNGLGETMAPPARAMETERFVNVPROC(uint target, uint pname, float *params);
    private delegate void PFNGLGETMAPATTRIBPARAMETERIVNVPROC(uint target, uint index, uint pname, int *params);
    private delegate void PFNGLGETMAPATTRIBPARAMETERFVNVPROC(uint target, uint index, uint pname, float *params);
    private delegate void PFNGLEVALMAPSNVPROC(uint target, uint mode);
    #ifdef GL_GLEXT_PROTOTYPES
    public static void glMapControlPointsNV(uint target, uint index, uint type, uint ustride, uint vstride, int uorder, int vorder, bool packed, const void *points);
    public static void glMapParameterivNV(uint target, uint pname, const int *params);
    public static void glMapParameterfvNV(uint target, uint pname, const float *params);
    public static void glGetMapControlPointsNV(uint target, uint index, uint type, uint ustride, uint vstride, bool packed, void *points);
    public static void glGetMapParameterivNV(uint target, uint pname, int *params);
    public static void glGetMapParameterfvNV(uint target, uint pname, float *params);
    public static void glGetMapAttribParameterivNV(uint target, uint index, uint pname, int *params);
    public static void glGetMapAttribParameterfvNV(uint target, uint index, uint pname, float *params);
    public static void glEvalMapsNV(uint target, uint mode);
    #endif
    #endif /* GL_NV_evaluators */

    #ifndef GL_NV_explicit_multisample
    #define GL_NV_explicit_multisample 1
    public const uint GL_SAMPLE_POSITION_NV = 0x8E50;
    public const uint GL_SAMPLE_MASK_NV = 0x8E51;
    public const uint GL_SAMPLE_MASK_VALUE_NV = 0x8E52;
    public const uint GL_TEXTURE_BINDING_RENDERBUFFER_NV = 0x8E53;
    public const uint GL_TEXTURE_RENDERBUFFER_DATA_STORE_BINDING_NV = 0x8E54;
    public const uint GL_TEXTURE_RENDERBUFFER_NV = 0x8E55;
    public const uint GL_SAMPLER_RENDERBUFFER_NV = 0x8E56;
    public const uint GL_INT_SAMPLER_RENDERBUFFER_NV = 0x8E57;
    public const uint GL_UNSIGNED_INT_SAMPLER_RENDERBUFFER_NV = 0x8E58;
    public const uint GL_MAX_SAMPLE_MASK_WORDS_NV = 0x8E59;
    private delegate void PFNGLGETMULTISAMPLEFVNVPROC(uint pname, uint index, float *val);
    private delegate void PFNGLSAMPLEMASKINDEXEDNVPROC(uint index, uint mask);
    private delegate void PFNGLTEXRENDERBUFFERNVPROC(uint target, uint renderbuffer);
    #ifdef GL_GLEXT_PROTOTYPES
    public static void glGetMultisamplefvNV(uint pname, uint index, float *val);
    public static void glSampleMaskIndexedNV(uint index, uint mask);
    public static void glTexRenderbufferNV(uint target, uint renderbuffer);
    #endif
    #endif /* GL_NV_explicit_multisample */

    #ifndef GL_NV_fence
    #define GL_NV_fence 1
    public const uint GL_ALL_COMPLETED_NV = 0x84F2;
    public const uint GL_FENCE_STATUS_NV = 0x84F3;
    public const uint GL_FENCE_CONDITION_NV = 0x84F4;
    private delegate void PFNGLDELETEFENCESNVPROC(uint n, const uint *fences);
    private delegate void PFNGLGENFENCESNVPROC(uint n, uint *fences);
    private delegate bool PFNGLISFENCENVPROC(uint fence);
    private delegate bool PFNGLTESTFENCENVPROC(uint fence);
    private delegate void PFNGLGETFENCEIVNVPROC(uint fence, uint pname, int *params);
    private delegate void PFNGLFINISHFENCENVPROC(uint fence);
    private delegate void PFNGLSETFENCENVPROC(uint fence, uint condition);
    #ifdef GL_GLEXT_PROTOTYPES
    public static void glDeleteFencesNV(uint n, const uint *fences);
    public static void glGenFencesNV(uint n, uint *fences);
    public static bool glIsFenceNV(uint fence);
    public static bool glTestFenceNV(uint fence);
    public static void glGetFenceivNV(uint fence, uint pname, int *params);
    public static void glFinishFenceNV(uint fence);
    public static void glSetFenceNV(uint fence, uint condition);
    #endif
    #endif /* GL_NV_fence */

    #ifndef GL_NV_float_buffer
    #define GL_NV_float_buffer 1
    public const uint GL_FLOAT_R_NV = 0x8880;
    public const uint GL_FLOAT_RG_NV = 0x8881;
    public const uint GL_FLOAT_RGB_NV = 0x8882;
    public const uint GL_FLOAT_RGBA_NV = 0x8883;
    public const uint GL_FLOAT_R16_NV = 0x8884;
    public const uint GL_FLOAT_R32_NV = 0x8885;
    public const uint GL_FLOAT_RG16_NV = 0x8886;
    public const uint GL_FLOAT_RG32_NV = 0x8887;
    public const uint GL_FLOAT_RGB16_NV = 0x8888;
    public const uint GL_FLOAT_RGB32_NV = 0x8889;
    public const uint GL_FLOAT_RGBA16_NV = 0x888A;
    public const uint GL_FLOAT_RGBA32_NV = 0x888B;
    public const uint GL_TEXTURE_FLOAT_COMPONENTS_NV = 0x888C;
    public const uint GL_FLOAT_CLEAR_COLOR_VALUE_NV = 0x888D;
    public const uint GL_FLOAT_RGBA_MODE_NV = 0x888E;
    #endif /* GL_NV_float_buffer */

    #ifndef GL_NV_fog_distance
    #define GL_NV_fog_distance 1
    public const uint GL_FOG_DISTANCE_MODE_NV = 0x855A;
    public const uint GL_EYE_RADIAL_NV = 0x855B;
    public const uint GL_EYE_PLANE_ABSOLUTE_NV = 0x855C;
    #endif /* GL_NV_fog_distance */

    #ifndef GL_NV_fragment_program
    #define GL_NV_fragment_program 1
    public const uint GL_MAX_FRAGMENT_PROGRAM_LOCAL_PARAMETERS_NV = 0x8868;
    public const uint GL_FRAGMENT_PROGRAM_NV = 0x8870;
    public const uint GL_MAX_TEXTURE_COORDS_NV = 0x8871;
    public const uint GL_MAX_TEXTURE_IMAGE_UNITS_NV = 0x8872;
    public const uint GL_FRAGMENT_PROGRAM_BINDING_NV = 0x8873;
    public const uint GL_PROGRAM_ERROR_STRING_NV = 0x8874;
    private delegate void PFNGLPROGRAMNAMEDPARAMETER4FNVPROC(uint id, uint len, const byte *name, float x, float y, float z, float w);
    private delegate void PFNGLPROGRAMNAMEDPARAMETER4FVNVPROC(uint id, uint len, const byte *name, const float *v);
    private delegate void PFNGLPROGRAMNAMEDPARAMETER4DNVPROC(uint id, uint len, const byte *name, double x, double y, double z, double w);
    private delegate void PFNGLPROGRAMNAMEDPARAMETER4DVNVPROC(uint id, uint len, const byte *name, const double *v);
    private delegate void PFNGLGETPROGRAMNAMEDPARAMETERFVNVPROC(uint id, uint len, const byte *name, float *params);
    private delegate void PFNGLGETPROGRAMNAMEDPARAMETERDVNVPROC(uint id, uint len, const byte *name, double *params);
    #ifdef GL_GLEXT_PROTOTYPES
    public static void glProgramNamedParameter4fNV(uint id, uint len, const byte *name, float x, float y, float z, float w);
    public static void glProgramNamedParameter4fvNV(uint id, uint len, const byte *name, const float *v);
    public static void glProgramNamedParameter4dNV(uint id, uint len, const byte *name, double x, double y, double z, double w);
    public static void glProgramNamedParameter4dvNV(uint id, uint len, const byte *name, const double *v);
    public static void glGetProgramNamedParameterfvNV(uint id, uint len, const byte *name, float *params);
    public static void glGetProgramNamedParameterdvNV(uint id, uint len, const byte *name, double *params);
    #endif
    #endif /* GL_NV_fragment_program */

    #ifndef GL_NV_fragment_program2
    #define GL_NV_fragment_program2 1
    public const uint GL_MAX_PROGRAM_EXEC_INSTRUCTIONS_NV = 0x88F4;
    public const uint GL_MAX_PROGRAM_CALL_DEPTH_NV = 0x88F5;
    public const uint GL_MAX_PROGRAM_IF_DEPTH_NV = 0x88F6;
    public const uint GL_MAX_PROGRAM_LOOP_DEPTH_NV = 0x88F7;
    public const uint GL_MAX_PROGRAM_LOOP_COUNT_NV = 0x88F8;
    #endif /* GL_NV_fragment_program2 */

    #ifndef GL_NV_fragment_program4
    #define GL_NV_fragment_program4 1
    #endif /* GL_NV_fragment_program4 */

    #ifndef GL_NV_fragment_program_option
    #define GL_NV_fragment_program_option 1
    #endif /* GL_NV_fragment_program_option */

    #ifndef GL_NV_framebuffer_multisample_coverage
    #define GL_NV_framebuffer_multisample_coverage 1
    public const uint GL_RENDERBUFFER_COVERAGE_SAMPLES_NV = 0x8CAB;
    public const uint GL_RENDERBUFFER_COLOR_SAMPLES_NV = 0x8E10;
    public const uint GL_MAX_MULTISAMPLE_COVERAGE_MODES_NV = 0x8E11;
    public const uint GL_MULTISAMPLE_COVERAGE_MODES_NV = 0x8E12;
    private delegate void PFNGLRENDERBUFFERSTORAGEMULTISAMPLECOVERAGENVPROC(uint target, uint coverageSamples, uint colorSamples, uint internalformat, uint width, uint height);
    #ifdef GL_GLEXT_PROTOTYPES
    public static void glRenderbufferStorageMultisampleCoverageNV(uint target, uint coverageSamples, uint colorSamples, uint internalformat, uint width, uint height);
    #endif
    #endif /* GL_NV_framebuffer_multisample_coverage */

    #ifndef GL_NV_geometry_program4
    #define GL_NV_geometry_program4 1
    public const uint GL_GEOMETRY_PROGRAM_NV = 0x8C26;
    public const uint GL_MAX_PROGRAM_OUTPUT_VERTICES_NV = 0x8C27;
    public const uint GL_MAX_PROGRAM_TOTAL_OUTPUT_COMPONENTS_NV = 0x8C28;
    private delegate void PFNGLPROGRAMVERTEXLIMITNVPROC(uint target, int limit);
    private delegate void PFNGLFRAMEBUFFERTEXTUREEXTPROC(uint target, uint attachment, uint texture, int level);
    private delegate void PFNGLFRAMEBUFFERTEXTURELAYEREXTPROC(uint target, uint attachment, uint texture, int level, int layer);
    private delegate void PFNGLFRAMEBUFFERTEXTUREFACEEXTPROC(uint target, uint attachment, uint texture, int level, uint face);
    #ifdef GL_GLEXT_PROTOTYPES
    public static void glProgramVertexLimitNV(uint target, int limit);
    public static void glFramebufferTextureEXT(uint target, uint attachment, uint texture, int level);
    public static void glFramebufferTextureLayerEXT(uint target, uint attachment, uint texture, int level, int layer);
    public static void glFramebufferTextureFaceEXT(uint target, uint attachment, uint texture, int level, uint face);
    #endif
    #endif /* GL_NV_geometry_program4 */

    #ifndef GL_NV_geometry_shader4
    #define GL_NV_geometry_shader4 1
    #endif /* GL_NV_geometry_shader4 */

    #ifndef GL_NV_gpu_program4
    #define GL_NV_gpu_program4 1
    public const uint GL_MIN_PROGRAM_TEXEL_OFFSET_NV = 0x8904;
    public const uint GL_MAX_PROGRAM_TEXEL_OFFSET_NV = 0x8905;
    public const uint GL_PROGRAM_ATTRIB_COMPONENTS_NV = 0x8906;
    public const uint GL_PROGRAM_RESULT_COMPONENTS_NV = 0x8907;
    public const uint GL_MAX_PROGRAM_ATTRIB_COMPONENTS_NV = 0x8908;
    public const uint GL_MAX_PROGRAM_RESULT_COMPONENTS_NV = 0x8909;
    public const uint GL_MAX_PROGRAM_GENERIC_ATTRIBS_NV = 0x8DA5;
    public const uint GL_MAX_PROGRAM_GENERIC_RESULTS_NV = 0x8DA6;
    private delegate void PFNGLPROGRAMLOCALPARAMETERI4INVPROC(uint target, uint index, int x, int y, int z, int w);
    private delegate void PFNGLPROGRAMLOCALPARAMETERI4IVNVPROC(uint target, uint index, const int *params);
    private delegate void PFNGLPROGRAMLOCALPARAMETERSI4IVNVPROC(uint target, uint index, uint count, const int *params);
    private delegate void PFNGLPROGRAMLOCALPARAMETERI4UINVPROC(uint target, uint index, uint x, uint y, uint z, uint w);
    private delegate void PFNGLPROGRAMLOCALPARAMETERI4UIVNVPROC(uint target, uint index, const uint *params);
    private delegate void PFNGLPROGRAMLOCALPARAMETERSI4UIVNVPROC(uint target, uint index, uint count, const uint *params);
    private delegate void PFNGLPROGRAMENVPARAMETERI4INVPROC(uint target, uint index, int x, int y, int z, int w);
    private delegate void PFNGLPROGRAMENVPARAMETERI4IVNVPROC(uint target, uint index, const int *params);
    private delegate void PFNGLPROGRAMENVPARAMETERSI4IVNVPROC(uint target, uint index, uint count, const int *params);
    private delegate void PFNGLPROGRAMENVPARAMETERI4UINVPROC(uint target, uint index, uint x, uint y, uint z, uint w);
    private delegate void PFNGLPROGRAMENVPARAMETERI4UIVNVPROC(uint target, uint index, const uint *params);
    private delegate void PFNGLPROGRAMENVPARAMETERSI4UIVNVPROC(uint target, uint index, uint count, const uint *params);
    private delegate void PFNGLGETPROGRAMLOCALPARAMETERIIVNVPROC(uint target, uint index, int *params);
    private delegate void PFNGLGETPROGRAMLOCALPARAMETERIUIVNVPROC(uint target, uint index, uint *params);
    private delegate void PFNGLGETPROGRAMENVPARAMETERIIVNVPROC(uint target, uint index, int *params);
    private delegate void PFNGLGETPROGRAMENVPARAMETERIUIVNVPROC(uint target, uint index, uint *params);
    #ifdef GL_GLEXT_PROTOTYPES
    public static void glProgramLocalParameterI4iNV(uint target, uint index, int x, int y, int z, int w);
    public static void glProgramLocalParameterI4ivNV(uint target, uint index, const int *params);
    public static void glProgramLocalParametersI4ivNV(uint target, uint index, uint count, const int *params);
    public static void glProgramLocalParameterI4uiNV(uint target, uint index, uint x, uint y, uint z, uint w);
    public static void glProgramLocalParameterI4uivNV(uint target, uint index, const uint *params);
    public static void glProgramLocalParametersI4uivNV(uint target, uint index, uint count, const uint *params);
    public static void glProgramEnvParameterI4iNV(uint target, uint index, int x, int y, int z, int w);
    public static void glProgramEnvParameterI4ivNV(uint target, uint index, const int *params);
    public static void glProgramEnvParametersI4ivNV(uint target, uint index, uint count, const int *params);
    public static void glProgramEnvParameterI4uiNV(uint target, uint index, uint x, uint y, uint z, uint w);
    public static void glProgramEnvParameterI4uivNV(uint target, uint index, const uint *params);
    public static void glProgramEnvParametersI4uivNV(uint target, uint index, uint count, const uint *params);
    public static void glGetProgramLocalParameterIivNV(uint target, uint index, int *params);
    public static void glGetProgramLocalParameterIuivNV(uint target, uint index, uint *params);
    public static void glGetProgramEnvParameterIivNV(uint target, uint index, int *params);
    public static void glGetProgramEnvParameterIuivNV(uint target, uint index, uint *params);
    #endif
    #endif /* GL_NV_gpu_program4 */

    #ifndef GL_NV_gpu_program5
    #define GL_NV_gpu_program5 1
    public const uint GL_MAX_GEOMETRY_PROGRAM_INVOCATIONS_NV = 0x8E5A;
    public const uint GL_MIN_FRAGMENT_INTERPOLATION_OFFSET_NV = 0x8E5B;
    public const uint GL_MAX_FRAGMENT_INTERPOLATION_OFFSET_NV = 0x8E5C;
    public const uint GL_FRAGMENT_PROGRAM_INTERPOLATION_OFFSET_BITS_NV = 0x8E5D;
    public const uint GL_MIN_PROGRAM_TEXTURE_GATHER_OFFSET_NV = 0x8E5E;
    public const uint GL_MAX_PROGRAM_TEXTURE_GATHER_OFFSET_NV = 0x8E5F;
    public const uint GL_MAX_PROGRAM_SUBROUTINE_PARAMETERS_NV = 0x8F44;
    public const uint GL_MAX_PROGRAM_SUBROUTINE_NUM_NV = 0x8F45;
    private delegate void PFNGLPROGRAMSUBROUTINEPARAMETERSUIVNVPROC(uint target, uint count, const uint *params);
    private delegate void PFNGLGETPROGRAMSUBROUTINEPARAMETERUIVNVPROC(uint target, uint index, uint *param);
    #ifdef GL_GLEXT_PROTOTYPES
    public static void glProgramSubroutineParametersuivNV(uint target, uint count, const uint *params);
    public static void glGetProgramSubroutineParameteruivNV(uint target, uint index, uint *param);
    #endif
    #endif /* GL_NV_gpu_program5 */

    #ifndef GL_NV_gpu_program5_mem_extended
    #define GL_NV_gpu_program5_mem_extended 1
    #endif /* GL_NV_gpu_program5_mem_extended */

    #ifndef GL_NV_gpu_shader5
    #define GL_NV_gpu_shader5 1
    typedef long longEXT;
    public const uint GL_long_NV = 0x140E;
    public const uint GL_UNSIGNED_long_NV = 0x140F;
    public const uint GL_INT8_NV = 0x8FE0;
    public const uint GL_INT8_VEC2_NV = 0x8FE1;
    public const uint GL_INT8_VEC3_NV = 0x8FE2;
    public const uint GL_INT8_VEC4_NV = 0x8FE3;
    public const uint GL_INT16_NV = 0x8FE4;
    public const uint GL_INT16_VEC2_NV = 0x8FE5;
    public const uint GL_INT16_VEC3_NV = 0x8FE6;
    public const uint GL_INT16_VEC4_NV = 0x8FE7;
    public const uint GL_long_VEC2_NV = 0x8FE9;
    public const uint GL_long_VEC3_NV = 0x8FEA;
    public const uint GL_long_VEC4_NV = 0x8FEB;
    public const uint GL_UNSIGNED_INT8_NV = 0x8FEC;
    public const uint GL_UNSIGNED_INT8_VEC2_NV = 0x8FED;
    public const uint GL_UNSIGNED_INT8_VEC3_NV = 0x8FEE;
    public const uint GL_UNSIGNED_INT8_VEC4_NV = 0x8FEF;
    public const uint GL_UNSIGNED_INT16_NV = 0x8FF0;
    public const uint GL_UNSIGNED_INT16_VEC2_NV = 0x8FF1;
    public const uint GL_UNSIGNED_INT16_VEC3_NV = 0x8FF2;
    public const uint GL_UNSIGNED_INT16_VEC4_NV = 0x8FF3;
    public const uint GL_UNSIGNED_long_VEC2_NV = 0x8FF5;
    public const uint GL_UNSIGNED_long_VEC3_NV = 0x8FF6;
    public const uint GL_UNSIGNED_long_VEC4_NV = 0x8FF7;
    public const uint GL_FLOAT16_NV = 0x8FF8;
    public const uint GL_FLOAT16_VEC2_NV = 0x8FF9;
    public const uint GL_FLOAT16_VEC3_NV = 0x8FFA;
    public const uint GL_FLOAT16_VEC4_NV = 0x8FFB;
    private delegate void PFNGLUNIFORM1I64NVPROC(int location, longEXT x);
    private delegate void PFNGLUNIFORM2I64NVPROC(int location, longEXT x, longEXT y);
    private delegate void PFNGLUNIFORM3I64NVPROC(int location, longEXT x, longEXT y, longEXT z);
    private delegate void PFNGLUNIFORM4I64NVPROC(int location, longEXT x, longEXT y, longEXT z, longEXT w);
    private delegate void PFNGLUNIFORM1I64VNVPROC(int location, uint count, const longEXT *value);
    private delegate void PFNGLUNIFORM2I64VNVPROC(int location, uint count, const longEXT *value);
    private delegate void PFNGLUNIFORM3I64VNVPROC(int location, uint count, const longEXT *value);
    private delegate void PFNGLUNIFORM4I64VNVPROC(int location, uint count, const longEXT *value);
    private delegate void PFNGLUNIFORM1UI64NVPROC(int location, ulong x);
    private delegate void PFNGLUNIFORM2UI64NVPROC(int location, ulong x, ulong y);
    private delegate void PFNGLUNIFORM3UI64NVPROC(int location, ulong x, ulong y, ulong z);
    private delegate void PFNGLUNIFORM4UI64NVPROC(int location, ulong x, ulong y, ulong z, ulong w);
    private delegate void PFNGLUNIFORM1UI64VNVPROC(int location, uint count, const ulong *value);
    private delegate void PFNGLUNIFORM2UI64VNVPROC(int location, uint count, const ulong *value);
    private delegate void PFNGLUNIFORM3UI64VNVPROC(int location, uint count, const ulong *value);
    private delegate void PFNGLUNIFORM4UI64VNVPROC(int location, uint count, const ulong *value);
    private delegate void PFNGLGETUNIFORMI64VNVPROC(uint program, int location, longEXT *params);
    private delegate void PFNGLPROGRAMUNIFORM1I64NVPROC(uint program, int location, longEXT x);
    private delegate void PFNGLPROGRAMUNIFORM2I64NVPROC(uint program, int location, longEXT x, longEXT y);
    private delegate void PFNGLPROGRAMUNIFORM3I64NVPROC(uint program, int location, longEXT x, longEXT y, longEXT z);
    private delegate void PFNGLPROGRAMUNIFORM4I64NVPROC(uint program, int location, longEXT x, longEXT y, longEXT z, longEXT w);
    private delegate void PFNGLPROGRAMUNIFORM1I64VNVPROC(uint program, int location, uint count, const longEXT *value);
    private delegate void PFNGLPROGRAMUNIFORM2I64VNVPROC(uint program, int location, uint count, const longEXT *value);
    private delegate void PFNGLPROGRAMUNIFORM3I64VNVPROC(uint program, int location, uint count, const longEXT *value);
    private delegate void PFNGLPROGRAMUNIFORM4I64VNVPROC(uint program, int location, uint count, const longEXT *value);
    private delegate void PFNGLPROGRAMUNIFORM1UI64NVPROC(uint program, int location, ulong x);
    private delegate void PFNGLPROGRAMUNIFORM2UI64NVPROC(uint program, int location, ulong x, ulong y);
    private delegate void PFNGLPROGRAMUNIFORM3UI64NVPROC(uint program, int location, ulong x, ulong y, ulong z);
    private delegate void PFNGLPROGRAMUNIFORM4UI64NVPROC(uint program, int location, ulong x, ulong y, ulong z, ulong w);
    private delegate void PFNGLPROGRAMUNIFORM1UI64VNVPROC(uint program, int location, uint count, const ulong *value);
    private delegate void PFNGLPROGRAMUNIFORM2UI64VNVPROC(uint program, int location, uint count, const ulong *value);
    private delegate void PFNGLPROGRAMUNIFORM3UI64VNVPROC(uint program, int location, uint count, const ulong *value);
    private delegate void PFNGLPROGRAMUNIFORM4UI64VNVPROC(uint program, int location, uint count, const ulong *value);
    #ifdef GL_GLEXT_PROTOTYPES
    public static void glUniform1i64NV(int location, longEXT x);
    public static void glUniform2i64NV(int location, longEXT x, longEXT y);
    public static void glUniform3i64NV(int location, longEXT x, longEXT y, longEXT z);
    public static void glUniform4i64NV(int location, longEXT x, longEXT y, longEXT z, longEXT w);
    public static void glUniform1i64vNV(int location, uint count, const longEXT *value);
    public static void glUniform2i64vNV(int location, uint count, const longEXT *value);
    public static void glUniform3i64vNV(int location, uint count, const longEXT *value);
    public static void glUniform4i64vNV(int location, uint count, const longEXT *value);
    public static void glUniform1ui64NV(int location, ulong x);
    public static void glUniform2ui64NV(int location, ulong x, ulong y);
    public static void glUniform3ui64NV(int location, ulong x, ulong y, ulong z);
    public static void glUniform4ui64NV(int location, ulong x, ulong y, ulong z, ulong w);
    public static void glUniform1ui64vNV(int location, uint count, const ulong *value);
    public static void glUniform2ui64vNV(int location, uint count, const ulong *value);
    public static void glUniform3ui64vNV(int location, uint count, const ulong *value);
    public static void glUniform4ui64vNV(int location, uint count, const ulong *value);
    public static void glGetUniformi64vNV(uint program, int location, longEXT *params);
    public static void glProgramUniform1i64NV(uint program, int location, longEXT x);
    public static void glProgramUniform2i64NV(uint program, int location, longEXT x, longEXT y);
    public static void glProgramUniform3i64NV(uint program, int location, longEXT x, longEXT y, longEXT z);
    public static void glProgramUniform4i64NV(uint program, int location, longEXT x, longEXT y, longEXT z, longEXT w);
    public static void glProgramUniform1i64vNV(uint program, int location, uint count, const longEXT *value);
    public static void glProgramUniform2i64vNV(uint program, int location, uint count, const longEXT *value);
    public static void glProgramUniform3i64vNV(uint program, int location, uint count, const longEXT *value);
    public static void glProgramUniform4i64vNV(uint program, int location, uint count, const longEXT *value);
    public static void glProgramUniform1ui64NV(uint program, int location, ulong x);
    public static void glProgramUniform2ui64NV(uint program, int location, ulong x, ulong y);
    public static void glProgramUniform3ui64NV(uint program, int location, ulong x, ulong y, ulong z);
    public static void glProgramUniform4ui64NV(uint program, int location, ulong x, ulong y, ulong z, ulong w);
    public static void glProgramUniform1ui64vNV(uint program, int location, uint count, const ulong *value);
    public static void glProgramUniform2ui64vNV(uint program, int location, uint count, const ulong *value);
    public static void glProgramUniform3ui64vNV(uint program, int location, uint count, const ulong *value);
    public static void glProgramUniform4ui64vNV(uint program, int location, uint count, const ulong *value);
    #endif
    #endif /* GL_NV_gpu_shader5 */

    #ifndef GL_NV_half_float
    #define GL_NV_half_float 1
    typedef unsigned short ushortNV;
    public const uint GL_HALF_FLOAT_NV = 0x140B;
    private delegate void PFNGLVERTEX2HNVPROC(ushortNV x, ushortNV y);
    private delegate void PFNGLVERTEX2HVNVPROC(const ushortNV *v);
    private delegate void PFNGLVERTEX3HNVPROC(ushortNV x, ushortNV y, ushortNV z);
    private delegate void PFNGLVERTEX3HVNVPROC(const ushortNV *v);
    private delegate void PFNGLVERTEX4HNVPROC(ushortNV x, ushortNV y, ushortNV z, ushortNV w);
    private delegate void PFNGLVERTEX4HVNVPROC(const ushortNV *v);
    private delegate void PFNGLNORMAL3HNVPROC(ushortNV nx, ushortNV ny, ushortNV nz);
    private delegate void PFNGLNORMAL3HVNVPROC(const ushortNV *v);
    private delegate void PFNGLCOLOR3HNVPROC(ushortNV red, ushortNV green, ushortNV blue);
    private delegate void PFNGLCOLOR3HVNVPROC(const ushortNV *v);
    private delegate void PFNGLCOLOR4HNVPROC(ushortNV red, ushortNV green, ushortNV blue, ushortNV alpha);
    private delegate void PFNGLCOLOR4HVNVPROC(const ushortNV *v);
    private delegate void PFNGLTEXCOORD1HNVPROC(ushortNV s);
    private delegate void PFNGLTEXCOORD1HVNVPROC(const ushortNV *v);
    private delegate void PFNGLTEXCOORD2HNVPROC(ushortNV s, ushortNV t);
    private delegate void PFNGLTEXCOORD2HVNVPROC(const ushortNV *v);
    private delegate void PFNGLTEXCOORD3HNVPROC(ushortNV s, ushortNV t, ushortNV r);
    private delegate void PFNGLTEXCOORD3HVNVPROC(const ushortNV *v);
    private delegate void PFNGLTEXCOORD4HNVPROC(ushortNV s, ushortNV t, ushortNV r, ushortNV q);
    private delegate void PFNGLTEXCOORD4HVNVPROC(const ushortNV *v);
    private delegate void PFNGLMULTITEXCOORD1HNVPROC(uint target, ushortNV s);
    private delegate void PFNGLMULTITEXCOORD1HVNVPROC(uint target, const ushortNV *v);
    private delegate void PFNGLMULTITEXCOORD2HNVPROC(uint target, ushortNV s, ushortNV t);
    private delegate void PFNGLMULTITEXCOORD2HVNVPROC(uint target, const ushortNV *v);
    private delegate void PFNGLMULTITEXCOORD3HNVPROC(uint target, ushortNV s, ushortNV t, ushortNV r);
    private delegate void PFNGLMULTITEXCOORD3HVNVPROC(uint target, const ushortNV *v);
    private delegate void PFNGLMULTITEXCOORD4HNVPROC(uint target, ushortNV s, ushortNV t, ushortNV r, ushortNV q);
    private delegate void PFNGLMULTITEXCOORD4HVNVPROC(uint target, const ushortNV *v);
    private delegate void PFNGLFOGCOORDHNVPROC(ushortNV fog);
    private delegate void PFNGLFOGCOORDHVNVPROC(const ushortNV *fog);
    private delegate void PFNGLSECONDARYCOLOR3HNVPROC(ushortNV red, ushortNV green, ushortNV blue);
    private delegate void PFNGLSECONDARYCOLOR3HVNVPROC(const ushortNV *v);
    private delegate void PFNGLVERTEXWEIGHTHNVPROC(ushortNV weight);
    private delegate void PFNGLVERTEXWEIGHTHVNVPROC(const ushortNV *weight);
    private delegate void PFNGLVERTEXATTRIB1HNVPROC(uint index, ushortNV x);
    private delegate void PFNGLVERTEXATTRIB1HVNVPROC(uint index, const ushortNV *v);
    private delegate void PFNGLVERTEXATTRIB2HNVPROC(uint index, ushortNV x, ushortNV y);
    private delegate void PFNGLVERTEXATTRIB2HVNVPROC(uint index, const ushortNV *v);
    private delegate void PFNGLVERTEXATTRIB3HNVPROC(uint index, ushortNV x, ushortNV y, ushortNV z);
    private delegate void PFNGLVERTEXATTRIB3HVNVPROC(uint index, const ushortNV *v);
    private delegate void PFNGLVERTEXATTRIB4HNVPROC(uint index, ushortNV x, ushortNV y, ushortNV z, ushortNV w);
    private delegate void PFNGLVERTEXATTRIB4HVNVPROC(uint index, const ushortNV *v);
    private delegate void PFNGLVERTEXATTRIBS1HVNVPROC(uint index, uint n, const ushortNV *v);
    private delegate void PFNGLVERTEXATTRIBS2HVNVPROC(uint index, uint n, const ushortNV *v);
    private delegate void PFNGLVERTEXATTRIBS3HVNVPROC(uint index, uint n, const ushortNV *v);
    private delegate void PFNGLVERTEXATTRIBS4HVNVPROC(uint index, uint n, const ushortNV *v);
    #ifdef GL_GLEXT_PROTOTYPES
    public static void glVertex2hNV(ushortNV x, ushortNV y);
    public static void glVertex2hvNV(const ushortNV *v);
    public static void glVertex3hNV(ushortNV x, ushortNV y, ushortNV z);
    public static void glVertex3hvNV(const ushortNV *v);
    public static void glVertex4hNV(ushortNV x, ushortNV y, ushortNV z, ushortNV w);
    public static void glVertex4hvNV(const ushortNV *v);
    public static void glNormal3hNV(ushortNV nx, ushortNV ny, ushortNV nz);
    public static void glNormal3hvNV(const ushortNV *v);
    public static void glColor3hNV(ushortNV red, ushortNV green, ushortNV blue);
    public static void glColor3hvNV(const ushortNV *v);
    public static void glColor4hNV(ushortNV red, ushortNV green, ushortNV blue, ushortNV alpha);
    public static void glColor4hvNV(const ushortNV *v);
    public static void glTexCoord1hNV(ushortNV s);
    public static void glTexCoord1hvNV(const ushortNV *v);
    public static void glTexCoord2hNV(ushortNV s, ushortNV t);
    public static void glTexCoord2hvNV(const ushortNV *v);
    public static void glTexCoord3hNV(ushortNV s, ushortNV t, ushortNV r);
    public static void glTexCoord3hvNV(const ushortNV *v);
    public static void glTexCoord4hNV(ushortNV s, ushortNV t, ushortNV r, ushortNV q);
    public static void glTexCoord4hvNV(const ushortNV *v);
    public static void glMultiTexCoord1hNV(uint target, ushortNV s);
    public static void glMultiTexCoord1hvNV(uint target, const ushortNV *v);
    public static void glMultiTexCoord2hNV(uint target, ushortNV s, ushortNV t);
    public static void glMultiTexCoord2hvNV(uint target, const ushortNV *v);
    public static void glMultiTexCoord3hNV(uint target, ushortNV s, ushortNV t, ushortNV r);
    public static void glMultiTexCoord3hvNV(uint target, const ushortNV *v);
    public static void glMultiTexCoord4hNV(uint target, ushortNV s, ushortNV t, ushortNV r, ushortNV q);
    public static void glMultiTexCoord4hvNV(uint target, const ushortNV *v);
    public static void glFogCoordhNV(ushortNV fog);
    public static void glFogCoordhvNV(const ushortNV *fog);
    public static void glSecondaryColor3hNV(ushortNV red, ushortNV green, ushortNV blue);
    public static void glSecondaryColor3hvNV(const ushortNV *v);
    public static void glVertexWeighthNV(ushortNV weight);
    public static void glVertexWeighthvNV(const ushortNV *weight);
    public static void glVertexAttrib1hNV(uint index, ushortNV x);
    public static void glVertexAttrib1hvNV(uint index, const ushortNV *v);
    public static void glVertexAttrib2hNV(uint index, ushortNV x, ushortNV y);
    public static void glVertexAttrib2hvNV(uint index, const ushortNV *v);
    public static void glVertexAttrib3hNV(uint index, ushortNV x, ushortNV y, ushortNV z);
    public static void glVertexAttrib3hvNV(uint index, const ushortNV *v);
    public static void glVertexAttrib4hNV(uint index, ushortNV x, ushortNV y, ushortNV z, ushortNV w);
    public static void glVertexAttrib4hvNV(uint index, const ushortNV *v);
    public static void glVertexAttribs1hvNV(uint index, uint n, const ushortNV *v);
    public static void glVertexAttribs2hvNV(uint index, uint n, const ushortNV *v);
    public static void glVertexAttribs3hvNV(uint index, uint n, const ushortNV *v);
    public static void glVertexAttribs4hvNV(uint index, uint n, const ushortNV *v);
    #endif
    #endif /* GL_NV_half_float */

    #ifndef GL_NV_light_max_exponent
    #define GL_NV_light_max_exponent 1
    public const uint GL_MAX_SHININESS_NV = 0x8504;
    public const uint GL_MAX_SPOT_EXPONENT_NV = 0x8505;
    #endif /* GL_NV_light_max_exponent */

    #ifndef GL_NV_multisample_coverage
    #define GL_NV_multisample_coverage 1
    public const uint GL_COLOR_SAMPLES_NV = 0x8E20;
    #endif /* GL_NV_multisample_coverage */

    #ifndef GL_NV_multisample_filter_hint
    #define GL_NV_multisample_filter_hint 1
    public const uint GL_MULTISAMPLE_FILTER_HINT_NV = 0x8534;
    #endif /* GL_NV_multisample_filter_hint */

    #ifndef GL_NV_occlusion_query
    #define GL_NV_occlusion_query 1
    public const uint GL_PIXEL_COUNTER_BITS_NV = 0x8864;
    public const uint GL_CURRENT_OCCLUSION_QUERY_ID_NV = 0x8865;
    public const uint GL_PIXEL_COUNT_NV = 0x8866;
    public const uint GL_PIXEL_COUNT_AVAILABLE_NV = 0x8867;
    private delegate void PFNGLGENOCCLUSIONQUERIESNVPROC(uint n, uint *ids);
    private delegate void PFNGLDELETEOCCLUSIONQUERIESNVPROC(uint n, const uint *ids);
    private delegate bool PFNGLISOCCLUSIONQUERYNVPROC(uint id);
    private delegate void PFNGLBEGINOCCLUSIONQUERYNVPROC(uint id);
    private delegate void PFNGLENDOCCLUSIONQUERYNVPROC(void);
    private delegate void PFNGLGETOCCLUSIONQUERYIVNVPROC(uint id, uint pname, int *params);
    private delegate void PFNGLGETOCCLUSIONQUERYUIVNVPROC(uint id, uint pname, uint *params);
    #ifdef GL_GLEXT_PROTOTYPES
    public static void glGenOcclusionQueriesNV(uint n, uint *ids);
    public static void glDeleteOcclusionQueriesNV(uint n, const uint *ids);
    public static bool glIsOcclusionQueryNV(uint id);
    public static void glBeginOcclusionQueryNV(uint id);
    public static void glEndOcclusionQueryNV(void);
    public static void glGetOcclusionQueryivNV(uint id, uint pname, int *params);
    public static void glGetOcclusionQueryuivNV(uint id, uint pname, uint *params);
    #endif
    #endif /* GL_NV_occlusion_query */

    #ifndef GL_NV_packed_depth_stencil
    #define GL_NV_packed_depth_stencil 1
    public const uint GL_DEPTH_STENCIL_NV = 0x84F9;
    public const uint GL_UNSIGNED_INT_24_8_NV = 0x84FA;
    #endif /* GL_NV_packed_depth_stencil */

    #ifndef GL_NV_parameter_buffer_object
    #define GL_NV_parameter_buffer_object 1
    public const uint GL_MAX_PROGRAM_PARAMETER_BUFFER_BINDINGS_NV = 0x8DA0;
    public const uint GL_MAX_PROGRAM_PARAMETER_BUFFER_SIZE_NV = 0x8DA1;
    public const uint GL_VERTEX_PROGRAM_PARAMETER_BUFFER_NV = 0x8DA2;
    public const uint GL_GEOMETRY_PROGRAM_PARAMETER_BUFFER_NV = 0x8DA3;
    public const uint GL_FRAGMENT_PROGRAM_PARAMETER_BUFFER_NV = 0x8DA4;
    private delegate void PFNGLPROGRAMBUFFERPARAMETERSFVNVPROC(uint target, uint bindingIndex, uint wordIndex, uint count, const float *params);
    private delegate void PFNGLPROGRAMBUFFERPARAMETERSIIVNVPROC(uint target, uint bindingIndex, uint wordIndex, uint count, const int *params);
    private delegate void PFNGLPROGRAMBUFFERPARAMETERSIUIVNVPROC(uint target, uint bindingIndex, uint wordIndex, uint count, const uint *params);
    #ifdef GL_GLEXT_PROTOTYPES
    public static void glProgramBufferParametersfvNV(uint target, uint bindingIndex, uint wordIndex, uint count, const float *params);
    public static void glProgramBufferParametersIivNV(uint target, uint bindingIndex, uint wordIndex, uint count, const int *params);
    public static void glProgramBufferParametersIuivNV(uint target, uint bindingIndex, uint wordIndex, uint count, const uint *params);
    #endif
    #endif /* GL_NV_parameter_buffer_object */

    #ifndef GL_NV_parameter_buffer_object2
    #define GL_NV_parameter_buffer_object2 1
    #endif /* GL_NV_parameter_buffer_object2 */

    #ifndef GL_NV_path_rendering
    #define GL_NV_path_rendering 1
    public const uint GL_PATH_FORMAT_SVG_NV = 0x9070;
    public const uint GL_PATH_FORMAT_PS_NV = 0x9071;
    public const uint GL_STANDARD_FONT_NAME_NV = 0x9072;
    public const uint GL_SYSTEM_FONT_NAME_NV = 0x9073;
    public const uint GL_FILE_NAME_NV = 0x9074;
    public const uint GL_PATH_STROKE_WIDTH_NV = 0x9075;
    public const uint GL_PATH_END_CAPS_NV = 0x9076;
    public const uint GL_PATH_INITIAL_END_CAP_NV = 0x9077;
    public const uint GL_PATH_TERMINAL_END_CAP_NV = 0x9078;
    public const uint GL_PATH_JOIN_STYLE_NV = 0x9079;
    public const uint GL_PATH_MITER_LIMIT_NV = 0x907A;
    public const uint GL_PATH_DASH_CAPS_NV = 0x907B;
    public const uint GL_PATH_INITIAL_DASH_CAP_NV = 0x907C;
    public const uint GL_PATH_TERMINAL_DASH_CAP_NV = 0x907D;
    public const uint GL_PATH_DASH_OFFSET_NV = 0x907E;
    public const uint GL_PATH_CLIENT_LENGTH_NV = 0x907F;
    public const uint GL_PATH_FILL_MODE_NV = 0x9080;
    public const uint GL_PATH_FILL_MASK_NV = 0x9081;
    public const uint GL_PATH_FILL_COVER_MODE_NV = 0x9082;
    public const uint GL_PATH_STROKE_COVER_MODE_NV = 0x9083;
    public const uint GL_PATH_STROKE_MASK_NV = 0x9084;
    public const uint GL_COUNT_UP_NV = 0x9088;
    public const uint GL_COUNT_DOWN_NV = 0x9089;
    public const uint GL_PATH_OBJECT_BOUNDING_BOX_NV = 0x908A;
    public const uint GL_CONVEX_HULL_NV = 0x908B;
    public const uint GL_BOUNDING_BOX_NV = 0x908D;
    public const uint GL_TRANSLATE_X_NV = 0x908E;
    public const uint GL_TRANSLATE_Y_NV = 0x908F;
    public const uint GL_TRANSLATE_2D_NV = 0x9090;
    public const uint GL_TRANSLATE_3D_NV = 0x9091;
    public const uint GL_AFFINE_2D_NV = 0x9092;
    public const uint GL_AFFINE_3D_NV = 0x9094;
    public const uint GL_TRANSPOSE_AFFINE_2D_NV = 0x9096;
    public const uint GL_TRANSPOSE_AFFINE_3D_NV = 0x9098;
    public const uint GL_UTF8_NV = 0x909A;
    public const uint GL_UTF16_NV = 0x909B;
    public const uint GL_BOUNDING_BOX_OF_BOUNDING_BOXES_NV = 0x909C;
    public const uint GL_PATH_COMMAND_COUNT_NV = 0x909D;
    public const uint GL_PATH_COORD_COUNT_NV = 0x909E;
    public const uint GL_PATH_DASH_ARRAY_COUNT_NV = 0x909F;
    public const uint GL_PATH_COMPUTED_LENGTH_NV = 0x90A0;
    public const uint GL_PATH_FILL_BOUNDING_BOX_NV = 0x90A1;
    public const uint GL_PATH_STROKE_BOUNDING_BOX_NV = 0x90A2;
    public const uint GL_SQUARE_NV = 0x90A3;
    public const uint GL_ROUND_NV = 0x90A4;
    public const uint GL_TRIANGULAR_NV = 0x90A5;
    public const uint GL_BEVEL_NV = 0x90A6;
    public const uint GL_MITER_REVERT_NV = 0x90A7;
    public const uint GL_MITER_TRUNCATE_NV = 0x90A8;
    public const uint GL_SKIP_MISSING_GLYPH_NV = 0x90A9;
    public const uint GL_USE_MISSING_GLYPH_NV = 0x90AA;
    public const uint GL_PATH_ERROR_POSITION_NV = 0x90AB;
    public const uint GL_PATH_FOG_GEN_MODE_NV = 0x90AC;
    public const uint GL_ACCUM_ADJACENT_PAIRS_NV = 0x90AD;
    public const uint GL_ADJACENT_PAIRS_NV = 0x90AE;
    public const uint GL_FIRST_TO_REST_NV = 0x90AF;
    public const uint GL_PATH_GEN_MODE_NV = 0x90B0;
    public const uint GL_PATH_GEN_COEFF_NV = 0x90B1;
    public const uint GL_PATH_GEN_COLOR_FORMAT_NV = 0x90B2;
    public const uint GL_PATH_GEN_COMPONENTS_NV = 0x90B3;
    public const uint GL_PATH_STENCIL_FUNC_NV = 0x90B7;
    public const uint GL_PATH_STENCIL_REF_NV = 0x90B8;
    public const uint GL_PATH_STENCIL_VALUE_MASK_NV = 0x90B9;
    public const uint GL_PATH_STENCIL_DEPTH_OFFSET_FACTOR_NV = 0x90BD;
    public const uint GL_PATH_STENCIL_DEPTH_OFFSET_UNITS_NV = 0x90BE;
    public const uint GL_PATH_COVER_DEPTH_FUNC_NV = 0x90BF;
    public const uint GL_PATH_DASH_OFFSET_RESET_NV = 0x90B4;
    public const uint GL_MOVE_TO_RESETS_NV = 0x90B5;
    public const uint GL_MOVE_TO_CONTINUES_NV = 0x90B6;
    public const uint GL_CLOSE_PATH_NV = 0x00;
    public const uint GL_MOVE_TO_NV = 0x02;
    public const uint GL_RELATIVE_MOVE_TO_NV = 0x03;
    public const uint GL_LINE_TO_NV = 0x04;
    public const uint GL_RELATIVE_LINE_TO_NV = 0x05;
    public const uint GL_HORIZONTAL_LINE_TO_NV = 0x06;
    public const uint GL_RELATIVE_HORIZONTAL_LINE_TO_NV = 0x07;
    public const uint GL_VERTICAL_LINE_TO_NV = 0x08;
    public const uint GL_RELATIVE_VERTICAL_LINE_TO_NV = 0x09;
    public const uint GL_QUADRATIC_CURVE_TO_NV = 0x0A;
    public const uint GL_RELATIVE_QUADRATIC_CURVE_TO_NV = 0x0B;
    public const uint GL_CUBIC_CURVE_TO_NV = 0x0C;
    public const uint GL_RELATIVE_CUBIC_CURVE_TO_NV = 0x0D;
    public const uint GL_SMOOTH_QUADRATIC_CURVE_TO_NV = 0x0E;
    public const uint GL_RELATIVE_SMOOTH_QUADRATIC_CURVE_TO_NV = 0x0F;
    public const uint GL_SMOOTH_CUBIC_CURVE_TO_NV = 0x10;
    public const uint GL_RELATIVE_SMOOTH_CUBIC_CURVE_TO_NV = 0x11;
    public const uint GL_SMALL_CCW_ARC_TO_NV = 0x12;
    public const uint GL_RELATIVE_SMALL_CCW_ARC_TO_NV = 0x13;
    public const uint GL_SMALL_CW_ARC_TO_NV = 0x14;
    public const uint GL_RELATIVE_SMALL_CW_ARC_TO_NV = 0x15;
    public const uint GL_LARGE_CCW_ARC_TO_NV = 0x16;
    public const uint GL_RELATIVE_LARGE_CCW_ARC_TO_NV = 0x17;
    public const uint GL_LARGE_CW_ARC_TO_NV = 0x18;
    public const uint GL_RELATIVE_LARGE_CW_ARC_TO_NV = 0x19;
    public const uint GL_RESTART_PATH_NV = 0xF0;
    public const uint GL_DUP_FIRST_CUBIC_CURVE_TO_NV = 0xF2;
    public const uint GL_DUP_LAST_CUBIC_CURVE_TO_NV = 0xF4;
    public const uint GL_RECT_NV = 0xF6;
    public const uint GL_CIRCULAR_CCW_ARC_TO_NV = 0xF8;
    public const uint GL_CIRCULAR_CW_ARC_TO_NV = 0xFA;
    public const uint GL_CIRCULAR_TANGENT_ARC_TO_NV = 0xFC;
    public const uint GL_ARC_TO_NV = 0xFE;
    public const uint GL_RELATIVE_ARC_TO_NV = 0xFF;
    public const uint GL_BOLD_BIT_NV = 0x01;
    public const uint GL_ITALIC_BIT_NV = 0x02;
    public const uint GL_GLYPH_WIDTH_BIT_NV = 0x01;
    public const uint GL_GLYPH_HEIGHT_BIT_NV = 0x02;
    public const uint GL_GLYPH_HORIZONTAL_BEARING_X_BIT_NV = 0x04;
    public const uint GL_GLYPH_HORIZONTAL_BEARING_Y_BIT_NV = 0x08;
    public const uint GL_GLYPH_HORIZONTAL_BEARING_ADVANCE_BIT_NV = 0x10;
    public const uint GL_GLYPH_VERTICAL_BEARING_X_BIT_NV = 0x20;
    public const uint GL_GLYPH_VERTICAL_BEARING_Y_BIT_NV = 0x40;
    public const uint GL_GLYPH_VERTICAL_BEARING_ADVANCE_BIT_NV = 0x80;
    public const uint GL_GLYPH_HAS_KERNING_BIT_NV = 0x100;
    public const uint GL_FONT_X_MIN_BOUNDS_BIT_NV = 0x00010000;
    public const uint GL_FONT_Y_MIN_BOUNDS_BIT_NV = 0x00020000;
    public const uint GL_FONT_X_MAX_BOUNDS_BIT_NV = 0x00040000;
    public const uint GL_FONT_Y_MAX_BOUNDS_BIT_NV = 0x00080000;
    public const uint GL_FONT_UNITS_PER_EM_BIT_NV = 0x00100000;
    public const uint GL_FONT_ASCENDER_BIT_NV = 0x00200000;
    public const uint GL_FONT_DESCENDER_BIT_NV = 0x00400000;
    public const uint GL_FONT_HEIGHT_BIT_NV = 0x00800000;
    public const uint GL_FONT_MAX_ADVANCE_WIDTH_BIT_NV = 0x01000000;
    public const uint GL_FONT_MAX_ADVANCE_HEIGHT_BIT_NV = 0x02000000;
    public const uint GL_FONT_UNDERLINE_POSITION_BIT_NV = 0x04000000;
    public const uint GL_FONT_UNDERLINE_THICKNESS_BIT_NV = 0x08000000;
    public const uint GL_FONT_HAS_KERNING_BIT_NV = 0x10000000;
    public const uint GL_PRIMARY_COLOR_NV = 0x852C;
    public const uint GL_SECONDARY_COLOR_NV = 0x852D;
    private delegate uint PFNGLGENPATHSNVPROC(uint range);
    private delegate void PFNGLDELETEPATHSNVPROC(uint path, uint range);
    private delegate bool PFNGLISPATHNVPROC(uint path);
    private delegate void PFNGLPATHCOMMANDSNVPROC(uint path, uint numCommands, const byte *commands, uint numCoords, uint coordType, const void *coords);
    private delegate void PFNGLPATHCOORDSNVPROC(uint path, uint numCoords, uint coordType, const void *coords);
    private delegate void PFNGLPATHSUBCOMMANDSNVPROC(uint path, uint commandStart, uint commandsToDelete, uint numCommands, const byte *commands, uint numCoords, uint coordType, const void *coords);
    private delegate void PFNGLPATHSUBCOORDSNVPROC(uint path, uint coordStart, uint numCoords, uint coordType, const void *coords);
    private delegate void PFNGLPATHSTRINGNVPROC(uint path, uint format, uint length, const void *pathString);
    private delegate void PFNGLPATHGLYPHSNVPROC(uint firstPathName, uint fontTarget, const void *fontName, uint fontStyle, uint numGlyphs, uint type, const void *charcodes, uint handleMissingGlyphs, uint pathParameterTemplate, float emScale);
    private delegate void PFNGLPATHGLYPHRANGENVPROC(uint firstPathName, uint fontTarget, const void *fontName, uint fontStyle, uint firstGlyph, uint numGlyphs, uint handleMissingGlyphs, uint pathParameterTemplate, float emScale);
    private delegate void PFNGLWEIGHTPATHSNVPROC(uint resultPath, uint numPaths, const uint *paths, const float *weights);
    private delegate void PFNGLCOPYPATHNVPROC(uint resultPath, uint srcPath);
    private delegate void PFNintERPOLATEPATHSNVPROC(uint resultPath, uint pathA, uint pathB, float weight);
    private delegate void PFNGLTRANSFORMPATHNVPROC(uint resultPath, uint srcPath, uint transformType, const float *transformValues);
    private delegate void PFNGLPATHPARAMETERIVNVPROC(uint path, uint pname, const int *value);
    private delegate void PFNGLPATHPARAMETERINVPROC(uint path, uint pname, int value);
    private delegate void PFNGLPATHPARAMETERFVNVPROC(uint path, uint pname, const float *value);
    private delegate void PFNGLPATHPARAMETERFNVPROC(uint path, uint pname, float value);
    private delegate void PFNGLPATHDASHARRAYNVPROC(uint path, uint dashCount, const float *dashArray);
    private delegate void PFNGLPATHSTENCILFUNCNVPROC(uint func, int ref, uint mask);
    private delegate void PFNGLPATHSTENCILDEPTHOFFSETNVPROC(float factor, float units);
    private delegate void PFNGLSTENCILFILLPATHNVPROC(uint path, uint fillMode, uint mask);
    private delegate void PFNGLSTENCILSTROKEPATHNVPROC(uint path, int reference, uint mask);
    private delegate void PFNGLSTENCILFILLPATHINSTANCEDNVPROC(uint numPaths, uint pathNameType, const void *paths, uint pathBase, uint fillMode, uint mask, uint transformType, const float *transformValues);
    private delegate void PFNGLSTENCILSTROKEPATHINSTANCEDNVPROC(uint numPaths, uint pathNameType, const void *paths, uint pathBase, int reference, uint mask, uint transformType, const float *transformValues);
    private delegate void PFNGLPATHCOVERDEPTHFUNCNVPROC(uint func);
    private delegate void PFNGLPATHCOLORGENNVPROC(uint color, uint genMode, uint colorFormat, const float *coeffs);
    private delegate void PFNGLPATHTEXGENNVPROC(uint texCoordSet, uint genMode, int components, const float *coeffs);
    private delegate void PFNGLPATHFOGGENNVPROC(uint genMode);
    private delegate void PFNGLCOVERFILLPATHNVPROC(uint path, uint coverMode);
    private delegate void PFNGLCOVERSTROKEPATHNVPROC(uint path, uint coverMode);
    private delegate void PFNGLCOVERFILLPATHINSTANCEDNVPROC(uint numPaths, uint pathNameType, const void *paths, uint pathBase, uint coverMode, uint transformType, const float *transformValues);
    private delegate void PFNGLCOVERSTROKEPATHINSTANCEDNVPROC(uint numPaths, uint pathNameType, const void *paths, uint pathBase, uint coverMode, uint transformType, const float *transformValues);
    private delegate void PFNGLGETPATHPARAMETERIVNVPROC(uint path, uint pname, int *value);
    private delegate void PFNGLGETPATHPARAMETERFVNVPROC(uint path, uint pname, float *value);
    private delegate void PFNGLGETPATHCOMMANDSNVPROC(uint path, byte *commands);
    private delegate void PFNGLGETPATHCOORDSNVPROC(uint path, float *coords);
    private delegate void PFNGLGETPATHDASHARRAYNVPROC(uint path, float *dashArray);
    private delegate void PFNGLGETPATHMETRICSNVPROC(uint metricQueryMask, uint numPaths, uint pathNameType, const void *paths, uint pathBase, uint stride, float *metrics);
    private delegate void PFNGLGETPATHMETRICRANGENVPROC(uint metricQueryMask, uint firstPathName, uint numPaths, uint stride, float *metrics);
    private delegate void PFNGLGETPATHSPACINGNVPROC(uint pathListMode, uint numPaths, uint pathNameType, const void *paths, uint pathBase, float advanceScale, float kerningScale, uint transformType, float *returnedSpacing);
    private delegate void PFNGLGETPATHCOLORGENIVNVPROC(uint color, uint pname, int *value);
    private delegate void PFNGLGETPATHCOLORGENFVNVPROC(uint color, uint pname, float *value);
    private delegate void PFNGLGETPATHTEXGENIVNVPROC(uint texCoordSet, uint pname, int *value);
    private delegate void PFNGLGETPATHTEXGENFVNVPROC(uint texCoordSet, uint pname, float *value);
    private delegate bool PFNGLISPOINTINFILLPATHNVPROC(uint path, uint mask, float x, float y);
    private delegate bool PFNGLISPOINTINSTROKEPATHNVPROC(uint path, float x, float y);
    private delegate float PFNGLGETPATHLENGTHNVPROC(uint path, uint startSegment, uint numSegments);
    private delegate bool PFNGLPOINTALONGPATHNVPROC(uint path, uint startSegment, uint numSegments, float distance, float *x, float *y, float *tangentX, float *tangentY);
    #ifdef GL_GLEXT_PROTOTYPES
    public static uint glGenPathsNV(uint range);
    public static void glDeletePathsNV(uint path, uint range);
    public static bool glIsPathNV(uint path);
    public static void glPathCommandsNV(uint path, uint numCommands, const byte *commands, uint numCoords, uint coordType, const void *coords);
    public static void glPathCoordsNV(uint path, uint numCoords, uint coordType, const void *coords);
    public static void glPathSubCommandsNV(uint path, uint commandStart, uint commandsToDelete, uint numCommands, const byte *commands, uint numCoords, uint coordType, const void *coords);
    public static void glPathSubCoordsNV(uint path, uint coordStart, uint numCoords, uint coordType, const void *coords);
    public static void glPathStringNV(uint path, uint format, uint length, const void *pathString);
    public static void glPathGlyphsNV(uint firstPathName, uint fontTarget, const void *fontName, uint fontStyle, uint numGlyphs, uint type, const void *charcodes, uint handleMissingGlyphs, uint pathParameterTemplate, float emScale);
    public static void glPathGlyphRangeNV(uint firstPathName, uint fontTarget, const void *fontName, uint fontStyle, uint firstGlyph, uint numGlyphs, uint handleMissingGlyphs, uint pathParameterTemplate, float emScale);
    public static void glWeightPathsNV(uint resultPath, uint numPaths, const uint *paths, const float *weights);
    public static void glCopyPathNV(uint resultPath, uint srcPath);
    public static void interpolatePathsNV(uint resultPath, uint pathA, uint pathB, float weight);
    public static void glTransformPathNV(uint resultPath, uint srcPath, uint transformType, const float *transformValues);
    public static void glPathParameterivNV(uint path, uint pname, const int *value);
    public static void glPathParameteriNV(uint path, uint pname, int value);
    public static void glPathParameterfvNV(uint path, uint pname, const float *value);
    public static void glPathParameterfNV(uint path, uint pname, float value);
    public static void glPathDashArrayNV(uint path, uint dashCount, const float *dashArray);
    public static void glPathStencilFuncNV(uint func, int ref, uint mask);
    public static void glPathStencilDepthOffsetNV(float factor, float units);
    public static void glStencilFillPathNV(uint path, uint fillMode, uint mask);
    public static void glStencilStrokePathNV(uint path, int reference, uint mask);
    public static void glStencilFillPathInstancedNV(uint numPaths, uint pathNameType, const void *paths, uint pathBase, uint fillMode, uint mask, uint transformType, const float *transformValues);
    public static void glStencilStrokePathInstancedNV(uint numPaths, uint pathNameType, const void *paths, uint pathBase, int reference, uint mask, uint transformType, const float *transformValues);
    public static void glPathCoverDepthFuncNV(uint func);
    public static void glPathColorGenNV(uint color, uint genMode, uint colorFormat, const float *coeffs);
    public static void glPathTexGenNV(uint texCoordSet, uint genMode, int components, const float *coeffs);
    public static void glPathFogGenNV(uint genMode);
    public static void glCoverFillPathNV(uint path, uint coverMode);
    public static void glCoverStrokePathNV(uint path, uint coverMode);
    public static void glCoverFillPathInstancedNV(uint numPaths, uint pathNameType, const void *paths, uint pathBase, uint coverMode, uint transformType, const float *transformValues);
    public static void glCoverStrokePathInstancedNV(uint numPaths, uint pathNameType, const void *paths, uint pathBase, uint coverMode, uint transformType, const float *transformValues);
    public static void glGetPathParameterivNV(uint path, uint pname, int *value);
    public static void glGetPathParameterfvNV(uint path, uint pname, float *value);
    public static void glGetPathCommandsNV(uint path, byte *commands);
    public static void glGetPathCoordsNV(uint path, float *coords);
    public static void glGetPathDashArrayNV(uint path, float *dashArray);
    public static void glGetPathMetricsNV(uint metricQueryMask, uint numPaths, uint pathNameType, const void *paths, uint pathBase, uint stride, float *metrics);
    public static void glGetPathMetricRangeNV(uint metricQueryMask, uint firstPathName, uint numPaths, uint stride, float *metrics);
    public static void glGetPathSpacingNV(uint pathListMode, uint numPaths, uint pathNameType, const void *paths, uint pathBase, float advanceScale, float kerningScale, uint transformType, float *returnedSpacing);
    public static void glGetPathColorGenivNV(uint color, uint pname, int *value);
    public static void glGetPathColorGenfvNV(uint color, uint pname, float *value);
    public static void glGetPathTexGenivNV(uint texCoordSet, uint pname, int *value);
    public static void glGetPathTexGenfvNV(uint texCoordSet, uint pname, float *value);
    public static bool glIsPointInFillPathNV(uint path, uint mask, float x, float y);
    public static bool glIsPointInStrokePathNV(uint path, float x, float y);
    public static float glGetPathLengthNV(uint path, uint startSegment, uint numSegments);
    public static bool glPointAlongPathNV(uint path, uint startSegment, uint numSegments, float distance, float *x, float *y, float *tangentX, float *tangentY);
    #endif
    #endif /* GL_NV_path_rendering */

    #ifndef GL_NV_pixel_data_range
    #define GL_NV_pixel_data_range 1
    public const uint GL_WRITE_PIXEL_DATA_RANGE_NV = 0x8878;
    public const uint GL_READ_PIXEL_DATA_RANGE_NV = 0x8879;
    public const uint GL_WRITE_PIXEL_DATA_RANGE_LENGTH_NV = 0x887A;
    public const uint GL_READ_PIXEL_DATA_RANGE_LENGTH_NV = 0x887B;
    public const uint GL_WRITE_PIXEL_DATA_RANGE_POINTER_NV = 0x887C;
    public const uint GL_READ_PIXEL_DATA_RANGE_POINTER_NV = 0x887D;
    private delegate void PFNGLPIXELDATARANGENVPROC(uint target, uint length, const void *pointer);
    private delegate void PFNGLFLUSHPIXELDATARANGENVPROC(uint target);
    #ifdef GL_GLEXT_PROTOTYPES
    public static void glPixelDataRangeNV(uint target, uint length, const void *pointer);
    public static void glFlushPixelDataRangeNV(uint target);
    #endif
    #endif /* GL_NV_pixel_data_range */

    #ifndef GL_NV_point_sprite
    #define GL_NV_point_sprite 1
    public const uint GL_POINT_SPRITE_NV = 0x8861;
    public const uint GL_COORD_REPLACE_NV = 0x8862;
    public const uint GL_POINT_SPRITE_R_MODE_NV = 0x8863;
    private delegate void PFNGLPOINTPARAMETERINVPROC(uint pname, int param);
    private delegate void PFNGLPOINTPARAMETERIVNVPROC(uint pname, const int *params);
    #ifdef GL_GLEXT_PROTOTYPES
    public static void glPointParameteriNV(uint pname, int param);
    public static void glPointParameterivNV(uint pname, const int *params);
    #endif
    #endif /* GL_NV_point_sprite */

    #ifndef GL_NV_present_video
    #define GL_NV_present_video 1
    public const uint GL_FRAME_NV = 0x8E26;
    public const uint GL_FIELDS_NV = 0x8E27;
    public const uint GL_CURRENT_TIME_NV = 0x8E28;
    public const uint GL_NUM_FILL_STREAMS_NV = 0x8E29;
    public const uint GL_PRESENT_TIME_NV = 0x8E2A;
    public const uint GL_PRESENT_DURATION_NV = 0x8E2B;
    private delegate void PFNGLPRESENTFRAMEKEYEDNVPROC(uint video_slot, ulong minPresentTime, uint beginPresentTimeId, uint presentDurationId, uint type, uint target0, uint fill0, uint key0, uint target1, uint fill1, uint key1);
    private delegate void PFNGLPRESENTFRAMEDUALFILLNVPROC(uint video_slot, ulong minPresentTime, uint beginPresentTimeId, uint presentDurationId, uint type, uint target0, uint fill0, uint target1, uint fill1, uint target2, uint fill2, uint target3, uint fill3);
    private delegate void PFNGLGETVIDEOIVNVPROC(uint video_slot, uint pname, int *params);
    private delegate void PFNGLGETVIDEOUIVNVPROC(uint video_slot, uint pname, uint *params);
    private delegate void PFNGLGETVIDEOI64VNVPROC(uint video_slot, uint pname, longEXT *params);
    private delegate void PFNGLGETVIDEOUI64VNVPROC(uint video_slot, uint pname, ulong *params);
    #ifdef GL_GLEXT_PROTOTYPES
    public static void glPresentFrameKeyedNV(uint video_slot, ulong minPresentTime, uint beginPresentTimeId, uint presentDurationId, uint type, uint target0, uint fill0, uint key0, uint target1, uint fill1, uint key1);
    public static void glPresentFrameDualFillNV(uint video_slot, ulong minPresentTime, uint beginPresentTimeId, uint presentDurationId, uint type, uint target0, uint fill0, uint target1, uint fill1, uint target2, uint fill2, uint target3, uint fill3);
    public static void glGetVideoivNV(uint video_slot, uint pname, int *params);
    public static void glGetVideouivNV(uint video_slot, uint pname, uint *params);
    public static void glGetVideoi64vNV(uint video_slot, uint pname, longEXT *params);
    public static void glGetVideoui64vNV(uint video_slot, uint pname, ulong *params);
    #endif
    #endif /* GL_NV_present_video */

    #ifndef GL_NV_primitive_restart
    #define GL_NV_primitive_restart 1
    public const uint GL_PRIMITIVE_RESTART_NV = 0x8558;
    public const uint GL_PRIMITIVE_RESTART_INDEX_NV = 0x8559;
    private delegate void PFNGLPRIMITIVERESTARTNVPROC(void);
    private delegate void PFNGLPRIMITIVERESTARTINDEXNVPROC(uint index);
    #ifdef GL_GLEXT_PROTOTYPES
    public static void glPrimitiveRestartNV(void);
    public static void glPrimitiveRestartIndexNV(uint index);
    #endif
    #endif /* GL_NV_primitive_restart */

    #ifndef GL_NV_register_combiners
    #define GL_NV_register_combiners 1
    public const uint GL_REGISTER_COMBINERS_NV = 0x8522;
    public const uint GL_VARIABLE_A_NV = 0x8523;
    public const uint GL_VARIABLE_B_NV = 0x8524;
    public const uint GL_VARIABLE_C_NV = 0x8525;
    public const uint GL_VARIABLE_D_NV = 0x8526;
    public const uint GL_VARIABLE_E_NV = 0x8527;
    public const uint GL_VARIABLE_F_NV = 0x8528;
    public const uint GL_VARIABLE_G_NV = 0x8529;
    public const uint GL_CONSTANT_COLOR0_NV = 0x852A;
    public const uint GL_CONSTANT_COLOR1_NV = 0x852B;
    public const uint GL_SPARE0_NV = 0x852E;
    public const uint GL_SPARE1_NV = 0x852F;
    public const uint GL_DISCARD_NV = 0x8530;
    public const uint GL_E_TIMES_F_NV = 0x8531;
    public const uint GL_SPARE0_PLUS_SECONDARY_COLOR_NV = 0x8532;
    public const uint GL_UNSIGNED_IDENTITY_NV = 0x8536;
    public const uint GL_UNSIGNED_INVERT_NV = 0x8537;
    public const uint GL_EXPAND_NORMAL_NV = 0x8538;
    public const uint GL_EXPAND_NEGATE_NV = 0x8539;
    public const uint GL_HALF_BIAS_NORMAL_NV = 0x853A;
    public const uint GL_HALF_BIAS_NEGATE_NV = 0x853B;
    public const uint GL_SIGNED_IDENTITY_NV = 0x853C;
    public const uint GL_SIGNED_NEGATE_NV = 0x853D;
    public const uint GL_SCALE_BY_TWO_NV = 0x853E;
    public const uint GL_SCALE_BY_FOUR_NV = 0x853F;
    public const uint GL_SCALE_BY_ONE_HALF_NV = 0x8540;
    public const uint GL_BIAS_BY_NEGATIVE_ONE_HALF_NV = 0x8541;
    public const uint GL_COMBINER_INPUT_NV = 0x8542;
    public const uint GL_COMBINER_MAPPING_NV = 0x8543;
    public const uint GL_COMBINER_COMPONENT_USAGE_NV = 0x8544;
    public const uint GL_COMBINER_AB_DOT_PRODUCT_NV = 0x8545;
    public const uint GL_COMBINER_CD_DOT_PRODUCT_NV = 0x8546;
    public const uint GL_COMBINER_MUX_SUM_NV = 0x8547;
    public const uint GL_COMBINER_SCALE_NV = 0x8548;
    public const uint GL_COMBINER_BIAS_NV = 0x8549;
    public const uint GL_COMBINER_AB_OUTPUT_NV = 0x854A;
    public const uint GL_COMBINER_CD_OUTPUT_NV = 0x854B;
    public const uint GL_COMBINER_SUM_OUTPUT_NV = 0x854C;
    public const uint GL_MAX_GENERAL_COMBINERS_NV = 0x854D;
    public const uint GL_NUM_GENERAL_COMBINERS_NV = 0x854E;
    public const uint GL_COLOR_SUM_CLAMP_NV = 0x854F;
    public const uint GL_COMBINER0_NV = 0x8550;
    public const uint GL_COMBINER1_NV = 0x8551;
    public const uint GL_COMBINER2_NV = 0x8552;
    public const uint GL_COMBINER3_NV = 0x8553;
    public const uint GL_COMBINER4_NV = 0x8554;
    public const uint GL_COMBINER5_NV = 0x8555;
    public const uint GL_COMBINER6_NV = 0x8556;
    public const uint GL_COMBINER7_NV = 0x8557;
    private delegate void PFNGLCOMBINERPARAMETERFVNVPROC(uint pname, const float *params);
    private delegate void PFNGLCOMBINERPARAMETERFNVPROC(uint pname, float param);
    private delegate void PFNGLCOMBINERPARAMETERIVNVPROC(uint pname, const int *params);
    private delegate void PFNGLCOMBINERPARAMETERINVPROC(uint pname, int param);
    private delegate void PFNGLCOMBINERINPUTNVPROC(uint stage, uint portion, uint variable, uint input, uint mapping, uint componentUsage);
    private delegate void PFNGLCOMBINEROUTPUTNVPROC(uint stage, uint portion, uint abOutput, uint cdOutput, uint sumOutput, uint scale, uint bias, bool abDotProduct, bool cdDotProduct, bool muxSum);
    private delegate void PFNGLFINALCOMBINERINPUTNVPROC(uint variable, uint input, uint mapping, uint componentUsage);
    private delegate void PFNGLGETCOMBINERINPUTPARAMETERFVNVPROC(uint stage, uint portion, uint variable, uint pname, float *params);
    private delegate void PFNGLGETCOMBINERINPUTPARAMETERIVNVPROC(uint stage, uint portion, uint variable, uint pname, int *params);
    private delegate void PFNGLGETCOMBINEROUTPUTPARAMETERFVNVPROC(uint stage, uint portion, uint pname, float *params);
    private delegate void PFNGLGETCOMBINEROUTPUTPARAMETERIVNVPROC(uint stage, uint portion, uint pname, int *params);
    private delegate void PFNGLGETFINALCOMBINERINPUTPARAMETERFVNVPROC(uint variable, uint pname, float *params);
    private delegate void PFNGLGETFINALCOMBINERINPUTPARAMETERIVNVPROC(uint variable, uint pname, int *params);
    #ifdef GL_GLEXT_PROTOTYPES
    public static void glCombinerParameterfvNV(uint pname, const float *params);
    public static void glCombinerParameterfNV(uint pname, float param);
    public static void glCombinerParameterivNV(uint pname, const int *params);
    public static void glCombinerParameteriNV(uint pname, int param);
    public static void glCombinerInputNV(uint stage, uint portion, uint variable, uint input, uint mapping, uint componentUsage);
    public static void glCombinerOutputNV(uint stage, uint portion, uint abOutput, uint cdOutput, uint sumOutput, uint scale, uint bias, bool abDotProduct, bool cdDotProduct, bool muxSum);
    public static void glFinalCombinerInputNV(uint variable, uint input, uint mapping, uint componentUsage);
    public static void glGetCombinerInputParameterfvNV(uint stage, uint portion, uint variable, uint pname, float *params);
    public static void glGetCombinerInputParameterivNV(uint stage, uint portion, uint variable, uint pname, int *params);
    public static void glGetCombinerOutputParameterfvNV(uint stage, uint portion, uint pname, float *params);
    public static void glGetCombinerOutputParameterivNV(uint stage, uint portion, uint pname, int *params);
    public static void glGetFinalCombinerInputParameterfvNV(uint variable, uint pname, float *params);
    public static void glGetFinalCombinerInputParameterivNV(uint variable, uint pname, int *params);
    #endif
    #endif /* GL_NV_register_combiners */

    #ifndef GL_NV_register_combiners2
    #define GL_NV_register_combiners2 1
    public const uint GL_PER_STAGE_CONSTANTS_NV = 0x8535;
    private delegate void PFNGLCOMBINERSTAGEPARAMETERFVNVPROC(uint stage, uint pname, const float *params);
    private delegate void PFNGLGETCOMBINERSTAGEPARAMETERFVNVPROC(uint stage, uint pname, float *params);
    #ifdef GL_GLEXT_PROTOTYPES
    public static void glCombinerStageParameterfvNV(uint stage, uint pname, const float *params);
    public static void glGetCombinerStageParameterfvNV(uint stage, uint pname, float *params);
    #endif
    #endif /* GL_NV_register_combiners2 */

    #ifndef GL_NV_shader_atomic_counters
    #define GL_NV_shader_atomic_counters 1
    #endif /* GL_NV_shader_atomic_counters */

    #ifndef GL_NV_shader_atomic_float
    #define GL_NV_shader_atomic_float 1
    #endif /* GL_NV_shader_atomic_float */

    #ifndef GL_NV_shader_buffer_load
    #define GL_NV_shader_buffer_load 1
    public const uint GL_BUFFER_GPU_ADDRESS_NV = 0x8F1D;
    public const uint GL_GPU_ADDRESS_NV = 0x8F34;
    public const uint GL_MAX_SHADER_BUFFER_ADDRESS_NV = 0x8F35;
    private delegate void PFNGLMAKEBUFFERRESIDENTNVPROC(uint target, uint access);
    private delegate void PFNGLMAKEBUFFERNONRESIDENTNVPROC(uint target);
    private delegate bool PFNGLISBUFFERRESIDENTNVPROC(uint target);
    private delegate void PFNGLMAKENAMEDBUFFERRESIDENTNVPROC(uint buffer, uint access);
    private delegate void PFNGLMAKENAMEDBUFFERNONRESIDENTNVPROC(uint buffer);
    private delegate bool PFNGLISNAMEDBUFFERRESIDENTNVPROC(uint buffer);
    private delegate void PFNGLGETBUFFERPARAMETERUI64VNVPROC(uint target, uint pname, ulong *params);
    private delegate void PFNGLGETNAMEDBUFFERPARAMETERUI64VNVPROC(uint buffer, uint pname, ulong *params);
    private delegate void PFNGLGETINTEGERUI64VNVPROC(uint value, ulong *result);
    private delegate void PFNGLUNIFORMUI64NVPROC(int location, ulong value);
    private delegate void PFNGLUNIFORMUI64VNVPROC(int location, uint count, const ulong *value);
    private delegate void PFNGLGETUNIFORMUI64VNVPROC(uint program, int location, ulong *params);
    private delegate void PFNGLPROGRAMUNIFORMUI64NVPROC(uint program, int location, ulong value);
    private delegate void PFNGLPROGRAMUNIFORMUI64VNVPROC(uint program, int location, uint count, const ulong *value);
    #ifdef GL_GLEXT_PROTOTYPES
    public static void glMakeBufferResidentNV(uint target, uint access);
    public static void glMakeBufferNonResidentNV(uint target);
    public static bool glIsBufferResidentNV(uint target);
    public static void glMakeNamedBufferResidentNV(uint buffer, uint access);
    public static void glMakeNamedBufferNonResidentNV(uint buffer);
    public static bool glIsNamedBufferResidentNV(uint buffer);
    public static void glGetBufferParameterui64vNV(uint target, uint pname, ulong *params);
    public static void glGetNamedBufferParameterui64vNV(uint buffer, uint pname, ulong *params);
    public static void glGetIntegerui64vNV(uint value, ulong *result);
    public static void glUniformui64NV(int location, ulong value);
    public static void glUniformui64vNV(int location, uint count, const ulong *value);
    public static void glGetUniformui64vNV(uint program, int location, ulong *params);
    public static void glProgramUniformui64NV(uint program, int location, ulong value);
    public static void glProgramUniformui64vNV(uint program, int location, uint count, const ulong *value);
    #endif
    #endif /* GL_NV_shader_buffer_load */

    #ifndef GL_NV_shader_buffer_store
    #define GL_NV_shader_buffer_store 1
    public const uint GL_SHADER_GLOBAL_ACCESS_BARRIER_BIT_NV = 0x00000010;
    #endif /* GL_NV_shader_buffer_store */

    #ifndef GL_NV_shader_storage_buffer_object
    #define GL_NV_shader_storage_buffer_object 1
    #endif /* GL_NV_shader_storage_buffer_object */

    #ifndef GL_NV_tessellation_program5
    #define GL_NV_tessellation_program5 1
    public const uint GL_MAX_PROGRAM_PATCH_ATTRIBS_NV = 0x86D8;
    public const uint GL_TESS_CONTROL_PROGRAM_NV = 0x891E;
    public const uint GL_TESS_EVALUATION_PROGRAM_NV = 0x891F;
    public const uint GL_TESS_CONTROL_PROGRAM_PARAMETER_BUFFER_NV = 0x8C74;
    public const uint GL_TESS_EVALUATION_PROGRAM_PARAMETER_BUFFER_NV = 0x8C75;
    #endif /* GL_NV_tessellation_program5 */

    #ifndef GL_NV_texgen_emboss
    #define GL_NV_texgen_emboss 1
    public const uint GL_EMBOSS_LIGHT_NV = 0x855D;
    public const uint GL_EMBOSS_CONSTANT_NV = 0x855E;
    public const uint GL_EMBOSS_MAP_NV = 0x855F;
    #endif /* GL_NV_texgen_emboss */

    #ifndef GL_NV_texgen_reflection
    #define GL_NV_texgen_reflection 1
    public const uint GL_NORMAL_MAP_NV = 0x8511;
    public const uint GL_REFLECTION_MAP_NV = 0x8512;
    #endif /* GL_NV_texgen_reflection */

    #ifndef GL_NV_texture_barrier
    #define GL_NV_texture_barrier 1
    private delegate void PFNGLTEXTUREBARRIERNVPROC(void);
    #ifdef GL_GLEXT_PROTOTYPES
    public static void glTextureBarrierNV(void);
    #endif
    #endif /* GL_NV_texture_barrier */

    #ifndef GL_NV_texture_compression_vtc
    #define GL_NV_texture_compression_vtc 1
    #endif /* GL_NV_texture_compression_vtc */

    #ifndef GL_NV_texture_env_combine4
    #define GL_NV_texture_env_combine4 1
    public const uint GL_COMBINE4_NV = 0x8503;
    public const uint GL_SOURCE3_RGB_NV = 0x8583;
    public const uint GL_SOURCE3_ALPHA_NV = 0x858B;
    public const uint GL_OPERAND3_RGB_NV = 0x8593;
    public const uint GL_OPERAND3_ALPHA_NV = 0x859B;
    #endif /* GL_NV_texture_env_combine4 */

    #ifndef GL_NV_texture_expand_normal
    #define GL_NV_texture_expand_normal 1
    public const uint GL_TEXTURE_UNSIGNED_REMAP_MODE_NV = 0x888F;
    #endif /* GL_NV_texture_expand_normal */

    #ifndef GL_NV_texture_multisample
    #define GL_NV_texture_multisample 1
    public const uint GL_TEXTURE_COVERAGE_SAMPLES_NV = 0x9045;
    public const uint GL_TEXTURE_COLOR_SAMPLES_NV = 0x9046;
    private delegate void PFNGLTEXIMAGE2DMULTISAMPLECOVERAGENVPROC(uint target, uint coverageSamples, uint colorSamples, int internalFormat, uint width, uint height, bool fixedSampleLocations);
    private delegate void PFNGLTEXIMAGE3DMULTISAMPLECOVERAGENVPROC(uint target, uint coverageSamples, uint colorSamples, int internalFormat, uint width, uint height, uint depth, bool fixedSampleLocations);
    private delegate void PFNGLTEXTUREIMAGE2DMULTISAMPLENVPROC(uint texture, uint target, uint samples, int internalFormat, uint width, uint height, bool fixedSampleLocations);
    private delegate void PFNGLTEXTUREIMAGE3DMULTISAMPLENVPROC(uint texture, uint target, uint samples, int internalFormat, uint width, uint height, uint depth, bool fixedSampleLocations);
    private delegate void PFNGLTEXTUREIMAGE2DMULTISAMPLECOVERAGENVPROC(uint texture, uint target, uint coverageSamples, uint colorSamples, int internalFormat, uint width, uint height, bool fixedSampleLocations);
    private delegate void PFNGLTEXTUREIMAGE3DMULTISAMPLECOVERAGENVPROC(uint texture, uint target, uint coverageSamples, uint colorSamples, int internalFormat, uint width, uint height, uint depth, bool fixedSampleLocations);
    #ifdef GL_GLEXT_PROTOTYPES
    public static void glTexImage2DMultisampleCoverageNV(uint target, uint coverageSamples, uint colorSamples, int internalFormat, uint width, uint height, bool fixedSampleLocations);
    public static void glTexImage3DMultisampleCoverageNV(uint target, uint coverageSamples, uint colorSamples, int internalFormat, uint width, uint height, uint depth, bool fixedSampleLocations);
    public static void glTextureImage2DMultisampleNV(uint texture, uint target, uint samples, int internalFormat, uint width, uint height, bool fixedSampleLocations);
    public static void glTextureImage3DMultisampleNV(uint texture, uint target, uint samples, int internalFormat, uint width, uint height, uint depth, bool fixedSampleLocations);
    public static void glTextureImage2DMultisampleCoverageNV(uint texture, uint target, uint coverageSamples, uint colorSamples, int internalFormat, uint width, uint height, bool fixedSampleLocations);
    public static void glTextureImage3DMultisampleCoverageNV(uint texture, uint target, uint coverageSamples, uint colorSamples, int internalFormat, uint width, uint height, uint depth, bool fixedSampleLocations);
    #endif
    #endif /* GL_NV_texture_multisample */

    #ifndef GL_NV_texture_rectangle
    #define GL_NV_texture_rectangle 1
    public const uint GL_TEXTURE_RECTANGLE_NV = 0x84F5;
    public const uint GL_TEXTURE_BINDING_RECTANGLE_NV = 0x84F6;
    public const uint GL_PROXY_TEXTURE_RECTANGLE_NV = 0x84F7;
    public const uint GL_MAX_RECTANGLE_TEXTURE_SIZE_NV = 0x84F8;
    #endif /* GL_NV_texture_rectangle */

    #ifndef GL_NV_texture_shader
    #define GL_NV_texture_shader 1
    public const uint GL_OFFSET_TEXTURE_RECTANGLE_NV = 0x864C;
    public const uint GL_OFFSET_TEXTURE_RECTANGLE_SCALE_NV = 0x864D;
    public const uint GL_DOT_PRODUCT_TEXTURE_RECTANGLE_NV = 0x864E;
    public const uint GL_RGBA_UNSIGNED_DOT_PRODUCT_MAPPING_NV = 0x86D9;
    public const uint GL_UNSIGNED_INT_S8_S8_8_8_NV = 0x86DA;
    public const uint GL_UNSIGNED_INT_8_8_S8_S8_REV_NV = 0x86DB;
    public const uint GL_DSDT_MAG_INTENSITY_NV = 0x86DC;
    public const uint GL_SHADER_CONSISTENT_NV = 0x86DD;
    public const uint GL_TEXTURE_SHADER_NV = 0x86DE;
    public const uint GL_SHADER_OPERATION_NV = 0x86DF;
    public const uint GL_CULL_MODES_NV = 0x86E0;
    public const uint GL_OFFSET_TEXTURE_MATRIX_NV = 0x86E1;
    public const uint GL_OFFSET_TEXTURE_SCALE_NV = 0x86E2;
    public const uint GL_OFFSET_TEXTURE_BIAS_NV = 0x86E3;
    public const uint GL_OFFSET_TEXTURE_2D_MATRIX_NV = 0x86E1;
    public const uint GL_OFFSET_TEXTURE_2D_SCALE_NV = 0x86E2;
    public const uint GL_OFFSET_TEXTURE_2D_BIAS_NV = 0x86E3;
    public const uint GL_PREVIOUS_TEXTURE_INPUT_NV = 0x86E4;
    public const uint GL_CONST_EYE_NV = 0x86E5;
    public const uint GL_PASS_THROUGH_NV = 0x86E6;
    public const uint GL_CULL_FRAGMENT_NV = 0x86E7;
    public const uint GL_OFFSET_TEXTURE_2D_NV = 0x86E8;
    public const uint GL_DEPENDENT_AR_TEXTURE_2D_NV = 0x86E9;
    public const uint GL_DEPENDENT_GB_TEXTURE_2D_NV = 0x86EA;
    public const uint GL_DOT_PRODUCT_NV = 0x86EC;
    public const uint GL_DOT_PRODUCT_DEPTH_REPLACE_NV = 0x86ED;
    public const uint GL_DOT_PRODUCT_TEXTURE_2D_NV = 0x86EE;
    public const uint GL_DOT_PRODUCT_TEXTURE_CUBE_MAP_NV = 0x86F0;
    public const uint GL_DOT_PRODUCT_DIFFUSE_CUBE_MAP_NV = 0x86F1;
    public const uint GL_DOT_PRODUCT_REFLECT_CUBE_MAP_NV = 0x86F2;
    public const uint GL_DOT_PRODUCT_CONST_EYE_REFLECT_CUBE_MAP_NV = 0x86F3;
    public const uint GL_HILO_NV = 0x86F4;
    public const uint GL_DSDT_NV = 0x86F5;
    public const uint GL_DSDT_MAG_NV = 0x86F6;
    public const uint GL_DSDT_MAG_VIB_NV = 0x86F7;
    public const uint GL_HILO16_NV = 0x86F8;
    public const uint GL_SIGNED_HILO_NV = 0x86F9;
    public const uint GL_SIGNED_HILO16_NV = 0x86FA;
    public const uint GL_SIGNED_RGBA_NV = 0x86FB;
    public const uint GL_SIGNED_RGBA8_NV = 0x86FC;
    public const uint GL_SIGNED_RGB_NV = 0x86FE;
    public const uint GL_SIGNED_RGB8_NV = 0x86FF;
    public const uint GL_SIGNED_LUMINANCE_NV = 0x8701;
    public const uint GL_SIGNED_LUMINANCE8_NV = 0x8702;
    public const uint GL_SIGNED_LUMINANCE_ALPHA_NV = 0x8703;
    public const uint GL_SIGNED_LUMINANCE8_ALPHA8_NV = 0x8704;
    public const uint GL_SIGNED_ALPHA_NV = 0x8705;
    public const uint GL_SIGNED_ALPHA8_NV = 0x8706;
    public const uint GL_SIGNED_INTENSITY_NV = 0x8707;
    public const uint GL_SIGNED_INTENSITY8_NV = 0x8708;
    public const uint GL_DSDT8_NV = 0x8709;
    public const uint GL_DSDT8_MAG8_NV = 0x870A;
    public const uint GL_DSDT8_MAG8_INTENSITY8_NV = 0x870B;
    public const uint GL_SIGNED_RGB_UNSIGNED_ALPHA_NV = 0x870C;
    public const uint GL_SIGNED_RGB8_UNSIGNED_ALPHA8_NV = 0x870D;
    public const uint GL_HI_SCALE_NV = 0x870E;
    public const uint GL_LO_SCALE_NV = 0x870F;
    public const uint GL_DS_SCALE_NV = 0x8710;
    public const uint GL_DT_SCALE_NV = 0x8711;
    public const uint GL_MAGNITUDE_SCALE_NV = 0x8712;
    public const uint GL_VIBRANCE_SCALE_NV = 0x8713;
    public const uint GL_HI_BIAS_NV = 0x8714;
    public const uint GL_LO_BIAS_NV = 0x8715;
    public const uint GL_DS_BIAS_NV = 0x8716;
    public const uint GL_DT_BIAS_NV = 0x8717;
    public const uint GL_MAGNITUDE_BIAS_NV = 0x8718;
    public const uint GL_VIBRANCE_BIAS_NV = 0x8719;
    public const uint GL_TEXTURE_BORDER_VALUES_NV = 0x871A;
    public const uint GL_TEXTURE_HI_SIZE_NV = 0x871B;
    public const uint GL_TEXTURE_LO_SIZE_NV = 0x871C;
    public const uint GL_TEXTURE_DS_SIZE_NV = 0x871D;
    public const uint GL_TEXTURE_DT_SIZE_NV = 0x871E;
    public const uint GL_TEXTURE_MAG_SIZE_NV = 0x871F;
    #endif /* GL_NV_texture_shader */

    #ifndef GL_NV_texture_shader2
    #define GL_NV_texture_shader2 1
    public const uint GL_DOT_PRODUCT_TEXTURE_3D_NV = 0x86EF;
    #endif /* GL_NV_texture_shader2 */

    #ifndef GL_NV_texture_shader3
    #define GL_NV_texture_shader3 1
    public const uint GL_OFFSET_PROJECTIVE_TEXTURE_2D_NV = 0x8850;
    public const uint GL_OFFSET_PROJECTIVE_TEXTURE_2D_SCALE_NV = 0x8851;
    public const uint GL_OFFSET_PROJECTIVE_TEXTURE_RECTANGLE_NV = 0x8852;
    public const uint GL_OFFSET_PROJECTIVE_TEXTURE_RECTANGLE_SCALE_NV = 0x8853;
    public const uint GL_OFFSET_HILO_TEXTURE_2D_NV = 0x8854;
    public const uint GL_OFFSET_HILO_TEXTURE_RECTANGLE_NV = 0x8855;
    public const uint GL_OFFSET_HILO_PROJECTIVE_TEXTURE_2D_NV = 0x8856;
    public const uint GL_OFFSET_HILO_PROJECTIVE_TEXTURE_RECTANGLE_NV = 0x8857;
    public const uint GL_DEPENDENT_HILO_TEXTURE_2D_NV = 0x8858;
    public const uint GL_DEPENDENT_RGB_TEXTURE_3D_NV = 0x8859;
    public const uint GL_DEPENDENT_RGB_TEXTURE_CUBE_MAP_NV = 0x885A;
    public const uint GL_DOT_PRODUCT_PASS_THROUGH_NV = 0x885B;
    public const uint GL_DOT_PRODUCT_TEXTURE_1D_NV = 0x885C;
    public const uint GL_DOT_PRODUCT_AFFINE_DEPTH_REPLACE_NV = 0x885D;
    public const uint GL_HILO8_NV = 0x885E;
    public const uint GL_SIGNED_HILO8_NV = 0x885F;
    public const uint GL_FORCE_BLUE_TO_ONE_NV = 0x8860;
    #endif /* GL_NV_texture_shader3 */

    #ifndef GL_NV_transform_feedback
    #define GL_NV_transform_feedback 1
    public const uint GL_BACK_PRIMARY_COLOR_NV = 0x8C77;
    public const uint GL_BACK_SECONDARY_COLOR_NV = 0x8C78;
    public const uint GL_TEXTURE_COORD_NV = 0x8C79;
    public const uint GL_CLIP_DISTANCE_NV = 0x8C7A;
    public const uint GL_VERTEX_ID_NV = 0x8C7B;
    public const uint GL_PRIMITIVE_ID_NV = 0x8C7C;
    public const uint GL_GENERIC_ATTRIB_NV = 0x8C7D;
    public const uint GL_TRANSFORM_FEEDBACK_ATTRIBS_NV = 0x8C7E;
    public const uint GL_TRANSFORM_FEEDBACK_BUFFER_MODE_NV = 0x8C7F;
    public const uint GL_MAX_TRANSFORM_FEEDBACK_SEPARATE_COMPONENTS_NV = 0x8C80;
    public const uint GL_ACTIVE_VARYINGS_NV = 0x8C81;
    public const uint GL_ACTIVE_VARYING_MAX_LENGTH_NV = 0x8C82;
    public const uint GL_TRANSFORM_FEEDBACK_VARYINGS_NV = 0x8C83;
    public const uint GL_TRANSFORM_FEEDBACK_BUFFER_START_NV = 0x8C84;
    public const uint GL_TRANSFORM_FEEDBACK_BUFFER_SIZE_NV = 0x8C85;
    public const uint GL_TRANSFORM_FEEDBACK_RECORD_NV = 0x8C86;
    public const uint GL_PRIMITIVES_GENERATED_NV = 0x8C87;
    public const uint GL_TRANSFORM_FEEDBACK_PRIMITIVES_WRITTEN_NV = 0x8C88;
    public const uint GL_RASTERIZER_DISCARD_NV = 0x8C89;
    public const uint GL_MAX_TRANSFORM_FEEDBACK_INTERLEAVED_COMPONENTS_NV = 0x8C8A;
    public const uint GL_MAX_TRANSFORM_FEEDBACK_SEPARATE_ATTRIBS_NV = 0x8C8B;
    public const uint GL_INTERLEAVED_ATTRIBS_NV = 0x8C8C;
    public const uint GL_SEPARATE_ATTRIBS_NV = 0x8C8D;
    public const uint GL_TRANSFORM_FEEDBACK_BUFFER_NV = 0x8C8E;
    public const uint GL_TRANSFORM_FEEDBACK_BUFFER_BINDING_NV = 0x8C8F;
    public const uint GL_LAYER_NV = 0x8DAA;
    #define GL_NEXT_BUFFER_NV                 -2
    #define GL_SKIP_COMPONENTS4_NV            -3
    #define GL_SKIP_COMPONENTS3_NV            -4
    #define GL_SKIP_COMPONENTS2_NV            -5
    #define GL_SKIP_COMPONENTS1_NV            -6
    private delegate void PFNGLBEGINTRANSFORMFEEDBACKNVPROC(uint primitiveMode);
    private delegate void PFNGLENDTRANSFORMFEEDBACKNVPROC(void);
    private delegate void PFNGLTRANSFORMFEEDBACKATTRIBSNVPROC(uint count, const int *attribs, uint bufferMode);
    private delegate void PFNGLBINDBUFFERRANGENVPROC(uint target, uint index, uint buffer, intptr offset, uintptr size);
    private delegate void PFNGLBINDBUFFEROFFSETNVPROC(uint target, uint index, uint buffer, intptr offset);
    private delegate void PFNGLBINDBUFFERBASENVPROC(uint target, uint index, uint buffer);
    private delegate void PFNGLTRANSFORMFEEDBACKVARYINGSNVPROC(uint program, uint count, const int *locations, uint bufferMode);
    private delegate void PFNGLACTIVEVARYINGNVPROC(uint program, const byte *name);
    private delegate int PFNGLGETVARYINGLOCATIONNVPROC(uint program, const byte *name);
    private delegate void PFNGLGETACTIVEVARYINGNVPROC(uint program, uint index, uint bufSize, uint *length, uint *size, uint *type, byte *name);
    private delegate void PFNGLGETTRANSFORMFEEDBACKVARYINGNVPROC(uint program, uint index, int *location);
    private delegate void PFNGLTRANSFORMFEEDBACKSTREAMATTRIBSNVPROC(uint count, const int *attribs, uint nbuffers, const int *bufstreams, uint bufferMode);
    #ifdef GL_GLEXT_PROTOTYPES
    public static void glBeginTransformFeedbackNV(uint primitiveMode);
    public static void glEndTransformFeedbackNV(void);
    public static void glTransformFeedbackAttribsNV(uint count, const int *attribs, uint bufferMode);
    public static void glBindBufferRangeNV(uint target, uint index, uint buffer, intptr offset, uintptr size);
    public static void glBindBufferOffsetNV(uint target, uint index, uint buffer, intptr offset);
    public static void glBindBufferBaseNV(uint target, uint index, uint buffer);
    public static void glTransformFeedbackVaryingsNV(uint program, uint count, const int *locations, uint bufferMode);
    public static void glActiveVaryingNV(uint program, const byte *name);
    public static int glGetVaryingLocationNV(uint program, const byte *name);
    public static void glGetActiveVaryingNV(uint program, uint index, uint bufSize, uint *length, uint *size, uint *type, byte *name);
    public static void glGetTransformFeedbackVaryingNV(uint program, uint index, int *location);
    public static void glTransformFeedbackStreamAttribsNV(uint count, const int *attribs, uint nbuffers, const int *bufstreams, uint bufferMode);
    #endif
    #endif /* GL_NV_transform_feedback */

    #ifndef GL_NV_transform_feedback2
    #define GL_NV_transform_feedback2 1
    public const uint GL_TRANSFORM_FEEDBACK_NV = 0x8E22;
    public const uint GL_TRANSFORM_FEEDBACK_BUFFER_PAUSED_NV = 0x8E23;
    public const uint GL_TRANSFORM_FEEDBACK_BUFFER_ACTIVE_NV = 0x8E24;
    public const uint GL_TRANSFORM_FEEDBACK_BINDING_NV = 0x8E25;
    private delegate void PFNGLBINDTRANSFORMFEEDBACKNVPROC(uint target, uint id);
    private delegate void PFNGLDELETETRANSFORMFEEDBACKSNVPROC(uint n, const uint *ids);
    private delegate void PFNGLGENTRANSFORMFEEDBACKSNVPROC(uint n, uint *ids);
    private delegate bool PFNGLISTRANSFORMFEEDBACKNVPROC(uint id);
    private delegate void PFNGLPAUSETRANSFORMFEEDBACKNVPROC(void);
    private delegate void PFNGLRESUMETRANSFORMFEEDBACKNVPROC(void);
    private delegate void PFNGLDRAWTRANSFORMFEEDBACKNVPROC(uint mode, uint id);
    #ifdef GL_GLEXT_PROTOTYPES
    public static void glBindTransformFeedbackNV(uint target, uint id);
    public static void glDeleteTransformFeedbacksNV(uint n, const uint *ids);
    public static void glGenTransformFeedbacksNV(uint n, uint *ids);
    public static bool glIsTransformFeedbackNV(uint id);
    public static void glPauseTransformFeedbackNV(void);
    public static void glResumeTransformFeedbackNV(void);
    public static void glDrawTransformFeedbackNV(uint mode, uint id);
    #endif
    #endif /* GL_NV_transform_feedback2 */

    #ifndef GL_NV_vdpau_interop
    #define GL_NV_vdpau_interop 1
    typedef intptr GLvdpauSurfaceNV;
    public const uint GL_SURFACE_STATE_NV = 0x86EB;
    public const uint GL_SURFACE_REGISTERED_NV = 0x86FD;
    public const uint GL_SURFACE_MAPPED_NV = 0x8700;
    public const uint GL_WRITE_DISCARD_NV = 0x88BE;
    private delegate void PFNGLVDPAUINITNVPROC(const void *vdpDevice, const void *getProcAddress);
    private delegate void PFNGLVDPAUFININVPROC(void);
    private delegate GLvdpauSurfaceNV PFNGLVDPAUREGISTERVIDEOSURFACENVPROC(const void *vdpSurface, uint target, uint numTextureNames, const uint *textureNames);
    private delegate GLvdpauSurfaceNV PFNGLVDPAUREGISTEROUTPUTSURFACENVPROC(const void *vdpSurface, uint target, uint numTextureNames, const uint *textureNames);
    private delegate void PFNGLVDPAUISSURFACENVPROC(GLvdpauSurfaceNV surface);
    private delegate void PFNGLVDPAUUNREGISTERSURFACENVPROC(GLvdpauSurfaceNV surface);
    private delegate void PFNGLVDPAUGETSURFACEIVNVPROC(GLvdpauSurfaceNV surface, uint pname, uint bufSize, uint *length, int *values);
    private delegate void PFNGLVDPAUSURFACEACCESSNVPROC(GLvdpauSurfaceNV surface, uint access);
    private delegate void PFNGLVDPAUMAPSURFACESNVPROC(uint numSurfaces, const GLvdpauSurfaceNV *surfaces);
    private delegate void PFNGLVDPAUUNMAPSURFACESNVPROC(uint numSurface, const GLvdpauSurfaceNV *surfaces);
    #ifdef GL_GLEXT_PROTOTYPES
    public static void glVDPAUInitNV(const void *vdpDevice, const void *getProcAddress);
    public static void glVDPAUFiniNV(void);
    public static GLvdpauSurfaceNV glVDPAURegisterVideoSurfaceNV(const void *vdpSurface, uint target, uint numTextureNames, const uint *textureNames);
    public static GLvdpauSurfaceNV glVDPAURegisterOutputSurfaceNV(const void *vdpSurface, uint target, uint numTextureNames, const uint *textureNames);
    public static void glVDPAUIsSurfaceNV(GLvdpauSurfaceNV surface);
    public static void glVDPAUUnregisterSurfaceNV(GLvdpauSurfaceNV surface);
    public static void glVDPAUGetSurfaceivNV(GLvdpauSurfaceNV surface, uint pname, uint bufSize, uint *length, int *values);
    public static void glVDPAUSurfaceAccessNV(GLvdpauSurfaceNV surface, uint access);
    public static void glVDPAUMapSurfacesNV(uint numSurfaces, const GLvdpauSurfaceNV *surfaces);
    public static void glVDPAUUnmapSurfacesNV(uint numSurface, const GLvdpauSurfaceNV *surfaces);
    #endif
    #endif /* GL_NV_vdpau_interop */

    #ifndef GL_NV_vertex_array_range
    #define GL_NV_vertex_array_range 1
    public const uint GL_VERTEX_ARRAY_RANGE_NV = 0x851D;
    public const uint GL_VERTEX_ARRAY_RANGE_LENGTH_NV = 0x851E;
    public const uint GL_VERTEX_ARRAY_RANGE_VALID_NV = 0x851F;
    public const uint GL_MAX_VERTEX_ARRAY_RANGE_ELEMENT_NV = 0x8520;
    public const uint GL_VERTEX_ARRAY_RANGE_POINTER_NV = 0x8521;
    private delegate void PFNGLFLUSHVERTEXARRAYRANGENVPROC(void);
    private delegate void PFNGLVERTEXARRAYRANGENVPROC(uint length, const void *pointer);
    #ifdef GL_GLEXT_PROTOTYPES
    public static void glFlushVertexArrayRangeNV(void);
    public static void glVertexArrayRangeNV(uint length, const void *pointer);
    #endif
    #endif /* GL_NV_vertex_array_range */

    #ifndef GL_NV_vertex_array_range2
    #define GL_NV_vertex_array_range2 1
    public const uint GL_VERTEX_ARRAY_RANGE_WITHOUT_FLUSH_NV = 0x8533;
    #endif /* GL_NV_vertex_array_range2 */

    #ifndef GL_NV_vertex_attrib_integer_64bit
    #define GL_NV_vertex_attrib_integer_64bit 1
    private delegate void PFNGLVERTEXATTRIBL1I64NVPROC(uint index, longEXT x);
    private delegate void PFNGLVERTEXATTRIBL2I64NVPROC(uint index, longEXT x, longEXT y);
    private delegate void PFNGLVERTEXATTRIBL3I64NVPROC(uint index, longEXT x, longEXT y, longEXT z);
    private delegate void PFNGLVERTEXATTRIBL4I64NVPROC(uint index, longEXT x, longEXT y, longEXT z, longEXT w);
    private delegate void PFNGLVERTEXATTRIBL1I64VNVPROC(uint index, const longEXT *v);
    private delegate void PFNGLVERTEXATTRIBL2I64VNVPROC(uint index, const longEXT *v);
    private delegate void PFNGLVERTEXATTRIBL3I64VNVPROC(uint index, const longEXT *v);
    private delegate void PFNGLVERTEXATTRIBL4I64VNVPROC(uint index, const longEXT *v);
    private delegate void PFNGLVERTEXATTRIBL1UI64NVPROC(uint index, ulong x);
    private delegate void PFNGLVERTEXATTRIBL2UI64NVPROC(uint index, ulong x, ulong y);
    private delegate void PFNGLVERTEXATTRIBL3UI64NVPROC(uint index, ulong x, ulong y, ulong z);
    private delegate void PFNGLVERTEXATTRIBL4UI64NVPROC(uint index, ulong x, ulong y, ulong z, ulong w);
    private delegate void PFNGLVERTEXATTRIBL1UI64VNVPROC(uint index, const ulong *v);
    private delegate void PFNGLVERTEXATTRIBL2UI64VNVPROC(uint index, const ulong *v);
    private delegate void PFNGLVERTEXATTRIBL3UI64VNVPROC(uint index, const ulong *v);
    private delegate void PFNGLVERTEXATTRIBL4UI64VNVPROC(uint index, const ulong *v);
    private delegate void PFNGLGETVERTEXATTRIBLI64VNVPROC(uint index, uint pname, longEXT *params);
    private delegate void PFNGLGETVERTEXATTRIBLUI64VNVPROC(uint index, uint pname, ulong *params);
    private delegate void PFNGLVERTEXATTRIBLFORMATNVPROC(uint index, int size, uint type, uint stride);
    #ifdef GL_GLEXT_PROTOTYPES
    public static void glVertexAttribL1i64NV(uint index, longEXT x);
    public static void glVertexAttribL2i64NV(uint index, longEXT x, longEXT y);
    public static void glVertexAttribL3i64NV(uint index, longEXT x, longEXT y, longEXT z);
    public static void glVertexAttribL4i64NV(uint index, longEXT x, longEXT y, longEXT z, longEXT w);
    public static void glVertexAttribL1i64vNV(uint index, const longEXT *v);
    public static void glVertexAttribL2i64vNV(uint index, const longEXT *v);
    public static void glVertexAttribL3i64vNV(uint index, const longEXT *v);
    public static void glVertexAttribL4i64vNV(uint index, const longEXT *v);
    public static void glVertexAttribL1ui64NV(uint index, ulong x);
    public static void glVertexAttribL2ui64NV(uint index, ulong x, ulong y);
    public static void glVertexAttribL3ui64NV(uint index, ulong x, ulong y, ulong z);
    public static void glVertexAttribL4ui64NV(uint index, ulong x, ulong y, ulong z, ulong w);
    public static void glVertexAttribL1ui64vNV(uint index, const ulong *v);
    public static void glVertexAttribL2ui64vNV(uint index, const ulong *v);
    public static void glVertexAttribL3ui64vNV(uint index, const ulong *v);
    public static void glVertexAttribL4ui64vNV(uint index, const ulong *v);
    public static void glGetVertexAttribLi64vNV(uint index, uint pname, longEXT *params);
    public static void glGetVertexAttribLui64vNV(uint index, uint pname, ulong *params);
    public static void glVertexAttribLFormatNV(uint index, int size, uint type, uint stride);
    #endif
    #endif /* GL_NV_vertex_attrib_integer_64bit */

    #ifndef GL_NV_vertex_buffer_unified_memory
    #define GL_NV_vertex_buffer_unified_memory 1
    public const uint GL_VERTEX_ATTRIB_ARRAY_UNIFIED_NV = 0x8F1E;
    public const uint GL_ELEMENT_ARRAY_UNIFIED_NV = 0x8F1F;
    public const uint GL_VERTEX_ATTRIB_ARRAY_ADDRESS_NV = 0x8F20;
    public const uint GL_VERTEX_ARRAY_ADDRESS_NV = 0x8F21;
    public const uint GL_NORMAL_ARRAY_ADDRESS_NV = 0x8F22;
    public const uint GL_COLOR_ARRAY_ADDRESS_NV = 0x8F23;
    public const uint GL_INDEX_ARRAY_ADDRESS_NV = 0x8F24;
    public const uint GL_TEXTURE_COORD_ARRAY_ADDRESS_NV = 0x8F25;
    public const uint GL_EDGE_FLAG_ARRAY_ADDRESS_NV = 0x8F26;
    public const uint GL_SECONDARY_COLOR_ARRAY_ADDRESS_NV = 0x8F27;
    public const uint GL_FOG_COORD_ARRAY_ADDRESS_NV = 0x8F28;
    public const uint GL_ELEMENT_ARRAY_ADDRESS_NV = 0x8F29;
    public const uint GL_VERTEX_ATTRIB_ARRAY_LENGTH_NV = 0x8F2A;
    public const uint GL_VERTEX_ARRAY_LENGTH_NV = 0x8F2B;
    public const uint GL_NORMAL_ARRAY_LENGTH_NV = 0x8F2C;
    public const uint GL_COLOR_ARRAY_LENGTH_NV = 0x8F2D;
    public const uint GL_INDEX_ARRAY_LENGTH_NV = 0x8F2E;
    public const uint GL_TEXTURE_COORD_ARRAY_LENGTH_NV = 0x8F2F;
    public const uint GL_EDGE_FLAG_ARRAY_LENGTH_NV = 0x8F30;
    public const uint GL_SECONDARY_COLOR_ARRAY_LENGTH_NV = 0x8F31;
    public const uint GL_FOG_COORD_ARRAY_LENGTH_NV = 0x8F32;
    public const uint GL_ELEMENT_ARRAY_LENGTH_NV = 0x8F33;
    public const uint GL_DRAW_INDIRECT_UNIFIED_NV = 0x8F40;
    public const uint GL_DRAW_INDIRECT_ADDRESS_NV = 0x8F41;
    public const uint GL_DRAW_INDIRECT_LENGTH_NV = 0x8F42;
    private delegate void PFNGLBUFFERADDRESSRANGENVPROC(uint pname, uint index, ulong address, uintptr length);
    private delegate void PFNGLVERTEXFORMATNVPROC(int size, uint type, uint stride);
    private delegate void PFNGLNORMALFORMATNVPROC(uint type, uint stride);
    private delegate void PFNGLCOLORFORMATNVPROC(int size, uint type, uint stride);
    private delegate void PFNGLINDEXFORMATNVPROC(uint type, uint stride);
    private delegate void PFNGLTEXCOORDFORMATNVPROC(int size, uint type, uint stride);
    private delegate void PFNGLEDGEFLAGFORMATNVPROC(uint stride);
    private delegate void PFNGLSECONDARYCOLORFORMATNVPROC(int size, uint type, uint stride);
    private delegate void PFNGLFOGCOORDFORMATNVPROC(uint type, uint stride);
    private delegate void PFNGLVERTEXATTRIBFORMATNVPROC(uint index, int size, uint type, bool normalized, uint stride);
    private delegate void PFNGLVERTEXATTRIBIFORMATNVPROC(uint index, int size, uint type, uint stride);
    private delegate void PFNGLGETINTEGERUI64I_VNVPROC(uint value, uint index, ulong *result);
    #ifdef GL_GLEXT_PROTOTYPES
    public static void glBufferAddressRangeNV(uint pname, uint index, ulong address, uintptr length);
    public static void glVertexFormatNV(int size, uint type, uint stride);
    public static void glNormalFormatNV(uint type, uint stride);
    public static void glColorFormatNV(int size, uint type, uint stride);
    public static void glIndexFormatNV(uint type, uint stride);
    public static void glTexCoordFormatNV(int size, uint type, uint stride);
    public static void glEdgeFlagFormatNV(uint stride);
    public static void glSecondaryColorFormatNV(int size, uint type, uint stride);
    public static void glFogCoordFormatNV(uint type, uint stride);
    public static void glVertexAttribFormatNV(uint index, int size, uint type, bool normalized, uint stride);
    public static void glVertexAttribIFormatNV(uint index, int size, uint type, uint stride);
    public static void glGetIntegerui64i_vNV(uint value, uint index, ulong *result);
    #endif
    #endif /* GL_NV_vertex_buffer_unified_memory */

    #ifndef GL_NV_vertex_program
    #define GL_NV_vertex_program 1
    public const uint GL_VERTEX_PROGRAM_NV = 0x8620;
    public const uint GL_VERTEX_STATE_PROGRAM_NV = 0x8621;
    public const uint GL_ATTRIB_ARRAY_SIZE_NV = 0x8623;
    public const uint GL_ATTRIB_ARRAY_STRIDE_NV = 0x8624;
    public const uint GL_ATTRIB_ARRAY_TYPE_NV = 0x8625;
    public const uint GL_CURRENT_ATTRIB_NV = 0x8626;
    public const uint GL_PROGRAM_LENGTH_NV = 0x8627;
    public const uint GL_PROGRAM_STRING_NV = 0x8628;
    public const uint GL_MODELVIEW_PROJECTION_NV = 0x8629;
    public const uint GL_IDENTITY_NV = 0x862A;
    public const uint GL_INVERSE_NV = 0x862B;
    public const uint GL_TRANSPOSE_NV = 0x862C;
    public const uint GL_INVERSE_TRANSPOSE_NV = 0x862D;
    public const uint GL_MAX_TRACK_MATRIX_STACK_DEPTH_NV = 0x862E;
    public const uint GL_MAX_TRACK_MATRICES_NV = 0x862F;
    public const uint GL_MATRIX0_NV = 0x8630;
    public const uint GL_MATRIX1_NV = 0x8631;
    public const uint GL_MATRIX2_NV = 0x8632;
    public const uint GL_MATRIX3_NV = 0x8633;
    public const uint GL_MATRIX4_NV = 0x8634;
    public const uint GL_MATRIX5_NV = 0x8635;
    public const uint GL_MATRIX6_NV = 0x8636;
    public const uint GL_MATRIX7_NV = 0x8637;
    public const uint GL_CURRENT_MATRIX_STACK_DEPTH_NV = 0x8640;
    public const uint GL_CURRENT_MATRIX_NV = 0x8641;
    public const uint GL_VERTEX_PROGRAM_POINT_SIZE_NV = 0x8642;
    public const uint GL_VERTEX_PROGRAM_TWO_SIDE_NV = 0x8643;
    public const uint GL_PROGRAM_PARAMETER_NV = 0x8644;
    public const uint GL_ATTRIB_ARRAY_POINTER_NV = 0x8645;
    public const uint GL_PROGRAM_TARGET_NV = 0x8646;
    public const uint GL_PROGRAM_RESIDENT_NV = 0x8647;
    public const uint GL_TRACK_MATRIX_NV = 0x8648;
    public const uint GL_TRACK_MATRIX_TRANSFORM_NV = 0x8649;
    public const uint GL_VERTEX_PROGRAM_BINDING_NV = 0x864A;
    public const uint GL_PROGRAM_ERROR_POSITION_NV = 0x864B;
    public const uint GL_VERTEX_ATTRIB_ARRAY0_NV = 0x8650;
    public const uint GL_VERTEX_ATTRIB_ARRAY1_NV = 0x8651;
    public const uint GL_VERTEX_ATTRIB_ARRAY2_NV = 0x8652;
    public const uint GL_VERTEX_ATTRIB_ARRAY3_NV = 0x8653;
    public const uint GL_VERTEX_ATTRIB_ARRAY4_NV = 0x8654;
    public const uint GL_VERTEX_ATTRIB_ARRAY5_NV = 0x8655;
    public const uint GL_VERTEX_ATTRIB_ARRAY6_NV = 0x8656;
    public const uint GL_VERTEX_ATTRIB_ARRAY7_NV = 0x8657;
    public const uint GL_VERTEX_ATTRIB_ARRAY8_NV = 0x8658;
    public const uint GL_VERTEX_ATTRIB_ARRAY9_NV = 0x8659;
    public const uint GL_VERTEX_ATTRIB_ARRAY10_NV = 0x865A;
    public const uint GL_VERTEX_ATTRIB_ARRAY11_NV = 0x865B;
    public const uint GL_VERTEX_ATTRIB_ARRAY12_NV = 0x865C;
    public const uint GL_VERTEX_ATTRIB_ARRAY13_NV = 0x865D;
    public const uint GL_VERTEX_ATTRIB_ARRAY14_NV = 0x865E;
    public const uint GL_VERTEX_ATTRIB_ARRAY15_NV = 0x865F;
    public const uint GL_MAP1_VERTEX_ATTRIB0_4_NV = 0x8660;
    public const uint GL_MAP1_VERTEX_ATTRIB1_4_NV = 0x8661;
    public const uint GL_MAP1_VERTEX_ATTRIB2_4_NV = 0x8662;
    public const uint GL_MAP1_VERTEX_ATTRIB3_4_NV = 0x8663;
    public const uint GL_MAP1_VERTEX_ATTRIB4_4_NV = 0x8664;
    public const uint GL_MAP1_VERTEX_ATTRIB5_4_NV = 0x8665;
    public const uint GL_MAP1_VERTEX_ATTRIB6_4_NV = 0x8666;
    public const uint GL_MAP1_VERTEX_ATTRIB7_4_NV = 0x8667;
    public const uint GL_MAP1_VERTEX_ATTRIB8_4_NV = 0x8668;
    public const uint GL_MAP1_VERTEX_ATTRIB9_4_NV = 0x8669;
    public const uint GL_MAP1_VERTEX_ATTRIB10_4_NV = 0x866A;
    public const uint GL_MAP1_VERTEX_ATTRIB11_4_NV = 0x866B;
    public const uint GL_MAP1_VERTEX_ATTRIB12_4_NV = 0x866C;
    public const uint GL_MAP1_VERTEX_ATTRIB13_4_NV = 0x866D;
    public const uint GL_MAP1_VERTEX_ATTRIB14_4_NV = 0x866E;
    public const uint GL_MAP1_VERTEX_ATTRIB15_4_NV = 0x866F;
    public const uint GL_MAP2_VERTEX_ATTRIB0_4_NV = 0x8670;
    public const uint GL_MAP2_VERTEX_ATTRIB1_4_NV = 0x8671;
    public const uint GL_MAP2_VERTEX_ATTRIB2_4_NV = 0x8672;
    public const uint GL_MAP2_VERTEX_ATTRIB3_4_NV = 0x8673;
    public const uint GL_MAP2_VERTEX_ATTRIB4_4_NV = 0x8674;
    public const uint GL_MAP2_VERTEX_ATTRIB5_4_NV = 0x8675;
    public const uint GL_MAP2_VERTEX_ATTRIB6_4_NV = 0x8676;
    public const uint GL_MAP2_VERTEX_ATTRIB7_4_NV = 0x8677;
    public const uint GL_MAP2_VERTEX_ATTRIB8_4_NV = 0x8678;
    public const uint GL_MAP2_VERTEX_ATTRIB9_4_NV = 0x8679;
    public const uint GL_MAP2_VERTEX_ATTRIB10_4_NV = 0x867A;
    public const uint GL_MAP2_VERTEX_ATTRIB11_4_NV = 0x867B;
    public const uint GL_MAP2_VERTEX_ATTRIB12_4_NV = 0x867C;
    public const uint GL_MAP2_VERTEX_ATTRIB13_4_NV = 0x867D;
    public const uint GL_MAP2_VERTEX_ATTRIB14_4_NV = 0x867E;
    public const uint GL_MAP2_VERTEX_ATTRIB15_4_NV = 0x867F;
    private delegate bool PFNGLAREPROGRAMSRESIDENTNVPROC(uint n, const uint *programs, bool *residences);
    private delegate void PFNGLBINDPROGRAMNVPROC(uint target, uint id);
    private delegate void PFNGLDELETEPROGRAMSNVPROC(uint n, const uint *programs);
    private delegate void PFNGLEXECUTEPROGRAMNVPROC(uint target, uint id, const float *params);
    private delegate void PFNGLGENPROGRAMSNVPROC(uint n, uint *programs);
    private delegate void PFNGLGETPROGRAMPARAMETERDVNVPROC(uint target, uint index, uint pname, double *params);
    private delegate void PFNGLGETPROGRAMPARAMETERFVNVPROC(uint target, uint index, uint pname, float *params);
    private delegate void PFNGLGETPROGRAMIVNVPROC(uint id, uint pname, int *params);
    private delegate void PFNGLGETPROGRAMSTRINGNVPROC(uint id, uint pname, byte *program);
    private delegate void PFNGLGETTRACKMATRIXIVNVPROC(uint target, uint address, uint pname, int *params);
    private delegate void PFNGLGETVERTEXATTRIBDVNVPROC(uint index, uint pname, double *params);
    private delegate void PFNGLGETVERTEXATTRIBFVNVPROC(uint index, uint pname, float *params);
    private delegate void PFNGLGETVERTEXATTRIBIVNVPROC(uint index, uint pname, int *params);
    private delegate void PFNGLGETVERTEXATTRIBPOINTERVNVPROC(uint index, uint pname, void **pointer);
    private delegate bool PFNGLISPROGRAMNVPROC(uint id);
    private delegate void PFNGLLOADPROGRAMNVPROC(uint target, uint id, uint len, const byte *program);
    private delegate void PFNGLPROGRAMPARAMETER4DNVPROC(uint target, uint index, double x, double y, double z, double w);
    private delegate void PFNGLPROGRAMPARAMETER4DVNVPROC(uint target, uint index, const double *v);
    private delegate void PFNGLPROGRAMPARAMETER4FNVPROC(uint target, uint index, float x, float y, float z, float w);
    private delegate void PFNGLPROGRAMPARAMETER4FVNVPROC(uint target, uint index, const float *v);
    private delegate void PFNGLPROGRAMPARAMETERS4DVNVPROC(uint target, uint index, uint count, const double *v);
    private delegate void PFNGLPROGRAMPARAMETERS4FVNVPROC(uint target, uint index, uint count, const float *v);
    private delegate void PFNGLREQUESTRESIDENTPROGRAMSNVPROC(uint n, const uint *programs);
    private delegate void PFNGLTRACKMATRIXNVPROC(uint target, uint address, uint matrix, uint transform);
    private delegate void PFNGLVERTEXATTRIBPOINTERNVPROC(uint index, int fsize, uint type, uint stride, const void *pointer);
    private delegate void PFNGLVERTEXATTRIB1DNVPROC(uint index, double x);
    private delegate void PFNGLVERTEXATTRIB1DVNVPROC(uint index, const double *v);
    private delegate void PFNGLVERTEXATTRIB1FNVPROC(uint index, float x);
    private delegate void PFNGLVERTEXATTRIB1FVNVPROC(uint index, const float *v);
    private delegate void PFNGLVERTEXATTRIB1SNVPROC(uint index, short x);
    private delegate void PFNGLVERTEXATTRIB1SVNVPROC(uint index, const short *v);
    private delegate void PFNGLVERTEXATTRIB2DNVPROC(uint index, double x, double y);
    private delegate void PFNGLVERTEXATTRIB2DVNVPROC(uint index, const double *v);
    private delegate void PFNGLVERTEXATTRIB2FNVPROC(uint index, float x, float y);
    private delegate void PFNGLVERTEXATTRIB2FVNVPROC(uint index, const float *v);
    private delegate void PFNGLVERTEXATTRIB2SNVPROC(uint index, short x, short y);
    private delegate void PFNGLVERTEXATTRIB2SVNVPROC(uint index, const short *v);
    private delegate void PFNGLVERTEXATTRIB3DNVPROC(uint index, double x, double y, double z);
    private delegate void PFNGLVERTEXATTRIB3DVNVPROC(uint index, const double *v);
    private delegate void PFNGLVERTEXATTRIB3FNVPROC(uint index, float x, float y, float z);
    private delegate void PFNGLVERTEXATTRIB3FVNVPROC(uint index, const float *v);
    private delegate void PFNGLVERTEXATTRIB3SNVPROC(uint index, short x, short y, short z);
    private delegate void PFNGLVERTEXATTRIB3SVNVPROC(uint index, const short *v);
    private delegate void PFNGLVERTEXATTRIB4DNVPROC(uint index, double x, double y, double z, double w);
    private delegate void PFNGLVERTEXATTRIB4DVNVPROC(uint index, const double *v);
    private delegate void PFNGLVERTEXATTRIB4FNVPROC(uint index, float x, float y, float z, float w);
    private delegate void PFNGLVERTEXATTRIB4FVNVPROC(uint index, const float *v);
    private delegate void PFNGLVERTEXATTRIB4SNVPROC(uint index, short x, short y, short z, short w);
    private delegate void PFNGLVERTEXATTRIB4SVNVPROC(uint index, const short *v);
    private delegate void PFNGLVERTEXATTRIB4UBNVPROC(uint index, byte x, byte y, byte z, byte w);
    private delegate void PFNGLVERTEXATTRIB4UBVNVPROC(uint index, const byte *v);
    private delegate void PFNGLVERTEXATTRIBS1DVNVPROC(uint index, uint count, const double *v);
    private delegate void PFNGLVERTEXATTRIBS1FVNVPROC(uint index, uint count, const float *v);
    private delegate void PFNGLVERTEXATTRIBS1SVNVPROC(uint index, uint count, const short *v);
    private delegate void PFNGLVERTEXATTRIBS2DVNVPROC(uint index, uint count, const double *v);
    private delegate void PFNGLVERTEXATTRIBS2FVNVPROC(uint index, uint count, const float *v);
    private delegate void PFNGLVERTEXATTRIBS2SVNVPROC(uint index, uint count, const short *v);
    private delegate void PFNGLVERTEXATTRIBS3DVNVPROC(uint index, uint count, const double *v);
    private delegate void PFNGLVERTEXATTRIBS3FVNVPROC(uint index, uint count, const float *v);
    private delegate void PFNGLVERTEXATTRIBS3SVNVPROC(uint index, uint count, const short *v);
    private delegate void PFNGLVERTEXATTRIBS4DVNVPROC(uint index, uint count, const double *v);
    private delegate void PFNGLVERTEXATTRIBS4FVNVPROC(uint index, uint count, const float *v);
    private delegate void PFNGLVERTEXATTRIBS4SVNVPROC(uint index, uint count, const short *v);
    private delegate void PFNGLVERTEXATTRIBS4UBVNVPROC(uint index, uint count, const byte *v);
    #ifdef GL_GLEXT_PROTOTYPES
    public static bool glAreProgramsResidentNV(uint n, const uint *programs, bool *residences);
    public static void glBindProgramNV(uint target, uint id);
    public static void glDeleteProgramsNV(uint n, const uint *programs);
    public static void glExecuteProgramNV(uint target, uint id, const float *params);
    public static void glGenProgramsNV(uint n, uint *programs);
    public static void glGetProgramParameterdvNV(uint target, uint index, uint pname, double *params);
    public static void glGetProgramParameterfvNV(uint target, uint index, uint pname, float *params);
    public static void glGetProgramivNV(uint id, uint pname, int *params);
    public static void glGetProgramStringNV(uint id, uint pname, byte *program);
    public static void glGetTrackMatrixivNV(uint target, uint address, uint pname, int *params);
    public static void glGetVertexAttribdvNV(uint index, uint pname, double *params);
    public static void glGetVertexAttribfvNV(uint index, uint pname, float *params);
    public static void glGetVertexAttribivNV(uint index, uint pname, int *params);
    public static void glGetVertexAttribPointervNV(uint index, uint pname, void **pointer);
    public static bool glIsProgramNV(uint id);
    public static void glLoadProgramNV(uint target, uint id, uint len, const byte *program);
    public static void glProgramParameter4dNV(uint target, uint index, double x, double y, double z, double w);
    public static void glProgramParameter4dvNV(uint target, uint index, const double *v);
    public static void glProgramParameter4fNV(uint target, uint index, float x, float y, float z, float w);
    public static void glProgramParameter4fvNV(uint target, uint index, const float *v);
    public static void glProgramParameters4dvNV(uint target, uint index, uint count, const double *v);
    public static void glProgramParameters4fvNV(uint target, uint index, uint count, const float *v);
    public static void glRequestResidentProgramsNV(uint n, const uint *programs);
    public static void glTrackMatrixNV(uint target, uint address, uint matrix, uint transform);
    public static void glVertexAttribPointerNV(uint index, int fsize, uint type, uint stride, const void *pointer);
    public static void glVertexAttrib1dNV(uint index, double x);
    public static void glVertexAttrib1dvNV(uint index, const double *v);
    public static void glVertexAttrib1fNV(uint index, float x);
    public static void glVertexAttrib1fvNV(uint index, const float *v);
    public static void glVertexAttrib1sNV(uint index, short x);
    public static void glVertexAttrib1svNV(uint index, const short *v);
    public static void glVertexAttrib2dNV(uint index, double x, double y);
    public static void glVertexAttrib2dvNV(uint index, const double *v);
    public static void glVertexAttrib2fNV(uint index, float x, float y);
    public static void glVertexAttrib2fvNV(uint index, const float *v);
    public static void glVertexAttrib2sNV(uint index, short x, short y);
    public static void glVertexAttrib2svNV(uint index, const short *v);
    public static void glVertexAttrib3dNV(uint index, double x, double y, double z);
    public static void glVertexAttrib3dvNV(uint index, const double *v);
    public static void glVertexAttrib3fNV(uint index, float x, float y, float z);
    public static void glVertexAttrib3fvNV(uint index, const float *v);
    public static void glVertexAttrib3sNV(uint index, short x, short y, short z);
    public static void glVertexAttrib3svNV(uint index, const short *v);
    public static void glVertexAttrib4dNV(uint index, double x, double y, double z, double w);
    public static void glVertexAttrib4dvNV(uint index, const double *v);
    public static void glVertexAttrib4fNV(uint index, float x, float y, float z, float w);
    public static void glVertexAttrib4fvNV(uint index, const float *v);
    public static void glVertexAttrib4sNV(uint index, short x, short y, short z, short w);
    public static void glVertexAttrib4svNV(uint index, const short *v);
    public static void glVertexAttrib4ubNV(uint index, byte x, byte y, byte z, byte w);
    public static void glVertexAttrib4ubvNV(uint index, const byte *v);
    public static void glVertexAttribs1dvNV(uint index, uint count, const double *v);
    public static void glVertexAttribs1fvNV(uint index, uint count, const float *v);
    public static void glVertexAttribs1svNV(uint index, uint count, const short *v);
    public static void glVertexAttribs2dvNV(uint index, uint count, const double *v);
    public static void glVertexAttribs2fvNV(uint index, uint count, const float *v);
    public static void glVertexAttribs2svNV(uint index, uint count, const short *v);
    public static void glVertexAttribs3dvNV(uint index, uint count, const double *v);
    public static void glVertexAttribs3fvNV(uint index, uint count, const float *v);
    public static void glVertexAttribs3svNV(uint index, uint count, const short *v);
    public static void glVertexAttribs4dvNV(uint index, uint count, const double *v);
    public static void glVertexAttribs4fvNV(uint index, uint count, const float *v);
    public static void glVertexAttribs4svNV(uint index, uint count, const short *v);
    public static void glVertexAttribs4ubvNV(uint index, uint count, const byte *v);
    #endif
    #endif /* GL_NV_vertex_program */

    #ifndef GL_NV_vertex_program1_1
    #define GL_NV_vertex_program1_1 1
    #endif /* GL_NV_vertex_program1_1 */

    #ifndef GL_NV_vertex_program2
    #define GL_NV_vertex_program2 1
    #endif /* GL_NV_vertex_program2 */

    #ifndef GL_NV_vertex_program2_option
    #define GL_NV_vertex_program2_option 1
    #endif /* GL_NV_vertex_program2_option */

    #ifndef GL_NV_vertex_program3
    #define GL_NV_vertex_program3 1
    #endif /* GL_NV_vertex_program3 */

    #ifndef GL_NV_vertex_program4
    #define GL_NV_vertex_program4 1
    public const uint GL_VERTEX_ATTRIB_ARRAY_INTEGER_NV = 0x88FD;
    private delegate void PFNGLVERTEXATTRIBI1IEXTPROC(uint index, int x);
    private delegate void PFNGLVERTEXATTRIBI2IEXTPROC(uint index, int x, int y);
    private delegate void PFNGLVERTEXATTRIBI3IEXTPROC(uint index, int x, int y, int z);
    private delegate void PFNGLVERTEXATTRIBI4IEXTPROC(uint index, int x, int y, int z, int w);
    private delegate void PFNGLVERTEXATTRIBI1UIEXTPROC(uint index, uint x);
    private delegate void PFNGLVERTEXATTRIBI2UIEXTPROC(uint index, uint x, uint y);
    private delegate void PFNGLVERTEXATTRIBI3UIEXTPROC(uint index, uint x, uint y, uint z);
    private delegate void PFNGLVERTEXATTRIBI4UIEXTPROC(uint index, uint x, uint y, uint z, uint w);
    private delegate void PFNGLVERTEXATTRIBI1IVEXTPROC(uint index, const int *v);
    private delegate void PFNGLVERTEXATTRIBI2IVEXTPROC(uint index, const int *v);
    private delegate void PFNGLVERTEXATTRIBI3IVEXTPROC(uint index, const int *v);
    private delegate void PFNGLVERTEXATTRIBI4IVEXTPROC(uint index, const int *v);
    private delegate void PFNGLVERTEXATTRIBI1UIVEXTPROC(uint index, const uint *v);
    private delegate void PFNGLVERTEXATTRIBI2UIVEXTPROC(uint index, const uint *v);
    private delegate void PFNGLVERTEXATTRIBI3UIVEXTPROC(uint index, const uint *v);
    private delegate void PFNGLVERTEXATTRIBI4UIVEXTPROC(uint index, const uint *v);
    private delegate void PFNGLVERTEXATTRIBI4BVEXTPROC(uint index, const sbyte *v);
    private delegate void PFNGLVERTEXATTRIBI4SVEXTPROC(uint index, const short *v);
    private delegate void PFNGLVERTEXATTRIBI4UBVEXTPROC(uint index, const byte *v);
    private delegate void PFNGLVERTEXATTRIBI4USVEXTPROC(uint index, const ushort *v);
    private delegate void PFNGLVERTEXATTRIBIPOINTEREXTPROC(uint index, int size, uint type, uint stride, const void *pointer);
    private delegate void PFNGLGETVERTEXATTRIBIIVEXTPROC(uint index, uint pname, int *params);
    private delegate void PFNGLGETVERTEXATTRIBIUIVEXTPROC(uint index, uint pname, uint *params);
    #ifdef GL_GLEXT_PROTOTYPES
    public static void glVertexAttribI1iEXT(uint index, int x);
    public static void glVertexAttribI2iEXT(uint index, int x, int y);
    public static void glVertexAttribI3iEXT(uint index, int x, int y, int z);
    public static void glVertexAttribI4iEXT(uint index, int x, int y, int z, int w);
    public static void glVertexAttribI1uiEXT(uint index, uint x);
    public static void glVertexAttribI2uiEXT(uint index, uint x, uint y);
    public static void glVertexAttribI3uiEXT(uint index, uint x, uint y, uint z);
    public static void glVertexAttribI4uiEXT(uint index, uint x, uint y, uint z, uint w);
    public static void glVertexAttribI1ivEXT(uint index, const int *v);
    public static void glVertexAttribI2ivEXT(uint index, const int *v);
    public static void glVertexAttribI3ivEXT(uint index, const int *v);
    public static void glVertexAttribI4ivEXT(uint index, const int *v);
    public static void glVertexAttribI1uivEXT(uint index, const uint *v);
    public static void glVertexAttribI2uivEXT(uint index, const uint *v);
    public static void glVertexAttribI3uivEXT(uint index, const uint *v);
    public static void glVertexAttribI4uivEXT(uint index, const uint *v);
    public static void glVertexAttribI4bvEXT(uint index, const sbyte *v);
    public static void glVertexAttribI4svEXT(uint index, const short *v);
    public static void glVertexAttribI4ubvEXT(uint index, const byte *v);
    public static void glVertexAttribI4usvEXT(uint index, const ushort *v);
    public static void glVertexAttribIPointerEXT(uint index, int size, uint type, uint stride, const void *pointer);
    public static void glGetVertexAttribIivEXT(uint index, uint pname, int *params);
    public static void glGetVertexAttribIuivEXT(uint index, uint pname, uint *params);
    #endif
    #endif /* GL_NV_vertex_program4 */

    #ifndef GL_NV_video_capture
    #define GL_NV_video_capture 1
    public const uint GL_VIDEO_BUFFER_NV = 0x9020;
    public const uint GL_VIDEO_BUFFER_BINDING_NV = 0x9021;
    public const uint GL_FIELD_UPPER_NV = 0x9022;
    public const uint GL_FIELD_LOWER_NV = 0x9023;
    public const uint GL_NUM_VIDEO_CAPTURE_STREAMS_NV = 0x9024;
    public const uint GL_NEXT_VIDEO_CAPTURE_BUFFER_STATUS_NV = 0x9025;
    public const uint GL_VIDEO_CAPTURE_TO_422_SUPPORTED_NV = 0x9026;
    public const uint GL_LAST_VIDEO_CAPTURE_STATUS_NV = 0x9027;
    public const uint GL_VIDEO_BUFFER_PITCH_NV = 0x9028;
    public const uint GL_VIDEO_COLOR_CONVERSION_MATRIX_NV = 0x9029;
    public const uint GL_VIDEO_COLOR_CONVERSION_MAX_NV = 0x902A;
    public const uint GL_VIDEO_COLOR_CONVERSION_MIN_NV = 0x902B;
    public const uint GL_VIDEO_COLOR_CONVERSION_OFFSET_NV = 0x902C;
    public const uint GL_VIDEO_BUFFER_INTERNAL_FORMAT_NV = 0x902D;
    public const uint GL_PARTIAL_SUCCESS_NV = 0x902E;
    public const uint GL_SUCCESS_NV = 0x902F;
    public const uint GL_FAILURE_NV = 0x9030;
    public const uint GL_YCBYCR8_422_NV = 0x9031;
    public const uint GL_YCBAYCR8A_4224_NV = 0x9032;
    public const uint GL_Z6Y10Z6CB10Z6Y10Z6CR10_422_NV = 0x9033;
    public const uint GL_Z6Y10Z6CB10Z6A10Z6Y10Z6CR10Z6A10_4224_NV = 0x9034;
    public const uint GL_Z4Y12Z4CB12Z4Y12Z4CR12_422_NV = 0x9035;
    public const uint GL_Z4Y12Z4CB12Z4A12Z4Y12Z4CR12Z4A12_4224_NV = 0x9036;
    public const uint GL_Z4Y12Z4CB12Z4CR12_444_NV = 0x9037;
    public const uint GL_VIDEO_CAPTURE_FRAME_WIDTH_NV = 0x9038;
    public const uint GL_VIDEO_CAPTURE_FRAME_HEIGHT_NV = 0x9039;
    public const uint GL_VIDEO_CAPTURE_FIELD_UPPER_HEIGHT_NV = 0x903A;
    public const uint GL_VIDEO_CAPTURE_FIELD_LOWER_HEIGHT_NV = 0x903B;
    public const uint GL_VIDEO_CAPTURE_SURFACE_ORIGIN_NV = 0x903C;
    private delegate void PFNGLBEGINVIDEOCAPTURENVPROC(uint video_capture_slot);
    private delegate void PFNGLBINDVIDEOCAPTURESTREAMBUFFERNVPROC(uint video_capture_slot, uint stream, uint frame_region, intptrARB offset);
    private delegate void PFNGLBINDVIDEOCAPTURESTREAMTEXTURENVPROC(uint video_capture_slot, uint stream, uint frame_region, uint target, uint texture);
    private delegate void PFNGLENDVIDEOCAPTURENVPROC(uint video_capture_slot);
    private delegate void PFNGLGETVIDEOCAPTUREIVNVPROC(uint video_capture_slot, uint pname, int *params);
    private delegate void PFNGLGETVIDEOCAPTURESTREAMIVNVPROC(uint video_capture_slot, uint stream, uint pname, int *params);
    private delegate void PFNGLGETVIDEOCAPTURESTREAMFVNVPROC(uint video_capture_slot, uint stream, uint pname, float *params);
    private delegate void PFNGLGETVIDEOCAPTURESTREAMDVNVPROC(uint video_capture_slot, uint stream, uint pname, double *params);
    private delegate uint PFNGLVIDEOCAPTURENVPROC(uint video_capture_slot, uint *sequence_num, ulong *capture_time);
    private delegate void PFNGLVIDEOCAPTURESTREAMPARAMETERIVNVPROC(uint video_capture_slot, uint stream, uint pname, const int *params);
    private delegate void PFNGLVIDEOCAPTURESTREAMPARAMETERFVNVPROC(uint video_capture_slot, uint stream, uint pname, const float *params);
    private delegate void PFNGLVIDEOCAPTURESTREAMPARAMETERDVNVPROC(uint video_capture_slot, uint stream, uint pname, const double *params);
    #ifdef GL_GLEXT_PROTOTYPES
    public static void glBeginVideoCaptureNV(uint video_capture_slot);
    public static void glBindVideoCaptureStreamBufferNV(uint video_capture_slot, uint stream, uint frame_region, intptrARB offset);
    public static void glBindVideoCaptureStreamTextureNV(uint video_capture_slot, uint stream, uint frame_region, uint target, uint texture);
    public static void glEndVideoCaptureNV(uint video_capture_slot);
    public static void glGetVideoCaptureivNV(uint video_capture_slot, uint pname, int *params);
    public static void glGetVideoCaptureStreamivNV(uint video_capture_slot, uint stream, uint pname, int *params);
    public static void glGetVideoCaptureStreamfvNV(uint video_capture_slot, uint stream, uint pname, float *params);
    public static void glGetVideoCaptureStreamdvNV(uint video_capture_slot, uint stream, uint pname, double *params);
    public static uint glVideoCaptureNV(uint video_capture_slot, uint *sequence_num, ulong *capture_time);
    public static void glVideoCaptureStreamParameterivNV(uint video_capture_slot, uint stream, uint pname, const int *params);
    public static void glVideoCaptureStreamParameterfvNV(uint video_capture_slot, uint stream, uint pname, const float *params);
    public static void glVideoCaptureStreamParameterdvNV(uint video_capture_slot, uint stream, uint pname, const double *params);
    #endif
    #endif /* GL_NV_video_capture */

    #ifndef GL_OML_interlace
    #define GL_OML_interlace 1
    public const uint GL_INTERLACE_OML = 0x8980;
    public const uint GL_INTERLACE_READ_OML = 0x8981;
    #endif /* GL_OML_interlace */

    #ifndef GL_OML_resample
    #define GL_OML_resample 1
    public const uint GL_PACK_RESAMPLE_OML = 0x8984;
    public const uint GL_UNPACK_RESAMPLE_OML = 0x8985;
    public const uint GL_RESAMPLE_REPLICATE_OML = 0x8986;
    public const uint GL_RESAMPLE_ZERO_FILL_OML = 0x8987;
    public const uint GL_RESAMPLE_AVERAGE_OML = 0x8988;
    public const uint GL_RESAMPLE_DECIMATE_OML = 0x8989;
    #endif /* GL_OML_resample */

    #ifndef GL_OML_subsample
    #define GL_OML_subsample 1
    public const uint GL_FORMAT_SUBSAMPLE_24_24_OML = 0x8982;
    public const uint GL_FORMAT_SUBSAMPLE_244_244_OML = 0x8983;
    #endif /* GL_OML_subsample */

    #ifndef GL_PGI_misc_hints
    #define GL_PGI_misc_hints 1
    public const uint GL_PREFER_DOUBLEBUFFER_HINT_PGI = 0x1A1F8;
    public const uint GL_CONSERVE_MEMORY_HINT_PGI = 0x1A1FD;
    public const uint GL_RECLAIM_MEMORY_HINT_PGI = 0x1A1FE;
    public const uint GL_NATIVE_GRAPHICS_HANDLE_PGI = 0x1A202;
    public const uint GL_NATIVE_GRAPHICS_BEGIN_HINT_PGI = 0x1A203;
    public const uint GL_NATIVE_GRAPHICS_END_HINT_PGI = 0x1A204;
    public const uint GL_ALWAYS_FAST_HINT_PGI = 0x1A20C;
    public const uint GL_ALWAYS_SOFT_HINT_PGI = 0x1A20D;
    public const uint GL_ALLOW_DRAW_OBJ_HINT_PGI = 0x1A20E;
    public const uint GL_ALLOW_DRAW_WIN_HINT_PGI = 0x1A20F;
    public const uint GL_ALLOW_DRAW_FRG_HINT_PGI = 0x1A210;
    public const uint GL_ALLOW_DRAW_MEM_HINT_PGI = 0x1A211;
    public const uint GL_STRICT_DEPTHFUNC_HINT_PGI = 0x1A216;
    public const uint GL_STRICT_LIGHTING_HINT_PGI = 0x1A217;
    public const uint GL_STRICT_SCISSOR_HINT_PGI = 0x1A218;
    public const uint GL_FULL_STIPPLE_HINT_PGI = 0x1A219;
    public const uint GL_CLIP_NEAR_HINT_PGI = 0x1A220;
    public const uint GL_CLIP_FAR_HINT_PGI = 0x1A221;
    public const uint GL_WIDE_LINE_HINT_PGI = 0x1A222;
    public const uint GL_BACK_NORMALS_HINT_PGI = 0x1A223;
    private delegate void PFNGLHINTPGIPROC(uint target, int mode);
    #ifdef GL_GLEXT_PROTOTYPES
    public static void glHintPGI(uint target, int mode);
    #endif
    #endif /* GL_PGI_misc_hints */

    #ifndef GL_PGI_vertex_hints
    #define GL_PGI_vertex_hints 1
    public const uint GL_VERTEX_DATA_HINT_PGI = 0x1A22A;
    public const uint GL_VERTEX_CONSISTENT_HINT_PGI = 0x1A22B;
    public const uint GL_MATERIAL_SIDE_HINT_PGI = 0x1A22C;
    public const uint GL_MAX_VERTEX_HINT_PGI = 0x1A22D;
    public const uint GL_COLOR3_BIT_PGI = 0x00010000;
    public const uint GL_COLOR4_BIT_PGI = 0x00020000;
    public const uint GL_EDGEFLAG_BIT_PGI = 0x00040000;
    public const uint GL_INDEX_BIT_PGI = 0x00080000;
    public const uint GL_MAT_AMBIENT_BIT_PGI = 0x00100000;
    public const uint GL_MAT_AMBIENT_AND_DIFFUSE_BIT_PGI = 0x00200000;
    public const uint GL_MAT_DIFFUSE_BIT_PGI = 0x00400000;
    public const uint GL_MAT_EMISSION_BIT_PGI = 0x00800000;
    public const uint GL_MAT_COLOR_INDEXES_BIT_PGI = 0x01000000;
    public const uint GL_MAT_SHININESS_BIT_PGI = 0x02000000;
    public const uint GL_MAT_SPECULAR_BIT_PGI = 0x04000000;
    public const uint GL_NORMAL_BIT_PGI = 0x08000000;
    public const uint GL_TEXCOORD1_BIT_PGI = 0x10000000;
    public const uint GL_TEXCOORD2_BIT_PGI = 0x20000000;
    public const uint GL_TEXCOORD3_BIT_PGI = 0x40000000;
    public const uint GL_TEXCOORD4_BIT_PGI = 0x80000000;
    public const uint GL_VERTEX23_BIT_PGI = 0x00000004;
    public const uint GL_VERTEX4_BIT_PGI = 0x00000008;
    #endif /* GL_PGI_vertex_hints */

    #ifndef GL_REND_screen_coordinates
    #define GL_REND_screen_coordinates 1
    public const uint GL_SCREEN_COORDINATES_REND = 0x8490;
    public const uint GL_INVERTED_SCREEN_W_REND = 0x8491;
    #endif /* GL_REND_screen_coordinates */

    #ifndef GL_S3_s3tc
    #define GL_S3_s3tc 1
    public const uint GL_RGB_S3TC = 0x83A0;
    public const uint GL_RGB4_S3TC = 0x83A1;
    public const uint GL_RGBA_S3TC = 0x83A2;
    public const uint GL_RGBA4_S3TC = 0x83A3;
    public const uint GL_RGBA_DXT5_S3TC = 0x83A4;
    public const uint GL_RGBA4_DXT5_S3TC = 0x83A5;
    #endif /* GL_S3_s3tc */

    #ifndef GL_SGIS_detail_texture
    #define GL_SGIS_detail_texture 1
    public const uint GL_DETAIL_TEXTURE_2D_SGIS = 0x8095;
    public const uint GL_DETAIL_TEXTURE_2D_BINDING_SGIS = 0x8096;
    public const uint GL_LINEAR_DETAIL_SGIS = 0x8097;
    public const uint GL_LINEAR_DETAIL_ALPHA_SGIS = 0x8098;
    public const uint GL_LINEAR_DETAIL_COLOR_SGIS = 0x8099;
    public const uint GL_DETAIL_TEXTURE_LEVEL_SGIS = 0x809A;
    public const uint GL_DETAIL_TEXTURE_MODE_SGIS = 0x809B;
    public const uint GL_DETAIL_TEXTURE_FUNC_POINTS_SGIS = 0x809C;
    private delegate void PFNGLDETAILTEXFUNCSGISPROC(uint target, uint n, const float *points);
    private delegate void PFNGLGETDETAILTEXFUNCSGISPROC(uint target, float *points);
    #ifdef GL_GLEXT_PROTOTYPES
    public static void glDetailTexFuncSGIS(uint target, uint n, const float *points);
    public static void glGetDetailTexFuncSGIS(uint target, float *points);
    #endif
    #endif /* GL_SGIS_detail_texture */

    #ifndef GL_SGIS_fog_function
    #define GL_SGIS_fog_function 1
    public const uint GL_FOG_FUNC_SGIS = 0x812A;
    public const uint GL_FOG_FUNC_POINTS_SGIS = 0x812B;
    public const uint GL_MAX_FOG_FUNC_POINTS_SGIS = 0x812C;
    private delegate void PFNGLFOGFUNCSGISPROC(uint n, const float *points);
    private delegate void PFNGLGETFOGFUNCSGISPROC(float *points);
    #ifdef GL_GLEXT_PROTOTYPES
    public static void glFogFuncSGIS(uint n, const float *points);
    public static void glGetFogFuncSGIS(float *points);
    #endif
    #endif /* GL_SGIS_fog_function */

    #ifndef GL_SGIS_generate_mipmap
    #define GL_SGIS_generate_mipmap 1
    public const uint GL_GENERATE_MIPMAP_SGIS = 0x8191;
    public const uint GL_GENERATE_MIPMAP_HINT_SGIS = 0x8192;
    #endif /* GL_SGIS_generate_mipmap */

    #ifndef GL_SGIS_multisample
    #define GL_SGIS_multisample 1
    public const uint GL_MULTISAMPLE_SGIS = 0x809D;
    public const uint GL_SAMPLE_ALPHA_TO_MASK_SGIS = 0x809E;
    public const uint GL_SAMPLE_ALPHA_TO_ONE_SGIS = 0x809F;
    public const uint GL_SAMPLE_MASK_SGIS = 0x80A0;
    public const uint GL_1PASS_SGIS = 0x80A1;
    public const uint GL_2PASS_0_SGIS = 0x80A2;
    public const uint GL_2PASS_1_SGIS = 0x80A3;
    public const uint GL_4PASS_0_SGIS = 0x80A4;
    public const uint GL_4PASS_1_SGIS = 0x80A5;
    public const uint GL_4PASS_2_SGIS = 0x80A6;
    public const uint GL_4PASS_3_SGIS = 0x80A7;
    public const uint GL_SAMPLE_BUFFERS_SGIS = 0x80A8;
    public const uint GL_SAMPLES_SGIS = 0x80A9;
    public const uint GL_SAMPLE_MASK_VALUE_SGIS = 0x80AA;
    public const uint GL_SAMPLE_MASK_INVERT_SGIS = 0x80AB;
    public const uint GL_SAMPLE_PATTERN_SGIS = 0x80AC;
    private delegate void PFNGLSAMPLEMASKSGISPROC(float value, bool invert);
    private delegate void PFNGLSAMPLEPATTERNSGISPROC(uint pattern);
    #ifdef GL_GLEXT_PROTOTYPES
    public static void glSampleMaskSGIS(float value, bool invert);
    public static void glSamplePatternSGIS(uint pattern);
    #endif
    #endif /* GL_SGIS_multisample */

    #ifndef GL_SGIS_pixel_texture
    #define GL_SGIS_pixel_texture 1
    public const uint GL_PIXEL_TEXTURE_SGIS = 0x8353;
    public const uint GL_PIXEL_FRAGMENT_RGB_SOURCE_SGIS = 0x8354;
    public const uint GL_PIXEL_FRAGMENT_ALPHA_SOURCE_SGIS = 0x8355;
    public const uint GL_PIXEL_GROUP_COLOR_SGIS = 0x8356;
    private delegate void PFNGLPIXELTEXGENPARAMETERISGISPROC(uint pname, int param);
    private delegate void PFNGLPIXELTEXGENPARAMETERIVSGISPROC(uint pname, const int *params);
    private delegate void PFNGLPIXELTEXGENPARAMETERFSGISPROC(uint pname, float param);
    private delegate void PFNGLPIXELTEXGENPARAMETERFVSGISPROC(uint pname, const float *params);
    private delegate void PFNGLGETPIXELTEXGENPARAMETERIVSGISPROC(uint pname, int *params);
    private delegate void PFNGLGETPIXELTEXGENPARAMETERFVSGISPROC(uint pname, float *params);
    #ifdef GL_GLEXT_PROTOTYPES
    public static void glPixelTexGenParameteriSGIS(uint pname, int param);
    public static void glPixelTexGenParameterivSGIS(uint pname, const int *params);
    public static void glPixelTexGenParameterfSGIS(uint pname, float param);
    public static void glPixelTexGenParameterfvSGIS(uint pname, const float *params);
    public static void glGetPixelTexGenParameterivSGIS(uint pname, int *params);
    public static void glGetPixelTexGenParameterfvSGIS(uint pname, float *params);
    #endif
    #endif /* GL_SGIS_pixel_texture */

    #ifndef GL_SGIS_point_line_texgen
    #define GL_SGIS_point_line_texgen 1
    public const uint GL_EYE_DISTANCE_TO_POINT_SGIS = 0x81F0;
    public const uint GL_OBJECT_DISTANCE_TO_POINT_SGIS = 0x81F1;
    public const uint GL_EYE_DISTANCE_TO_LINE_SGIS = 0x81F2;
    public const uint GL_OBJECT_DISTANCE_TO_LINE_SGIS = 0x81F3;
    public const uint GL_EYE_POINT_SGIS = 0x81F4;
    public const uint GL_OBJECT_POINT_SGIS = 0x81F5;
    public const uint GL_EYE_LINE_SGIS = 0x81F6;
    public const uint GL_OBJECT_LINE_SGIS = 0x81F7;
    #endif /* GL_SGIS_point_line_texgen */

    #ifndef GL_SGIS_point_parameters
    #define GL_SGIS_point_parameters 1
    public const uint GL_POINT_SIZE_MIN_SGIS = 0x8126;
    public const uint GL_POINT_SIZE_MAX_SGIS = 0x8127;
    public const uint GL_POINT_FADE_THRESHOLD_SIZE_SGIS = 0x8128;
    public const uint GL_DISTANCE_ATTENUATION_SGIS = 0x8129;
    private delegate void PFNGLPOINTPARAMETERFSGISPROC(uint pname, float param);
    private delegate void PFNGLPOINTPARAMETERFVSGISPROC(uint pname, const float *params);
    #ifdef GL_GLEXT_PROTOTYPES
    public static void glPointParameterfSGIS(uint pname, float param);
    public static void glPointParameterfvSGIS(uint pname, const float *params);
    #endif
    #endif /* GL_SGIS_point_parameters */

    #ifndef GL_SGIS_sharpen_texture
    #define GL_SGIS_sharpen_texture 1
    public const uint GL_LINEAR_SHARPEN_SGIS = 0x80AD;
    public const uint GL_LINEAR_SHARPEN_ALPHA_SGIS = 0x80AE;
    public const uint GL_LINEAR_SHARPEN_COLOR_SGIS = 0x80AF;
    public const uint GL_SHARPEN_TEXTURE_FUNC_POINTS_SGIS = 0x80B0;
    private delegate void PFNGLSHARPENTEXFUNCSGISPROC(uint target, uint n, const float *points);
    private delegate void PFNGLGETSHARPENTEXFUNCSGISPROC(uint target, float *points);
    #ifdef GL_GLEXT_PROTOTYPES
    public static void glSharpenTexFuncSGIS(uint target, uint n, const float *points);
    public static void glGetSharpenTexFuncSGIS(uint target, float *points);
    #endif
    #endif /* GL_SGIS_sharpen_texture */

    #ifndef GL_SGIS_texture4D
    #define GL_SGIS_texture4D 1
    public const uint GL_PACK_SKIP_VOLUMES_SGIS = 0x8130;
    public const uint GL_PACK_IMAGE_DEPTH_SGIS = 0x8131;
    public const uint GL_UNPACK_SKIP_VOLUMES_SGIS = 0x8132;
    public const uint GL_UNPACK_IMAGE_DEPTH_SGIS = 0x8133;
    public const uint GL_TEXTURE_4D_SGIS = 0x8134;
    public const uint GL_PROXY_TEXTURE_4D_SGIS = 0x8135;
    public const uint GL_TEXTURE_4DSIZE_SGIS = 0x8136;
    public const uint GL_TEXTURE_WRAP_Q_SGIS = 0x8137;
    public const uint GL_MAX_4D_TEXTURE_SIZE_SGIS = 0x8138;
    public const uint GL_TEXTURE_4D_BINDING_SGIS = 0x814F;
    private delegate void PFNGLTEXIMAGE4DSGISPROC(uint target, int level, uint internalformat, uint width, uint height, uint depth, uint size4d, int border, uint format, uint type, const void *pixels);
    private delegate void PFNGLTEXSUBIMAGE4DSGISPROC(uint target, int level, int xoffset, int yoffset, int zoffset, int woffset, uint width, uint height, uint depth, uint size4d, uint format, uint type, const void *pixels);
    #ifdef GL_GLEXT_PROTOTYPES
    public static void glTexImage4DSGIS(uint target, int level, uint internalformat, uint width, uint height, uint depth, uint size4d, int border, uint format, uint type, const void *pixels);
    public static void glTexSubImage4DSGIS(uint target, int level, int xoffset, int yoffset, int zoffset, int woffset, uint width, uint height, uint depth, uint size4d, uint format, uint type, const void *pixels);
    #endif
    #endif /* GL_SGIS_texture4D */

    #ifndef GL_SGIS_texture_border_clamp
    #define GL_SGIS_texture_border_clamp 1
    public const uint GL_CLAMP_TO_BORDER_SGIS = 0x812D;
    #endif /* GL_SGIS_texture_border_clamp */

    #ifndef GL_SGIS_texture_color_mask
    #define GL_SGIS_texture_color_mask 1
    public const uint GL_TEXTURE_COLOR_WRITEMASK_SGIS = 0x81EF;
    private delegate void PFNGLTEXTURECOLORMASKSGISPROC(bool red, bool green, bool blue, bool alpha);
    #ifdef GL_GLEXT_PROTOTYPES
    public static void glTextureColorMaskSGIS(bool red, bool green, bool blue, bool alpha);
    #endif
    #endif /* GL_SGIS_texture_color_mask */

    #ifndef GL_SGIS_texture_edge_clamp
    #define GL_SGIS_texture_edge_clamp 1
    public const uint GL_CLAMP_TO_EDGE_SGIS = 0x812F;
    #endif /* GL_SGIS_texture_edge_clamp */

    #ifndef GL_SGIS_texture_filter4
    #define GL_SGIS_texture_filter4 1
    public const uint GL_FILTER4_SGIS = 0x8146;
    public const uint GL_TEXTURE_FILTER4_SIZE_SGIS = 0x8147;
    private delegate void PFNGLGETTEXFILTERFUNCSGISPROC(uint target, uint filter, float *weights);
    private delegate void PFNGLTEXFILTERFUNCSGISPROC(uint target, uint filter, uint n, const float *weights);
    #ifdef GL_GLEXT_PROTOTYPES
    public static void glGetTexFilterFuncSGIS(uint target, uint filter, float *weights);
    public static void glTexFilterFuncSGIS(uint target, uint filter, uint n, const float *weights);
    #endif
    #endif /* GL_SGIS_texture_filter4 */

    #ifndef GL_SGIS_texture_lod
    #define GL_SGIS_texture_lod 1
    public const uint GL_TEXTURE_MIN_LOD_SGIS = 0x813A;
    public const uint GL_TEXTURE_MAX_LOD_SGIS = 0x813B;
    public const uint GL_TEXTURE_BASE_LEVEL_SGIS = 0x813C;
    public const uint GL_TEXTURE_MAX_LEVEL_SGIS = 0x813D;
    #endif /* GL_SGIS_texture_lod */

    #ifndef GL_SGIS_texture_select
    #define GL_SGIS_texture_select 1
    public const uint GL_DUAL_ALPHA4_SGIS = 0x8110;
    public const uint GL_DUAL_ALPHA8_SGIS = 0x8111;
    public const uint GL_DUAL_ALPHA12_SGIS = 0x8112;
    public const uint GL_DUAL_ALPHA16_SGIS = 0x8113;
    public const uint GL_DUAL_LUMINANCE4_SGIS = 0x8114;
    public const uint GL_DUAL_LUMINANCE8_SGIS = 0x8115;
    public const uint GL_DUAL_LUMINANCE12_SGIS = 0x8116;
    public const uint GL_DUAL_LUMINANCE16_SGIS = 0x8117;
    public const uint GL_DUAL_INTENSITY4_SGIS = 0x8118;
    public const uint GL_DUAL_INTENSITY8_SGIS = 0x8119;
    public const uint GL_DUAL_INTENSITY12_SGIS = 0x811A;
    public const uint GL_DUAL_INTENSITY16_SGIS = 0x811B;
    public const uint GL_DUAL_LUMINANCE_ALPHA4_SGIS = 0x811C;
    public const uint GL_DUAL_LUMINANCE_ALPHA8_SGIS = 0x811D;
    public const uint GL_QUAD_ALPHA4_SGIS = 0x811E;
    public const uint GL_QUAD_ALPHA8_SGIS = 0x811F;
    public const uint GL_QUAD_LUMINANCE4_SGIS = 0x8120;
    public const uint GL_QUAD_LUMINANCE8_SGIS = 0x8121;
    public const uint GL_QUAD_INTENSITY4_SGIS = 0x8122;
    public const uint GL_QUAD_INTENSITY8_SGIS = 0x8123;
    public const uint GL_DUAL_TEXTURE_SELECT_SGIS = 0x8124;
    public const uint GL_QUAD_TEXTURE_SELECT_SGIS = 0x8125;
    #endif /* GL_SGIS_texture_select */

    #ifndef GL_SGIX_async
    #define GL_SGIX_async 1
    public const uint GL_ASYNC_MARKER_SGIX = 0x8329;
    private delegate void PFNGLASYNCMARKERSGIXPROC(uint marker);
    private delegate int PFNGLFINISHASYNCSGIXPROC(uint *markerp);
    private delegate int PFNGLPOLLASYNCSGIXPROC(uint *markerp);
    private delegate uint PFNGLGENASYNCMARKERSSGIXPROC(uint range);
    private delegate void PFNGLDELETEASYNCMARKERSSGIXPROC(uint marker, uint range);
    private delegate bool PFNGLISASYNCMARKERSGIXPROC(uint marker);
    #ifdef GL_GLEXT_PROTOTYPES
    public static void glAsyncMarkerSGIX(uint marker);
    public static int glFinishAsyncSGIX(uint *markerp);
    public static int glPollAsyncSGIX(uint *markerp);
    public static uint glGenAsyncMarkersSGIX(uint range);
    public static void glDeleteAsyncMarkersSGIX(uint marker, uint range);
    public static bool glIsAsyncMarkerSGIX(uint marker);
    #endif
    #endif /* GL_SGIX_async */

    #ifndef GL_SGIX_async_histogram
    #define GL_SGIX_async_histogram 1
    public const uint GL_ASYNC_HISTOGRAM_SGIX = 0x832C;
    public const uint GL_MAX_ASYNC_HISTOGRAM_SGIX = 0x832D;
    #endif /* GL_SGIX_async_histogram */

    #ifndef GL_SGIX_async_pixel
    #define GL_SGIX_async_pixel 1
    public const uint GL_ASYNC_TEX_IMAGE_SGIX = 0x835C;
    public const uint GL_ASYNC_DRAW_PIXELS_SGIX = 0x835D;
    public const uint GL_ASYNC_READ_PIXELS_SGIX = 0x835E;
    public const uint GL_MAX_ASYNC_TEX_IMAGE_SGIX = 0x835F;
    public const uint GL_MAX_ASYNC_DRAW_PIXELS_SGIX = 0x8360;
    public const uint GL_MAX_ASYNC_READ_PIXELS_SGIX = 0x8361;
    #endif /* GL_SGIX_async_pixel */

    #ifndef GL_SGIX_blend_alpha_minmax
    #define GL_SGIX_blend_alpha_minmax 1
    public const uint GL_ALPHA_MIN_SGIX = 0x8320;
    public const uint GL_ALPHA_MAX_SGIX = 0x8321;
    #endif /* GL_SGIX_blend_alpha_minmax */

    #ifndef GL_SGIX_calligraphic_fragment
    #define GL_SGIX_calligraphic_fragment 1
    public const uint GL_CALLIGRAPHIC_FRAGMENT_SGIX = 0x8183;
    #endif /* GL_SGIX_calligraphic_fragment */

    #ifndef GL_SGIX_clipmap
    #define GL_SGIX_clipmap 1
    public const uint GL_LINEAR_CLIPMAP_LINEAR_SGIX = 0x8170;
    public const uint GL_TEXTURE_CLIPMAP_CENTER_SGIX = 0x8171;
    public const uint GL_TEXTURE_CLIPMAP_FRAME_SGIX = 0x8172;
    public const uint GL_TEXTURE_CLIPMAP_OFFSET_SGIX = 0x8173;
    public const uint GL_TEXTURE_CLIPMAP_VIRTUAL_DEPTH_SGIX = 0x8174;
    public const uint GL_TEXTURE_CLIPMAP_LOD_OFFSET_SGIX = 0x8175;
    public const uint GL_TEXTURE_CLIPMAP_DEPTH_SGIX = 0x8176;
    public const uint GL_MAX_CLIPMAP_DEPTH_SGIX = 0x8177;
    public const uint GL_MAX_CLIPMAP_VIRTUAL_DEPTH_SGIX = 0x8178;
    public const uint GL_NEAREST_CLIPMAP_NEAREST_SGIX = 0x844D;
    public const uint GL_NEAREST_CLIPMAP_LINEAR_SGIX = 0x844E;
    public const uint GL_LINEAR_CLIPMAP_NEAREST_SGIX = 0x844F;
    #endif /* GL_SGIX_clipmap */

    #ifndef GL_SGIX_convolution_accuracy
    #define GL_SGIX_convolution_accuracy 1
    public const uint GL_CONVOLUTION_HINT_SGIX = 0x8316;
    #endif /* GL_SGIX_convolution_accuracy */

    #ifndef GL_SGIX_depth_pass_instrument
    #define GL_SGIX_depth_pass_instrument 1
    #endif /* GL_SGIX_depth_pass_instrument */

    #ifndef GL_SGIX_depth_texture
    #define GL_SGIX_depth_texture 1
    public const uint GL_DEPTH_COMPONENT16_SGIX = 0x81A5;
    public const uint GL_DEPTH_COMPONENT24_SGIX = 0x81A6;
    public const uint GL_DEPTH_COMPONENT32_SGIX = 0x81A7;
    #endif /* GL_SGIX_depth_texture */

    #ifndef GL_SGIX_flush_raster
    #define GL_SGIX_flush_raster 1
    private delegate void PFNGLFLUSHRASTERSGIXPROC(void);
    #ifdef GL_GLEXT_PROTOTYPES
    public static void glFlushRasterSGIX(void);
    #endif
    #endif /* GL_SGIX_flush_raster */

    #ifndef GL_SGIX_fog_offset
    #define GL_SGIX_fog_offset 1
    public const uint GL_FOG_OFFSET_SGIX = 0x8198;
    public const uint GL_FOG_OFFSET_VALUE_SGIX = 0x8199;
    #endif /* GL_SGIX_fog_offset */

    #ifndef GL_SGIX_fragment_lighting
    #define GL_SGIX_fragment_lighting 1
    public const uint GL_FRAGMENT_LIGHTING_SGIX = 0x8400;
    public const uint GL_FRAGMENT_COLOR_MATERIAL_SGIX = 0x8401;
    public const uint GL_FRAGMENT_COLOR_MATERIAL_FACE_SGIX = 0x8402;
    public const uint GL_FRAGMENT_COLOR_MATERIAL_PARAMETER_SGIX = 0x8403;
    public const uint GL_MAX_FRAGMENT_LIGHTS_SGIX = 0x8404;
    public const uint GL_MAX_ACTIVE_LIGHTS_SGIX = 0x8405;
    public const uint GL_CURRENT_RASTER_NORMAL_SGIX = 0x8406;
    public const uint GL_LIGHT_ENV_MODE_SGIX = 0x8407;
    public const uint GL_FRAGMENT_LIGHT_MODEL_LOCAL_VIEWER_SGIX = 0x8408;
    public const uint GL_FRAGMENT_LIGHT_MODEL_TWO_SIDE_SGIX = 0x8409;
    public const uint GL_FRAGMENT_LIGHT_MODEL_AMBIENT_SGIX = 0x840A;
    public const uint GL_FRAGMENT_LIGHT_MODEL_NORMAL_INTERPOLATION_SGIX = 0x840B;
    public const uint GL_FRAGMENT_LIGHT0_SGIX = 0x840C;
    public const uint GL_FRAGMENT_LIGHT1_SGIX = 0x840D;
    public const uint GL_FRAGMENT_LIGHT2_SGIX = 0x840E;
    public const uint GL_FRAGMENT_LIGHT3_SGIX = 0x840F;
    public const uint GL_FRAGMENT_LIGHT4_SGIX = 0x8410;
    public const uint GL_FRAGMENT_LIGHT5_SGIX = 0x8411;
    public const uint GL_FRAGMENT_LIGHT6_SGIX = 0x8412;
    public const uint GL_FRAGMENT_LIGHT7_SGIX = 0x8413;
    private delegate void PFNGLFRAGMENTCOLORMATERIALSGIXPROC(uint face, uint mode);
    private delegate void PFNGLFRAGMENTLIGHTFSGIXPROC(uint light, uint pname, float param);
    private delegate void PFNGLFRAGMENTLIGHTFVSGIXPROC(uint light, uint pname, const float *params);
    private delegate void PFNGLFRAGMENTLIGHTISGIXPROC(uint light, uint pname, int param);
    private delegate void PFNGLFRAGMENTLIGHTIVSGIXPROC(uint light, uint pname, const int *params);
    private delegate void PFNGLFRAGMENTLIGHTMODELFSGIXPROC(uint pname, float param);
    private delegate void PFNGLFRAGMENTLIGHTMODELFVSGIXPROC(uint pname, const float *params);
    private delegate void PFNGLFRAGMENTLIGHTMODELISGIXPROC(uint pname, int param);
    private delegate void PFNGLFRAGMENTLIGHTMODELIVSGIXPROC(uint pname, const int *params);
    private delegate void PFNGLFRAGMENTMATERIALFSGIXPROC(uint face, uint pname, float param);
    private delegate void PFNGLFRAGMENTMATERIALFVSGIXPROC(uint face, uint pname, const float *params);
    private delegate void PFNGLFRAGMENTMATERIALISGIXPROC(uint face, uint pname, int param);
    private delegate void PFNGLFRAGMENTMATERIALIVSGIXPROC(uint face, uint pname, const int *params);
    private delegate void PFNGLGETFRAGMENTLIGHTFVSGIXPROC(uint light, uint pname, float *params);
    private delegate void PFNGLGETFRAGMENTLIGHTIVSGIXPROC(uint light, uint pname, int *params);
    private delegate void PFNGLGETFRAGMENTMATERIALFVSGIXPROC(uint face, uint pname, float *params);
    private delegate void PFNGLGETFRAGMENTMATERIALIVSGIXPROC(uint face, uint pname, int *params);
    private delegate void PFNGLLIGHTENVISGIXPROC(uint pname, int param);
    #ifdef GL_GLEXT_PROTOTYPES
    public static void glFragmentColorMaterialSGIX(uint face, uint mode);
    public static void glFragmentLightfSGIX(uint light, uint pname, float param);
    public static void glFragmentLightfvSGIX(uint light, uint pname, const float *params);
    public static void glFragmentLightiSGIX(uint light, uint pname, int param);
    public static void glFragmentLightivSGIX(uint light, uint pname, const int *params);
    public static void glFragmentLightModelfSGIX(uint pname, float param);
    public static void glFragmentLightModelfvSGIX(uint pname, const float *params);
    public static void glFragmentLightModeliSGIX(uint pname, int param);
    public static void glFragmentLightModelivSGIX(uint pname, const int *params);
    public static void glFragmentMaterialfSGIX(uint face, uint pname, float param);
    public static void glFragmentMaterialfvSGIX(uint face, uint pname, const float *params);
    public static void glFragmentMaterialiSGIX(uint face, uint pname, int param);
    public static void glFragmentMaterialivSGIX(uint face, uint pname, const int *params);
    public static void glGetFragmentLightfvSGIX(uint light, uint pname, float *params);
    public static void glGetFragmentLightivSGIX(uint light, uint pname, int *params);
    public static void glGetFragmentMaterialfvSGIX(uint face, uint pname, float *params);
    public static void glGetFragmentMaterialivSGIX(uint face, uint pname, int *params);
    public static void glLightEnviSGIX(uint pname, int param);
    #endif
    #endif /* GL_SGIX_fragment_lighting */

    #ifndef GL_SGIX_framezoom
    #define GL_SGIX_framezoom 1
    public const uint GL_FRAMEZOOM_SGIX = 0x818B;
    public const uint GL_FRAMEZOOM_FACTOR_SGIX = 0x818C;
    public const uint GL_MAX_FRAMEZOOM_FACTOR_SGIX = 0x818D;
    private delegate void PFNGLFRAMEZOOMSGIXPROC(int factor);
    #ifdef GL_GLEXT_PROTOTYPES
    public static void glFrameZoomSGIX(int factor);
    #endif
    #endif /* GL_SGIX_framezoom */

    #ifndef GL_SGIX_igloo_interface
    #define GL_SGIX_igloo_interface 1
    private delegate void PFNGLIGLOOINTERFACESGIXPROC(uint pname, const void *params);
    #ifdef GL_GLEXT_PROTOTYPES
    public static void glIglooInterfaceSGIX(uint pname, const void *params);
    #endif
    #endif /* GL_SGIX_igloo_interface */

    #ifndef GL_SGIX_instruments
    #define GL_SGIX_instruments 1
    public const uint GL_INSTRUMENT_BUFFER_POINTER_SGIX = 0x8180;
    public const uint GL_INSTRUMENT_MEASUREMENTS_SGIX = 0x8181;
    private delegate int PFNGLGETINSTRUMENTSSGIXPROC(void);
    private delegate void PFNGLINSTRUMENTSBUFFERSGIXPROC(uint size, int *buffer);
    private delegate int PFNGLPOLLINSTRUMENTSSGIXPROC(int *marker_p);
    private delegate void PFNGLREADINSTRUMENTSSGIXPROC(int marker);
    private delegate void PFNGLSTARTINSTRUMENTSSGIXPROC(void);
    private delegate void PFNGLSTOPINSTRUMENTSSGIXPROC(int marker);
    #ifdef GL_GLEXT_PROTOTYPES
    public static int glGetInstrumentsSGIX(void);
    public static void glInstrumentsBufferSGIX(uint size, int *buffer);
    public static int glPollInstrumentsSGIX(int *marker_p);
    public static void glReadInstrumentsSGIX(int marker);
    public static void glStartInstrumentsSGIX(void);
    public static void glStopInstrumentsSGIX(int marker);
    #endif
    #endif /* GL_SGIX_instruments */

    #ifndef GL_SGIX_interlace
    #define GL_SGIX_interlace 1
    public const uint GL_INTERLACE_SGIX = 0x8094;
    #endif /* GL_SGIX_interlace */

    #ifndef GL_SGIX_ir_instrument1
    #define GL_SGIX_ir_instrument1 1
    public const uint GL_IR_INSTRUMENT1_SGIX = 0x817F;
    #endif /* GL_SGIX_ir_instrument1 */

    #ifndef GL_SGIX_list_priority
    #define GL_SGIX_list_priority 1
    public const uint GL_LIST_PRIORITY_SGIX = 0x8182;
    private delegate void PFNGLGETLISTPARAMETERFVSGIXPROC(uint list, uint pname, float *params);
    private delegate void PFNGLGETLISTPARAMETERIVSGIXPROC(uint list, uint pname, int *params);
    private delegate void PFNGLLISTPARAMETERFSGIXPROC(uint list, uint pname, float param);
    private delegate void PFNGLLISTPARAMETERFVSGIXPROC(uint list, uint pname, const float *params);
    private delegate void PFNGLLISTPARAMETERISGIXPROC(uint list, uint pname, int param);
    private delegate void PFNGLLISTPARAMETERIVSGIXPROC(uint list, uint pname, const int *params);
    #ifdef GL_GLEXT_PROTOTYPES
    public static void glGetListParameterfvSGIX(uint list, uint pname, float *params);
    public static void glGetListParameterivSGIX(uint list, uint pname, int *params);
    public static void glListParameterfSGIX(uint list, uint pname, float param);
    public static void glListParameterfvSGIX(uint list, uint pname, const float *params);
    public static void glListParameteriSGIX(uint list, uint pname, int param);
    public static void glListParameterivSGIX(uint list, uint pname, const int *params);
    #endif
    #endif /* GL_SGIX_list_priority */

    #ifndef GL_SGIX_pixel_texture
    #define GL_SGIX_pixel_texture 1
    public const uint GL_PIXEL_TEX_GEN_SGIX = 0x8139;
    public const uint GL_PIXEL_TEX_GEN_MODE_SGIX = 0x832B;
    private delegate void PFNGLPIXELTEXGENSGIXPROC(uint mode);
    #ifdef GL_GLEXT_PROTOTYPES
    public static void glPixelTexGenSGIX(uint mode);
    #endif
    #endif /* GL_SGIX_pixel_texture */

    #ifndef GL_SGIX_pixel_tiles
    #define GL_SGIX_pixel_tiles 1
    public const uint GL_PIXEL_TILE_BEST_ALIGNMENT_SGIX = 0x813E;
    public const uint GL_PIXEL_TILE_CACHE_INCREMENT_SGIX = 0x813F;
    public const uint GL_PIXEL_TILE_WIDTH_SGIX = 0x8140;
    public const uint GL_PIXEL_TILE_HEIGHT_SGIX = 0x8141;
    public const uint GL_PIXEL_TILE_GRID_WIDTH_SGIX = 0x8142;
    public const uint GL_PIXEL_TILE_GRID_HEIGHT_SGIX = 0x8143;
    public const uint GL_PIXEL_TILE_GRID_DEPTH_SGIX = 0x8144;
    public const uint GL_PIXEL_TILE_CACHE_SIZE_SGIX = 0x8145;
    #endif /* GL_SGIX_pixel_tiles */

    #ifndef GL_SGIX_polynomial_ffd
    #define GL_SGIX_polynomial_ffd 1
    public const uint GL_TEXTURE_DEFORMATION_BIT_SGIX = 0x00000001;
    public const uint GL_GEOMETRY_DEFORMATION_BIT_SGIX = 0x00000002;
    public const uint GL_GEOMETRY_DEFORMATION_SGIX = 0x8194;
    public const uint GL_TEXTURE_DEFORMATION_SGIX = 0x8195;
    public const uint GL_DEFORMATIONS_MASK_SGIX = 0x8196;
    public const uint GL_MAX_DEFORMATION_ORDER_SGIX = 0x8197;
    private delegate void PFNGLDEFORMATIONMAP3DSGIXPROC(uint target, double u1, double u2, int ustride, int uorder, double v1, double v2, int vstride, int vorder, double w1, double w2, int wstride, int worder, const double *points);
    private delegate void PFNGLDEFORMATIONMAP3FSGIXPROC(uint target, float u1, float u2, int ustride, int uorder, float v1, float v2, int vstride, int vorder, float w1, float w2, int wstride, int worder, const float *points);
    private delegate void PFNGLDEFORMSGIXPROC(uint mask);
    private delegate void PFNGLLOADIDENTITYDEFORMATIONMAPSGIXPROC(uint mask);
    #ifdef GL_GLEXT_PROTOTYPES
    public static void glDeformationMap3dSGIX(uint target, double u1, double u2, int ustride, int uorder, double v1, double v2, int vstride, int vorder, double w1, double w2, int wstride, int worder, const double *points);
    public static void glDeformationMap3fSGIX(uint target, float u1, float u2, int ustride, int uorder, float v1, float v2, int vstride, int vorder, float w1, float w2, int wstride, int worder, const float *points);
    public static void glDeformSGIX(uint mask);
    public static void glLoadIdentityDeformationMapSGIX(uint mask);
    #endif
    #endif /* GL_SGIX_polynomial_ffd */

    #ifndef GL_SGIX_reference_plane
    #define GL_SGIX_reference_plane 1
    public const uint GL_REFERENCE_PLANE_SGIX = 0x817D;
    public const uint GL_REFERENCE_PLANE_EQUATION_SGIX = 0x817E;
    private delegate void PFNGLREFERENCEPLANESGIXPROC(const double *equation);
    #ifdef GL_GLEXT_PROTOTYPES
    public static void glReferencePlaneSGIX(const double *equation);
    #endif
    #endif /* GL_SGIX_reference_plane */

    #ifndef GL_SGIX_resample
    #define GL_SGIX_resample 1
    public const uint GL_PACK_RESAMPLE_SGIX = 0x842C;
    public const uint GL_UNPACK_RESAMPLE_SGIX = 0x842D;
    public const uint GL_RESAMPLE_REPLICATE_SGIX = 0x842E;
    public const uint GL_RESAMPLE_ZERO_FILL_SGIX = 0x842F;
    public const uint GL_RESAMPLE_DECIMATE_SGIX = 0x8430;
    #endif /* GL_SGIX_resample */

    #ifndef GL_SGIX_scalebias_hint
    #define GL_SGIX_scalebias_hint 1
    public const uint GL_SCALEBIAS_HINT_SGIX = 0x8322;
    #endif /* GL_SGIX_scalebias_hint */

    #ifndef GL_SGIX_shadow
    #define GL_SGIX_shadow 1
    public const uint GL_TEXTURE_COMPARE_SGIX = 0x819A;
    public const uint GL_TEXTURE_COMPARE_OPERATOR_SGIX = 0x819B;
    public const uint GL_TEXTURE_LEQUAL_R_SGIX = 0x819C;
    public const uint GL_TEXTURE_GEQUAL_R_SGIX = 0x819D;
    #endif /* GL_SGIX_shadow */

    #ifndef GL_SGIX_shadow_ambient
    #define GL_SGIX_shadow_ambient 1
    public const uint GL_SHADOW_AMBIENT_SGIX = 0x80BF;
    #endif /* GL_SGIX_shadow_ambient */

    #ifndef GL_SGIX_sprite
    #define GL_SGIX_sprite 1
    public const uint GL_SPRITE_SGIX = 0x8148;
    public const uint GL_SPRITE_MODE_SGIX = 0x8149;
    public const uint GL_SPRITE_AXIS_SGIX = 0x814A;
    public const uint GL_SPRITE_TRANSLATION_SGIX = 0x814B;
    public const uint GL_SPRITE_AXIAL_SGIX = 0x814C;
    public const uint GL_SPRITE_OBJECT_ALIGNED_SGIX = 0x814D;
    public const uint GL_SPRITE_EYE_ALIGNED_SGIX = 0x814E;
    private delegate void PFNGLSPRITEPARAMETERFSGIXPROC(uint pname, float param);
    private delegate void PFNGLSPRITEPARAMETERFVSGIXPROC(uint pname, const float *params);
    private delegate void PFNGLSPRITEPARAMETERISGIXPROC(uint pname, int param);
    private delegate void PFNGLSPRITEPARAMETERIVSGIXPROC(uint pname, const int *params);
    #ifdef GL_GLEXT_PROTOTYPES
    public static void glSpriteParameterfSGIX(uint pname, float param);
    public static void glSpriteParameterfvSGIX(uint pname, const float *params);
    public static void glSpriteParameteriSGIX(uint pname, int param);
    public static void glSpriteParameterivSGIX(uint pname, const int *params);
    #endif
    #endif /* GL_SGIX_sprite */

    #ifndef GL_SGIX_subsample
    #define GL_SGIX_subsample 1
    public const uint GL_PACK_SUBSAMPLE_RATE_SGIX = 0x85A0;
    public const uint GL_UNPACK_SUBSAMPLE_RATE_SGIX = 0x85A1;
    public const uint GL_PIXEL_SUBSAMPLE_4444_SGIX = 0x85A2;
    public const uint GL_PIXEL_SUBSAMPLE_2424_SGIX = 0x85A3;
    public const uint GL_PIXEL_SUBSAMPLE_4242_SGIX = 0x85A4;
    #endif /* GL_SGIX_subsample */

    #ifndef GL_SGIX_tag_sample_buffer
    #define GL_SGIX_tag_sample_buffer 1
    private delegate void PFNGLTAGSAMPLEBUFFERSGIXPROC(void);
    #ifdef GL_GLEXT_PROTOTYPES
    public static void glTagSampleBufferSGIX(void);
    #endif
    #endif /* GL_SGIX_tag_sample_buffer */

    #ifndef GL_SGIX_texture_add_env
    #define GL_SGIX_texture_add_env 1
    public const uint GL_TEXTURE_ENV_BIAS_SGIX = 0x80BE;
    #endif /* GL_SGIX_texture_add_env */

    #ifndef GL_SGIX_texture_coordinate_clamp
    #define GL_SGIX_texture_coordinate_clamp 1
    public const uint GL_TEXTURE_MAX_CLAMP_S_SGIX = 0x8369;
    public const uint GL_TEXTURE_MAX_CLAMP_T_SGIX = 0x836A;
    public const uint GL_TEXTURE_MAX_CLAMP_R_SGIX = 0x836B;
    #endif /* GL_SGIX_texture_coordinate_clamp */

    #ifndef GL_SGIX_texture_lod_bias
    #define GL_SGIX_texture_lod_bias 1
    public const uint GL_TEXTURE_LOD_BIAS_S_SGIX = 0x818E;
    public const uint GL_TEXTURE_LOD_BIAS_T_SGIX = 0x818F;
    public const uint GL_TEXTURE_LOD_BIAS_R_SGIX = 0x8190;
    #endif /* GL_SGIX_texture_lod_bias */

    #ifndef GL_SGIX_texture_multi_buffer
    #define GL_SGIX_texture_multi_buffer 1
    public const uint GL_TEXTURE_MULTI_BUFFER_HINT_SGIX = 0x812E;
    #endif /* GL_SGIX_texture_multi_buffer */

    #ifndef GL_SGIX_texture_scale_bias
    #define GL_SGIX_texture_scale_bias 1
    public const uint GL_POST_TEXTURE_FILTER_BIAS_SGIX = 0x8179;
    public const uint GL_POST_TEXTURE_FILTER_SCALE_SGIX = 0x817A;
    public const uint GL_POST_TEXTURE_FILTER_BIAS_RANGE_SGIX = 0x817B;
    public const uint GL_POST_TEXTURE_FILTER_SCALE_RANGE_SGIX = 0x817C;
    #endif /* GL_SGIX_texture_scale_bias */

    #ifndef GL_SGIX_vertex_preclip
    #define GL_SGIX_vertex_preclip 1
    public const uint GL_VERTEX_PRECLIP_SGIX = 0x83EE;
    public const uint GL_VERTEX_PRECLIP_HINT_SGIX = 0x83EF;
    #endif /* GL_SGIX_vertex_preclip */

    #ifndef GL_SGIX_ycrcb
    #define GL_SGIX_ycrcb 1
    public const uint GL_YCRCB_422_SGIX = 0x81BB;
    public const uint GL_YCRCB_444_SGIX = 0x81BC;
    #endif /* GL_SGIX_ycrcb */

    #ifndef GL_SGIX_ycrcb_subsample
    #define GL_SGIX_ycrcb_subsample 1
    #endif /* GL_SGIX_ycrcb_subsample */

    #ifndef GL_SGIX_ycrcba
    #define GL_SGIX_ycrcba 1
    public const uint GL_YCRCB_SGIX = 0x8318;
    public const uint GL_YCRCBA_SGIX = 0x8319;
    #endif /* GL_SGIX_ycrcba */

    #ifndef GL_SGI_color_matrix
    #define GL_SGI_color_matrix 1
    public const uint GL_COLOR_MATRIX_SGI = 0x80B1;
    public const uint GL_COLOR_MATRIX_STACK_DEPTH_SGI = 0x80B2;
    public const uint GL_MAX_COLOR_MATRIX_STACK_DEPTH_SGI = 0x80B3;
    public const uint GL_POST_COLOR_MATRIX_RED_SCALE_SGI = 0x80B4;
    public const uint GL_POST_COLOR_MATRIX_GREEN_SCALE_SGI = 0x80B5;
    public const uint GL_POST_COLOR_MATRIX_BLUE_SCALE_SGI = 0x80B6;
    public const uint GL_POST_COLOR_MATRIX_ALPHA_SCALE_SGI = 0x80B7;
    public const uint GL_POST_COLOR_MATRIX_RED_BIAS_SGI = 0x80B8;
    public const uint GL_POST_COLOR_MATRIX_GREEN_BIAS_SGI = 0x80B9;
    public const uint GL_POST_COLOR_MATRIX_BLUE_BIAS_SGI = 0x80BA;
    public const uint GL_POST_COLOR_MATRIX_ALPHA_BIAS_SGI = 0x80BB;
    #endif /* GL_SGI_color_matrix */

    #ifndef GL_SGI_color_table
    #define GL_SGI_color_table 1
    public const uint GL_COLOR_TABLE_SGI = 0x80D0;
    public const uint GL_POST_CONVOLUTION_COLOR_TABLE_SGI = 0x80D1;
    public const uint GL_POST_COLOR_MATRIX_COLOR_TABLE_SGI = 0x80D2;
    public const uint GL_PROXY_COLOR_TABLE_SGI = 0x80D3;
    public const uint GL_PROXY_POST_CONVOLUTION_COLOR_TABLE_SGI = 0x80D4;
    public const uint GL_PROXY_POST_COLOR_MATRIX_COLOR_TABLE_SGI = 0x80D5;
    public const uint GL_COLOR_TABLE_SCALE_SGI = 0x80D6;
    public const uint GL_COLOR_TABLE_BIAS_SGI = 0x80D7;
    public const uint GL_COLOR_TABLE_FORMAT_SGI = 0x80D8;
    public const uint GL_COLOR_TABLE_WIDTH_SGI = 0x80D9;
    public const uint GL_COLOR_TABLE_RED_SIZE_SGI = 0x80DA;
    public const uint GL_COLOR_TABLE_GREEN_SIZE_SGI = 0x80DB;
    public const uint GL_COLOR_TABLE_BLUE_SIZE_SGI = 0x80DC;
    public const uint GL_COLOR_TABLE_ALPHA_SIZE_SGI = 0x80DD;
    public const uint GL_COLOR_TABLE_LUMINANCE_SIZE_SGI = 0x80DE;
    public const uint GL_COLOR_TABLE_INTENSITY_SIZE_SGI = 0x80DF;
    private delegate void PFNGLCOLORTABLESGIPROC(uint target, uint internalformat, uint width, uint format, uint type, const void *table);
    private delegate void PFNGLCOLORTABLEPARAMETERFVSGIPROC(uint target, uint pname, const float *params);
    private delegate void PFNGLCOLORTABLEPARAMETERIVSGIPROC(uint target, uint pname, const int *params);
    private delegate void PFNGLCOPYCOLORTABLESGIPROC(uint target, uint internalformat, int x, int y, uint width);
    private delegate void PFNGLGETCOLORTABLESGIPROC(uint target, uint format, uint type, void *table);
    private delegate void PFNGLGETCOLORTABLEPARAMETERFVSGIPROC(uint target, uint pname, float *params);
    private delegate void PFNGLGETCOLORTABLEPARAMETERIVSGIPROC(uint target, uint pname, int *params);
    #ifdef GL_GLEXT_PROTOTYPES
    public static void glColorTableSGI(uint target, uint internalformat, uint width, uint format, uint type, const void *table);
    public static void glColorTableParameterfvSGI(uint target, uint pname, const float *params);
    public static void glColorTableParameterivSGI(uint target, uint pname, const int *params);
    public static void glCopyColorTableSGI(uint target, uint internalformat, int x, int y, uint width);
    public static void glGetColorTableSGI(uint target, uint format, uint type, void *table);
    public static void glGetColorTableParameterfvSGI(uint target, uint pname, float *params);
    public static void glGetColorTableParameterivSGI(uint target, uint pname, int *params);
    #endif
    #endif /* GL_SGI_color_table */

    #ifndef GL_SGI_texture_color_table
    #define GL_SGI_texture_color_table 1
    public const uint GL_TEXTURE_COLOR_TABLE_SGI = 0x80BC;
    public const uint GL_PROXY_TEXTURE_COLOR_TABLE_SGI = 0x80BD;
    #endif /* GL_SGI_texture_color_table */

    #ifndef GL_SUNX_constant_data
    #define GL_SUNX_constant_data 1
    public const uint GL_UNPACK_CONSTANT_DATA_SUNX = 0x81D5;
    public const uint GL_TEXTURE_CONSTANT_DATA_SUNX = 0x81D6;
    private delegate void PFNGLFINISHTEXTURESUNXPROC(void);
    #ifdef GL_GLEXT_PROTOTYPES
    public static void glFinishTextureSUNX(void);
    #endif
    #endif /* GL_SUNX_constant_data */

    #ifndef GL_SUN_convolution_border_modes
    #define GL_SUN_convolution_border_modes 1
    public const uint GL_WRAP_BORDER_SUN = 0x81D4;
    #endif /* GL_SUN_convolution_border_modes */

    #ifndef GL_SUN_global_alpha
    #define GL_SUN_global_alpha 1
    public const uint GL_GLOBAL_ALPHA_SUN = 0x81D9;
    public const uint GL_GLOBAL_ALPHA_FACTOR_SUN = 0x81DA;
    private delegate void PFNGLGLOBALALPHAFACTORBSUNPROC(sbyte factor);
    private delegate void PFNGLGLOBALALPHAFACTORSSUNPROC(short factor);
    private delegate void PFNGLGLOBALALPHAFACTORISUNPROC(int factor);
    private delegate void PFNGLGLOBALALPHAFACTORFSUNPROC(float factor);
    private delegate void PFNGLGLOBALALPHAFACTORDSUNPROC(double factor);
    private delegate void PFNGLGLOBALALPHAFACTORUBSUNPROC(byte factor);
    private delegate void PFNGLGLOBALALPHAFACTORUSSUNPROC(ushort factor);
    private delegate void PFNGLGLOBALALPHAFACTORUISUNPROC(uint factor);
    #ifdef GL_GLEXT_PROTOTYPES
    public static void glGlobalAlphaFactorbSUN(sbyte factor);
    public static void glGlobalAlphaFactorsSUN(short factor);
    public static void glGlobalAlphaFactoriSUN(int factor);
    public static void glGlobalAlphaFactorfSUN(float factor);
    public static void glGlobalAlphaFactordSUN(double factor);
    public static void glGlobalAlphaFactorubSUN(byte factor);
    public static void glGlobalAlphaFactorusSUN(ushort factor);
    public static void glGlobalAlphaFactoruiSUN(uint factor);
    #endif
    #endif /* GL_SUN_global_alpha */

    #ifndef GL_SUN_mesh_array
    #define GL_SUN_mesh_array 1
    public const uint GL_QUAD_MESH_SUN = 0x8614;
    public const uint GL_TRIANGLE_MESH_SUN = 0x8615;
    private delegate void PFNGLDRAWMESHARRAYSSUNPROC(uint mode, int first, uint count, uint width);
    #ifdef GL_GLEXT_PROTOTYPES
    public static void glDrawMeshArraysSUN(uint mode, int first, uint count, uint width);
    #endif
    #endif /* GL_SUN_mesh_array */

    #ifndef GL_SUN_slice_accum
    #define GL_SUN_slice_accum 1
    public const uint GL_SLICE_ACCUM_SUN = 0x85CC;
    #endif /* GL_SUN_slice_accum */

    #ifndef GL_SUN_triangle_list
    #define GL_SUN_triangle_list 1
    public const uint GL_RESTART_SUN = 0x0001;
    public const uint GL_REPLACE_MIDDLE_SUN = 0x0002;
    public const uint GL_REPLACE_OLDEST_SUN = 0x0003;
    public const uint GL_TRIANGLE_LIST_SUN = 0x81D7;
    public const uint GL_REPLACEMENT_CODE_SUN = 0x81D8;
    public const uint GL_REPLACEMENT_CODE_ARRAY_SUN = 0x85C0;
    public const uint GL_REPLACEMENT_CODE_ARRAY_TYPE_SUN = 0x85C1;
    public const uint GL_REPLACEMENT_CODE_ARRAY_STRIDE_SUN = 0x85C2;
    public const uint GL_REPLACEMENT_CODE_ARRAY_POINTER_SUN = 0x85C3;
    public const uint GL_R1UI_V3F_SUN = 0x85C4;
    public const uint GL_R1UI_C4UB_V3F_SUN = 0x85C5;
    public const uint GL_R1UI_C3F_V3F_SUN = 0x85C6;
    public const uint GL_R1UI_N3F_V3F_SUN = 0x85C7;
    public const uint GL_R1UI_C4F_N3F_V3F_SUN = 0x85C8;
    public const uint GL_R1UI_T2F_V3F_SUN = 0x85C9;
    public const uint GL_R1UI_T2F_N3F_V3F_SUN = 0x85CA;
    public const uint GL_R1UI_T2F_C4F_N3F_V3F_SUN = 0x85CB;
    private delegate void PFNGLREPLACEMENTCODEUISUNPROC(uint code);
    private delegate void PFNGLREPLACEMENTCODEUSSUNPROC(ushort code);
    private delegate void PFNGLREPLACEMENTCODEUBSUNPROC(byte code);
    private delegate void PFNGLREPLACEMENTCODEUIVSUNPROC(const uint *code);
    private delegate void PFNGLREPLACEMENTCODEUSVSUNPROC(const ushort *code);
    private delegate void PFNGLREPLACEMENTCODEUBVSUNPROC(const byte *code);
    private delegate void PFNGLREPLACEMENTCODEPOINTERSUNPROC(uint type, uint stride, const void **pointer);
    #ifdef GL_GLEXT_PROTOTYPES
    public static void glReplacementCodeuiSUN(uint code);
    public static void glReplacementCodeusSUN(ushort code);
    public static void glReplacementCodeubSUN(byte code);
    public static void glReplacementCodeuivSUN(const uint *code);
    public static void glReplacementCodeusvSUN(const ushort *code);
    public static void glReplacementCodeubvSUN(const byte *code);
    public static void glReplacementCodePointerSUN(uint type, uint stride, const void **pointer);
    #endif
    #endif /* GL_SUN_triangle_list */

    #ifndef GL_SUN_vertex
    #define GL_SUN_vertex 1
    private delegate void PFNGLCOLOR4UBVERTEX2FSUNPROC(byte r, byte g, byte b, byte a, float x, float y);
    private delegate void PFNGLCOLOR4UBVERTEX2FVSUNPROC(const byte *c, const float *v);
    private delegate void PFNGLCOLOR4UBVERTEX3FSUNPROC(byte r, byte g, byte b, byte a, float x, float y, float z);
    private delegate void PFNGLCOLOR4UBVERTEX3FVSUNPROC(const byte *c, const float *v);
    private delegate void PFNGLCOLOR3FVERTEX3FSUNPROC(float r, float g, float b, float x, float y, float z);
    private delegate void PFNGLCOLOR3FVERTEX3FVSUNPROC(const float *c, const float *v);
    private delegate void PFNGLNORMAL3FVERTEX3FSUNPROC(float nx, float ny, float nz, float x, float y, float z);
    private delegate void PFNGLNORMAL3FVERTEX3FVSUNPROC(const float *n, const float *v);
    private delegate void PFNGLCOLOR4FNORMAL3FVERTEX3FSUNPROC(float r, float g, float b, float a, float nx, float ny, float nz, float x, float y, float z);
    private delegate void PFNGLCOLOR4FNORMAL3FVERTEX3FVSUNPROC(const float *c, const float *n, const float *v);
    private delegate void PFNGLTEXCOORD2FVERTEX3FSUNPROC(float s, float t, float x, float y, float z);
    private delegate void PFNGLTEXCOORD2FVERTEX3FVSUNPROC(const float *tc, const float *v);
    private delegate void PFNGLTEXCOORD4FVERTEX4FSUNPROC(float s, float t, float p, float q, float x, float y, float z, float w);
    private delegate void PFNGLTEXCOORD4FVERTEX4FVSUNPROC(const float *tc, const float *v);
    private delegate void PFNGLTEXCOORD2FCOLOR4UBVERTEX3FSUNPROC(float s, float t, byte r, byte g, byte b, byte a, float x, float y, float z);
    private delegate void PFNGLTEXCOORD2FCOLOR4UBVERTEX3FVSUNPROC(const float *tc, const byte *c, const float *v);
    private delegate void PFNGLTEXCOORD2FCOLOR3FVERTEX3FSUNPROC(float s, float t, float r, float g, float b, float x, float y, float z);
    private delegate void PFNGLTEXCOORD2FCOLOR3FVERTEX3FVSUNPROC(const float *tc, const float *c, const float *v);
    private delegate void PFNGLTEXCOORD2FNORMAL3FVERTEX3FSUNPROC(float s, float t, float nx, float ny, float nz, float x, float y, float z);
    private delegate void PFNGLTEXCOORD2FNORMAL3FVERTEX3FVSUNPROC(const float *tc, const float *n, const float *v);
    private delegate void PFNGLTEXCOORD2FCOLOR4FNORMAL3FVERTEX3FSUNPROC(float s, float t, float r, float g, float b, float a, float nx, float ny, float nz, float x, float y, float z);
    private delegate void PFNGLTEXCOORD2FCOLOR4FNORMAL3FVERTEX3FVSUNPROC(const float *tc, const float *c, const float *n, const float *v);
    private delegate void PFNGLTEXCOORD4FCOLOR4FNORMAL3FVERTEX4FSUNPROC(float s, float t, float p, float q, float r, float g, float b, float a, float nx, float ny, float nz, float x, float y, float z, float w);
    private delegate void PFNGLTEXCOORD4FCOLOR4FNORMAL3FVERTEX4FVSUNPROC(const float *tc, const float *c, const float *n, const float *v);
    private delegate void PFNGLREPLACEMENTCODEUIVERTEX3FSUNPROC(uint rc, float x, float y, float z);
    private delegate void PFNGLREPLACEMENTCODEUIVERTEX3FVSUNPROC(const uint *rc, const float *v);
    private delegate void PFNGLREPLACEMENTCODEUICOLOR4UBVERTEX3FSUNPROC(uint rc, byte r, byte g, byte b, byte a, float x, float y, float z);
    private delegate void PFNGLREPLACEMENTCODEUICOLOR4UBVERTEX3FVSUNPROC(const uint *rc, const byte *c, const float *v);
    private delegate void PFNGLREPLACEMENTCODEUICOLOR3FVERTEX3FSUNPROC(uint rc, float r, float g, float b, float x, float y, float z);
    private delegate void PFNGLREPLACEMENTCODEUICOLOR3FVERTEX3FVSUNPROC(const uint *rc, const float *c, const float *v);
    private delegate void PFNGLREPLACEMENTCODEUINORMAL3FVERTEX3FSUNPROC(uint rc, float nx, float ny, float nz, float x, float y, float z);
    private delegate void PFNGLREPLACEMENTCODEUINORMAL3FVERTEX3FVSUNPROC(const uint *rc, const float *n, const float *v);
    private delegate void PFNGLREPLACEMENTCODEUICOLOR4FNORMAL3FVERTEX3FSUNPROC(uint rc, float r, float g, float b, float a, float nx, float ny, float nz, float x, float y, float z);
    private delegate void PFNGLREPLACEMENTCODEUICOLOR4FNORMAL3FVERTEX3FVSUNPROC(const uint *rc, const float *c, const float *n, const float *v);
    private delegate void PFNGLREPLACEMENTCODEUITEXCOORD2FVERTEX3FSUNPROC(uint rc, float s, float t, float x, float y, float z);
    private delegate void PFNGLREPLACEMENTCODEUITEXCOORD2FVERTEX3FVSUNPROC(const uint *rc, const float *tc, const float *v);
    private delegate void PFNGLREPLACEMENTCODEUITEXCOORD2FNORMAL3FVERTEX3FSUNPROC(uint rc, float s, float t, float nx, float ny, float nz, float x, float y, float z);
    private delegate void PFNGLREPLACEMENTCODEUITEXCOORD2FNORMAL3FVERTEX3FVSUNPROC(const uint *rc, const float *tc, const float *n, const float *v);
    private delegate void PFNGLREPLACEMENTCODEUITEXCOORD2FCOLOR4FNORMAL3FVERTEX3FSUNPROC(uint rc, float s, float t, float r, float g, float b, float a, float nx, float ny, float nz, float x, float y, float z);
    private delegate void PFNGLREPLACEMENTCODEUITEXCOORD2FCOLOR4FNORMAL3FVERTEX3FVSUNPROC(const uint *rc, const float *tc, const float *c, const float *n, const float *v);
    #ifdef GL_GLEXT_PROTOTYPES
    public static void glColor4ubVertex2fSUN(byte r, byte g, byte b, byte a, float x, float y);
    public static void glColor4ubVertex2fvSUN(const byte *c, const float *v);
    public static void glColor4ubVertex3fSUN(byte r, byte g, byte b, byte a, float x, float y, float z);
    public static void glColor4ubVertex3fvSUN(const byte *c, const float *v);
    public static void glColor3fVertex3fSUN(float r, float g, float b, float x, float y, float z);
    public static void glColor3fVertex3fvSUN(const float *c, const float *v);
    public static void glNormal3fVertex3fSUN(float nx, float ny, float nz, float x, float y, float z);
    public static void glNormal3fVertex3fvSUN(const float *n, const float *v);
    public static void glColor4fNormal3fVertex3fSUN(float r, float g, float b, float a, float nx, float ny, float nz, float x, float y, float z);
    public static void glColor4fNormal3fVertex3fvSUN(const float *c, const float *n, const float *v);
    public static void glTexCoord2fVertex3fSUN(float s, float t, float x, float y, float z);
    public static void glTexCoord2fVertex3fvSUN(const float *tc, const float *v);
    public static void glTexCoord4fVertex4fSUN(float s, float t, float p, float q, float x, float y, float z, float w);
    public static void glTexCoord4fVertex4fvSUN(const float *tc, const float *v);
    public static void glTexCoord2fColor4ubVertex3fSUN(float s, float t, byte r, byte g, byte b, byte a, float x, float y, float z);
    public static void glTexCoord2fColor4ubVertex3fvSUN(const float *tc, const byte *c, const float *v);
    public static void glTexCoord2fColor3fVertex3fSUN(float s, float t, float r, float g, float b, float x, float y, float z);
    public static void glTexCoord2fColor3fVertex3fvSUN(const float *tc, const float *c, const float *v);
    public static void glTexCoord2fNormal3fVertex3fSUN(float s, float t, float nx, float ny, float nz, float x, float y, float z);
    public static void glTexCoord2fNormal3fVertex3fvSUN(const float *tc, const float *n, const float *v);
    public static void glTexCoord2fColor4fNormal3fVertex3fSUN(float s, float t, float r, float g, float b, float a, float nx, float ny, float nz, float x, float y, float z);
    public static void glTexCoord2fColor4fNormal3fVertex3fvSUN(const float *tc, const float *c, const float *n, const float *v);
    public static void glTexCoord4fColor4fNormal3fVertex4fSUN(float s, float t, float p, float q, float r, float g, float b, float a, float nx, float ny, float nz, float x, float y, float z, float w);
    public static void glTexCoord4fColor4fNormal3fVertex4fvSUN(const float *tc, const float *c, const float *n, const float *v);
    public static void glReplacementCodeuiVertex3fSUN(uint rc, float x, float y, float z);
    public static void glReplacementCodeuiVertex3fvSUN(const uint *rc, const float *v);
    public static void glReplacementCodeuiColor4ubVertex3fSUN(uint rc, byte r, byte g, byte b, byte a, float x, float y, float z);
    public static void glReplacementCodeuiColor4ubVertex3fvSUN(const uint *rc, const byte *c, const float *v);
    public static void glReplacementCodeuiColor3fVertex3fSUN(uint rc, float r, float g, float b, float x, float y, float z);
    public static void glReplacementCodeuiColor3fVertex3fvSUN(const uint *rc, const float *c, const float *v);
    public static void glReplacementCodeuiNormal3fVertex3fSUN(uint rc, float nx, float ny, float nz, float x, float y, float z);
    public static void glReplacementCodeuiNormal3fVertex3fvSUN(const uint *rc, const float *n, const float *v);
    public static void glReplacementCodeuiColor4fNormal3fVertex3fSUN(uint rc, float r, float g, float b, float a, float nx, float ny, float nz, float x, float y, float z);
    public static void glReplacementCodeuiColor4fNormal3fVertex3fvSUN(const uint *rc, const float *c, const float *n, const float *v);
    public static void glReplacementCodeuiTexCoord2fVertex3fSUN(uint rc, float s, float t, float x, float y, float z);
    public static void glReplacementCodeuiTexCoord2fVertex3fvSUN(const uint *rc, const float *tc, const float *v);
    public static void glReplacementCodeuiTexCoord2fNormal3fVertex3fSUN(uint rc, float s, float t, float nx, float ny, float nz, float x, float y, float z);
    public static void glReplacementCodeuiTexCoord2fNormal3fVertex3fvSUN(const uint *rc, const float *tc, const float *n, const float *v);
    public static void glReplacementCodeuiTexCoord2fColor4fNormal3fVertex3fSUN(uint rc, float s, float t, float r, float g, float b, float a, float nx, float ny, float nz, float x, float y, float z);
    public static void glReplacementCodeuiTexCoord2fColor4fNormal3fVertex3fvSUN(const uint *rc, const float *tc, const float *c, const float *n, const float *v);
    #endif
    #endif /* GL_SUN_vertex */

    #ifndef GL_WIN_phong_shading
    #define GL_WIN_phong_shading 1
    public const uint GL_PHONG_WIN = 0x80EA;
    public const uint GL_PHONG_HINT_WIN = 0x80EB;
    #endif /* GL_WIN_phong_shading */

    #ifndef GL_WIN_specular_fog
    #define GL_WIN_specular_fog 1
    public const uint GL_FOG_SPECULAR_TEXTURE_WIN = 0x80EC;
    #endif /* GL_WIN_specular_fog */

    #ifdef __cplusplus
    }
    #endif

    #endif
  }
}